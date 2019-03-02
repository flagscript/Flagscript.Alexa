using System.Runtime.Serialization;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Confirmation Values for Alexa Objects.
	/// </summary>
	public enum ConfirmationStatus
	{

		/// <summary>
		/// None
		/// </summary>
		[EnumMember(Value = "NONE")]
		None = 0,

		/// <summary>
		/// Confirmed.
		/// </summary>
		[EnumMember(Value = "CONFIRMED")]
		Confirmed = 1,

		/// <summary>
		/// Denied
		/// </summary>
		[EnumMember(Value = "DENIED")]
		Denied = 2

	}

}
