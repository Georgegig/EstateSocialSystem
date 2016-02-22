namespace EstateSocialSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Data.Models;
    using Data.Common.Repository;
    using ViewModels;
    using Microsoft.AspNet.Identity;

    public class ApplianceController : Controller
    {
        private IDeletableEntityRepository<Appliance> appliances;

        public ApplianceController(IDeletableEntityRepository<Appliance> appliances)
        {
            this.appliances = appliances;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Appliances_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.appliances
                .All()
                .To<AdministerApplianceViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Appliances_Create([DataSourceRequest]DataSourceRequest request, AdministerApplianceViewModel appliance)
        {
            var newId = 0;
            if (ModelState.IsValid)
            {
                var entity = new Appliance
                {
                    Name = appliance.Name,
                    Type = appliance.Type,
                    Power = appliance.Power,
                    Input = appliance.Input,
                    Output = appliance.Output,
                    ManufacturerId = this.User.Identity.GetUserId()
                };

                this.appliances.Add(entity);
                this.appliances.SaveChanges();
                newId = entity.Id;
            }
            var applianceToDisplay = this.appliances
                .All()
                .To<AdministerApplianceViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return Json(new[] { applianceToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Appliances_Update([DataSourceRequest]DataSourceRequest request, AdministerApplianceViewModel appliance)
        {   
            if (ModelState.IsValid)
            {
                var entity = this.appliances.GetById(appliance.Id);
                entity.Name = appliance.Name;
                entity.Type = appliance.Type;
                entity.Power = appliance.Power;
                entity.Input = appliance.Input;
                entity.Output = appliance.Output;
                
                this.appliances.SaveChanges();
            }

            var applianceToDisplay = this.appliances
               .All()
               .To<AdministerApplianceViewModel>()
               .FirstOrDefault(x => x.Id == appliance.Id);

            return Json(new[] { applianceToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Appliances_Destroy([DataSourceRequest]DataSourceRequest request, Appliance appliance)
        {
            this.appliances.Delete(appliance.Id);
            this.appliances.SaveChanges();

            return Json(new[] { appliance }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.appliances.Dispose();
            base.Dispose(disposing);
        }
    }
}
