using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InstagramReplicaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void CreateUser(User user);

        [OperationContract]
        User getUser(int userId);

        [OperationContract]
        User getUserByEmail(string email);

        [OperationContract]
        int getUserId(string email);

        [OperationContract]
        void DeleteUser(int userId);

        [OperationContract]
        void UpdateUser(User user);

        [OperationContract]
        List<User> getUserWith(string username);

    }
}
