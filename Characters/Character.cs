﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    public class Character
    {
        #region Variables
		public int CurrentHealth { get; set; }
		public int MaxHealth { get; set; }
		public int CurrentMagic { get; set; }
		public int MaxMagic { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int Experience { get; set; }
		public int AttackDamage { get; set; }
		public int AnzLittleHPPotions { get; set; }
		public int AnzMiddleHPPotions { get; set; }
		public int AnzBigHPPotions { get; set; }
		public int AnzLittleMPPotions { get; set; }
		public int AnzMiddleMPPotions { get; set; }
		public int AnzBigMPPotions { get; set; }
		public string Identifier { get; set; }
		public string Print { get; set; }
		public bool isAlive { get; set; }
		public double Gold { get; set; }
        #endregion

        public Character()
        {

        }

        #region functions
        public void PrintMonster()
        {

        }
        #endregion
    }
    

}
