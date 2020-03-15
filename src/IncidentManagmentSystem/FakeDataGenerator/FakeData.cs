using System;
using System.Linq;
using System.Security.Cryptography;

namespace BuildingBlocks.Domain.UnitTests
{
    public static class FakeData
    {
        private readonly static Random _random = new Random();
        public static string AlphaNumeric(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static string Alpha(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static int Int(int toExclusive)
        {
            return RandomNumberGenerator.GetInt32(toExclusive);
        }
    }
}
