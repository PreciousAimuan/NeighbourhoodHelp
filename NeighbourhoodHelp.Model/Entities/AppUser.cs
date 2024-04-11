﻿using Microsoft.AspNetCore.Identity;

namespace NeighbourhoodHelp.Model.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public IList<Errand> Errands { get; set; }
        public IList<Agent> Agents { get; set; }
    }
}