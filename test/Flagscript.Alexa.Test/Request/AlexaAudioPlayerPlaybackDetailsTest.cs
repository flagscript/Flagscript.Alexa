using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit Tests for <see cref="AlexaAudioPlayerPlaybackDetails"/>
	/// </summary>
	public class AlexaAudioPlayerPlaybackDetailsTest
	{

		#region Test Methods 

		/// <summary>
		/// Unit test for <see cref="AlexaAudioPlayerPlaybackDetails.PlayerActivity"/>,
		/// </summary>
		/// <param name="enumValue">The player activity JSON value to test..</param>
		[Theory]
		[MemberData(nameof(PlayerActivityData))]
		public void TestPlayerActivityProperty(string enumValue)
		{
			try
			{
				string testJson = GetAlexaAudioPlayerPlaybackDetailsJson(enumValue);
				AlexaAudioPlayerPlaybackDetails pb = JsonConvert.DeserializeObject<AlexaAudioPlayerPlaybackDetails>(testJson);
				int playerActivity = (int)pb.PlayerActivity;
				Assert.True(playerActivity > -1);
				Assert.True(playerActivity < 6);
			}
			catch (JsonSerializationException)
			{
				Assert.Equal("faker", enumValue);
			}
		}

		#endregion

		#region JSON Builders

		/// <summary>
		/// Returns JSON to <see cref="AlexaAudioPlayerPlaybackDetails.PlayerActivity"/>.
		/// </summary>
		/// <returns>The alexa audio player playback details json.</returns>
		/// <param name="enumValue">Palyer activity value to test.</param>
		public string GetAlexaAudioPlayerPlaybackDetailsJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("playerActivity", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="TestPlayerActivityProperty(string)"/>.
		/// </summary>
		/// <value>The player activity test data.</value>
		public static IEnumerable<object[]> PlayerActivityData => new List<object[]>()
		{
			new object[] { AudioPlayerActivity.Idle },
			new object[] { AudioPlayerActivity.Paused },
			new object[] { AudioPlayerActivity.Playing },
			new object[] { AudioPlayerActivity.BufferUnderrun },
			new object[] { AudioPlayerActivity.Finished },
			new object[] { AudioPlayerActivity.Stopped },
			new object[] {"faker" }
		};

		#endregion

	}

}
