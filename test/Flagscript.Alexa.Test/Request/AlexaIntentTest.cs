using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit Tests for <see cref="AlexaIntent"/>.
	/// </summary>
	public class AlexaIntentTest
	{

		#region Test Methods 

		/// <summary>
		/// Unit test for <see cref="AlexaIntent.ConfirmationStatus"/>,
		/// </summary>
		/// <param name="enumValue">The confirmation status JSON value to test..</param>
		[Theory]
		[MemberData(nameof(ConfirmationStatusData))]
		public void TestIntentConfirmationStatusProperty(string enumValue)
		{
			try
			{
				string testJson = GetIntentConfirmationStatusJson(enumValue);
				AlexaIntent intent = JsonConvert.DeserializeObject<AlexaIntent>(testJson);
				int confirmationStatus = (int)intent.ConfirmationStatus;
				Assert.True(confirmationStatus > -1);
				Assert.True(confirmationStatus < 3);
			}
			catch (JsonSerializationException)
			{
				Assert.Equal("faker", enumValue);
			}
		}

		#endregion

		#region JSON Builders

		/// <summary>
		/// Returns JSON to <see cref="AlexaIntent.ConfirmationStatus"/>.
		/// </summary>
		/// <returns>The alexa intent confiruation status json.</returns>
		/// <param name="enumValue">Confirmation Status value to test.</param>
		public string GetIntentConfirmationStatusJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("confirmationStatus", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetIntentConfirmationStatusJson(string)"/>.
		/// </summary>
		/// <value>The player activity test data.</value>
		public static IEnumerable<object[]> ConfirmationStatusData => new List<object[]>()
		{
			new object[] { ConfirmationStatus.None },
			new object[] { ConfirmationStatus.Confirmed },
			new object[] { ConfirmationStatus.Denied },
			new object[] {"faker" }
		};

		#endregion

	}

}
