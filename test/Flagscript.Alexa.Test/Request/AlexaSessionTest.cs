using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit tests for <see cref="AlexaSession"/>.
	/// </summary>
	public class AlexaSessionTest
	{

		#region Const/Static

		/// <summary>
		/// Valid Alexa Session Id.
		/// </summary>
		private const string ValidSessionId = "amzn1.echo-api.session.1a123795-2114-4d2b-bdbe-62ecd404ae50";

		/// <summary>
		/// Invalid Alexa Session Id.
		/// </summary>
		private const string InvalidSessionId = "amzn2.echo-api.session.1a123795-2114-4d2b-bdbe-62ecd404ae50";

		#endregion

		#region Test Methods

		/// <summary>
		/// Tests the serialization of the session id property will only accept valid 
		/// amazon session id prefixes.
		/// </summary>
		/// <param name="sessionId">Session ID theory to test.</param>
		[Theory]
		[InlineData(ValidSessionId)]
		[InlineData(InvalidSessionId)]
		public void TestSessionIdProperty(string sessionId)
		{
			string requestJson = GetSessionIdTestJson(sessionId);
			try
			{
				AlexaSession alexaSession = JsonConvert.DeserializeObject<AlexaSession>(requestJson);
				Assert.Equal(ValidSessionId, sessionId);
				Assert.Equal(ValidSessionId, alexaSession.SessionId);
			}
			catch (JsonSerializationException)
			{
				Assert.NotEqual(ValidSessionId, sessionId);
			}
		}

		/// <summary>
		/// Tests the serialization of the attributes dictionary.
		/// </summary>
		[Fact]
		public void TestAttributesProperty()
		{
			string requestJson = GetAttributesJson();
			AlexaSession alexaSession = JsonConvert.DeserializeObject<AlexaSession>(requestJson);
			Assert.Equal(2, alexaSession.Attributes.Count);
		}

		#endregion

		#region Json Builders

		/// <summary>
		/// Returns test JSON for <see cref="TestSessionIdProperty(string)"/>.
		/// </summary>
		/// <returns>The session ID test json.</returns>
		/// <param name="sessionId">Session ID string to test with.</param>
		private string GetSessionIdTestJson(string sessionId)
		{
			JObject testJson = new JObject(
				new JProperty("sessionId", sessionId)
			);
			return testJson.ToString();
		}

		/// <summary>
		/// Returns test JSON for <see cref="TestAttributesProperty"/>.
		/// </summary>
		/// <returns>The attributes json.</returns>
		private string GetAttributesJson()
		{
			JObject testJson = new JObject(
				new JProperty("attributes",
					new JObject(
						new JProperty("key1", "string value 1"),
						new JProperty("key2", "string value 2")
					)
				)
			);
			return testJson.ToString();
		}

		#endregion

	}

}
