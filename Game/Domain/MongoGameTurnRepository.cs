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
            turnsCollection.Indexes.CreateOne(
                new CreateIndexModel<GameTurnEntity>(
                    Builders<GameTurnEntity>.IndexKeys
                        .Ascending(t => t.GameId)
                        .Ascending(x => x.TurnIndex)));
        }

        public IReadOnlyList<GameTurnEntity> GetLastTurns(Guid gameId, int turnsCount)
        {
            var turns = turnsCollection.Find(t => t.GameId == gameId)
                .SortByDescending(t => t.TurnIndex)
                .Limit(turnsCount)
                .ToList();
            turns.Reverse();
            return turns;
        }

        public GameTurnEntity Insert(GameTurnEntity entity)
        {
            turnsCollection.InsertOne(entity);
            return entity;
        }
    }
}