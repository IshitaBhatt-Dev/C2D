using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace C2D.Model
{
    class Donors
    {
        [BsonId]
        public BsonObjectId Id{ get; set; }
        public string FirstName{get;set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Contact { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
