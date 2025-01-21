using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    [Table("Users")]
    public class RegisterDto
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est requis.")]
        [StringLength(50,ErrorMessage = "Le Nom ne peut pas dépasser de 50 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le champ Matricule est requis.")]
        [Range(1,int.MaxValue, ErrorMessage = "Matricule : Nombre positive uniquement")]
        public int Matricule { get; set; }

        [Required(ErrorMessage = "Le champ email est requis.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ numéro téléphone est requis.")]
        [StringLength(20,ErrorMessage = "Le numéro téléphone ne peut pas dépasser de 20 caractères.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Le champ Adresse est requis.")]
        [StringLength(30,ErrorMessage = "L'Adresse ne peut pas dépasser de 30 caractères.")]
        public string Address {  get; set; }

        [Required(ErrorMessage = "Le champ poste est requis.")]
        [StringLength(50,ErrorMessage = "Le poste ne peut pas dépasser de 50 caractères.")]
        public string Poste {  get; set; }

        public string Role {  get; set; }

        [Required(ErrorMessage = "Le champ mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}