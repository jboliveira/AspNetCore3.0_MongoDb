using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleApi.Models
{
	public class Journey
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonRequired]
		public string Code { get; set; }

		[BsonRequired]
		[BsonElement("Title")]
		public string JourneyTitle { get; set; }

		[BsonElement("Subtitle")]
		public string JourneySubtitle { get; set; }

		public string Description { get; set; }

		public IEnumerable<Task> Tasks { get; set; }
	}
}
