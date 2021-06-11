using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class ProgramTestWithDelegates
    {
        public MainMenu BuildMenu()
        {
            MainMenu menu = new MainMenu("Delegates Menu");
            SubMenuItem subMenu1 = new SubMenuItem("Spaces and Version");
            SubMenuItem subMenu2 = new SubMenuItem("Show Date/Time");

            ActionMenuItem item1InMenu1 = new ActionMenuItem("Show Version");
            item1InMenu1.Clicked += new ActionMenuItem.ClickNofityDelegate(showVersion_Clicked);
            ActionMenuItem item2InMenu1 = new ActionMenuItem("Count Spaces");
            item2InMenu1.Clicked += new ActionMenuItem.ClickNofityDelegate(countSpaces_Clicked);


            ActionMenuItem item1InMenu2 = new ActionMenuItem("Show Date");
            item1InMenu2.Clicked += new ActionMenuItem.ClickNofityDelegate(showDate_Clicked);
            ActionMenuItem item2InMenu2 = new ActionMenuItem("Show Time");
            item2InMenu2.Clicked += new ActionMenuItem.ClickNofityDelegate(showTime_Clicked);

            subMenu1.SubMenuItmes.Add(item1InMenu1);
            subMenu1.SubMenuItmes.Add(item2InMenu1);
            subMenu2.SubMenuItmes.Add(item1InMenu2);
            subMenu2.SubMenuItmes.Add(item2InMenu2);

            menu.Add(subMenu1);
            menu.Add(subMenu2);

            return menu;
        }

        private void showVersion_Clicked()
        {
            Console.WriteLine("Version: 21.1.4.8930");
        }

        private void countSpaces_Clicked()
        {
            int spacesCounter = 0;
            string sentence;

            Console.WriteLine("please write a sentence: ");
            sentence = Console.ReadLine();

            foreach(char c in sentence)
            {
                if(c == ' ')
                {
                    spacesCounter++;
                }
            }

            Console.WriteLine(string.Format("The number of spaces in the sentence is: {0}", spacesCounter));
        }

        private void showTime_Clicked()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(string.Format("{0:t}", now));
        }

        private void showDate_Clicked()
        {
            DateTime date = DateTime.Today;
            Console.WriteLine(date.ToString("d"));
        }
    }
}
