using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFContactBook
{
    [ServiceContract]
    public interface IContactBook
    {
        [OperationContract]
        List<Contact> GetAllContacts();

        [OperationContract]
        List<Group> GetAllGroups();

        [OperationContract]
        List<Contact> GetContactsByGroup(string groupName);

        [OperationContract]
        void CreateGroup(Group group);

        [OperationContract]
        void CreateContact(Contact contact);

        [OperationContract]
        void UpdateContact(Contact contact);

        [OperationContract]
        void DeleteContact(int contactID);

        [OperationContract]
        void DeleteGroup(int groupID);
    }
}
