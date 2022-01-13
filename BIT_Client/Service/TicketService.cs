using BIT_Client.Service.IService;
using BIT_Models;
using Newtonsoft.Json;
using System.Text;

namespace BIT_Client.Service
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _client;

        public TicketService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<TicketDTO> GetTicket(int ticketId)
        {
            var response = await _client.GetAsync($"api/tickets/getticket/{ticketId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var room = JsonConvert.DeserializeObject<TicketDTO>(content);
                return room;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMessage);
            }
        }

        public async Task<IEnumerable<TicketDTO>> GetTickets()
        {
            var response = await _client.GetAsync($"api/tickets/getalltickets");
            var content = await response.Content.ReadAsStringAsync();

            var tickets = JsonConvert.DeserializeObject<IEnumerable<TicketDTO>>(content);
            return tickets;
        }

        public async Task<TicketDTO> CreateTicket(TicketDTO ticket)
        {

            var content = JsonConvert.SerializeObject(ticket);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/tickets/create", bodyContent);
            //FOR DEBUG
            //var respResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<TicketDTO>(contentTemp);
                return res;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                throw new Exception(contentTemp);
            }
        }

        public async Task<TicketDTO> UpdateTicket(int ticketId, TicketDTO ticket)
        {
            var content = JsonConvert.SerializeObject(ticket);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/tickets/update/{ticketId}", bodyContent);
            //FOR DEBUG
            //var respResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<TicketDTO>(contentTemp);
                return res;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                throw new Exception(contentTemp);
            }
        }

        public async Task<int> DeleteTicket(int ticketId)
        {
            var response = await _client.DeleteAsync($"/api/tickets/delete/{ticketId}");
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

        public async Task<IEnumerable<TicketDTO>> GetChildrenTickets(int parentTicketId)
        {
            var response = await _client.GetAsync($"api/tickets/getchildrentickets/{parentTicketId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var childrenTickets = JsonConvert.DeserializeObject<IEnumerable<TicketDTO>>(content);
                return childrenTickets;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMessage);
            }
        }
    }
}
