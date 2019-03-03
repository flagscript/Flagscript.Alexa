using Newtonsoft.Json;

namespace Flagscript.Alexa.Response
{

	/// <summary>
	/// Speech output for general and reprompt speech.
	/// </summary>
	[JsonObject]
	public abstract class OutputSpeechBase
	{

		#region Properties

		/// <summary>
		/// The type of output speech to render
		/// </summary>
		[JsonProperty("type")]
		public abstract string Type { get; }

		/// <summary>
		/// The queuing and playback of this output speech.
		/// </summary>
		[JsonProperty("playBehavior")]
		public OutputSpeechPlayBehavior PlayBehavior { get; set; }

		#endregion

	}
}
