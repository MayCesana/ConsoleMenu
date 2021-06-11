using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private SubMenuItem m_MainMenuItem;

        public MainMenu()
        {
            m_MainMenuItem.IsFirstLevel = true;
        }

        public MainMenu(string i_MainMenuTitle)
        {
            m_MainMenuItem = new SubMenuItem(i_MainMenuTitle);
            m_MainMenuItem.IsFirstLevel = true;
        }

        public MainMenu(List<MenuItem> i_MenuItems, string i_MainMenuTitle)
        {
            m_MainMenuItem = new SubMenuItem(i_MenuItems, i_MainMenuTitle);
            m_MainMenuItem.IsFirstLevel = true;
        }

        public string MainMenuTitle
        {
            get
            {
                return m_MainMenuItem.Title;
            }
            set
            {
                m_MainMenuItem.Title = value;
            }
        } 

        public void Show()
        {
            m_MainMenuItem.Show();
        }

        public void Add(MenuItem i_newMenuItem)
        {
            m_MainMenuItem.SubMenuItmes.Add(i_newMenuItem);
        }

        public void Remove(string i_MenuItemTitle)
        {
            foreach(MenuItem item in m_MainMenuItem.SubMenuItmes)
            {
                if(item.Title.Equals(i_MenuItemTitle))
                {
                    m_MainMenuItem.SubMenuItmes.Remove(item);
                    break;
                }
            }
        }
    }
}
