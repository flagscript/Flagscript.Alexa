using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Alexa permissions.
	/// </summary>
	[JsonObject]
	public class AlexaPermissions
	{

		/// <summary>
		/// Token allowing the skill access to information that the customer has 
		/// consented to provide.
		/// </summary>
		/// <value>The consent token.</value>
		[JsonProperty("consentToken")]
		public string ConsentToken { get; set; }

	}

}
