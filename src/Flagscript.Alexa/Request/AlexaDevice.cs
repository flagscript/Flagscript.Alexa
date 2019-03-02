using System.Collections.Generic;

using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Information about the device used to send the request.
	/// </summary>
	[JsonObject]
	public class AlexaDevice
	{

		#region Properties

		/// <summary>
		/// Unique identifier for the device.
		/// </summary>
		/// <value>Unique identifier for the device.</value>
		[JsonProperty("deviceId")]
		public string DeviceId { get; set; }

		/// <summary>
		/// Every interface the device supports.
		/// </summary>
		/// <value>Every interface the device supports.</value>
		[JsonProperty("supportedInterfaces")]
		public Dictionary<string, object> SupportedInterfaces { get; set; }

		#endregion

	}

}
