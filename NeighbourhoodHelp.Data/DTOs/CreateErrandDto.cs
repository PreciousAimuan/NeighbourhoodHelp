using NeighbourhoodHelp.Model.Entities;
using NeighbourhoodHelp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Data.DTOs
{
    public class CreateErrandDto
    {
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string ItemName { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
       /* public ErrandStatus ErrandStatus { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Payment Payment { get; set; }*/

    }
}
