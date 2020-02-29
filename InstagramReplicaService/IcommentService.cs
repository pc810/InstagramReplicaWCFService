using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InstagramReplicaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IcommentService" in both code and config file together.
    [ServiceContract]
    public interface IcommentService
    {
        [OperationContract]
        void createComment(Comment comment);

        [OperationContract]
        void deleteComment(int commentId);

        [OperationContract]
        void updateComment(Comment comment);

        [OperationContract]
        List<Comment> fetchComment(int postId);
    }
}
