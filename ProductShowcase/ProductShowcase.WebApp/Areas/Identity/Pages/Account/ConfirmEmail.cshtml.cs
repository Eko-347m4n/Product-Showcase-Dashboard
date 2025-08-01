
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ProductShowcase.Core.Models;

namespace ProductShowcase.WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ConfirmEmailModel> _logger;

        public ConfirmEmailModel(UserManager<ApplicationUser> userManager, ILogger<ConfirmEmailModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            _logger.LogInformation("--- Starting Email Confirmation ---");
            _logger.LogInformation("Received userId: {UserId}", userId);
            _logger.LogInformation("Received code: {Code}", code);

            if (userId == null || code == null)
            {
                _logger.LogWarning("User ID or code is null. Redirecting to home.");
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Could not find user with ID: {UserId}", userId);
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            _logger.LogInformation("Successfully found user: {UserName}", user.UserName);

            try
            {
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                _logger.LogInformation("Successfully decoded code: {DecodedCode}", code);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error decoding the confirmation code.");
                StatusMessage = "Error: Invalid confirmation token.";
                return Page();
            }
            
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                _logger.LogInformation("Email confirmed successfully for user: {UserName}", user.UserName);
                StatusMessage = "Thank you for confirming your email.";
            }
            else
            {
                _logger.LogError("Email confirmation failed for user: {UserName}", user.UserName);
                foreach (var error in result.Errors)
                {
                    _logger.LogError("Error Code: {ErrorCode}, Description: {ErrorDescription}", error.Code, error.Description);
                }
                StatusMessage = "Error confirming your email.";
            }

            _logger.LogInformation("--- Finished Email Confirmation. Sending page to user. ---");
            return Page();
        }
    }
}
