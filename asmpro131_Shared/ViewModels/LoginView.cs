using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.ViewModels
{
    public class LoginView
    {
        [Required(ErrorMessage = "Username cannot be blank")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string? PassWord { get; set; }
    }
}
