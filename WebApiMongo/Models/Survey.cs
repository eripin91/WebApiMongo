using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Models
{
    public class Survey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Question { get; set; }
        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public bool Required { get; set; }

        public string Prefix { get; set; }
        public int Page { get; set; }
        public List<string> Option { get; set; }
    }
}
