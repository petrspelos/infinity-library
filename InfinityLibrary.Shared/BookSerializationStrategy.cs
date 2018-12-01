using System.Collections.Generic;
using SimpleJson;

namespace InfinityLibrary.Shared
{
    public class BookSerializationStrategy : PocoJsonSerializerStrategy
    {
        private readonly Dictionary<string, string> _memberNameOverrides = new Dictionary<string, string>
        {
            { "Id", "id" },
            { "Title", "title" },
            { "Genre", "genre" },
            { "Author", "author" },
            { "PublicationYear", "publicationYear" },
            { "Copies", "copies" },
            { "ThumbnailUrl", "thumbnailUrl" }
        };

        protected override string MapClrMemberNameToJsonFieldName(string jsonFieldName)
        {
            return _memberNameOverrides.ContainsKey(jsonFieldName) ? _memberNameOverrides[jsonFieldName] : jsonFieldName;
        }
    }
}