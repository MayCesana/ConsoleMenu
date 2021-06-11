using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ProgramTestWithInterfaces
    {
        public MainMenu BuildMenu()
        {
            MainMenu menu = new MainMenu("Interfaces Menu");
            SubMenuItem subMenu1 = new SubMenuItem("Spaces and Version");
            SubMenuItem subMenu2 = new SubMenuItem("Show Date/Time");

            ActionMenuItem item1InMenu1 = new ActionMenuItem("Show Version");
            item1InMenu1.ActionMenuItemListeners.Add(new ShowVersion());
            ActionMenuItem item2InMenu1 = new ActionMenuItem("Count Spaces");
            item2InMenu1.ActionMenuItemListeners.Add(new CountSpaces());


            ActionMenuItem item1InMenu2 = new ActionMenuItem("Show Date");
            item1InMenu2.ActionMenuItemListeners.Add(new ShowDate());
            ActionMenuItem item2InMenu2 = new ActionMenuItem("Show Time");
            item2InMenu2.ActionMenuItemListeners.Add(new ShowTime());

            subMenu1.SubMenuItmes.Add(item1InMenu1);
            subMenu1.SubMenuItmes.Add(item2InMenu1);
            subMenu2.SubMenuItmes.Add(item1InMenu2);
            subMenu2.SubMenuItmes.Add(item2InMenu2);

            menu.Add(subMenu1);
            menu.Add(subMenu2);

            return menu;
        }

        public class ShowVersion : IOperationMenuItemListener
        {
            void IOperationMenuItemListener.Operate()
            {
                Console.WriteLine("Version: 21.1.4.8930");
            }
        }

        public class CountSpaces : IOperationMenuItemListener
        {
            void IOperationMenuItemListener.Operate()
            {
                int spacesCounter = 0;
                string sentence;

                Console.WriteLine("please write a sentence: ");
                sentence = Console.ReadLine();

                foreach (char c in sentence)
                {
                    if (c == ' ')
                    {
                        spacesCounter++;
                    }
                }

                Console.WriteLine(string.Format("The number of spaces in the sentence is: {0}", spacesCounter));
            }
        }

        public class ShowTime : IOperationMenuItemListener
        {
            void IOperationMenuItemListener.Operate()
            {
                DateTime now = DateTime.Now;
                Console.WriteLine(string.Format("{0:t}", now));
            }
        }

        public class ShowDate : IOperationMenuItemListener
        {
            void IOperationMenuItemListener.Operate()
            {
                DateTime date = DateTime.Today;
                Console.WriteLine(date.ToString("d"));
            }
        }
    }
}
