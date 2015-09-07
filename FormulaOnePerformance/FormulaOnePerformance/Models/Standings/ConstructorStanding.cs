using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOnePerformance.Models
{
    public class ConstructorStanding
    {
        public string Position { get; set; }
        public string PositionText { get; set; }
        public string Points { get; set; }
        public string Wins { get; set; }
        public Constructor Constructor { get; set; }
    }
}
