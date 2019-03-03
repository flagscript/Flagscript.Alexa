using Newtonsoft.Json;

namespace Flagscript.Alexa.Response
{

	/// <summary>
	/// Plain Text speech output for general and reprompt speech.
	/// </summary>
	[JsonObject]
	public class PlainTextOutputSpeech : OutputSpeechBase
	{

		#region Properties

		/// <summary>
		/// The type of output speech to render
		/// </summary>
		[JsonProperty("type")]
		public override string Type => "PlainText";

		/// <summary>
		/// A string containing the speech to render to the user.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		#endregion

	}

}
