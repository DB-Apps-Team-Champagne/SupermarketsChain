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

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public double QuantitySold { get; set; }

        public double income { get; set; }

        public string Vendor { get; set; }

    }
}
