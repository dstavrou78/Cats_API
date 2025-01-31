using Cats_API.Models;

namespace Cats_API.Interfaces
{
    public interface IExternalAPI
    {
        public Task GetAsync(HttpClient httpClient, CatsContext db, string? api_key);
    }
}
