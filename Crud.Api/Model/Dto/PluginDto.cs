namespace Crud.Api
{
    public class PluginDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectDto LocatedProject { get; set; }
    }
}
