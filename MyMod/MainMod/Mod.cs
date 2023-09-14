using Assets.src.e;
using MyMod.Interfaces;
using MyMod.Model;
using MyMod.View;

namespace MyMod.MainMod
{
    public class Mod : IActionAuto
    {
        private static Mod Instance;

        private CommandMod cmdTest;
        private CommandMod cmdPanel;
        private TField tfTest;

        private bool isAuto;

        public readonly string VERSION = "MOD.0.0.1";

        public MyPanel panel;
        public static Mod gI()
        {
            return Instance ??= new Mod();
        }

        public void init()
        {
            cmdTest = new CommandMod("Load", null, 0, 155, 5);
            cmdTest.setType(0);
            tfTest = new TField();
            tfTest.x = 200;
            tfTest.y = 5;
            tfTest.width = 200;
            tfTest.height = mScreen.ITEM_HEIGHT + 2;
            tfTest.isFocus = true;
            tfTest.setIputType(TField.INPUT_TYPE_ANY);
            tfTest.name = "Test";
            panel = new MyPanel();

            cmdPanel = new CommandMod(string.Empty, null, 1);
            cmdPanel.img = GameCanvas.loadImage("/mainImage/myTexture2dmenu.png");
            cmdPanel.cmdClosePanel = true;
            cmdPanel.w = mGraphics.getImageWidth(cmdPanel.img) + 20;
            cmdPanel.x = GameCanvas.w - mGraphics.getImageWidth(cmdPanel.img);
            cmdPanel.y = GameCanvas.h/2 - 20;
            cmdPanel.transform = 2;


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
                        GameCanvas.startOKDlg($"Done ");
                    }
                    break;
                case 1:
                    {
                        panel.show();
                    }
                    break;
            }
        }

        public void perform(int idAction, object p)
        {
            switch (idAction)
            {
                case 1:
                    {

                    }
                    break;
            }
        }

        public void updateMain()
        {
            
        }

        public void updateGameScr()
        {
            if(GameCanvas.gameTick % 20 == 0)
            {
                //Service.gI().petInfo();
            }
            if (cmdTest.isPointerPressInside())
            {
                cmdTest.performAction();
                return;
            }
            if (cmdPanel.isPointerPressInside())
            {
                cmdPanel.performAction();
                return;
            }
        }

        public void updateKeyMain(int keyCode)
        {

        }

        public bool updateKeyGameScr()
        {
            if(GameCanvas.keyAsciiPress == 'm')
            {
               
                return true;
            }
            return false;
        }
        public void paintMain(mGraphics g)
        {
            panel.paint(g);
        }

        public void paintGameScr(mGraphics g)
        {
            mFont.tahoma_7b_white.drawString(g, $"name : {TileMap.zoneID}", 150, 50, 0);
            int y = 20;
            for (int i = 0; i < GameScr.vCharInMap.size(); i++)
            {
                Char c = (Char)GameScr.vCharInMap.elementAt(i);
                mFont.tahoma_7b_white.drawString(g, $"name : {c.cName}", 100, y, 0);
                y += 10;
            }
            cmdTest.paint(g);
            cmdPanel.paint(g);
        }
        
    }
}
