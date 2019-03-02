using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Alexa session error information.
	/// </summary>
	[JsonObject]
	public class AlexaSessionError
	{

		/// <summary>
		/// The type of error that occured.
		/// </summary>
		/// <value>The type of the error.</value>
		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public SessionErrorType ErrorType { get; set; }

		/// <summary>
		/// More information about the error.
		/// </summary>
		/// <value>Information about the error.</value>
		[JsonProperty("message")]
		public string Message { get; set; }

	}

}
