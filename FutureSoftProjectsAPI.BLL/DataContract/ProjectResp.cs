namespace FutureSoftProjectsAPI.BLL.DataContract
{
    public class ProjectResp
    {
        public string Name { get; set; } = string.Empty;
        public string ImageLink { get; set; } = string.Empty;
        public List<GroupResp> Groups { get; set; } = new();
    }
}
