using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// What the user meant based on a predefined event schema.
	/// </summary>
	[JsonObject]
	public class AlexaSlot
	{

		#region Properties

		/// <summary>
		/// The name of the slot.
		/// </summary>
		/// <value>The name of the slot.</value>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The value the user spoke for the slot.
		/// </summary>
		/// <value>The value the user spoke for the slot.</value>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// Whether the user has explicitly confirmed or denied the value of this slot. 
		/// </summary>
		/// <value>The confirmation status.</value>
		[JsonProperty("confirmationStatus")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ConfirmationStatus ConfirmationStatus { get; set; }

		#endregion

	}

}
