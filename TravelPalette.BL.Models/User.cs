using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalette.BL.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("User Name")]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("User Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
