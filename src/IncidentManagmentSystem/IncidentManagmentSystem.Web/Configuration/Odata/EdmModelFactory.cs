using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace IncidentManagmentSystem.Web.Configuration.Odata
{
    public static class EdmModelFactory
    {
        public static IEdmModel Create()
        {
            var odataBuilder = new ODataConventionModelBuilder();
          //  odataBuilder.EntitySet<DraftApplicationDto>("DraftApplication");

            return odataBuilder.GetEdmModel();
        }
    }
}
