﻿using System;
using System.Collections.Generic;
using System.Text;
using NVNC;

namespace VNCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            VncServer s = new VncServer("1", 5900, "TestServer");
            try
            {
                s.Start();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.ReadLine();
        }
    }
}