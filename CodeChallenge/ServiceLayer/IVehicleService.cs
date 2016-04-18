using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CodeChallenge
{
    /// <summary>
    /// Serice Contract Interface, RESTful API 
    /// NOTE:
    /// 1. Endpoint Address is "vehicles"
    /// 2. To get by vehicle properties, you need strictly enforce the UriTemplate even if some parameter is empty
    /// </summary>
    [ServiceContract]
    public interface IVehicleService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/")]
        List<Vehicle> GetVehicleList();

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/{id}")]
        Vehicle GetVehicleById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/?make={make}&model={model}&year={year}")]
        List<Vehicle> GetVehicleListBy(string make, string model, string year);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/")]
        Vehicle AddNewVehicle(Vehicle vehicle);

        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/")]
        void UpdateVehicle(Vehicle vehicle);

        [OperationContract]
        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/{id}")]
        void DeleteVehicle(string id);
    }


}
