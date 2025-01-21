using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    [Table("Incidents")]
    public class IncidentDto
    {
        public int Id {  get; set; }
        public string User {  get; set; }
        public string Type {  get; set; }
        public string Details {  get; set; }
        public string Etat {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string Action { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Responsible {  get; set; }
    }
}