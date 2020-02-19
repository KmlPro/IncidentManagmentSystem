using System;
using System.Collections.Generic;
using Moq;
using Newtonsoft.Json;

namespace IncidentManagmentSystem.Web.Tests.Mocks.JsonMoq
{
    //ref https://stackoverflow.com/questions/55966212/how-to-mock-with-moq-an-interface-that-is-serialized-by-newtonsoft-json
    public class JsonMockConverter : JsonConverter
    {
        private static readonly Dictionary<object, Func<object>> mockSerializers = new Dictionary<object, Func<object>>();
        private static readonly HashSet<Type> mockTypes = new HashSet<Type>();

        public static void RegisterMock<T>(Mock<T> mock, Func<object> serializer) where T : class
        {
            mockSerializers[mock.Object] = serializer;
            mockTypes.Add(mock.Object.GetType());
        }

        public override bool CanConvert(Type objectType)
        {
            return mockTypes.Contains(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!mockSerializers.TryGetValue(value, out var mockSerializer))
            {
                throw new InvalidOperationException("Attempt to serialize unregistered mock.");
            }
            serializer.Serialize(writer, mockSerializer());
        }
    }
}
