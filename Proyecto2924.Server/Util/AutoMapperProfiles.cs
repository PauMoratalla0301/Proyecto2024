﻿using AutoMapper;
using Proyecto2024.DB.Data.Entity;
using Proyecto2024.Shared.DTO;

namespace Proyecto2024.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<AgregaralCarritoDTO, AgregaralCarrito>();
        }
    }
}
