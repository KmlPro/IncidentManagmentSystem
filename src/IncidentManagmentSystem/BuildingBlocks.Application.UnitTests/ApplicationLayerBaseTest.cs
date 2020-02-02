using BuildingBlocks.Application.Abstract;
using NUnit.Framework;

namespace BuildingBlocks.Application.UnitTests
{
    public class ApplicationLayerBaseTest
    {
        public static void AssertApplicationLayerException<TApplicationLayerException>(TestDelegate testDelegate) where TApplicationLayerException : ApplicationLayerException
        {
            var message = $"Expected {typeof(TApplicationLayerException).Name} exception";
            var applicationLayerException = Assert.Throws<TApplicationLayerException>(testDelegate, message);
            Assert.AreNotEqual(applicationLayerException, null, message);
        }
    }
}
