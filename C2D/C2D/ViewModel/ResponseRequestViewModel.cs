using C2D.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace C2D.ViewModel
{
    class ResponseRequestViewModel
    {
        private IMongoDatabase db;
        private MongoClient client;
        private MongoClientSettings settings;

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
        }
        public void AddNewRequestResponse(Response request)
        {
            var collection = db.GetCollection<BsonDocument>("Response");
            var document = new BsonDocument
                {
                    { "RequestId",request.RequestId},
                    { "description",request.ResponseDescription},
                     { "DonorUserName",request.DonorUserName},
                
                };

            collection.InsertOne(document);

        }
    }
}
