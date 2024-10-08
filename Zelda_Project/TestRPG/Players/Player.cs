﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.GameObjects;
using TestRPG.Monsters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Players
{
    public class Player
    {

        protected int curHP = 100;
        public int CurHP { get { return curHP; } set { curHP = value; } }

        protected int maxHP;
        public int MaxHP { get { return maxHP; } set { maxHP = value; } }

        protected int attack = 30;
        public int Attack { get { return attack; } }

        protected int defense = 20;
        public int Defense { get { return defense; } }

        protected int gold;
        public int Gold { get { return gold; } set { gold = value; } }


        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("==========================================");

            Console.WriteLine($" 체력 : {curHP,+3} /  공격 : {attack,-3} / 방어 : {defense,-3}");
            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}
