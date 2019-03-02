namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// The types of Alexa Requests.
	/// </summary>
	public enum AlexaRequestType
	{

		/// <summary>
		/// A launch request. Maps to <see cref="AlexaLaunchRequest"/>.
		/// </summary>
		LaunchRequest = 0,

		/// <summary>
		/// An intent request. Maps to <see cref="AlexaIntentRequest"/>.
		/// </summary>
		IntentRequest = 1,

		/// <summary>
		/// A session ended request. Maps to <see cref="AlexaSessionEndedRequest"/>.
		/// </summary>
		SessionEndedRequest = 2,

		/// <summary>
		/// A can fulfill intent request. 
		/// </summary>
		CanFulfillIntentRequest = 3

	}

}
