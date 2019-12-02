using System.Collections.Generic;
using MongoDB.Driver;
using SampleApi.Infrastructure;
using SampleApi.Models;

namespace SampleApi.Services
{
	public class SampleService : ISampleService
	{
		private readonly IMongoCollection<Journey> _journeys;

		public SampleService(IMongoDbSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_journeys = database.GetCollection<Journey>(settings.SamplesCollectionName);
		}

		public List<Journey> Get() =>
			_journeys.Find(journey => true).ToList();

		public Journey Get(string id) =>
			_journeys.Find<Journey>(journey => journey.Id == id).FirstOrDefault();

		public Journey Create(Journey journey)
		{
			_journeys.InsertOne(journey);
			return journey;
		}

		public void Update(string id, Journey journeyIn) =>
			_journeys.ReplaceOne(journey => journey.Id == id, journeyIn);

		public void Remove(Journey journeyIn) =>
			_journeys.DeleteOne(journey => journey.Id == journeyIn.Id);

		public void Remove(string id) =>
			_journeys.DeleteOne(journey => journey.Id == id);
	}
}
