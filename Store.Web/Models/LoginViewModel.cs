namespace Store.Web.Models
{
    using System.ComponentModel.DataAnnotations;


    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }


        [Required]
        [MaxLength(6)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

    }
}
