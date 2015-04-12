namespace Speech.Services.Speech
{
	using System.Threading.Tasks;

	public interface ISpeechService
	{
		SpeechService.SpeechState State { get; }

		/// <summary>
		/// Synthetize a text into a speech and pronounces it.
		/// </summary>
		/// <param name="message">The message to be pronounced.</param>
		Task Start(string message);

		/// <summary>
		/// Stop the current speech running.
		/// </summary>
		void Stop();
    }
}
