using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiMongoDb.Model;

namespace WebApiMongoDb.Service
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _collection;

        public ProdutoService(IOptions<ProdutoDataBaseSettings> produtoService)
        {
            var mongClient = new MongoClient(produtoService.Value.ConnectionString);
            var mongDataBase = mongClient.GetDatabase(produtoService.Value.DataBaseName);

            _collection = mongDataBase.GetCollection<Produto>
                (produtoService.Value.ProdutoCollectionName);
        }

        public async Task<List<Produto>> GetAsync()
            => await _collection.Find(x => true).ToListAsync();

        public async Task<Produto> GetAsync(string id)
         => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreatAsync(Produto produto)
            => await _collection.InsertOneAsync(produto);

        public async Task UpdateAsync(string id, Produto produto)
           => await _collection.ReplaceOneAsync(x => x.Id == id, produto);

        public async Task RemoveAsync(string id)
            => await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
