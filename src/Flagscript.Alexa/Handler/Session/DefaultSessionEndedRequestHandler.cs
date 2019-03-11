using System;

using Microsoft.Extensions.Logging;

using Flagscript.Alexa.Request;

namespace Flagscript.Alexa.Handler.Session
{

	/// <summary>
	/// Out of the box Flagscript.Alexa session request handler. 
	/// </summary>
	public class DefaultSessionEndedRequestHandler : BaseSessionEndedRequestHandler
	{

		#region Constructors

		public DefaultSessionEndedRequestHandler(ILogger logger) : base(logger)
		{
		}

		#endregion

		#region Abstract Implementations

		protected override void OnError(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session)
		{
			RemovePersistantSession(context, session);
			throw new NotImplementedException();
		}

		protected override void OnMaxRepromts(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session)
		{
			RemovePersistantSession(context, session);
			throw new NotImplementedException();
		}

		protected override void OnUserInitiated(AlexaSessionEndedRequest sessionEndedRequest, AlexaContext context, AlexaSession session)
		{
			RemovePersistantSession(context, session);
			throw new NotImplementedException();
		}

		#endregion

		#region Virtual Methods

		protected virtual void RemovePersistantSession(AlexaContext context, AlexaSession session)
		{

		}

		#endregion

	}

}
