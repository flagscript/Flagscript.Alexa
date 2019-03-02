using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// Alexa session context.
	/// </summary>
	public class AlexaSession
	{

		#region Const/Static 

		/// <summary>
		/// Session Idenitifier prefix for Alexa sessions.
		/// </summary>
		private const string AlexaSessionPrefix = "amzn1.echo-api.session.";

		#endregion

		#region Fields

		/// <summary>
		/// Backing field for <see cref="SessionId"/>.
		/// </summary>
		private string _sessionId;

		#endregion

		#region Properties

		/// <summary>
		/// Whether or not this is a new session.
		/// </summary>
		/// <value>Whether or not this is a new session.</value>
		[JsonProperty("new")]
		public bool NewSession { get; set; }

		/// <summary>
		/// Unique session identifier per users active session.
		/// </summary>
		/// <value>Unique session identifier.</value>
		[JsonProperty("sesisonId")]
		public string SessionId
		{
			get
			{
				return _sessionId;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("AlexaSessionPrefix"))
				{
					throw new ArgumentOutOfRangeException(
						"SessionId",
						"Invalid session prefix."
					);
				}
				_sessionId = value;
			}
		}

		/// <summary>
		/// Object indicating the alexa application for the intended skill. 
		/// </summary>
		/// <value>Alexa Application</value>
		[JsonProperty("application")]
		public AlexaApplication Application { get; set; }

		/// <summary>
		/// Key/Value Pair attributes used to maintain session state.
		/// </summary>
		[JsonProperty("attributes")]
		public Dictionary<string, string> Attributes { get;set;}

		#endregion

	}

}
