using MyMod.Interfaces;
using MyMod.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace MyMod.Main
{
    public class Mod : IActionAuto
    {
        private static Mod Instance;

        private CommandMod cmdTest;

        public static Mod gI()
        {
            return Instance ??= new Mod();
        }

        public void init()
        {
            cmdTest ??= new CommandMod(string.Empty, this, 0, false, 50, 20);
            cmdTest.setType(0);
        }

        public void perform(int idAction, bool isAuto)
        {
            switch (idAction)
            {
                case 0:
                    {
                        cmdTest.setIsAuto();
                        GameCanvas.startOKDlg("Test");
                    }
                    break;
            }
        }

        public void updateMain()
        {

        }

        public void updateGameScr()
        {

        }


        public bool updateKeyGameScr()
        {
            if (cmdTest.isPointerPressInside())
            {
                cmdTest.performAction();
                return true;
            }
            return false;
        }

        public void paintGameScr(mGraphics g)
        {

            cmdTest.paint(g);
        }
    }
}
