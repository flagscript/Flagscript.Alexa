using System.Runtime.Serialization;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Status of a multi turn dialog.
	/// </summary>
	public enum DialogState
	{

		/// <summary>
		/// User invoked the intent that has a dialog.
		/// </summary>
		[EnumMember(Value = "STARTED")]
		Started = 0,

		/// <summary>
		/// Dialog is in progress.
		/// </summary>
		[EnumMember(Value = "IN_PROGRESS")]
		InProgress = 1,

		/// <summary>
		/// Dialog is complete. 
		/// </summary>
		[EnumMember(Value = "COMPLETED")]
		Completed = 2

	}

}
