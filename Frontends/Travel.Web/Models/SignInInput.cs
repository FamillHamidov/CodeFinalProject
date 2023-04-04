using System.ComponentModel;

namespace Travel.Web.Models
{
    public class SignInInput
    {
        [DisplayName("Mailiniz")]
        public string Email { get; set; } = null!;
        [DisplayName("Şifrəniz")]
        public string Password { get; set; } = null!;
        [DisplayName("Məni xatırla")]
        public bool IsRemember { get; set; }    
    }
}
