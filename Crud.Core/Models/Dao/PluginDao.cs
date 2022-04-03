namespace Crud.Core
{
    public class PluginDao
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public int ProjectId { get; set; }
        public ProjectDao LocatedProject { get; set; }
    }
}
