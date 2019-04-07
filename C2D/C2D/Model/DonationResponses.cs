using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace C2D.Model
{
    class DonationResponses
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string Title { get; set; }
    }
}
