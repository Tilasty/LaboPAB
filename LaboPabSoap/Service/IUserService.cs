using LaboPabSoap.Entities;
using System.ServiceModel;

namespace LaboPabSoap.Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string RegisterUser(User user);
    }
}