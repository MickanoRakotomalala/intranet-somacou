using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    public class ProfileDto
    {
        public string Name {  get; set; }
        public int Matricule { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string Address {  get; set; }
        public string Poste {  get; set; }
        public string Role {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}