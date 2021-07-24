using MongoDB.Bson;

namespace Glamz.Domain.Data
{
    public static class UniqueIdentifier
    {
        public static string New => ObjectId.GenerateNewId().ToString();
    }
}
