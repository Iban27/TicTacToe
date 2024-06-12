using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class GameSettings
    {
        public static GameMode gameMode;
    }

    public enum GameMode
    {
        PvP,
        PvE
    }
}
