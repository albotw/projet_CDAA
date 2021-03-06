﻿using projet_CDAA_2020_2021.CLI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

using static System.Console;

namespace projet_CDAA_2020_2021.CLI
{
    class CLIManager
    {
        private Stack<CLIElement> drawStack;

        public void init()
        {
            Title = "Gestion des jeux | " + "[" + LargestWindowWidth + "x" + LargestWindowHeight + "]";
            drawStack = new Stack<CLIElement>();
            CursorVisible = false;
            SetWindowSize(LargestWindowWidth, LargestWindowHeight);
        }

        public void AddElement(CLIElement e)
        {
            drawStack.Push(e);
        }

        //pour forcer le traitement d'un élément
        public void Interrupt(CLIElement e)
        {
            AddElement(e);
            Update();
            e.HandleInput(ReadKey(true).Key);
            DeleteTop();
        }

        public void DeleteTop()
        {
            drawStack.Peek().Clear();
            drawStack.Pop();
        }

        public void Loop()
        {
            ConsoleKeyInfo cki;
            do
            {
                Program.UpdateMainTable();
                Update();
                cki = ReadKey(true);
                drawStack.Peek().HandleInput(cki.Key);
                
            } while (cki.Key != ConsoleKey.Escape);
        }

        public void Update()
        {
            
            CLIElement[] tmp = drawStack.ToArray();
            for (int i = tmp.Length - 1; i >= 0; i--)
            {
                tmp[i].Clear();
                tmp[i].Draw();
            }
            
            //drawStack.Peek().Draw();
            SetCursorPosition(0, 0);
        }
    }
}
