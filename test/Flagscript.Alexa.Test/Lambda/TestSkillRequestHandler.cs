using Flagscript.Alexa.Request;
using Flagscript.Alexa.Response;

namespace Flagscript.Alexa.Lambda.Test
{

	public class TestSkillRequestHandler : AlexaSkillRequestHandlerLambda
	{

		public override AlexaResponse HandleLaunchRequest(AlexaLaunchRequest launchRequest, AlexaContext context, AlexaSession session)
		{

			AlexaResponse alexaResponse = new AlexaResponse();
			PlainTextOutputSpeech plainText = new PlainTextOutputSpeech
			{
				Text = "AlexaLaunchRequest"
			};
			AlexaResponseData responseData = new AlexaResponseData
			{
				OutputSpeech = plainText
			};

			alexaResponse.Response = responseData;
			return alexaResponse;

		}

		public override void HandleSessionEndedRequest(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session)
		{
			// No impl
		}

		public override AlexaResponse HandleIntentRequest(AlexaIntentRequest intentRequest, AlexaContext context, AlexaSession session)
		{

			AlexaResponse alexaResponse = new AlexaResponse();
			PlainTextOutputSpeech plainText = new PlainTextOutputSpeech
			{
				Text = "AlexaIntentRequest"
			};
			AlexaResponseData responseData = new AlexaResponseData
			{
				OutputSpeech = plainText
			};

			alexaResponse.Response = responseData;
			return alexaResponse;

		}

		public override AlexaResponse HandleCanFulfillIntentRequest(AlexaCanFulfillIntentRequest canFulfillIntentRequest, AlexaContext context, AlexaSession session)
		{

			AlexaResponse alexaResponse = new AlexaResponse();
			PlainTextOutputSpeech plainText = new PlainTextOutputSpeech
			{
				Text = "AlexaCanFulfillIntentRequest"
			};
			AlexaResponseData responseData = new AlexaResponseData
			{
				OutputSpeech = plainText
			};

			alexaResponse.Response = responseData;
			return alexaResponse;

		}

	}

}
