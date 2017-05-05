namespace PCMarket.WebApplication.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Services;

    [RoutePrefix("News")]
    public class NewsController : BaseController
    {
        private NewsService newsService;

        public NewsController(NewsService newsService)
        {
            this.NewsService = newsService;
        }

        public NewsController()
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

        [HttpGet]
        public ActionResult Software(int? count)
        {
            return this.View(this.NewsService.GetSoftwareNews(count));
        }

        [HttpGet]
        [Route("Software/{id}")]
        public ActionResult SoftwareNewsById(int id)
        {
            return this.View(this.NewsService.GetSoftwareNewById(id));
        }

        [HttpGet]
        public ActionResult Hardware(int? count)
        {
            return this.View(this.NewsService.GetHardwareNews(count));
        }

        [HttpGet]
        [Route("Hardware/{id}")]
        public ActionResult HardwareNewsById(int id)
        {
            return this.View(this.NewsService.GetHardwareNewById(id));
        }
    }
}