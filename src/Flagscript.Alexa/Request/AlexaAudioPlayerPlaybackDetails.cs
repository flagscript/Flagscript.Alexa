using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Details about the audio player playback.
	/// </summary>
	[JsonObject]
	public class AlexaAudioPlayerPlaybackDetails
	{

		#region Fields

		/// <summary>
		/// Backing field for <see cref="PlayerActivity"/>.
		/// </summary>
		//private AudioPlayerActivity? _playerActivity;

		#endregion

		#region Properties

		/// <summary>
		/// An opaque token that represents the audio stream described by this object.
		/// </summary>
		/// <value>Audio player token.</value>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		/// Identifies a track's offset in milliseconds.
		/// </summary>
		/// <value>The track offset in milliseconds.</value>
		[JsonProperty("offsetInMilliseconds")]
		public long? OffsetInMilliseconds { get; set; }

		/// <summary>
		/// Indicates the last known state of audio playback.
		/// </summary>
		/// <value>Last known state of audio playback.</value>
		[JsonProperty("playerActivity")]
		[JsonConverter(typeof(StringEnumConverter))]
		public AudioPlayerActivity PlayerActivity { get; set; }

		#endregion

	}

}
