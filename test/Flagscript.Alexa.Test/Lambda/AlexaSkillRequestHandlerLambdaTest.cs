using System.Collections.Generic;

using Xunit;

using Flagscript.Alexa.Request;
using Flagscript.Alexa.Response;

namespace Flagscript.Alexa.Lambda.Test
{

	/// <summary>
	/// Unit test for <see cref="AlexaSkillRequestHandlerLambda"/>.
	/// </summary>
	public class AlexaSkillRequestHandlerLambdaTest
	{

		#region Properties

		/// <summary>
		/// Request handler to use for testing.
		/// </summary>
		public TestSkillRequestHandler RequestHander { get; private set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public AlexaSkillRequestHandlerLambdaTest()
		{
			RequestHander = new TestSkillRequestHandler();
		}

		#endregion

		#region Test Methods

		/// <summary>
		/// Basic test of the variations of handle skill request.
		/// </summary>
		[Theory]
		[MemberData(nameof(AlexaRequestData))]
		public void TestHandleAlexaSkillRequest(AlexaRequestDataBase requestBase, string compare)
		{
			AlexaRequest alexaRequest = new AlexaRequest
			{
				RequestData = requestBase
			};


			AlexaResponse alexaResponse = RequestHander.HandleAlexaSkillRequest(alexaRequest, null);
			PlainTextOutputSpeech plainText = alexaResponse?.Response?.OutputSpeech as PlainTextOutputSpeech;
			Assert.Equal(compare, plainText?.Text);

		}

		#endregion

		#region Data Methods

		/// <summary>
		/// Test data for <see cref="TestAlexaLaunchRequest(string)"/>.
		/// </summary>
		/// <value>The alexa request test data.</value>
		public static IEnumerable<object[]> AlexaRequestData => new List<object[]>()
		{
			new object[] { new AlexaLaunchRequest { RequestType = AlexaRequestType.LaunchRequest }, "AlexaLaunchRequest" },
			new object[] { new AlexaSessionEndedRequest { RequestType = AlexaRequestType.SessionEndedRequest }, null },
			new object[] { new AlexaCanFulfillIntentRequest { RequestType = AlexaRequestType.CanFulfillIntentRequest }, "AlexaCanFulfillIntentRequest" },
			new object[] { new AlexaIntentRequest { RequestType = AlexaRequestType.IntentRequest }, "AlexaIntentRequest" },
		};

		#endregion


	}

}
