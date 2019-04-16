using MongoDB.Bson;
using MongoDB.Driver;
using C2D.Model;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace C2D.ViewModel
{
    class RegistrationViewModels
    {
        private static IMongoDatabase db;
        private MongoClient mongoclient;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private static IMongoCollection<Recipients> collaction;
        public RegistrationViewModels()
        {
            string connectionString =
  @"mongodb://c2drepo:movrVMUQ2jhHLeC6x9Y7YA6VGK3HrdIyCgkt9Q9GGigagQt0NjirUSXfaaGsZpP0oIkzPROyobHo7wZMI7Zh3Q==@c2drepo.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            mongoclient = new MongoClient(settings);
           // client = new MongoClient("mongodb://localhost:27017/C2D");
            db= mongoclient.GetDatabase("C2D");
            collaction = db.GetCollection<Recipients>("Recipients");
        }
        public void addinfo(Donors donor)
        {
            var collection = db.GetCollection<BsonDocument>("Donors");
            var document = new BsonDocument
                {
                    { "firstname",donor.FirstName},
                    { "lastname",donor.LastName},
                    { "email",donor.Email},
                    { "contact",donor.Contact},
                    { "username",donor.UserName},
                    { "password",donor.Password}

                };

            collection.InsertOneAsync(document);

        }

        public void addinfo(Recipients recipient)
        {
            var collection = db.GetCollection<BsonDocument>("Recipients");
            var document = new BsonDocument
                {
                    { "fullname",recipient.FullName},
                    { "govtid",recipient.GovtId},
                    { "email",recipient.Email},
                    { "contact",recipient.Contact},
                    { "username",recipient.userName},
                    { "password",recipient.Password}

                };

            collection.InsertOneAsync(document);
            

        }
        //public IMongoQueryable<Recipients> SearchByUserName(string userName)
        //{
        //    //collaction = db.GetCollection<Recipients>("Recipients");
        //    ////var results = await collaction
        //    ////                   .AsQueryable()
        //    ////                   .Where(tdi => tdi.UserName.Contains(userName))
        //    ////                   .ToListAsync();
        //    ////return results;
        //    ////var results = await collaction
        //    ////                  .AsQueryable()
        //    ////                  .Where(tdi => tdi.UserName.Equals(userName))
        //    ////                  .FirstAsync();
        //    ////return results;
        //    //var query =
        //    //        collaction.AsQueryable<Recipients>()
        //    //        .Where(e => e.UserName == userName)
        //    //        .Select(e => e);
        //    //return query;
        //}
        public IMongoQueryable<Recipients> SearchByUserName(string username)
        {
           
            //var results = await collaction
            //                .AsQueryable()
            //                .Where(tdi => tdi.userName.Contains(username))
            //                .ToListAsync();
                    var query = 
            from e in collaction.AsQueryable<Recipients>()
            where e.userName == username
            select e;

            return query;
        }
        public async Task<List<Donors>> SearchByDonorUserName(string username)
        {
            var collection = db.GetCollection<Donors>("Donors");
            var results = await collection
                            .AsQueryable()
                            .Where(tdi => tdi.UserName.Contains(username))
                            .ToListAsync();

            return results;
        }

    }
}
