using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace C2D.Model
{
    class Response
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string RequestId { get; set; }
        public string description { get; set; }
        public string DonorUserName { get; set; }
        public string RecipientUserName { get; set; }
        public int status { get; set; }


    }
}
