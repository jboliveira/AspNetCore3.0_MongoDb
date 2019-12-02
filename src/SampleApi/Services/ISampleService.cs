using System.Collections.Generic;
using SampleApi.Models;

namespace SampleApi.Services
{
	public interface ISampleService
	{
		List<Journey> Get();
		Journey Get(string id);
		Journey Create(Journey journey);
		void Update(string id, Journey journeyIn);
		void Remove(Journey journeyIn);
		void Remove(string id);
	}
}
