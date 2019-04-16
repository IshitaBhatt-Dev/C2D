using C2D.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace C2D.ViewModel
{
   
    class ListDonationRequestsViewModel
    {
        private IMongoDatabase db;
        private MongoClient client;
        private MongoClientSettings settings;
        private  IMongoCollection<DonationRequests> collaction;
        
        public ListDonationRequestsViewModel()
        {
            string connectionString =
 @"mongodb://c2drepo:movrVMUQ2jhHLeC6x9Y7YA6VGK3HrdIyCgkt9Q9GGigagQt0NjirUSXfaaGsZpP0oIkzPROyobHo7wZMI7Zh3Q==@c2drepo.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            settings = MongoClientSettings.FromUrl(
               new MongoUrl(connectionString)
             );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            client = new MongoClient(settings);
            db = client.GetDatabase("C2D");
            collaction = db.GetCollection<DonationRequests>("DonationRequests");

        }

        public async Task<List<DonationRequests>> GetAllItems()
        {
           
            var allItems = await collaction
                .AsQueryable()
                .ToListAsync();

            return allItems;
        }

        public async Task<DonationRequests> SearchById(string id)
        {
            var results = await collaction
                               .AsQueryable()
                               .Where(tdi => tdi.Id.Equals(ObjectId.Parse(id)))
                               .FirstAsync();
            return results;
        }
        public async Task<List<DonationRequests>> SearchByUserName(string username)
        {
            var results = await collaction
                            .AsQueryable()
                            .Where(tdi => tdi.username.Contains(username))
                            .ToListAsync();

            return results;
        }





        public void UpdateItem(DonationRequests item, string id)
        {
            var filter = Builders<DonationRequests>.Filter.Eq(s => s.Id, ObjectId.Parse(id));
            var update = Builders<DonationRequests>.Update
                .Set(s => s.title, item.title)
                .Set(s => s.description, item.description)
                .Set(s => s.keyword1, item.keyword1)
                .Set(s => s.keyword2, item.keyword2)
                .Set(s=>s.username,item.username)
                .Set(s => s.status, item.status);

             collaction.UpdateOneAsync(filter, update);
        }

       
    }
}
