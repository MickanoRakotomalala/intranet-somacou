using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    public class RegisterDto
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        [StringLength(50,ErrorMessage = "Le Nom ne peut pas dépasser de 50 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le champ Matricule est obligatoire.")]
        [Range(1,int.MaxValue, ErrorMessage = "Nombre positive uniquement")]
        public int Matricule { get; set; }

        [Required(ErrorMessage = "Le champ email est obligatoire.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ numéro téléphone est obligatoire.")]
        [StringLength(20,ErrorMessage = "Le numéro téléphone ne peut pas dépasser de 20 caractères.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Le champ Adresse est obligatoire.")]
        [StringLength(30,ErrorMessage = "L'Adresse ne peut pas dépasser de 30 caractères.")]
        public string Address {  get; set; }

        [Required(ErrorMessage = "Le champ poste est obligatoire.")]
        [StringLength(50,ErrorMessage = "Le poste ne peut pas dépasser de 50 caractères.")]
        public string Poste {  get; set; }

        public string Role {  get; set; }

        [Required(ErrorMessage = "Le champ mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}