using System;
using Flagscript.Alexa.Request;

namespace Flagscript.Alexa.Handler
{

	/// <summary>
	/// Interface to handle an Alexa session ended requests.
	/// </summary>
	public interface ISessionEndedRequestHandler
	{

		/// <summary>
		/// Handles the session ended request.
		/// </summary>
		/// <param name="sessionEndedRequest">The Alexa session ended request.</param>
		/// <param name="context">The Alexa context.</param>
		/// <param name="session">The Alexa session.</param>
		void HandleRequest(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session);

	}

}
