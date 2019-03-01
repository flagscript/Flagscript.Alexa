using System;

using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

    /// <summary>
    /// Base Request from Alexa.
    /// </summary>
    /// <remarks>
    /// Request documentation can be found at
    /// https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html.
    /// This is coded as of date 3.1.19.
    /// </remarks>
    public class AlexaRequest
    {

		#region Properties 

		/// <summary>
		/// The version specifier for the Alexa Request.
		/// </summary>
		/// <value>Request version specifier.</value>
		[JsonProperty("version")]
        public string Version 
        {
            get
			{
				return "1.0";
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value) || value != "1.0")
				{
					throw new ArgumentOutOfRangeException(
						"Value", 
						"Flagscript.Alexa only supports Alexa requests with version 1.0."
					);
				}
			}
        }

		#endregion

	}

}