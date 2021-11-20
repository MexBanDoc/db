using System;
using System.Collections.Generic;

namespace Game.Domain
{
    public interface IGameTurnRepository
    {
        // TODO: Спроектировать интерфейс исходя из потребностей ConsoleApp
        IReadOnlyList<GameTurnEntity> GetLastTurns(Guid gameId, int turnsCount);
        GameTurnEntity Insert(GameTurnEntity entity);
    }
}