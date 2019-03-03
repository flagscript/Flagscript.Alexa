using Xunit;

namespace Flagscript.Alexa.Response.Test
{

	/// <summary>
	/// Unit tests for <see cref="PlainTextOutputSpeech"/>.
	/// </summary>
	public class PlainTextOutputSpeechTest
	{

		#region Test Methods

		/// <summary>
		/// Unit Test for <see cref="PlainTextOutputSpeech.Type"/>.
		/// </summary>
		[Fact]
		public void TestTypeProperty()
		{
			PlainTextOutputSpeech plainText = new PlainTextOutputSpeech();
			Assert.Equal("PlainText", plainText.Type);
		}

		#endregion

	}

}
