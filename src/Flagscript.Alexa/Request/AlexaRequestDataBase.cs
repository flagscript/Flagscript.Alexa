using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Base class for all Alexa Request Data.
	/// </summary>
	[JsonObject]
	public class AlexaRequestDataBase
	{

		#region Properties

		/// <summary>
		/// Type of the Alexa Request.
		/// </summary>
		/// <value>The type of the alexa request.</value>
		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public AlexaRequestType RequestType { get; set; }

		/// <summary>
		/// When Alexa sent the request.
		/// </summary>
		/// <value>The timestamp Alexa sent the request.</value>
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// Unique Identifier for this specific request.
		/// </summary>
		/// <value>The request identifier.</value>
		[JsonProperty("requestId")]
		public string RequestId { get; set; }

		/// <summary>
		/// The users locale.
		/// </summary>
		/// <value>The users locale.</value>
		[JsonProperty("localeId")]
		public string Locale { get; set; }

		#endregion

	}

}
