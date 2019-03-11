namespace Flagscript.Alexa.Handler {

	/// <summary> 	/// Interface to retrieve request handlers for Alexa request types. 	/// </summary>     public interface IAlexaRequestHandler 	{

		#region Interface Properties

		/// <summary> 		/// The handler for can fulfill intent requests. 		/// </summary> 		/// <value>The can fulfill intent request handler.</value>         ICanFulfillIntentRequestHandler CanFulfillIntentRequestHandler { get; }

		/// <summary> 		/// The handler for intent requests. 		/// </summary> 		/// <value>The intent request handler.</value>         IIntentRequestHandler IntentRequestHandler { get; }

		/// <summary> 		/// The handler for launch requests. 		/// </summary> 		/// <value>The launch request handler.</value>         ILaunchRequestHandler LaunchRequestHandler { get; }

		/// <summary> 		/// The handler for session ended requests. 		/// </summary> 		/// <value>The session ended request handler.</value>         ISessionEndedRequestHandler SessionEndedRequestHandler { get; }

		#endregion 
	}  }