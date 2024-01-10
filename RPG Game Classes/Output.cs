using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Classes
{
    public static class Output
    {
        public static BindingList<string> Dialogs = new();

        public static int AmountAdded = 0;

        public static void AddDialogs(params string[] strings)
        {
            // add dialogs to a single list
            AmountAdded = strings.Length;
            foreach (string dialog in strings)
            {
                Dialogs.Add(dialog);
            }
            Dialogs.Add("");
        }
    }
}