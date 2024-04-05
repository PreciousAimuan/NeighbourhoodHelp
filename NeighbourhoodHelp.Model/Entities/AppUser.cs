﻿using Microsoft.AspNetCore.Identity;

namespace NeighbourhoodHelp.Model.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string? Image { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Rating { get; set; } = 0;
        public string Role { get; set; }
        public IList<Errand> Errands { get; set; }
    }
}