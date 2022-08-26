using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Identity.Models;

namespace Notes.Identity.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    public class AuthController : Controller
    {
        /// <summary>
        /// SignIn manager
        /// </summary>
        private readonly SignInManager<AppUser> _signInManager;

        /// <summary>
        /// User manages
        /// </summary>
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// Interaction service
        /// </summary>
        private readonly IIdentityServerInteractionService _interactionService;

        /// <summary>
        /// Initializes class instance of <see cref="AuthController"/>
        /// </summary>
        /// <param name="signInManager">SignIn manager</param>
        /// <param name="userManager">User manages</param>
        /// <param name="interactionService">Interaction service</param>
        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

        /// <summary>
        /// Authorizes client
        /// </summary>
        /// <param name="returnUrl">Redirect url</param>
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(viewModel);
        }

        /// <summary>
        /// Authorizes client
        /// </summary>
        /// <param name="viewModel">User's form data</param>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(viewModel);
            }

            var result = await _signInManager
                            .PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Login error");

            return View(viewModel);
        }

        /// <summary>
        /// Registers client
        /// </summary>
        /// <param name="returnUrl">Redirect url</param>
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var viewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(viewModel);
        }

        /// <summary>
        /// Registers client
        /// </summary>
        /// <param name="viewModel">User's form data</param>
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new AppUser
            {
                UserName = viewModel.Username
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(viewModel.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Error occured");
            return View(viewModel);
        }

        /// <summary>
        /// Logout client
        /// </summary>
        /// <param name="logoutId">Logout id</param>
        [HttpGet]
        public async Task<IActionResult> LogoutAsync(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
