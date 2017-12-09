using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Baseball.Model
{
    public class Positions : Collection<Position>
    {
        public bool IsRP
        {
            get
            {
                if (this.Count == 0)
                    return false;

                foreach (Position p in this)
                {
                    if (p == Position.RP)
                        return true;
                }

                return false;
            }
        }

        public void Add(string position)
        {
            switch (position.ToLower())
            {
                case "rp": this.Add(Position.RP); break;
                case "sp": this.Add(Position.SP); break;
                case "c": this.Add(Position.C); break;
                case "1b": this.Add(Position.First); break;
                case "2b": this.Add(Position.Second); break;
                case "3b": this.Add(Position.Third); break;
                case "ss": this.Add(Position.SS); break;
                case "of": this.Add(Position.OF); break;
                case "util": this.Add(Position.Util); break;
                default: this.Add(Position.Unknown); break;
            }
        }

        public override string ToString()
        {
            if (this.Count == 0)
                return "Unknown Positions";
            else
            {
                var posList = new List<string>();

                foreach (Position pos in this)
                {
                    if (pos == Position.First)
                        posList.Add("1B");
                    else if (pos == Position.Second)
                        posList.Add("2B");
                    else if (pos == Position.Third)
                        posList.Add("3B");
                    else
                        posList.Add(pos.ToString());
                }

                return string.Join(",", posList.ToArray());
            }
        }
    }
    public enum Position
    {
        Unknown = 1, First = 2, Second = 3, Third = 4, SS = 5,
        OF = 6, Util = 7, SP = 8, RP = 9, C = 10
    }
}
