using System;
using System.Collections.Generic;
using System.Threading;
using NAudio.Wave;

//https://www.reddit.com/r/dailyprogrammer/comments/6jr76h/20170627_challenge_321_easy_talking_clock/
namespace TalkingClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

          
            
            Console.WriteLine(new TalkingClock().ParseTime("00:00"));
            Console.WriteLine(new TalkingClock().ParseTime("20:29"));

            using (var audioFile = new AudioFileReader(@"C:\work\DailyChallenge\321\easy\soundFiles\BigBen\00.wav"))
            using(var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }

        }
    }
}