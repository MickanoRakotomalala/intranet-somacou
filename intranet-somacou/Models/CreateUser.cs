using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    public class CreateUser
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "Le Nom est obligatoire.")]
        [StringLength(50,ErrorMessage = "Le Nom ne peut pas dépasser de 50 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le Matricule est obligatoire.")]
        public int Matricule { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le numéro téléphone est obligatoire.")]
        [StringLength(20,ErrorMessage = "Le numéro téléphone ne peut pas dépasser de 20 caractères.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "L'Adresse est obligatoire.")]
        [StringLength(30,ErrorMessage = "L'Adresse ne peut pas dépasser de 30 caractères.")]
        public string Address {  get; set; }

        [Required(ErrorMessage = "Le poste est obligatoire.")]
        [StringLength(50,ErrorMessage = "Le poste ne peut pas dépasser de 50 caractères.")]
        public string Poste {  get; set; }

        [Required(ErrorMessage = "Le Rôle est obligatoire.")]
        [StringLength(30,ErrorMessage = "Le rôle ne peut pas dépasser de 30 caractères.")]
        public string Role {  get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}