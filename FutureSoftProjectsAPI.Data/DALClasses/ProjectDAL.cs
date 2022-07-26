using FutureSoftProjectsAPI.Data.Entities;

namespace FutureSoftProjectsAPI.Data.DALClasses
{
    public class ProjectDAL
    {
        public async Task<List<Project>> GetProjects(string filePath, string? searchValue)
        {
            List<Project> _projectResps = new();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _projectResps = await StaticClass.JsonFileReader.ReadAsync<List<Project>>(filePath);
            }
            else
            {
                foreach (var project in await StaticClass.JsonFileReader.ReadAsync<List<Project>>(filePath))
                {

                    var _groups = project.groups.Where(group => group.name.ToLower().Contains(searchValue.ToLower()));

                    if (_groups.Any())
                    {
                        _projectResps.Add(new Project()
                        {
                            id = project.id,
                            name = project.name,
                            groups = _groups,
                            image = project.image,
                            url = project.url
                        });
                    }
                }
            }

            return _projectResps;
        }
    }
}
