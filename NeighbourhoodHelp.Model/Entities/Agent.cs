using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Model.Entities
{
    public class Agent : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string? Image { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Rating { get; set; } = 0;
        public bool IsActive { get; set; } = false;
        public string NIN { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Document { get; set; }
        public IList<AppUser> AppUsers { get; set; }
        public IList<Errand> Errands { get; set; }
    }
}
