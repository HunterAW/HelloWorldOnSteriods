using System;
using System.IO;
using System.Net;
using System.Speech.Synthesis;
using Newtonsoft;
using Newtonsoft.Json;

namespace HelloWorldSteriods
{
    class Program
    {
        static void Main(string[] args)
        {
            var joke =GetJoke();
            Speak(joke.Value);
        }

        private static Joke GetJoke()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var jokeStr = stream.ReadToEnd();
                return JsonConvert.DeserializeObject<Joke>(jokeStr);
            }
        }

        private static void Speak(string textToSpeak)
        {
            var syn = new SpeechSynthesizer();
            syn.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            syn.Speak(textToSpeak);
            Console.ReadLine();
        }
    }
}
