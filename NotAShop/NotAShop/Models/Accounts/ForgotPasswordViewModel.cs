using System.ComponentModel.DataAnnotations;

namespace NotAShop.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
