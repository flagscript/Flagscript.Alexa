using Newtonsoft.Json;

namespace Flagscript.Alexa.Response
{

	/// <summary>
	/// What to render to the user and whether to end the current session.
	/// </summary>
	[JsonObject]
	public class AlexaResponseData
	{

		#region Properties

		/// <summary>
		/// The object containing the speech to render to the user.
		/// </summary>
		/// <value>Speech to render to the user.</value>
		[JsonProperty("outputSpeech")]
		public OutputSpeechBase OutputSpeech { get; set; }

		/// <summary>
		/// The object containing the output speech to use if a re-prompt is necessary.
		/// </summary>
		/// <value>Speech to use if a re-prompt is necessary.</value>
		[JsonProperty("reprompt")]
		public OutputSpeechBase Reprompt { get; set; }

		/// <summary>
		/// Whether or not to end the users session.
		/// </summary>
		/// <remarks>defaults to <c>true</c>.</remarks>
		[JsonProperty("shouldEndSession")]
		public bool ShouldEndSession { get; set; } = true;

		#endregion

	}

}
