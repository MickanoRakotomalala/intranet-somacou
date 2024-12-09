using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    public class CreateUser
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address {  get; set; }
        public string Role {  get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}