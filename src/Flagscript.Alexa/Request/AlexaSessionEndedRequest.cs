using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// A request made to an Alexa skill to notify that a session was ended.
	/// </summary>
	[JsonObject]
	public class AlexaSessionEndedRequest : AlexaRequestDataBase
	{

		#region Additional Request Properties

		/// <summary>
		/// Describes why the session ended.
		/// </summary>
		/// <value>The reason the sesion ended.</value>
		[JsonProperty("reason")]
		[JsonConverter(typeof(StringEnumConverter))]
		public SessionEndedReason Reason { get; set; }

		/// <summary>
		/// More information about the error that occurred.
		/// </summary>
		/// <value>Information about the error.</value>
		[JsonProperty("error")]
		public AlexaSessionError Error { get; set; }

		#endregion

	}

}
