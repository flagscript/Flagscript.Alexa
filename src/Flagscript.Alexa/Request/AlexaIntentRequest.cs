using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// A request made to a skill based on what the user wants to do.
	/// </summary>
	[JsonObject]
	public class AlexaIntentRequest : AlexaRequestDataBase
	{

		#region Additional Request Properties

		/// <summary>
		/// The status of the multi-turn dialog.
		/// </summary>
		/// <value>The state of the dialog.</value>
		[JsonProperty("dialogState")]
		[JsonConverter(typeof(StringEnumConverter))]
		public DialogState DialogState { get; set; }

		/// <summary>
		/// What the user wants.
		/// </summary>
		/// <value>Intent the user wants.</value>
		[JsonProperty("intent")]
		public AlexaIntent Intent { get; set; }

		#endregion

	}

}
