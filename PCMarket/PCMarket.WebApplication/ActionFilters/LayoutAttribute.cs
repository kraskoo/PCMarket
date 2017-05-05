namespace PCMarket.WebApplication.ActionFilters
{
    using System;
    using System.Web.Mvc;

    public class LayoutAttribute : ActionFilterAttribute
    {
        private readonly bool isInAdminRole;
        private readonly string layout;

        public LayoutAttribute(Func<Action<Controller, string>, bool> methodRoleCheck, string layout)
        {
            this.layout = layout;
            this.isInAdminRole = methodRoleCheck((c, role) => c.User.IsInRole(role));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (this.isInAdminRole)
            {
                result.MasterName = layout;
            }
        }
    }
}