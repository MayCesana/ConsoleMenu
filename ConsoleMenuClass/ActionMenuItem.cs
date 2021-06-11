using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class ActionMenuItem : MenuItem
    {
        public delegate void ClickNofityDelegate();

        public event ClickNofityDelegate Clicked;

        public ActionMenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public void ActionItemWasClicked()
        {
            OnClicked();
        }

        protected virtual void OnClicked()
        {
            if (Clicked != null)
            {
                Clicked.Invoke();
            }
        }
    }
}
