using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Flagscript.Alexa.Response
{

	/// <summary>
	/// Base common portions of an Alexa response.
	/// </summary>
	[JsonObject]
	public class AlexaResponse
	{

		#region Properties

		/// <summary>
		/// The version specifier for the response.
		/// </summary>
		/// <value>Response version.</value>
		[JsonProperty("version")]
		public string Version => "1.0";

		/// <summary>
		/// A map of key-value pairs to persist in the session.
		/// </summary>
		/// <value>Session attributes for the users session.</value>
		[JsonProperty("sessionAttributes")]
		public Dictionary<string, object> SessionAttributes { get; set; }

		/// <summary>
		/// What to render to the user and whether to end the current session.
		/// </summary>
		[JsonProperty("response")]
		public AlexaResponseData Response { get; set; }

		#endregion

	}

}
