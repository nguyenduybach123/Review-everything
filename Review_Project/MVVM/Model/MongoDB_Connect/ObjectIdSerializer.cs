using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class ObjectIdSerializer : IBsonDocumentSerializer
    {
        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return BsonObjectIdSerializer.Instance.Deserialize(context);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            BsonObjectIdSerializer.Instance.Serialize(context, (ObjectId)value);
        }

        public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
        {
            throw new NotImplementedException();
        }

        public Type ValueType => typeof(ObjectId);
    }
}
