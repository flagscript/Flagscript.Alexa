using System;

using Amazon.Lambda.Core;
using Flagscript.Alexa.Request;
using Flagscript.Alexa.Response;

namespace Flagscript.Alexa.Lambda
{

	public abstract class AlexaSkillRequestHandlerLambda
	{

		#region Constructors

		public AlexaSkillRequestHandlerLambda()
		{

		}

		#endregion

		#region Core Handler

		public AlexaResponse HandleAlexaSkillRequest(AlexaRequest alexaRequest, ILambdaContext lambdaContext)
		{
			ILambdaLogger logger = lambdaContext?.Logger;

			AlexaResponse response;

			switch (alexaRequest.RequestData.RequestType)
			{
				// Handle Launch request.
				case AlexaRequestType.LaunchRequest:
					AlexaLaunchRequest launchRequest = alexaRequest.RequestData as AlexaLaunchRequest;
					response = HandleLaunchRequest(launchRequest, alexaRequest.Context, alexaRequest.Session);
					break;
				// Can not send response to session ended request.
				case AlexaRequestType.SessionEndedRequest:					
					AlexaSessionEndedRequest sessionEndedRequest = alexaRequest.RequestData as AlexaSessionEndedRequest;
					HandleSessionEndedRequest(sessionEndedRequest, alexaRequest.Context, alexaRequest.Session);
					return null;
				case AlexaRequestType.IntentRequest:
					AlexaIntentRequest intentRequest = alexaRequest.RequestData as AlexaIntentRequest;
					response = HandleIntentRequest(intentRequest, alexaRequest.Context, alexaRequest.Session);
					break;
				case AlexaRequestType.CanFulfillIntentRequest:
					AlexaCanFulfillIntentRequest canFulfillIntentRequest = alexaRequest.RequestData as AlexaCanFulfillIntentRequest;
					response = HandleCanFulfillIntentRequest(canFulfillIntentRequest, alexaRequest.Context, alexaRequest.Session);
					break;

				default:
					logger?.LogLine($"Recieved not implemented request type: {alexaRequest.RequestData.RequestType}");
					throw new NotImplementedException($"{alexaRequest.RequestData.RequestType} is not yet implemented.");

			}


			return response;
		}

		#endregion

		#region Request Type Handlers

		public virtual AlexaResponse HandleLaunchRequest(AlexaLaunchRequest launchRequest, AlexaContext context, AlexaSession session)
		{
			throw new NotImplementedException("HandleLaunchRequest not yet implemented.");
		}

		public virtual void HandleSessionEndedRequest(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session)
		{
			throw new NotImplementedException("HandleSessionEndedRequest not yet implemented.");
		}

		public virtual AlexaResponse HandleIntentRequest(AlexaIntentRequest intentRequest, AlexaContext context, AlexaSession session)
		{
			throw new NotImplementedException("HandleIntentRequest not yet implemented.");
		}

		public virtual AlexaResponse HandleCanFulfillIntentRequest(AlexaCanFulfillIntentRequest canFulfillIntentRequest, AlexaContext context, AlexaSession session)
		{
			throw new NotImplementedException("HandleCanFulfillIntentRequest not yet implemented.");
		}

		#endregion

	}

}
