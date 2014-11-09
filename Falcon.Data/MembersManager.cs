using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Falcon.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Falcon.Data
{
    public class MembersManager : UserManager<Member, int> 
    {
        public MembersManager(IUserStore<Member, int> store) : base(store)
        {

        }

        public static MembersManager Create(IdentityFactoryOptions<MembersManager> options, IOwinContext context)
        {
            var manager = new MembersManager(
            new CustomUserStore(context.Get<FalconDbContext>()));

            //Username Validation
            manager.UserValidator = new UserValidator<Member, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords 
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Register two factor authentication providers. This application uses Phone 
            // and Emails as a step of receiving a code for verifying the user 
            // You can write your own provider and plug in here. 
            
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Member, int>(
                        dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager; 

        }
    }
    public class MembersSignInManager : SignInManager<Member, int>
    {
        public MembersSignInManager(MembersManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(Member user)
        {
            return user.GenerateUserIdentityAsync((MembersManager)UserManager);
        }

        public static MembersSignInManager Create(IdentityFactoryOptions<MembersSignInManager> options, IOwinContext context)
        {
            return new MembersSignInManager(context.GetUserManager<MembersManager>(), context.Authentication);
        }
    }
}
