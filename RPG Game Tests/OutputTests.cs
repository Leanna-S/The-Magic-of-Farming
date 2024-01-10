using RPG_Game_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class OutputTests
    {
        [Fact]
        public void Output_AddDialogs_AddsDialogsCorrectly()
        {
            Output.AddDialogs("One", "Two", "Three", "Four");
            Assert.Contains("One", Output.Dialogs);
            Assert.Contains("Two", Output.Dialogs);
            Assert.Contains("Three", Output.Dialogs);
            Assert.Contains("Four", Output.Dialogs);
            Assert.Equal(4, Output.AmountAdded);
            Assert.Equal(5, Output.Dialogs.Count);
        }
    }
}