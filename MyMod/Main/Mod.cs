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

        private bool isAuto;

        public static Mod gI()
        {
            return Instance ??= new Mod();
        }

        public void init()
        {
            cmdTest ??= new CommandMod(string.Empty, null, 0, 155, 5);
            cmdTest.setType(0);
        }

        public void setIsAuto(bool isAuto)
        {
            this.isAuto = isAuto;
        }

        public bool getIsAuto()
        {
            return this.isAuto;
        }
        public void perform(int idAction)
        {
            switch (idAction)
            {
                case 0:
                    {
                        setIsAuto(!isAuto);
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

        public void updateKeyMain()
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
        public void paintMain(mGraphics g)
        {

        }

        public void paintGameScr(mGraphics g)
        {
            cmdTest.paint(g);
        }
    }
}
