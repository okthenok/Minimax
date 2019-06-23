using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class IGameState
    {
        public int Value { get; }
        public bool IsTerminal { get; }
        public IEnumerable<IGameState> Moves { get; }
    }
}
