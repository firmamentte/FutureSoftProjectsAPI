namespace FutureSoftProjectsAPI.Data.Entities
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public Image image { get; set; } = new();
        public IEnumerable<Group> groups { get; set; } = Enumerable.Empty<Group>();
        public string url { get; set; } = string.Empty;
    }
}
