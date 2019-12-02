using System;

namespace SampleApi.Models
{
	[Flags]
	public enum TaskTags
	{
		None,
		Mandatory,
		MakeAppointment
	}
}
