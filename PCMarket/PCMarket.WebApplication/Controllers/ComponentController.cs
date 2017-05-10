namespace PCMarket.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Services;
    using Services.UserServices;

    [RouteArea("Component")]
    public class ComponentController : BaseController
    {
        private readonly ComponentService componentService;

        public ComponentController(
            UserService service,
            ComponentService componentService) : base(service)
        {
            this.componentService = componentService;
        }

        [HttpGet]
        [Route("Processors")]
        public ActionResult Processors()
        {
            return this.View(this.componentService.GetAllProcessors());
        }

        [HttpGet]
        [Route("CoreComponents/Motherboards")]
        public ActionResult Motherboards()
        {
            return this.View(this.componentService.GetAllMotherboards());
        }

        [HttpGet]
        [Route("CoreComponents/VideoCards")]
        public ActionResult VideoCards()
        {
            return this.View(this.componentService.GetAllVideoCards());
        }

        [HttpGet]
        [Route("CoreComponents/HardDrives")]
        public ActionResult HardDrives()
        {
            return this.View(this.componentService.GetAllHardDrives());
        }

        [HttpGet]
        [Route("SolidStateDrives")]
        public ActionResult SolidStateDrives()
        {
            return this.View(this.componentService.GetAllSolidStates());
        }

        [HttpGet]
        [Route("BackupDevices")]
        public ActionResult BackupDevices()
        {
            return this.View(this.componentService.GetAllBackupDevices());
        }
    }
}