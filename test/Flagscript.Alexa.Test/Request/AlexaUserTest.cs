using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;


namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit tests for <see cref="AlexaUser"/>.
	/// </summary>
	public class AlexaUserTest
	{

		#region Const/Static

		/// <summary>
		/// Valid Alexa User Id.
		/// </summary>
		private const string ValidUserId = "amzn1.ask.account.1a123795-2114-4d2b-bdbe-62ecd404ae50";

		/// <summary>
		/// Invalid Alexa User Id.
		/// </summary>
		private const string InvalidUserId = "amzn2.ask.account.1a123795-2114-4d2b-bdbe-62ecd404ae50";

		#endregion

		#region Test Methods

		/// <summary>
		/// Tests the serialization of the user ID property will only accept valid 
		/// amazon user id prefixes.
		/// </summary>
		/// <param name="userId">User ID theory to test.</param>
		[Theory]
		[InlineData(ValidUserId)]
		[InlineData(InvalidUserId)]
		public void TestUserIdProperty(string userId)
		{
			string requestJson = GetUserIdTestJson(userId);
			try
			{
				AlexaUser alexaUser = JsonConvert.DeserializeObject<AlexaUser>(requestJson);
				Assert.Equal(ValidUserId, userId);
				Assert.Equal(ValidUserId, alexaUser.UserId);
			}
			catch (JsonSerializationException)
			{
				Assert.NotEqual(ValidUserId, userId);
			}
		}

		#endregion

		#region Json Builders

		/// <summary>
		/// Returns test JSON for <see cref="TestUserIdProperty(string)"/>.
		/// </summary>
		/// <returns>The user id test json.</returns>
		/// <param name="version">User ID string to test with.</param>
		private string GetUserIdTestJson(string version)
		{
			JObject testJson = new JObject(
				new JProperty("userId", version)
			);
			return testJson.ToString();
		}

		#endregion

	}

}
