using NeighbourhoodHelp.Data.DTOs;
using NeighbourhoodHelp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IErrandRepository
    {

        Task<string> CreateErrand(CreateErrandDto createErrand);

    }
}
