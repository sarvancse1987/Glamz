using Glamz.Domain.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Glamz.Domain
{
    public abstract class ParentEntity
    {
        protected ParentEntity()
        {
            _id = UniqueIdentifier.New;
        }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _id = UniqueIdentifier.New;
                else
                    _id = value;
            }
        }

        private string _id;

    }
}
