using EasyBase.src.ui.windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyBase.src.code
{
    internal static class WindowDictionary
    {
        private static ArrayList windowDictionary = new ArrayList();

        public static void addWindow(Window window)
        {
            windowDictionary.Add(window);
        }

        public static ArrayList getDictionary()
        {
            return windowDictionary;
        }

        public static object getWindow(Type WindowSearched)
        {
            foreach (object window in windowDictionary)
            {
                if (window.GetType() == WindowSearched)
                {
                    return window;
                }
            }

            return null;
        }
    }
}
