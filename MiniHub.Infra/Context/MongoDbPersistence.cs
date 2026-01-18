using MiniHub.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

public static class MongoDbPersistence
{
    private static bool _isConfigured = false;

    public static void Configure()
    {
        // Garante que rode apenas uma vez
        if (_isConfigured) return;
        _isConfigured = true;

        // Configura o serializador padrão de Guid globalmente para BsonType.String
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

        BsonClassMap.RegisterClassMap<LogModel>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id);
            cm.SetIgnoreExtraElements(true);
        });
    }
}