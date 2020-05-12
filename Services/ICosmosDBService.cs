using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslationApi.Models;

namespace TranslationApi.Services
{
    public class ICosmosDBService
    {
        public interface ICosmosDbService
        {
            Task<IEnumerable<TranslationItem>> GetItemsAsync(string query);
            Task<TranslationItem> GetItemAsync(string id);
            Task AddItemAsync(TranslationItem item);
            Task UpdateItemAsync(string id, TranslationItem item);
            Task DeleteItemAsync(string id);
        }
    }
}
