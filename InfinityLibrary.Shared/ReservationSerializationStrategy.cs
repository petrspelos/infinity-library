using System.Collections.Generic;
using SimpleJson;

namespace InfinityLibrary.Shared
{
    public class ReservationSerializationStrategy : PocoJsonSerializerStrategy
    {
        private readonly Dictionary<string, string> _memberNameOverrides = new Dictionary<string, string>
        {
            { "Id", "id" },
            { "UserId", "userId" },
            { "BookId", "bookId" },
            { "Date", "date" }
        };

        protected override string MapClrMemberNameToJsonFieldName(string jsonFieldName)
        {
            return _memberNameOverrides.ContainsKey(jsonFieldName) ? _memberNameOverrides[jsonFieldName] : jsonFieldName;
        }
    }
}