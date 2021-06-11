using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex04.Menus.Delegates
{
    public class SubMenuItem : MenuItem
    {
        public enum eExitOption { Exit, Back };

        private readonly List<MenuItem> m_SubMenuItems = new List<MenuItem>();
        private bool m_IsFirstLevel = false;

        public SubMenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public SubMenuItem(List<MenuItem> i_SubMenuItems, string i_Title)
        {
            m_SubMenuItems = i_SubMenuItems;
            m_Title = i_Title;
        }

        public List<MenuItem> SubMenuItmes
        {
            get
            {
                return m_SubMenuItems;
            }
        }

        internal bool IsFirstLevel
        {
            get { return m_IsFirstLevel; }
            set { m_IsFirstLevel = value; }
        }

        public void Show()
        {
            int input = -1;

            while (input != 0)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(m_Title);
                    showSubMenuItems();
                    Console.WriteLine("please enter your choise from the menu: ");

                    input = getInputFromUser();
                    selectMenuItemFromUserChoise(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(1500);
                }
            }
        }

        private void showSubMenuItems()
        {
            int i = 0;
            if (m_IsFirstLevel)
            {
                Console.WriteLine(string.Format("{0}. {1} ", i, eExitOption.Exit));
            }
            else
            {
                Console.WriteLine(string.Format("{0}. {1} ", i, eExitOption.Back));
            }

            foreach (MenuItem item in m_SubMenuItems)
            {
                i++;
                Console.WriteLine(i + ". " + item.Title);
            }
        }

        private void selectMenuItemFromUserChoise(int i_Choise)
        {
            Console.Clear();
            if (i_Choise == 0)
            {
                return;
            }
            else
            {
                if (m_SubMenuItems[i_Choise - 1] is ActionMenuItem)
                {
                    (m_SubMenuItems[i_Choise - 1] as ActionMenuItem).ActionItemWasClicked();
                    Thread.Sleep(1500);
                }
                else
                {
                    (m_SubMenuItems[i_Choise - 1] as SubMenuItem).Show();
                }
            }
        }

        private int getInputFromUser()
        {
            int input = int.Parse(Console.ReadLine());

            if(input < 0 || input > m_SubMenuItems.Count)
            {
                throw new Exception("wrong input");
            }
            else
            {
                return input;
            }
        }
    }
}

