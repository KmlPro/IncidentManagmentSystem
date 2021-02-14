using System.Net.Http;

namespace IncidentManagementSystem.ApiBehavioursTests.TestUtils
{
    public static class IsResponseContentNotEmpty
    {
        public static bool Check(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return !string.IsNullOrEmpty(content) && content != "[]";
        }
    }
}
