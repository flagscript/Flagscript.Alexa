using System;

using Microsoft.Extensions.Logging;

namespace Flagscript.Alexa.Handler
{
	public abstract class BaseAlexaRequestHandler : IAlexaRequestHandler
	{

		#region Fields

		/// <summary>
		/// Logger to be used in default lower level implementations.
		/// </summary>
		/// <value>The logger to use in default implementations.</value>
		protected ILogger Logger { get; }

		/// <summary>
		/// The handler for can fulfill intent requests.
		/// </summary>
		/// <value>The can fulfill intent request handler.</value>
		public abstract ICanFulfillIntentRequestHandler CanFulfillIntentRequestHandler { get; }

		/// <summary>
		/// The handler for intent requests.
		/// </summary>
		/// <value>The intent request handler.</value>
		public abstract IIntentRequestHandler IntentRequestHandler { get; }

		/// <summary>
		/// The handler for launch requests.
		/// </summary>
		/// <value>The launch request handler.</value>
		public abstract ILaunchRequestHandler LaunchRequestHandler { get; }

		/// <summary>
		/// The handler for session ended requests.
		/// </summary>
		/// <value>The session ended request handler.</value>
		public abstract ISessionEndedRequestHandler SessionEndedRequestHandler { get; }

		#endregion


		#region Constructor

		protected BaseAlexaRequestHandler(ILogger logger)
		{

			Logger = logger ?? throw new ArgumentNullException(nameof(logger));

		}

		#endregion

	}

}
