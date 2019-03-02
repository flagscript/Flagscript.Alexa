using System;

using Newtonsoft.Json;

namespace Flagscript.Alexa.Request
{

	/// <summary>
	/// The Alexa user making the request.
	/// </summary>
	[JsonObject]
	public class AlexaUser
	{

		#region Const/Static

		private const string AlexaUserPrefix = "amzn1.ask.account.";

		#endregion

		#region Fields

		/// <summary>
		/// Backing field for <see cref="UserId"/>.
		/// </summary>
		private string _userId;

		#endregion

		#region Properties

		/// <summary>
		/// Identifier for the user making the request.
		/// </summary>
		/// <value>Unique user identifier.</value>
		[JsonProperty("userId")]
		public string UserId
		{
			get => _userId;
			set
			{
				if (string.IsNullOrWhiteSpace(value) || !value.StartsWith(AlexaUserPrefix, StringComparison.Ordinal))
				{
					throw new ArgumentException($"Invalid user prefix => {value}.");
				}
				_userId = value;
			}
		}

		/// <summary>
		/// A token identifying the user in another system.
		/// </summary>
		/// <value>Token identifying the user in another system.</value>
		[JsonProperty("accessToken")]
		public string AccessToken { get; set; }

		/// <summary>
		/// Permissions the user has consented to provide.
		/// </summary>
		/// <value>User consented permissions.</value>
		[JsonProperty("permissions")]
		public AlexaPermissions Permissions { get; set; }

		#endregion

	}

}
