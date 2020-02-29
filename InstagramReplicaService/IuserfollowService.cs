using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InstagramReplicaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IuserfollowService" in both code and config file together.
    [ServiceContract]
    public interface IuserfollowService
    {
        [OperationContract]
        void followUser(int userId1,int userId2);

        [OperationContract]
        void unfollowUser(int userId1, int userId2);
    }
}
