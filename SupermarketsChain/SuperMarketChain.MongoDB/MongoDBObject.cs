using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperMarketChain.MongoDB
{
    class MongoDBObject
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Product { get; set; }

        public double Quantity { get; set; }

        public DateTime SaleTime { get; set; }

        public string Vendor { get; set; }

    }
}
