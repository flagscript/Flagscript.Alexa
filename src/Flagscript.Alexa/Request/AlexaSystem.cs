using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Current state of service and device at time of request.
	/// </summary>
	[JsonObject]
	public class AlexaSystem
	{

		#region Properties

		/// <summary>
		/// Token that can be used to access Alexa-specific APIs.
		/// </summary>
		/// <value>Alexa API Token.</value>
		[JsonProperty("apiAccessToken")]
		public string ApiAccessToken { get; set; }

		/// <summary>
		/// Correct base URI to refer to by region.
		/// </summary>
		/// <value>Base URI to refer to by region..</value>
		[JsonProperty("apiEndpoint")]
		public string ApiEndpoint { get; set; }

		/// <summary>
		/// Object indicating the alexa application for the intended skill. 
		/// </summary>
		/// <value>Alexa Application</value>
		[JsonProperty("application")]
		public AlexaApplication Application { get; set; }

		/// <summary>
		///  Information about the device used to send the request.
		/// </summary>
		/// <value>Information about the Alexa device.</value>
		[JsonProperty("device")]
		public AlexaDevice Device { get; set; }

		/// <summary>
		/// The user making the request.
		/// </summary>
		/// <value>The user making the request.</value>
		[JsonProperty("user")]
		public AlexaUser User { get; set; }

		#endregion

	}

}
