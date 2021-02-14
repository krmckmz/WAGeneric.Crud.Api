using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Model.Dto
{
    public class SavePluginDto
    {
        public string Title { get; set; }

        public int ProjectId { get; set; }
    }
}
