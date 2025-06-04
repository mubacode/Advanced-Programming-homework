using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Filters
{
    public class LibrarianAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetObject<User>("CurrentUser");
            
            if (user == null || (user.Role != "Librarian" && user.Role != "Admin"))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
} 