using System;
using System.Collections.Generic;

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

		/// <summary>
		/// Test that the <see cref="AlexaRequest.RequestData"/> is of a proper
		/// subclassed based on JSON request type values.
		/// </summary>
		/// <param name="requestType">Request type to test.</param>
		/// <param name="requestObjectType">Expected concrete request object type.</param>
		[Theory]
		[MemberData(nameof(RequestTypeData))]
		public void TestRequestDataProperty(string requestType, Type requestObjectType)
		{
			string requestJson = GetRequestDataJson(requestType);
			try
			{
				AlexaRequest alexaRequest = JsonConvert.DeserializeObject<AlexaRequest>(requestJson);
				Assert.True(alexaRequest.RequestData.GetType() == requestObjectType);
			}
			catch (JsonSerializationException)
			{
				Assert.Equal("faker", requestType);
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

		/// <summary>
		/// Returns test JSON for <see cref="TestRequestDataProperty(string, Type)"/>.
		/// </summary>
		/// <returns>The request type json value.</returns>
		/// <param name="requestType">Request type to test with.</param>
		private string GetRequestDataJson(string requestType)
		{
			JObject testJson = new JObject(
				new JProperty("version", "1.0"),
				new JProperty("request",
					new JObject(
						new JProperty("type", requestType)
					)					
				)
			);
			return testJson.ToString();
		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="GetRequestDataJson(string)"/>.
		/// </summary>
		/// <value>The request type data.</value>
		public static IEnumerable<object[]> RequestTypeData => new List<object[]>()
		{
			new object[] { AlexaRequestType.LaunchRequest, typeof(AlexaLaunchRequest) },
			new object[] { AlexaRequestType.IntentRequest, typeof(AlexaIntentRequest) },
			new object[] { AlexaRequestType.SessionEndedRequest, typeof(AlexaSessionEndedRequest) },
			new object[] { AlexaRequestType.CanFulfillIntentRequest, typeof(AlexaCanFulfillIntentRequest) },
			new object[] {"faker" , typeof(string) }
		};

		#endregion

	}

}
