using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            ProgramTestWithDelegates delegateProgram = new ProgramTestWithDelegates();
            Ex04.Menus.Delegates.MainMenu delegateMenu = delegateProgram.BuildMenu();
            delegateMenu.Show();

            ProgramTestWithInterfaces interfaceProgram = new ProgramTestWithInterfaces();
            Ex04.Menus.Interfaces.MainMenu interfaceMenu = interfaceProgram.BuildMenu();
            interfaceMenu.Show();

            Console.ReadLine();
        }
    }
}
