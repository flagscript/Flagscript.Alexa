using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit Tests for <see cref="AlexaRequest"/>.
	/// </summary>
	public class AlexaRequestTest
	{

		#region Test Methods

		/// <summary>
		/// Tests the serialization of the version property will only accept and
		/// return '1.0'.
		/// </summary>
		/// <param name="version">Version theory to test.</param>
		[Theory]
		[InlineData("1.0")]
		[InlineData("1.2")]
		public void TestVersionProperty(string version)
		{
			string requestJson = GetVersionTestJson(version);
			try
			{
				AlexaRequest alexaRequest = JsonConvert.DeserializeObject<AlexaRequest>(requestJson);
				Assert.Equal("1.0", version);
				Assert.Equal("1.0", alexaRequest.Version);
			}
			catch (JsonSerializationException)
			{
				Assert.NotEqual("1.0", version);
			}
		}

		#endregion

		#region Json Builders

		/// <summary>
		/// Returns test JSON for <see cref="TestVersionProperty(string)"/>.
		/// </summary>
		/// <returns>The version test json.</returns>
		/// <param name="version">Version string to test with.</param>
		private string GetVersionTestJson(string version)
		{
			JObject testJson = new JObject(
				new JProperty("version", version)
			);
			return testJson.ToString();
		}

		#endregion

	}

}
