using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Object indicating the alexa application for the intended skill. 
	/// </summary>
	[JsonObject]
	public class AlexaApplication
	{

		/// <summary>
		/// Application ID for the intended skill.
		/// </summary>
		[JsonProperty("applicationId")]
		public string ApplicationId { get; set; }

	}

}
