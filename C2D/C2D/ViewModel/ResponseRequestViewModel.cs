using C2D.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace C2D.ViewModel
{
    class ResponseRequestViewModel
    {
        private IMongoDatabase db;
        private MongoClient client;
        private MongoClientSettings settings;
        private IMongoCollection<Response> collection;
        public ResponseRequestViewModel()
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
            collection = db.GetCollection<Response>("Response");
        }
        public void AddNewRequestResponse(Response request)
        {
            var collection = db.GetCollection<BsonDocument>("Response");
            var document = new BsonDocument
                {
                    { "RequestId",request.RequestId},
                    { "description",request.description},
                    { "DonorUserName",request.DonorUserName},
                    {"RecipientUserName",request.RecipientUserName },
                {"status",request.status}
                };

            collection.InsertOne(document);

        }

        public async Task<List<Response>> SearchByRecipientUserName(string username)
        {
            var results = await collection
                            .AsQueryable()
                            .Where(tdi => tdi.RecipientUserName.Contains(username))
                            .ToListAsync();

            var reqCollection = db.GetCollection<DonationRequests>("DonationRequests");

       
            return results;
        }
        public void SetStatus(string description1, int status1)
        {
            ResponseRequestViewModel listDonationRequestsViewModel = new ResponseRequestViewModel();
            Response dr = new Response
            {

                status = status1
            };
            UpdateResponseItem(dr, description1);
        }
        public void UpdateResponseItem(Response dr1,string description)
        {
            var collection = db.GetCollection<Response>("Response");
            var filter = Builders<Response>.Filter.Eq(s => s.description,description);
            var update = Builders<Response>.Update
                .Set(s => s.status, dr1.status);

            collection.UpdateOneAsync(filter, update);
        }

    }
}
