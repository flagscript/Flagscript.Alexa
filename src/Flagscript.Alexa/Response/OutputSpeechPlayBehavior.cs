using System.Runtime.Serialization;

namespace Flagscript.Alexa.Response
{

	/// <summary>
	/// Queuing and playback of this output speech
	/// </summary>
	public enum OutputSpeechPlayBehavior
	{

		/// <summary>
		/// Add this speech to the end of the queue. Do not interrupt Alexa's current speech.
		/// </summary>
		[EnumMember(Value = "ENQUEUE")]
		Enqueue = 0,

		/// <summary>
		/// Immediately begin playback of this speech, and replace any current and enqueued speech.
		/// </summary>
		[EnumMember(Value = "REPLACE_ALL")]
		ReplaceAll = 1,

		/// <summary>
		/// Replace all speech in the queue with this speech.
		/// </summary>
		[EnumMember(Value = "REPLACE_ENQUEUED")]
		ReplaceEnqueued = 2
	}
}
