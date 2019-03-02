using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit tests for <see cref="AlexaSessionEndedRequest"/>.
	/// </summary>
	public class AlexaSessionEndedRequestTest
	{

		#region Test Methods

		/// <summary>
		/// Unit test for <see cref="AlexaSessionEndedRequest.Reason"/>.
		/// </summary>
		/// <param name="enumValue">Thereason type JSON value to test.</param>
		[Theory]
		[MemberData(nameof(ReasonTypeData))]
		public void TestReason(string enumValue)
		{
			try
			{
				string testJson = GetAlexaSessionEndedReasonJson(enumValue);
				AlexaSessionEndedRequest sessionEndedRequest = JsonConvert.DeserializeObject<AlexaSessionEndedRequest>(testJson);
				int sessionEndedReason = (int)sessionEndedRequest.Reason;
				Assert.True(sessionEndedReason > -1);
				Assert.True(sessionEndedReason < 3);
			}
			catch (JsonSerializationException)
			{
				Assert.Equal("faker", enumValue);
			}
		}

		#endregion

		#region JSON Builders

		/// <summary>
		/// Returns JSON to <see cref="AlexaSessionError.ErrorType"/>.
		/// </summary>
		/// <returns>The alexa audio player playback details json.</returns>
		/// <param name="enumValue">Palyer activity value to test.</param>
		public string GetAlexaSessionEndedReasonJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("reason", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetAlexaSessionEndedReasonJson(string)"/>.
		/// </summary>
		/// <value>The session error type test data.</value>
		public static IEnumerable<object[]> ReasonTypeData => new List<object[]>()
		{
			new object[] { SessionEndedReason.UserInitiated },
			new object[] { SessionEndedReason.Error },
			new object[] { SessionEndedReason.ExceededMaxReprompts },
			new object[] {"faker" }
		};

		#endregion

	}

}
