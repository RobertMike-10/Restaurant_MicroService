using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Services.Identity.DbContexts;
using Restaurant.Services.Identity.Initializer;

namespace DeliRestaurant.Pages.Home;

[AllowAnonymous]
public class Index : PageModel
{
    public string Version;

    public Index(IDbInitializer init )
    {
        init.Intialize();
    }
        
    public void OnGet()
    {
        Version = typeof(Duende.IdentityServer.Hosting.IdentityServerMiddleware).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('+').First();
    }
}