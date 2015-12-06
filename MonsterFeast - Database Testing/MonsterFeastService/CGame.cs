using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterFeastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CGame : IGame
    {
        private bool isStart;
        private bool isEnd;
        Player P1;
        Player P2;
        private System.Timers.Timer timer;

        public CGame(Player p1, Player p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public int calculateDamage(Player attacker, Player defender) { return 0; }

        public int calculateHP(Player defender, int damage) { return 0; }

        public int calculateExp(Player p) { return 0; }

        public void changeTurn() { }

        public void attack(Skill a) { }

        public void usePoint() { }

        public void giveUp() { }

        public void sendMessage(string message, Player sender, DateTime time) { }

    }
}
