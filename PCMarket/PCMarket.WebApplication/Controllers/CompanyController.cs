namespace PCMarket.WebApplication.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Models.BindingModels;
    using Services;
    using Services.Managers;
    using Services.UserServices;

    [RoutePrefix("Company")]
    public class CompanyController : BaseController
    {
        private static readonly TemproaryFileManager fileManager = new TemproaryFileManager(HttpRuntime.AppDomainAppPath);
        private CompanyService companyService;

        public CompanyController(
            UserService service,
            CompanyService companyService) : base(service)
        {
            this.CompanyService = companyService;
        }

        public TemproaryFileManager FileManager => fileManager;

        public CompanyController()
        {
        }

        public CompanyService CompanyService
        {
            get
            {
                return this.companyService ?? (this.companyService =
                    new CompanyService(this.Context, this.HttpContext.GetOwinContext()));
            }

            private set
            {
                this.companyService = value;
            }
        }


        [HttpGet]
        [Route("Companies")]
        public ActionResult All()
        {
            return this.View(this.companyService.GetAllCompanies());
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(CompanyBindingModel company)
        {
            if (this.ModelState == null || !this.ModelState.IsValid)
            {
                this.View("Add", company);
            }

            this.CompanyService.AddCompany(company, this.FileManager);
            return this.RedirectToAction("Index", "Home");
        }
    }
}