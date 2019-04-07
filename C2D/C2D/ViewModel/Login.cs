using C2D.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace C2D.ViewModel
{
    public class Login
    {
        private IMongoDatabase db;
        private MongoClient client;
        private MongoClientSettings settings;
       
        public Login() {
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
        
        public bool Authenticate(string userName, string Password, bool donor)
        {
            if (donor)
            {
                var collection = db.GetCollection<BsonDocument>("Donors");
                    var document = new BsonDocument
                {
                     { "username",userName},
                     { "password",Password}
                };
                    long count = collection.CountDocuments(document);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                
            }
            else
            {
              
                var collection = db.GetCollection<BsonDocument>("Recipients");
                var document = new BsonDocument
                {
                     { "username",userName},
                     { "password",Password}
                };
                long count = collection.CountDocuments(document);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
        }
    }
}
