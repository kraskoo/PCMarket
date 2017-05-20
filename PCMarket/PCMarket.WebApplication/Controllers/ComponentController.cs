namespace PCMarket.WebApplication.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Services;
    using Services.UserServices;
    
    [RoutePrefix("Component")]
    public class ComponentController : BaseController
    {
        private ComponentService componentService;

        public ComponentController(
            UserService service,
            ComponentService componentService) : base(service)
        {
            this.ComponentService = componentService;
        }

        public ComponentController()
        {
        }

        public ComponentService ComponentService
        {
            get
            {
                return this.componentService ?? (this.componentService =
                           new ComponentService(this.Context, this.HttpContext.GetOwinContext()));
            }

            private set
            {
                this.componentService = value;
            }
        }

        [HttpGet]
        [Route("CoreComponents/Processors")]
        public ActionResult Processors()
        {
            return this.View(this.ComponentService.GetAllProcessors());
        }

        [HttpGet]
        [Route("CoreComponents/Motherboards")]
        public ActionResult Motherboards()
        {
            return this.View(this.ComponentService.GetAllMotherboards());
        }

        [HttpGet]
        [Route("CoreComponents/VideoCards")]
        public ActionResult VideoCards()
        {
            return this.View(this.ComponentService.GetAllVideoCards());
        }

        [HttpGet]
        [Route("StorageDevices/HardDrives")]
        public ActionResult HardDrives()
        {
            return this.View(this.ComponentService.GetAllHardDrives());
        }

        [HttpGet]
        [Route("StorageDevices/SolidStateDrives")]
        public ActionResult SolidStateDrives()
        {
            return this.View(this.ComponentService.GetAllSolidStates());
        }

        [HttpGet]
        [Route("StorageDevices/BackupDevices")]
        public ActionResult BackupDevices()
        {
            return this.View(this.ComponentService.GetAllBackupDevices());
        }
    }
}