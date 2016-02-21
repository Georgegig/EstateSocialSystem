namespace EstateSocialSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Data.Models;
    using Data.Common.Repository;

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
            DataSourceResult result = this.estates.All().ToDataSourceResult(request, estate => new {
                Id = estate.Id,
                Name = estate.Name,
                Address = estate.Address,
                Size = estate.Size,
                IsDeleted = estate.IsDeleted,
                DeletedOn = estate.DeletedOn,
                CreatedOn = estate.CreatedOn,
                ModifiedOn = estate.ModifiedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Estates_Create([DataSourceRequest]DataSourceRequest request, Estate estate)
        {
            if (ModelState.IsValid)
            {
                var entity = new Estate
                {
                    Name = estate.Name,
                    Address = estate.Address,
                    Size = estate.Size,
                    IsDeleted = estate.IsDeleted,
                    DeletedOn = estate.DeletedOn,
                    CreatedOn = estate.CreatedOn,
                    ModifiedOn = estate.ModifiedOn
                };
                
                this.estates.Add(entity);
                this.estates.SaveChanges();
                estate.Id = entity.Id;
            }

            return Json(new[] { estate }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Estates_Update([DataSourceRequest]DataSourceRequest request, Estate estate)
        {
            if (ModelState.IsValid)
            {
                var entity = new Estate
                {
                    Id = estate.Id,
                    Name = estate.Name,
                    Address = estate.Address,
                    Size = estate.Size,
                    IsDeleted = estate.IsDeleted,
                    DeletedOn = estate.DeletedOn,
                    CreatedOn = estate.CreatedOn,
                    ModifiedOn = estate.ModifiedOn
                };

                this.estates.Update(entity);
                this.estates.SaveChanges();
            }

            return Json(new[] { estate }.ToDataSourceResult(request, ModelState));
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
