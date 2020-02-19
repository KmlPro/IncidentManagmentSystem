using System.Linq;
using Moq;

namespace IncidentManagmentSystem.Web.Tests.Mocks.JsonMoq
{
    internal static class MockExtensions
    {
        public static Mock<T> RegisterForJsonSerialization<T>(this Mock<T> mock) where T : class
        {
            JsonMockConverter.RegisterMock(
                mock,
                () => typeof(T).GetProperties().ToDictionary(p => p.Name, p => p.GetValue(mock.Object))
            );
            return mock;
        }
    }
}
