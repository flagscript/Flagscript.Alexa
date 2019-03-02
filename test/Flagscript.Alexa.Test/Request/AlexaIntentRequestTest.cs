using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit tests for <see cref="AlexaIntentRequest"/>.
	/// </summary>
	public class AlexaIntentRequestTest
	{

		#region Test Methods 

		/// <summary>
		/// Unit test for <see cref="AlexaIntentRequest.DialogState"/>,
		/// </summary>
		/// <param name="enumValue">The dialog state JSON value to test..</param>
		[Theory]
		[MemberData(nameof(DialogStateData))]
		public void TestIntentRequestDialogStateProperty(string enumValue)
		{
			try
			{
				string testJson = GetIntentRequestDialogStateJson(enumValue);
				AlexaIntentRequest intentRequest = JsonConvert.DeserializeObject<AlexaIntentRequest>(testJson);
				int dialogState = (int)intentRequest.DialogState;
				Assert.True(dialogState > -1);
				Assert.True(dialogState < 3);
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
		public string GetIntentRequestDialogStateJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("dialogState", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetIntentRequestDialogStateJson(string)"/>.
		/// </summary>
		/// <value>The player activity test data.</value>
		public static IEnumerable<object[]> DialogStateData => new List<object[]>()
		{
			new object[] { DialogState.Started },
			new object[] { DialogState.InProgress },
			new object[] { DialogState.Completed },
			new object[] {"faker" }
		};

		#endregion

	}

}
