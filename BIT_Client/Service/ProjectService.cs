using BIT_Client.Service.IService;
using BIT_Models;
using Newtonsoft.Json;
using System.Text;

namespace BIT_Client.Service
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _client;

        public ProjectService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<ProjectDTO> GetProject(int projectId)
        {
            var response = await _client.GetAsync($"api/projects/getticket/{projectId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var projectDTO = JsonConvert.DeserializeObject<ProjectDTO>(content);
                return projectDTO;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            var response = await _client.GetAsync($"api/projects/getallprojects");
            var content = await response.Content.ReadAsStringAsync();

            var projectDTOs = JsonConvert.DeserializeObject<IEnumerable<ProjectDTO>>(content);
            return projectDTOs;
        }

        public async Task<ProjectDTO> CreateProject(ProjectDTO project)
        {
            var content = JsonConvert.SerializeObject(project);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/projects/create", bodyContent);
            //FOR DEBUG
            //var respResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<ProjectDTO>(contentTemp);
                return res;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                throw new Exception(contentTemp);
            }
        }

        public async Task<ProjectDTO> UpdateProject(int projectId, ProjectDTO project)
        {
            var content = JsonConvert.SerializeObject(project);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/projects/update/{projectId}", bodyContent);
            //FOR DEBUG
            //var respResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<ProjectDTO>(contentTemp);
                return res;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                throw new Exception(contentTemp);
            }
        }

        public async Task<int>DeleteProject(int projectId)
        {
            var response = await _client.DeleteAsync($"/api/projects/delete/{projectId}");
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<int>(contentTemp);
                return res;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                throw new Exception(contentTemp);
            }
        }
    }
}
