using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core
{
    public class ProjectDao
    {
        public ProjectDao()
        {
            Plugins = new List<PluginDao>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PluginDao> Plugins { get; set; }
    }
}
