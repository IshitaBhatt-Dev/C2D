using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace C2D.Model
{
    class DonationRequests
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string keyword1 { get; set; }
        public string keyword2 { get; set; }
        public string username { get; set; }
        public bool status { get; set; }
    }
}
