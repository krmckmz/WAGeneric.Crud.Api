using AutoMapper;
using Crud.Core;

namespace Crud.Api
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
