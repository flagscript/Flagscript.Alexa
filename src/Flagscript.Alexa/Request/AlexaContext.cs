using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Current state of service and device at time of request.
	/// </summary>
	[JsonObject]
	public class AlexaContext
	{

		#region Properties

		/// <summary>
		/// Current state of service and device at time of request.
		/// </summary>
		/// <value>Current state of service and device.</value>
		[JsonProperty("System")]
		public AlexaSystem System { get; set; }

		#endregion

	}

}
