using System.Web.Mvc;

namespace ManagementCinemaBookings
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var login_email = filterContext.HttpContext.Session["log_email"];

                if (login_email == null)
                {
                    filterContext.Result = new RedirectResult("/Authorization/Login");                    
                }                                    
            }            
        }       
    }
}