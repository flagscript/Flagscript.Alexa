using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit tests for <see cref="AlexaSessionError"/>.
	/// </summary>
	public class AlexaSessionErrorTest
	{

		#region Test Methods

		/// <summary>
		/// Unit test for <see cref="AlexaSessionError.ErrorType"/>.
		/// </summary>
		/// <param name="enumValue">The session error type JSON value to test.</param>
		[Theory]
		[MemberData(nameof(SessionErrorTypeData))]
		public void TestErrorType(string enumValue)
		{
			try
			{
				string testJson = GetAlexaSessionErrorTypeJson(enumValue);
				AlexaSessionError sessionError = JsonConvert.DeserializeObject<AlexaSessionError>(testJson);
				int playerActivity = (int)sessionError.ErrorType;
				Assert.True(playerActivity > -1);
				Assert.True(playerActivity < 3);
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
		public string GetAlexaSessionErrorTypeJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("type", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetAlexaSessionErrorTypeJson(string)"/>.
		/// </summary>
		/// <value>The session error type test data.</value>
		public static IEnumerable<object[]> SessionErrorTypeData => new List<object[]>()
		{
			new object[] { SessionErrorType.InvalidResponse },
			new object[] { SessionErrorType.DeviceCommunicationError },
			new object[] { SessionErrorType.InternalError },
			new object[] {"faker" }
		};

		#endregion

	}

}
