using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    [Table("Incidents")]
    public class IncidentDto
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "Le champ utilisateur est requis"),MaxLength(50)]
        public string UserName {  get; set; }

        //Clé étrangère vers la table Users
        public int UserId { get; set; }

        public virtual RegisterDto User { get; set; } // Propriété de navigation

        [Required(ErrorMessage = "Le champ Type est requis")]
        public string Type {  get; set; }

        [Required(ErrorMessage = "Le champ Détails est requis")]
        public string Details {  get; set; }

        [Required(ErrorMessage = "Le champ Statut est requis")]
        public string Etat {  get; set; }

        [Required(ErrorMessage = "Le champ Date de Création est requis")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Le champ Action est requis")]
        public string Action { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Responsible {  get; set; }
    }
}