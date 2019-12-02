using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.Models;
using SampleApi.Services;

namespace SampleApi.Controllers
{
	/// <summary> Sample Controller </summary>
	[ApiController]
	[Route("[controller]")]
	public class SampleController : ControllerBase
	{
		private readonly ILogger<SampleController> _logger;
		private readonly ISampleService _sampleService;

		public SampleController(ILogger<SampleController> logger, ISampleService sampleService)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_sampleService = sampleService ?? throw new ArgumentNullException(nameof(sampleService));
		}

		[HttpGet]
		public ActionResult<List<Journey>> Get() =>
			_sampleService.Get();

		[HttpGet("{id:length(24)}", Name = "GetJourney")]
		public ActionResult<Journey> Get(string id)
		{
			var journey = _sampleService.Get(id);

			if (journey == null)
			{
				return NotFound();
			}

			return journey;
		}

		[HttpPost]
		public ActionResult<Journey> Create(Journey journey)
		{
			_sampleService.Create(journey);

			return CreatedAtRoute("GetJourney", new { id = journey.Id }, journey);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Journey journeyIn)
		{
			var journey = _sampleService.Get(id);

			if (journey == null)
			{
				return NotFound();
			}

			_sampleService.Update(id, journeyIn);

			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var journey = _sampleService.Get(id);

			if (journey == null)
			{
				return NotFound();
			}

			_sampleService.Remove(journey.Id);

			return NoContent();
		}
	}
}
