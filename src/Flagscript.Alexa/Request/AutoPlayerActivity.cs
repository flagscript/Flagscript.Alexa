using System.Runtime.Serialization;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Valid states for audio play playback.
	/// </summary>
	public enum AudioPlayerActivity
	{

		/// <summary>
		/// Nothing was playing, no enqueued items.
		/// </summary>
		[EnumMember(Value = "IDLE")]
		Idle = 0,

		/// <summary>
		/// Stream was paused.
		/// </summary>
		[EnumMember(Value = "PAUSED")]
		Paused = 1,

		/// <summary>
		/// Stream was playing.
		/// </summary>
		[EnumMember(Value = "PLAYING")]
		Playing = 2,

		/// <summary>
		/// Buffer Underrun.
		/// </summary>
		[EnumMember(Value = "BUFFER_UNDERRUN")]
		BufferUnderrun = 3,

		/// <summary>
		/// Stream was finished playing.
		/// </summary>
		[EnumMember(Value = "FINISHED")]
		Finished = 4,

		/// <summary>
		/// Stream was interrupted.
		/// </summary>
		[EnumMember(Value = "STOPPED")]
		Stopped = 5

	}

}
