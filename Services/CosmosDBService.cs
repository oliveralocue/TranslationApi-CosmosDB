using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using TranslationApi.Models;
using static TranslationApi.Services.ICosmosDBService;

namespace TranslationApi.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(TranslationItem item)
        {
            await this._container.CreateItemAsync<TranslationItem>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<TranslationItem>(id, new PartitionKey(id));
        }

        public async Task<TranslationItem> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<TranslationItem> response = await this._container.ReadItemAsync<TranslationItem>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<TranslationItem>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<TranslationItem>(new QueryDefinition(queryString));
            List<TranslationItem> results = new List<TranslationItem>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, TranslationItem item)
        {
            await this._container.UpsertItemAsync<TranslationItem>(item, new PartitionKey(id));
        }
    }
}
