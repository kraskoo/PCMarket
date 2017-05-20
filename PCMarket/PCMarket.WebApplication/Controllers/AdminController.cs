using PCMarket.Models.BindingModels.StorageDevices;

namespace PCMarket.WebApplication.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Services;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.News;

    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private NewsService newsService;

        public AdminController(NewsService newsService)
        {
            this.NewsService = newsService;
        }

        public AdminController()
        {
        }

        public NewsService NewsService
        {
            get
            {
                return this.newsService ?? (this.newsService =
                           new NewsService(this.Context, this.HttpContext.GetOwinContext()));
            }

            private set { this.newsService = value; }
        }

        [HttpPost]
        public ActionResult AddBackupDevice(BackupDeviceBindingModel backupDevice)
        {
            if (this.ModelState == null || !this.ModelState.IsValid)
            {
                return this.RedirectToAction("BackupDevices", "Component", backupDevice);
            }


            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddSoftwareNew()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddSoftwareNew(SoftwareNewBindingModel bindingModel)
        {
            if (this.ModelState == null || !this.ModelState.IsValid)
            {
                return this.View("AddSoftwareNew", bindingModel);
            }

            this.NewsService.AddSoftwareNew(
                bindingModel,
                this.UserService
                    .FindAdminUserByIdentityId(this.User.Identity.GetUserId()));
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddHardwareNew()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddHardwareNew(HardwareNewBindingModel bindingModel)
        {
            if (this.ModelState == null || !this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            this.NewsService.AddHardwareNew(
                bindingModel,
                this.UserService
                    .FindAdminUserByIdentityId(this.User.Identity.GetUserId()));

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditSoftwareNew(int id)
        {
            return this.View(this.NewsService.GetEditForSoftwareNew(id));
        }

        [HttpPost]
        public ActionResult EditSoftwareNew(SoftwareNewBindingModel bindingModel)
        {
            if (this.ModelState == null || !this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            this.NewsService.EditSoftwareNew(bindingModel);
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DeleteSoftwareNew(int id)
        {
            this.NewsService.DeleteSoftwareNew(id);
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult EditHardwareNew(int id)
        {
            return this.View(this.NewsService.GetEditForHardwareNew(id));
        }

        [HttpPost]
        public ActionResult EditHardwareNew(HardwareNewBindingModel bindingModel)
        {
            if (this.ModelState == null || !this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            this.NewsService.EditHardwareNew(bindingModel);
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DeleteHardwareNew(int id)
        {
            this.NewsService.DeleteHardwareNew(id);
            return this.RedirectToAction("Index", "Home");
        }
    }
}