using IdentityModel;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using LiquerStore.Web.Areas.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace LiquerStore.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                // Add Db context to service
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                // Default Identity
                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

                // Add possible claims
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("Customer", policy => policy.RequireClaim("role", "customer"));
                    options.AddPolicy("Employee", policy => policy.RequireClaim("role", "employee"));
                });

                // Add scopes
                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AdditionalUserClaimsPrincipalFactory>();

            });
        }
    }

	public class AdditionalUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
	{
        // Constructor
		public AdditionalUserClaimsPrincipalFactory(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor)
		{ }

		public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
		{
            // Create new things and identity
            var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;

            // Empty claim list
			var claims = new List<Claim>();

            // Switch between all roles
            switch (user.Role)
            {
                case Roles.Employee:
			claims.Add(new Claim(JwtClaimTypes.Role, "employee"));
                    break;
                case Roles.Customer:
			claims.Add(new Claim(JwtClaimTypes.Role, "customer"));
                    break;
                default:
                    break;
            }

            // Add the claims to the identity
			identity.AddClaims(claims);

            // Return
			return principal;
		}
	}
}