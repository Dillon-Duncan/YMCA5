using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YmcaApiClient.Models;

namespace YmcaApiClient
{
    public class YmcaApiClientService
    {
        private readonly HttpClient _httpClient;

        public YmcaApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }

        // User methods
        public async Task<List<User>?> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("/api/User");
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<User?>($"/api/User/{id}");
        }

        public async Task<HttpResponseMessage> AddUser(User user)
        {
            return await _httpClient.PostAsJsonAsync("/api/User", user);
        }

        public async Task UpdateUser(User user)
        {
            await _httpClient.PutAsJsonAsync("/api/User", user);
        }

        public async Task DeleteUser(int id)
        {
            await _httpClient.DeleteAsync($"/api/User/{id}");
        }

        // Admin methods
        public async Task<List<Admin>?> GetAdmins()
        {
            return await _httpClient.GetFromJsonAsync<List<Admin>>("/api/Admin");
        }

        public async Task<Admin?> GetAdminById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Admin?>($"/api/Admin/{id}");
        }

        public async Task AddAdmin(Admin admin)
        {
            await _httpClient.PostAsJsonAsync("/api/Admin", admin);
        }

        public async Task UpdateAdmin(Admin admin)
        {
            await _httpClient.PutAsJsonAsync("/api/Admin", admin);
        }

        public async Task DeleteAdmin(int id)
        {
            await _httpClient.DeleteAsync($"/api/Admin/{id}");
        }

        // Bulletin methods
        public async Task<List<Bulletin>?> GetBulletins()
        {
            return await _httpClient.GetFromJsonAsync<List<Bulletin>>("/api/Bulletin");
        }

        public async Task<Bulletin?> GetBulletinById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Bulletin?>($"/api/Bulletin/{id}");
        }

        public async Task AddBulletin(Bulletin bulletin)
        {
            await _httpClient.PostAsJsonAsync("/api/Bulletin", bulletin);
        }

        public async Task UpdateBulletin(Bulletin bulletin)
        {
            await _httpClient.PutAsJsonAsync("/api/Bulletin", bulletin);
        }

        public async Task DeleteBulletin(int id)
        {
            await _httpClient.DeleteAsync($"/api/Bulletin/{id}");
        }

        // Chat methods
        public async Task<List<Chat>?> GetChats()
        {
            return await _httpClient.GetFromJsonAsync<List<Chat>>("/api/Chat");
        }

        public async Task<Chat?> GetChatById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Chat?>($"/api/Chat/{id}");
        }

        public async Task AddChat(Chat chat)
        {
            await _httpClient.PostAsJsonAsync("/api/Chat", chat);
        }

        public async Task UpdateChat(Chat chat)
        {
            await _httpClient.PutAsJsonAsync("/api/Chat", chat);
        }

        public async Task DeleteChat(int id)
        {
            await _httpClient.DeleteAsync($"/api/Chat/{id}");
        }

        // Event methods
        public async Task<List<Event>?> GetEvents()
        {
            return await _httpClient.GetFromJsonAsync<List<Event>>("/api/Event");
        }

        public async Task<Event?> GetEventById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Event?>($"/api/Event/{id}");
        }

        public async Task AddEvent(Event @event)
        {
            await _httpClient.PostAsJsonAsync("/api/Event", @event);
        }

        public async Task UpdateEvent(Event @event)
        {
            await _httpClient.PutAsJsonAsync("/api/Event", @event);
        }

        public async Task DeleteEvent(int id)
        {
            await _httpClient.DeleteAsync($"/api/Event/{id}");
        }

        // Message methods
        public async Task<List<Message>?> GetMessages()
        {
            return await _httpClient.GetFromJsonAsync<List<Message>>("/api/Message");
        }

        public async Task<Message?> GetMessageById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Message?>($"/api/Message/{id}");
        }

        public async Task AddMessage(Message message)
        {
            await _httpClient.PostAsJsonAsync("/api/Message", message);
        }

        public async Task UpdateMessage(Message message)
        {
            await _httpClient.PutAsJsonAsync("/api/Message", message);
        }

        public async Task DeleteMessage(int id)
        {
            await _httpClient.DeleteAsync($"/api/Message/{id}");
        }

        // News methods
        public async Task<List<News>?> GetNews()
        {
            return await _httpClient.GetFromJsonAsync<List<News>>("/api/News");
        }

        public async Task<News?> GetNewsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<News?>($"/api/News/{id}");
        }

        public async Task AddNews(News news)
        {
            await _httpClient.PostAsJsonAsync("/api/News", news);
        }

        public async Task UpdateNews(News news)
        {
            await _httpClient.PutAsJsonAsync("/api/News", news);
        }

        public async Task DeleteNews(int id)
        {
            await _httpClient.DeleteAsync($"/api/News/{id}");
        }
    }
}