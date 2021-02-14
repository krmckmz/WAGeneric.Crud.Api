using Crud.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Model.Dto
{
    public class PluginDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectDto LocatedProject { get; set; }
    }
}
