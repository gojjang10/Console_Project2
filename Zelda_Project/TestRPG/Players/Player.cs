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
    public abstract class Player
    {
        public bool cant = false;

        protected int curHP;
        public int CurHP { get { return curHP; } }

        protected int maxHP;
        public int MaxHP { get { return maxHP; } }

        protected int attack;
        public int Attack { get { return attack; } }

        protected int defense;
        public int Defense { get { return defense; } }

        protected int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        public void AddItem(Item item)
        {
            // 인벤토리에 아이템 추가

        }
        public abstract void Skill(Monster monster);


        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("==========================================");

            Console.WriteLine($" 체력 : {curHP,+3} / {maxHP}  공격 : {attack,-3} / 방어 : {defense,-3}");
            Console.WriteLine($" 골드 : {gold,+5} G");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }
    }
}
