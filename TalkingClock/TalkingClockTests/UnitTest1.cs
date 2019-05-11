using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace TalkingClockTests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            var testTimes = new Dictionary<string, string>
            {
                {"00:00", "It's twelve am"},
                {"01:30", "It's one thirty am"},
                {"12:05", "It's twelve oh five pm"},
                {"14:01", "It's two oh one pm"},
                {"20:29", "It's eight twenty nine pm"},
                {"21:00", "It's nine pm"}
            };

            foreach (var (key, value) in testTimes)
            {
                _testOutputHelper.WriteLine($"Expected:\t{value}");
                var result = new TalkingClock.TalkingClock().ParseTime(key);
                _testOutputHelper.WriteLine($"Actual:\t\t{result}");


                Assert.Equal(value,result);
            }
        }
    }
}