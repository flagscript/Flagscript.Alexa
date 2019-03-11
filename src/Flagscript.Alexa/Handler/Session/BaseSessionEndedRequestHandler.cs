using System;

using Microsoft.Extensions.Logging;

using Flagscript.Alexa.Request;

namespace Flagscript.Alexa.Handler.Session
{

	/// <summary>
	/// Base class for Session Ended Request Handlers that use common Flagscript.Alexa
	/// resources.
	/// </summary>
	public abstract class BaseSessionEndedRequestHandler : ISessionEndedRequestHandler
	{

		#region Properties

		protected ILogger Logger { get; }

		#endregion

		#region Constructors

		protected BaseSessionEndedRequestHandler(ILogger logger)
		{
			Logger = logger;
		}

		#endregion

		#region ISessionEndedRequestHandler Implementation

		/// <summary>
		/// Handles the session ended request.
		/// </summary>
		/// <param name="sessionEndedRequest">The Alexa session ended request.</param>
		/// <param name="context">The Alexa context.</param>
		/// <param name="session">The Alexa session.</param>
		public void HandleRequest(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session)
		{

			switch (sessionEndedRequest.Reason)
			{
				case SessionEndedReason.UserInitiated:
					OnUserInitiated(sessionEndedRequest, context, session);
					break;
				case SessionEndedReason.Error:
					OnError(sessionEndedRequest, context, session);
					break;
				case SessionEndedReason.ExceededMaxReprompts:
					OnMaxRepromts(sessionEndedRequest, context, session);
					break;
				default:
					break;
			}

		}

		#endregion

		#region Abstract Methods

		/// <summary>
		/// Handle session ended request initiated by the end user.
		/// </summary>
		/// <param name="sessionEndedRequest">The Alexa session ended request.</param>
		/// <param name="context">The Alexa context.</param>
		/// <param name="session">The Alexa session.</param>
		protected abstract void OnUserInitiated(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session);

		/// <summary>
		/// Handle session ended request where an error has occured.
		/// </summary>
		/// <param name="sessionEndedRequest">The Alexa session ended request.</param>
		/// <param name="context">The Alexa context.</param>
		/// <param name="session">The Alexa session.</param>
		protected abstract void OnError(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session);

		/// <summary>
		/// Handle session ended request where the max reprompts occured.
		/// </summary>
		/// <param name="sessionEndedRequest">The Alexa session ended request.</param>
		/// <param name="context">The Alexa context.</param>
		/// <param name="session">The Alexa session.</param>
		protected abstract void OnMaxRepromts(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session);

		#endregion

	}

}
