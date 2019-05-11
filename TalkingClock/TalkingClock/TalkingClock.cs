using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace TalkingClock
{
    public class TalkingClock
    {
        public TalkingClock()
        {
        }

        public string ParseTime(string timeString)
        {
            var mc = Regex.Matches(timeString, @"^(?:\d|[01]\d|2[0-3]):[0-5]\d$");
            if (mc.Count != 1)
            {
                throw new Exception("Bad time format exception");
            }

            var inputHours = timeString.Substring(0, 2);
            var inputTens = timeString.Substring(3, 1);
            var inputOnes = timeString.Substring(4, 1);

            var hoursWord = ParseHour(inputHours);
            var minutesWord = string.Empty;
            if (!$"{inputTens}{inputOnes}".Equals("00"))
            {
                var tensText = TensToWord(inputTens);
                var onesText = OnesToWord(inputOnes);
                minutesWord = inputOnes.Equals("0") ? $" {tensText}" : $" {tensText} {onesText}";
            }

            var amPmText = ParseAmPm(inputHours);

            var result = $"It's {hoursWord}{minutesWord} {amPmText}";
            return result;
        }

        private static string ParseAmPm(string hourString)
        {
            return int.Parse(hourString) < 12 ? "am" : "pm";
        }

        private static string ParseHour(string hourString)
        {
            string hourText;
            switch (hourString)
            {
                case "00":
                case "12":
                {
                    hourText = "twelve";
                }
                    break;

                case "01":
                case "13":
                {
                    hourText = "one";
                }
                    break;
                case "02":
                case "14":
                {
                    hourText = "two";
                }
                    break;
                case "03":
                case "15":
                {
                    hourText = "three";
                }
                    break;
                case "04":
                case "16":
                {
                    hourText = "four";
                }
                    break;
                case "05":
                case "17":
                {
                    hourText = "five";
                }
                    break;
                case "06":
                case "18":
                {
                    hourText = "six";
                }
                    break;
                case "07":
                case "19":
                {
                    hourText = "seven";
                }
                    break;
                case "08":
                case "20":
                {
                    hourText = "eight";
                }
                    break;
                case "09":
                case "21":
                {
                    hourText = "nine";
                }
                    break;
                case "10":
                case "22":
                {
                    hourText = "ten";
                }
                    break;
                case "11":
                case "23":
                {
                    hourText = "eleven";
                }
                    break;
                default:
                {
                    throw new Exception("Unknown hour format");
                }
            }

            return hourText;
        }


        private static string OnesToWord(string value)
        {
            var words = new List<string>()
                {"oh", "one", "two", "three", "four", "five", "six", "sever", "eight", "nine"};
            return words[int.Parse(value)];
        }

        private static string TensToWord(string value)
        {
            var words = new List<string>() {"oh", "ten", "twenty", "thirty", "forty", "fifty"};
            return words[int.Parse(value)];
        }
    }
}