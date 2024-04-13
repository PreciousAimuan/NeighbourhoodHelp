using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Model.Entities
{
    public class Agent : BaseEntity
    {
        public int Rating { get; set; } = 0;
        public bool IsActive { get; set; } = false;
        public string NIN { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public AppUser AppUser { get; set; }
    }
}
