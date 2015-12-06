using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFeastService
{
    public enum Session
    {
        InGame,
        InLobby,
        QuitApp,
    };

    public enum Element
    {
        Water,
        Fire,
        Air,
        Earth,
    };

    public enum CharClass
    {
        Warrior,
        Mage,
        Archer,
    };

    public enum Attribute
    {
        Strength,
        Constitution,
        Magic,
        Wisdom,
        Agility,
        Dexterity,
    };
}
