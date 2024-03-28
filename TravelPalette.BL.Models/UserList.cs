using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalette.BL.Models
{
    public class UserList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ListId { get; set; }

        [DisplayName("List Name")]
        public string ListName { get; set; }
    }
}
