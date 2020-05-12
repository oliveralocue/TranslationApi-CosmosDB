
namespace TranslationApi.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TranslationApi.Models;

    public interface ICosmosDbService
    {
        Task<IEnumerable<TranslationItem>> GetItemsAsync(string query);
        Task<TranslationItem> GetItemAsync(string id);
        Task AddItemAsync(TranslationItem item);
        Task UpdateItemAsync(string id, TranslationItem item);
        Task DeleteItemAsync(string id);
    }
}
