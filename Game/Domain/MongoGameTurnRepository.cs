using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Game.Domain
{
    public class MongoGameTurnRepository : IGameTurnRepository
    {
        public const string CollectionName = "gameTurns";
        private readonly IMongoCollection<GameTurnEntity> turnsCollection;
        
        public MongoGameTurnRepository(IMongoDatabase db)
        {
            turnsCollection = db.GetCollection<GameTurnEntity>(CollectionName);
            var options = new CreateIndexOptions {Unique = true};
            turnsCollection.Indexes.CreateOne(
                new CreateIndexModel<GameTurnEntity>(
                    Builders<GameTurnEntity>.IndexKeys.Ascending(x => x.TurnIndex), options));
        }
        
        public IReadOnlyList<GameTurnEntity> GetLastTurns(Guid gameId, int turnsCount)
        {
            return turnsCollection.Find(t => t.GameId == gameId)
            .SortByDescending(t => t.TurnIndex)
            .Limit(turnsCount)
            .SortBy(t => t.TurnIndex)
            .ToList();
        }

        public GameTurnEntity Insert(GameTurnEntity entity)
        {
            turnsCollection.InsertOne(entity);
            return entity;
        }
    }
}