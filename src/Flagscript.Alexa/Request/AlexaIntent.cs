using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// What the user wants.
	/// </summary>
	[JsonObject]
	public class AlexaIntent
	{

		#region Properties

		/// <summary>
		/// The name of the intent.
		/// </summary>
		/// <value>The name of the intent.</value>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Whether the user has explicitly confirmed or denied the entire intent.
		/// </summary>
		/// <value>The confirmation status.</value>
		[JsonProperty("confirmationStatus")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ConfirmationStatus ConfirmationStatus { get; set; }

		/// <summary>
		/// A map of key-value pairs that further describes what the user meant 
		/// based on a predefined intent schema.
		/// </summary>
		/// <value>The slots defining what the user meant.</value>
		[JsonProperty("slots")]
		public Dictionary<string, AlexaSlot> Slots { get; set; }

		#endregion

	}

}
