using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Response.Test
{

	/// <summary>
	/// Unit tests for <see cref="OutputSpeechBase"/>.
	/// </summary>
	public class OutputSpeechBaseTest
	{

		#region Test Methods

		/// <summary>
		/// Unit test for <see cref="OutputSpeechBase.PlayBehavior"/>.
		/// </summary>
		/// <param name="enumValue">The session error type JSON value to test.</param>
		[Theory]
		[MemberData(nameof(PlayBehaviorData))]
		public void TestErrorType(string enumValue)
		{
			try
			{
				string testJson = GetOutputSpeechBasePlayBehaviorJson(enumValue);
				PlainTextOutputSpeech outputSpeech = JsonConvert.DeserializeObject<PlainTextOutputSpeech>(testJson);
				int playBehavior = (int)outputSpeech.PlayBehavior;
				Assert.True(playBehavior > -1);
				Assert.True(playBehavior < 3);
			}
			catch (JsonSerializationException)
			{
				Assert.Equal("faker", enumValue);
			}
		}

		#endregion

		#region JSON Builders

		/// <summary>
		/// Returns JSON to <see cref="OutputSpeechBase.PlayBehavior"/>.
		/// </summary>
		/// <returns>The alexa output speech beavior details json.</returns>
		/// <param name="enumValue">Palyer behavior value to test.</param>
		public string GetOutputSpeechBasePlayBehaviorJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("playBehavior", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetOutputSpeechBasePlayBehaviorJson(string)"/>.
		/// </summary>
		/// <value>The play behavior test data.</value>
		public static IEnumerable<object[]> PlayBehaviorData => new List<object[]>()
		{
			new object[] { OutputSpeechPlayBehavior.Enqueue },
			new object[] { OutputSpeechPlayBehavior.ReplaceAll },
			new object[] { OutputSpeechPlayBehavior.ReplaceEnqueued },
			new object[] {"faker" }
		};

		#endregion

	}

}
