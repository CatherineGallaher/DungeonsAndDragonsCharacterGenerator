﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DnDClassesTest
{
    class Rogue : Profession
    {
        protected bool[] PickedSkills;
        public bool[] _pickedSkills
        {
            get
            {
                return PickedSkills;
            }
            set
            {//will be passed a bool[18], needs validations
                PickedSkills = value;
            }
        }
        protected override List<string> Features { get; set; }

        public Rogue()
        {
            this._level = 1;
            this._hitDie = 8;
            this._caster = (this._proPath == 2)? true : false;
            this._numProSkills = 4;
        }

        public Rogue(int level, int path)
        {
            this._level = level;
            this._hitDie = 8;
            this._proPath = path;
            this._caster = (path == 2) ? true : false;
            this._numProSkills = 4;
            this.Features = this.ClassFeatures();
        }
        public override bool[] ClassSkills()
        {//Acrobatics, Athletics, Deception. Insight, Intimidation, Investigation,
        //Perception, Performance.Persuasion, Sleight of Hand, Stealth
            bool[] SkillList = new bool[18];
            /*bool[] = true;
             * bool[] = true;
             * bool[] = true;
             * bool[] = true;
             * bool[] = true;
             bool[] = true;
             bool[] = true;
             bool[] = true;
             bool[] = true;
             bool[] = true;
             bool[] = true;*/
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/
            ;
            Saves[1] = true;
            Saves[3] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        public override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\RogueClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[19];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;

        }



        public override bool[] Unlocked()
        {
            bool[] unlocked = new bool[12]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 5) unlocked[3] = true;
            if (this._level >= 7) unlocked[4] = true;
            if (this._level >= 9) unlocked[5] = true;
            if (this._level >= 11) unlocked[6] = true;
            if (this._level >= 13) unlocked[7] = true;
            if (this._level >= 14) unlocked[8] = true;
            if (this._level >= 15) unlocked[9] = true;
            if (this._level >= 17) unlocked[10] = true;
            if (this._level >= 18) unlocked[11] = true;
            if (this._level == 20) unlocked[12] = true;
            return unlocked;
        }

        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 7; i <= 0; --i)
            {
                if (unlock[i]) break;
            }
            if (i == 7) current = Features;
            else if (i == 6) current = Features.GetRange(0, 7);
            else if (i == 5) current = Features.GetRange(0, 6);
            else if (i == 4) current = Features.GetRange(0, 5);
            else if (i == 3) current = Features.GetRange(0, 3);
            else if (i == 2) current = Features.GetRange(0, 2);
            else if (i == 2) current = Features.GetRange(0, 1);
            else current.Add(Features[0]);
            return current;
        }

        //insert class feature methods here
    }
}
