using System;

using Newtonsoft.Json;
using Xunit;

namespace Flagscript.Alexa.Request.Test
{

	/// <summary>
	/// Unit Tests for <see cref="AlexaRequest"/>.
	/// </summary>
	public class AlexaRequestTest
	{

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

			var requestJson = "{ \"version\": \"" + version + "\" }";
			AlexaRequest alexaRequest = null;
			try
			{
				alexaRequest = JsonConvert.DeserializeObject<AlexaRequest>(requestJson);
				Assert.Equal("1.0", version);
				Assert.Equal("1.0", alexaRequest.Version);
			}
			catch (JsonSerializationException)
			{
				Assert.NotEqual("1.0", version);
			}
		}


	}

}
