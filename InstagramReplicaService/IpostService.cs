using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InstagramReplicaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IpostService" in both code and config file together.
    [ServiceContract]
    public interface IpostService
    {
        [OperationContract]
        void createPost(Post post);

        [OperationContract]
        void deletePost(int postid);

        [OperationContract]
        void updatePost(Post post);

        [OperationContract]
        List<Post> fetchPost(int userid);

        [OperationContract]
        int? incrementLike(int likes, int postid);

        [OperationContract]
        int? decrementLike(int likes, int postid);
    }
}
