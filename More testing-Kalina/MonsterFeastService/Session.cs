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
        Water=0,
        Fire=1,
        Air=2,
        Earth=3,
    };

    public enum CharClass
    {
        Warrior=0,
        Wizard=1,
        Archer=2,
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
