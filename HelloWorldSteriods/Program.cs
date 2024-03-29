﻿using System;
using System.Net;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWorldSteriods
{
    class Program
    {
        private const string Address = "https://api.chucknorris.io/jokes/random";

        static void Main(string[] args)
        {
            var joke = GetJoke();
            Console.WriteLine(joke.Value);
            Speak(joke.Value);
            Console.WriteLine("Press any key for the next joke");
            Console.ReadLine();

            var asyncJoke = GetJokeAsync().Result;
            Console.WriteLine(asyncJoke.Value);
            Speak(asyncJoke.Value);
            Console.ReadLine();
        }

        private static Joke GetJoke()
        {
            var client = new WebClient();
            var str = client.DownloadString(Address);
            return JsonConvert.DeserializeObject<Joke>(str);
        }

        private static async Task<Joke> GetJokeAsync()
        {
            var client = new WebClient();
            var str = await client.DownloadStringTaskAsync(Address);
            return JsonConvert.DeserializeObject<Joke>(str);
        }

        private static void Speak(string textToSpeak)
        {
            var syn = new SpeechSynthesizer();
            syn.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            syn.Speak(textToSpeak);
        }
    }
}
