using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoGrafanaAPI.Models
{
    public class TransactionLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("transaction_id")]
        public string TransactionId { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("path")]
        public string Path { get; set; }

        [BsonElement("request_body")]
        public string RequestBody { get; set; }

        [BsonElement("transaction_output")]
        public string TransactionOutput { get; set; }

        [BsonElement("aws_request_id")]
        public string AwsRequestId { get; set; }
    }
}
