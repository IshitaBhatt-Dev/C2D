using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace C2D.Model
{
    class Recipients
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string FullName { get; set; }
        public string GovtId { get; set; }
        public string Email { get; set; }
        public long Contact { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
    }
}
