using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleApi.Models
{
	public class Task
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonRequired]
		public string Code { get; set; }

		[BsonRequired]
		[BsonElement("Title")]
		public string TaskTitle { get; set; }

		[BsonElement("Subtitle")]
		public string TaskSubtitle { get; set; }

		public string Description { get; set; }

		[BsonRequired]
		[BsonDefaultValue(1)]
		[BsonRepresentation(BsonType.Int32)]
		public int Points { get; set; }

		[BsonRequired]
		[BsonElement("Category")]
		public TaskCategory TaskCategory { get; set; }

		[BsonElement("Tags")]
		public TaskTags TaskTags { get; set; }
	}
}
