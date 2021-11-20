using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Game.Domain
{
    public class GameTurnEntity
    {
        public Guid Id { get; set; }
        [BsonElement]
        public Guid GameId { get; }
        
        [BsonElement]
        public Guid WinnerId { get; }

        [BsonElement]
        public int TurnIndex { get; }
        
        [BsonElement]
        public Dictionary<string, PlayerDecision> playerDecisions { get; }

        //TODO: Придумать какие свойства должны быть в этом классе, чтобы сохранять всю информацию о закончившемся туре.
        public GameTurnEntity(Guid gameId, int turnIndex, Dictionary<string, PlayerDecision> playerDecisions, Guid winnerId)
            : this(Guid.Empty, gameId, turnIndex, playerDecisions, winnerId)
        {

        }
        
        [BsonConstructor]
        public GameTurnEntity(Guid id, Guid gameId, int turnIndex, Dictionary<string, PlayerDecision> playerDecisions, Guid winnerId)
        {
            Id = id;
            GameId = gameId;
            TurnIndex = turnIndex;
            this.playerDecisions = playerDecisions;
            WinnerId = winnerId;
        }
    }
}