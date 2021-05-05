using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetProjekt.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public int Spots_Available { get; set; }
        [InverseProperty("HostedEvents")]
        public MyUser Organizer { get; set; }
        [InverseProperty("JoinedEvents")]
        public List<MyUser> Attendees { get; set; }
    }
}
