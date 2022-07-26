using FutureSoftProjectsAPI.BLL.DataContract;
using FutureSoftProjectsAPI.Data.DALClasses;
using FutureSoftProjectsAPI.Data.Entities;

namespace FutureSoftProjectsAPI.BLL.BLLClasses
{
    public class ProjectBLL
    {
        private readonly ProjectDAL _projectDAL;

        public ProjectBLL()
        {
            _projectDAL = new();
        }

        public async Task<List<ProjectResp>> GetProjects(string filePath, string? searchValue)
        {
            List<ProjectResp> _projectResps = new();

            foreach (var project in await _projectDAL.GetProjects(filePath, searchValue))
            {
                _projectResps.Add(FillProjectResp(project));
            }

            return _projectResps;
        }

        private ProjectResp FillProjectResp(Project project)
        {
            return new ProjectResp()
            {
                Name = project.name,
                ImageLink = project.image.link,
                Groups = FillGroupsResp(project.groups)
            };
        }

        private List<GroupResp> FillGroupsResp(IEnumerable<Group> groups)
        {
            List<GroupResp> _groupResps = new();

            foreach (var group in groups)
            {
                _groupResps.Add(new GroupResp()
                {
                    Name = group.name
                });
            }

            return _groupResps;
        }
    }
}
