namespace EstateSocialSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Data.Models;
    using Data.Common.Repository;
    using ViewModels;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using System.Linq;

    public class EstateController : Controller
    {
        private readonly IDeletableEntityRepository<Estate> estates;

        public EstateController(IDeletableEntityRepository<Estate> estates)
        {
            this.estates = estates;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Estates_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.estates.
                All()
                .To<AdministerEstateViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Estates_Create([DataSourceRequest]DataSourceRequest request, AdministerEstateViewModel estate)
        {
            var newId = 0;
            if (ModelState.IsValid)
            {
                var entity = new Estate
                {
                    Name = estate.Name,
                    Address = estate.Address,
                    Size = estate.Size,
                    AuthorId = this.User.Identity.GetUserId()
                };
                
                this.estates.Add(entity);
                this.estates.SaveChanges();
                newId = entity.Id;
            }
            var estateToDisplay = this.estates
                .All()
                .To<AdministerEstateViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return Json(new[] { estateToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Estates_Update([DataSourceRequest]DataSourceRequest request, AdministerEstateViewModel estate)
        {
            if (ModelState.IsValid)
            {
                var entity = this.estates.GetById(estate.Id);
                entity.Name = estate.Name;
                entity.Address = estate.Address;
                entity.Size = estate.Size;
                this.estates.SaveChanges();
            }

            var estateToDisplay = this.estates
                .All()
                .To<AdministerEstateViewModel>()
                .FirstOrDefault(x => x.Id == estate.Id);

            return Json(new[] { estateToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Estates_Destroy([DataSourceRequest]DataSourceRequest request, Estate estate)
        {
            this.estates.Delete(estate.Id);
            this.estates.SaveChanges();

            return Json(new[] { estate }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.estates.Dispose();
            base.Dispose(disposing);
        }
    }
}
