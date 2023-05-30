using MyMod.Interfaces;
using MyMod.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMod.Model
{
    public class CommandMod : Command
    {
        private IActionAuto actionAuto;
        private bool isAuto;

        public CommandMod(string caption, IActionAuto actionAuto, int idAction, bool isAuto)
        {
            this.caption = caption;
            this.idAction = idAction;
            this.actionAuto = actionAuto;
            this.isAuto = isAuto;
        }
        public CommandMod(string caption, IActionAuto actionAuto, int idAction, bool isAuto, int x, int y)
        {
            this.caption = caption;
            this.idAction = idAction;
            this.actionAuto = actionAuto;
            this.isAuto = isAuto;
            this.x = x;
            this.y = y;
        }

        public void setIsAuto()
        {
            isAuto = !isAuto;
        }

        public void setType(int type)
        {
            this.type = type;
            switch (type)
            {
                case 0:
                    {
                        w = 36;
                        hw = 18;
                        break;
                    }
                case 1:
                    {
                        w = 50;
                        hw = 25;
                        break;
                    }
                case 2:
                    {

                        w = 76;
                        hw = 38;
                        break;
                    }
            }
        }

        public override void performAction()
        {
            if (actionAuto != null)
            {
                actionAuto.perform(idAction, isAuto);
            }
            else
            {
                Mod.gI().perform(idAction, isAuto);
            }
        }
        public override void paint(mGraphics g)
        {
            if (!isFocus)
            {
                paintOngMau(btn0left, btn0mid, btn0right, x, y, w, g);
            }
            else
            {
                paintOngMau(btn1left, btn1mid, btn1right, x, y, w, g);
            }
            int num = x + hw;
            if (caption == string.Empty)
            {
                if (!isFocus)
                {
                    mFont.tahoma_7b_dark.drawString(g, isAuto ? "Bật" : "Tắt", num, y + 7, 2);
                }
                else
                {
                    mFont.tahoma_7b_green2.drawString(g, isAuto ? "Bật" : "Tắt", num, y + 7, 2);
                }
                return;
            }
            if (!isFocus)
            {
                mFont.tahoma_7b_dark.drawString(g, caption, num, y + 7, 2);
            }
            else
            {
                mFont.tahoma_7b_green2.drawString(g, caption, num, y + 7, 2);
            }
        }
    }

}
