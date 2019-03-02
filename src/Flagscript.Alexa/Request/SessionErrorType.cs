using System.Runtime.Serialization;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// The type of session error that occured.
	/// </summary>
	public enum SessionErrorType
	{

		[EnumMember(Value = "INVALID_RESPONSE")]
		InvalidResponse = 0,

		[EnumMember(Value = "DEVICE_COMMUNICATION_ERROR")]
		DeviceCommunicationError = 1,

		[EnumMember(Value = "INTERNAL_ERROR")]
		InternalError = 2

	}

}
