using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flagscript.Alexa.Request
{

	public class AlexaRequestDataConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{

			JToken jObject = JToken.ReadFrom(reader);
			AlexaRequestType requestType;
			try
			{
				requestType = jObject["type"].ToObject<AlexaRequestType>();
			}
			catch (ArgumentException ae)
			{
				throw new JsonSerializationException(ae.Message);
			}

			AlexaRequestDataBase result;
			switch (requestType)
			{
				case AlexaRequestType.LaunchRequest:
					result = new AlexaLaunchRequest();
					break;
				case AlexaRequestType.SessionEndedRequest:
					result = new AlexaSessionEndedRequest();
					break;
				case AlexaRequestType.CanFulfillIntentRequest:
					result = new AlexaCanFulfillIntentRequest();
					break;
				case AlexaRequestType.IntentRequest:
					result = new AlexaIntentRequest();
					break;
				default:
					throw new ArgumentOutOfRangeException($"Request type {requestType} is not a valid Alexa request type.");
			}

			serializer.Populate(jObject.CreateReader(), result);

			return result;


		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

	}

}
