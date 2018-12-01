using SimpleJson;
using System.Collections.Generic;

namespace InfinityLibrary.Shared
{
    public class UserSerializationStrategy : PocoJsonSerializerStrategy
    {
        private readonly Dictionary<string, string> _memberNameOverrides = new Dictionary<string, string>
        {
            { "Id", "id" },
            { "FirstName", "firstName" },
            { "LastName", "lastName" },
            { "Address", "address" },
            { "Email", "email" },
            { "DateOfBirth", "dateOfBirth" },
            { "MembershipValidTill", "membershipValidTill" }
        };

        protected override string MapClrMemberNameToJsonFieldName(string jsonFieldName)
        {
            return _memberNameOverrides.ContainsKey(jsonFieldName) ? _memberNameOverrides[jsonFieldName] : jsonFieldName;
        }
    }
}