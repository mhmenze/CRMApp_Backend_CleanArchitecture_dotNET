//using CRMApp.DOMAIN.Services;
//using Microsoft.AspNetCore.Identity;

//namespace CRMApp.Infrastructure.Services
//{
//    public class ApplicationUser : IdentityUser
//    {
//        public string? FullName { get; set; }
//    }
//    public class IdentityAuthenticationService : IAuthenticationService
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;

//        public IdentityAuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        public async Task<bool> RegisterUserAsync(string fullName, string email, string password)
//        {
//            var user = new ApplicationUser { UserName = email, Email = email, FullName = fullName };
//            var result = await _userManager.CreateAsync(user, password);
//            return result.Succeeded;
//        }

//        public async Task<bool> SignInAsync(string email, string password)
//        {
//            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: true);
//            return result.Succeeded;
//        }

//        public async Task SignOutAsync()
//        {
//            await _signInManager.SignOutAsync();
//        }
//    }

//    public class IdentityAuthorizationService : IAuthorizationService
//    {
//        public Task<bool> IsUserAuthorizedAsync(string userId, string resource)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
