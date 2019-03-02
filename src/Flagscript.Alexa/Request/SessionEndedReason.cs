using System.Runtime.Serialization;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Reasons describing why a session ended.
	/// </summary>
	public enum SessionEndedReason
	{

		/// <summary>
		/// The user explicitly ended the session.
		/// </summary>
		[EnumMember(Value = "USER_INITIATED")]
		UserInitiated = 0,

		/// <summary>
		/// An error occurred that caused the session to end.
		/// </summary>
		[EnumMember(Value = "ERROR")]
		Error = 1,

		/// <summary>
		/// The user either did not respond or responded with an utterance that 
		/// did not match any of the intents defined in your voice interface.
		/// </summary>
		[EnumMember(Value = "EXCEEDED_MAX_REPROMPTS")]
		ExceededMaxReprompts = 2

	}

}
