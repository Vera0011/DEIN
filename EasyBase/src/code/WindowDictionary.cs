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

        public static object getWindow(int position)
        {
            return windowDictionary[position];
        }

        public static ArrayList getDictionary()
        {
            return windowDictionary;
        }
    }
}
