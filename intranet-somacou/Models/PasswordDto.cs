using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    public class PasswordDto
    {
        [Required(ErrorMessage = "Ancien Mot de passe obligatoire"), MaxLength(50)]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Nouveau Mot de passe obligatoire"),MaxLength(50)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirmation Mot de passe obligatoire"),MaxLength(50)]
        [Compare("NewPassword",ErrorMessage = "Erreur de confimation")]
        public string ConfirmPassword { get; set; }
    }
}