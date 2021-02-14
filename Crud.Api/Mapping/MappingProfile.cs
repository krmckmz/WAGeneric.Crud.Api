using AutoMapper;
using Crud.Api.Model.Dto;
using Crud.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PluginDao, PluginDto>();
            CreateMap<ProjectDao, ProjectDto>();

            CreateMap<PluginDto, PluginDao>();
            CreateMap<ProjectDto, ProjectDao>();

            CreateMap<SavePluginDto, PluginDao>();
            CreateMap<SaveProjectDto, ProjectDao>();
        }
    }
}
