using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit tests for <see cref="AlexaSlot"/>.
	/// </summary>
	public class AlexaSlotTest
	{

		#region Test Methods 

		/// <summary>
		/// Unit test for <see cref="AlexaSlot.ConfirmationStatus"/>,
		/// </summary>
		/// <param name="enumValue">The confirmation status JSON value to test..</param>
		[Theory]
		[MemberData(nameof(ConfirmationStatusData))]
		public void TestIntentConfirmationStatusProperty(string enumValue)
		{
			try
			{
				string testJson = GetSlotConfirmationStatusJson(enumValue);
				AlexaSlot slot = JsonConvert.DeserializeObject<AlexaSlot>(testJson);
				int confirmationStatus = (int)slot.ConfirmationStatus;
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
		/// Returns JSON to <see cref="AlexaSlot.ConfirmationStatus"/>.
		/// </summary>
		/// <returns>The alexa slot confiruation status json.</returns>
		/// <param name="enumValue">Confirmation Status value to test.</param>
		public string GetSlotConfirmationStatusJson(string enumValue)
		{
			JObject testJson = new JObject(
				new JProperty("confirmationStatus", enumValue)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetSlotConfirmationStatusJson(string)"/>.
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
