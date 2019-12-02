namespace SampleApi.Infrastructure
{
	public interface IMongoDbSettings
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
		string SamplesCollectionName { get; set; }
	}
}
