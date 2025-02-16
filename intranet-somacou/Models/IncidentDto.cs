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

        public string UserName {  get; set; }

        //Clé étrangère vers la table Users
        public int UserId { get; set; }

        public virtual RegisterDto User { get; set; } // Propriété de navigation
        public string Phone { get; set; }

        public string Type {  get; set; }

        public string Details {  get; set; }

        public string Etat {  get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Responsible {  get; set; }

        public string Observation { get; set; }
    }
}