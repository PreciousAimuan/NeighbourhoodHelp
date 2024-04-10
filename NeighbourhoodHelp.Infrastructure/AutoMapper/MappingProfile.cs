﻿using AutoMapper;
using NeighbourhoodHelp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Infrastructure.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, LoginDto>();
            // Add more mappings if needed
        }
    }
}
