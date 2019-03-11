using System;
using Microsoft.Extensions.Logging;

using Flagscript.Alexa.Handler.Session;

namespace Flagscript.Alexa.Handler
{

	public class DefaultAlexaRequestHandler : BaseAlexaRequestHandler
	{

		#region Fields 

		/// <summary>
		/// Backing field for <see cref="CanFulfillIntentRequestHandler"/>.
		/// </summary>
		private ICanFulfillIntentRequestHandler _canFulfillIntentRequestHandler;

		/// <summary>
		/// Backing field for <see cref="IntentRequestHandler"/>.
		/// </summary>
		private IIntentRequestHandler _intentRequestHandler;

		/// <summary>
		/// Backing field for <see cref="LaunchRequestHandler"/>.
		/// </summary>
		private ILaunchRequestHandler _launchRequestHandler;

		/// <summary>
		/// Backing field for <see cref="SessionEndedRequestHandler"/>.
		/// </summary>
		private ISessionEndedRequestHandler _sessionEndedRequestHandler;

		#endregion

		#region Constructors

		public DefaultAlexaRequestHandler(
			ILogger logger,
			ICanFulfillIntentRequestHandler canFulfillIntentRequestHandler,
			IIntentRequestHandler intentRequestHandler,
			ILaunchRequestHandler launchRequestHandler,
			ISessionEndedRequestHandler sessionEndedRequestHandler
		) : base(logger)
		{
			_canFulfillIntentRequestHandler = canFulfillIntentRequestHandler;
			_intentRequestHandler = intentRequestHandler;
			_launchRequestHandler = launchRequestHandler;
			_sessionEndedRequestHandler = sessionEndedRequestHandler;

		}

		#endregion

		#region Interface Implementations

		/// <summary>
		/// The handler for can fulfill intent requests.
		/// </summary>
		/// <value>The can fulfill intent request handler.</value>
		public override ICanFulfillIntentRequestHandler CanFulfillIntentRequestHandler => throw new NotImplementedException();

		/// <summary>
		/// The handler for intent requests.
		/// </summary>
		/// <value>The intent request handler.</value>
		public override IIntentRequestHandler IntentRequestHandler => throw new NotImplementedException();

		/// <summary>
		/// The handler for launch requests.
		/// </summary>
		/// <value>The launch request handler.</value>
		public override ILaunchRequestHandler LaunchRequestHandler => throw new NotImplementedException();

		/// <summary>
		/// The handler for session ended requests.
		/// </summary>
		/// <value>The session ended request handler.</value>
		public override ISessionEndedRequestHandler SessionEndedRequestHandler =>
			_sessionEndedRequestHandler ?? 
			(_sessionEndedRequestHandler = new DefaultSessionEndedRequestHandler(Logger));


		#endregion


	}

}
