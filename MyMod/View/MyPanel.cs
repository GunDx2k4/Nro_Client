using MyMod.Interfaces;
using MyMod.MainMod;
using MyMod.Model;
using System;
using System.Drawing;
using UnityEngine;

namespace MyMod.View
{
    public class MyPanel : IActionAuto
    {
        public readonly int X = 20;
        public readonly int Y = 40;
        public readonly int W = GameCanvas.w - 40;
        public readonly int H = GameCanvas.h - 80;

        public CommandMod cmdClose;
        public CommandMod cmdCallFB;
        public CommandMod cmdCallDownload;
        public CommandMod cmdAttackPet;

        public bool isShow;

        public Image imgTitle;

        public string[][] tabName;
        public int currentTabIndex;


        public MyPanel()
        {

            cmdClose = new CommandMod(string.Empty, this, 1);
            cmdClose.img = GameCanvas.loadImage("/mainImage/myTexture2dbtX.png");
            cmdClose.cmdClosePanel = true;
            cmdClose.x = W - 5;
            cmdClose.y = Y + 7;


            cmdCallFB = new CommandMod("Mở FB", this, 2);
            cmdCallFB.x = X + 70;
            cmdCallFB.y = Y + 35;
            cmdCallFB.w = mFont.tahoma_7b_white.getWidth("Liên hệ hỗ trợ : https://www.facebook.com/l7ungdz");
            cmdCallFB.h = mFont.tahoma_7b_white.getHeight();

            cmdCallDownload = new CommandMod("Mở Download", this, 3);
            cmdCallDownload.x = X + 70;
            cmdCallDownload.y = Y + 15;
            cmdCallDownload.w = mFont.tahoma_7b_white.getWidth("Mod chỉ tải ở nguồn duy nhất : https://github.com/GunDx2k4");
            cmdCallDownload.h = mFont.tahoma_7b_white.getHeight();

            cmdAttackPet = new CommandMod("Tấn Công",this, 4);

            imgTitle = GameCanvas.loadImage("/mainImage/logo1.png");

            tabName = new string[11][]
            {
                new string[]
                {
                    "Thông",
                    "Tin"
                },
                new string[]
                {
                    "Set",
                    "1"
                },new string[]
                {
                    "Set",
                    "2"
                },new string[]
                {
                    "test",
                    string.Empty
                },new string[]
                {
                    "test",
                    string.Empty
                },new string[]
                {
                    "test",
                    "test"
                },new string[]
                {
                    "test",
                    string.Empty
                },new string[]
                {
                    "test",
                    "test"
                },new string[]
                {
                    "test",
                    "test"
                },new string[]
                {
                    "test",
                    "test"
                },new string[]
                {
                    "test",
                    "test"
                },
            };
            currentTabIndex = 0;
        }

        public void update()
        {
            switch (currentTabIndex)
            {
                case 0:
                    {

                    }
                    break;
                case 1:
                    {

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;
                case 4:
                    {

                    }
                    break;
                case 5:
                    {

                    }
                    break;
                case 6:
                    {

                    }
                    break;
                case 7:
                    {

                    }
                    break;
                case 8:
                    {

                    }
                    break;
                case 9:
                    {

                    }
                    break;
                case 10:
                    {

                    }
                    break;
            }
        }

        public void updateKey()
        {
            if (GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24])
            {
                currentTabIndex++; 
                if (currentTabIndex >= tabName.Length)
                {
                    currentTabIndex = 0;
                }
                GameCanvas.keyPressed[(!Main.isPC) ? 6 : 24] = false;
            }
            if (GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23])
            {
                currentTabIndex--;
                if (currentTabIndex < 0)
                {
                    currentTabIndex = tabName.Length - 1;
                }
                GameCanvas.keyPressed[(!Main.isPC) ? 4 : 23] = false;
            }
            for (int i = 0; i < tabName.Length; i++)
            {
                if (!GameCanvas.isPointer(X + 10 + i * 41, Y + H / 4 + 1, 40, 30))
                {
                    continue;
                }
                if (GameCanvas.isPointerJustRelease)
                {
                    currentTabIndex = i;
                    GameCanvas.isPointerJustRelease = false;
                    break;
                }
            }
            if (cmdClose.isPointerPressInside())
            {
                cmdClose.performAction();
                return;
            }
            if (cmdCallFB.isPointerPressInside())
            {
                cmdCallFB.performAction();
                return;
            }
            if (cmdCallDownload.isPointerPressInside())
            {
                cmdCallDownload.performAction();
                return;
            }
        }

        public void setIsAuto(bool isAuto)
        {

        }

        public bool getIsAuto()
        {
            return true;
        }

        public void perform(int idAction)
        {
            switch (idAction)
            {
                case 1:
                    {
                        hide();
                    }
                    break;
                case 2:
                    {
                        Application.OpenURL("https://www.facebook.com/l7ungdz");
                    }
                    break;
                case 3:
                    {
                        Application.OpenURL("https://github.com/GunDx2k4");
                    }
                    break;
            }
        }

        public void paint(mGraphics g)
        {
            if(isShow)
            {
                GameCanvas.paintz.paintFrameSimple(X, Y, W, H, g);

                resetTranslate(g);

                paintTopInfo(g);
                paintTab(g);

                switch (currentTabIndex)
                {
                    case 0:
                        {
                            paintInfo(g);
                        }
                        break;
                    case 1:
                        {

                        }
                        break;
                    case 2:
                        {

                        }
                        break;
                    case 3:
                        {

                        }
                        break;
                    case 4:
                        {

                        }
                        break;
                    case 5:
                        {

                        }
                        break;
                    case 6:
                        {

                        }
                        break;
                    case 7:
                        {

                        }
                        break;
                    case 8:
                        {

                        }
                        break;
                    case 9:
                        {

                        }
                        break;
                    case 10:
                        {

                        }
                        break;
                }
                GameScr.resetTranslate(g);
                cmdClose.paint(g);

            }
        }

        public void paintTopInfo(mGraphics g)
        {

            //Ve Vien
            g.setColor(6702080);
            g.fillRect(0, 0, W, H / 4);

            //Ve Khung
            g.setColor(9993045);
            g.fillRect(1, 1, W - 2, H / 4 - 2);

            SmallImage.drawSmallImage(g, 4520, 5, H / 4, 0, StaticObj.BOTTOM_LEFT);
            //g.drawImage(imgTitle, 5, 27 , StaticObj.VCENTER_LEFT);
            Util.draw2ColorBD(g, $"<Code by l7ungdz> Version : ", $"[{Mod.gI().VERSION}]", mFont.tahoma_7b_white, mFont.tahoma_7b_green, 70, 5);
            Util.draw2ColorBD(g, "Mod chỉ tải ở nguồn duy nhất : ", $"https://github.com/GunDx2k4", mFont.tahoma_7b_white, mFont.tahoma_7_blue1, cmdCallDownload.x - X, cmdCallDownload.y - Y);
            Util.draw2ColorBD(g, "Mod hỗ trợ game, giúp game trải nghiệm dễ dàng hơn, ", $"tải sai nguồn mất nick tự chịu", mFont.tahoma_7b_white, mFont.tahoma_7b_red, 70, 25);
            Util.draw2ColorBD(g, "Liên hệ hỗ trợ : ", $"https://www.facebook.com/l7ungdz", mFont.tahoma_7b_white, mFont.tahoma_7_blue1, cmdCallFB.x - X, cmdCallFB.y - Y);
        }

        public void paintTab(mGraphics g)
        {

            //Ve vien
            g.setColor(13524492);
            g.fillRect(1, H / 4 + 32, W - 2, 1);

            for(int i = 0 ; i < tabName.Length; i++)
            {
                PopUp.paintPopUp(g, 10 + i*41, H / 4 + 1, 40, 30, (i == currentTabIndex) ? 1 : 0, isButton: true);
                mFont mFont2 = ((i != currentTabIndex) ? mFont.tahoma_7_grey : mFont.tahoma_7_green2);
                if (!tabName[i][1].Equals(string.Empty))
                {
                    mFont2.drawString(g, tabName[i][0], 10 + 20 + i * 41, H / 4 + 1 + 5, mFont.CENTER);
                    mFont2.drawString(g, tabName[i][1], 10 + 20 + i * 41, H / 4 + 1 + 15, mFont.CENTER);
                }
                else
                {
                    mFont2.drawString(g, tabName[i][0], 10 + 20 + i * 41, H / 4 + 1 + 10, mFont.CENTER);
                }
            }
        }

        public void paintInfo(mGraphics g)
        {
            int w1 = W / 2 - 9;
            int h1 = H - (H / 4 + 37 + 6);

            g.setColor(6702080);
            g.fillRect(5, H / 4 + 36, w1, h1);

            g.setColor(9993045);
            g.fillRect(6, H / 4 + 37, w1 - 2, h1 - 2);
            g.setClip(5, H / 4 + 36, w1 * 2 + 12 , h1 + 1);

            SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), 6 + 5, H / 4 + 37 + 55, 0, StaticObj.BOTTOM_LEFT);
            Util.draw2ColorBD(g, $"Sư Phụ : ", $"{Char.myCharz().cName}", mFont.tahoma_7b_yellow, mFont.tahoma_7b_white, 6 + 100, H / 4 + 37);
            mFont.tahoma_7_yellow.drawString(g, $"Sức Mạnh : {NinjaUtil.getMoneys(Char.myCharz().cPower)}", 6 + 100, H / 4 + 37 + 10, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Tiềm năng : {NinjaUtil.getMoneys(Char.myCharz().cTiemNang)}", 6 + 100, H / 4 + 37 + 20, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"HP : {NinjaUtil.getMoneys(Char.myCharz().cHP)}/{NinjaUtil.getMoneys(Char.myCharz().cHPFull)}", 6 + 100, H / 4 + 37 + 30, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"MP : {NinjaUtil.getMoneys(Char.myCharz().cMP)}/{NinjaUtil.getMoneys(Char.myCharz().cMPFull)}", 6 + 100, H / 4 + 37 + 40, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"SĐ : {NinjaUtil.getMoneys(Char.myCharz().cDamFull)}", 6 + 100, H / 4 + 37 + 50, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Giáp: {NinjaUtil.getMoneys(Char.myCharz().cDefull)}, CM : {Char.myCharz().cCriticalFull} %", 6 + 100, H / 4 + 37 + 60, mFont.LEFT);
            

            g.setColor(6702080);
            g.fillRect(w1 + 11, H / 4 + 36, w1, h1);
            g.setColor(9993045);
            g.fillRect(w1 + 12, H / 4 + 37, w1 - 2, h1 - 2);

            SmallImage.drawSmallImage(g, Char.myPetz().avatarz(), w1 + 12 + 5, H / 4 + 37 + 55, 0, StaticObj.BOTTOM_LEFT);
            Util.draw2ColorBD(g, $"Sư Phụ : ", $"{Char.myPetz().cName}", mFont.tahoma_7b_yellow, mFont.tahoma_7b_white, w1 + 12 + 100, H / 4 + 37);
            mFont.tahoma_7_yellow.drawString(g, $"Sức Mạnh : {NinjaUtil.getMoneys(Char.myPetz().cPower)}", w1 + 12 + 100, H / 4 + 37 + 10, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Tiềm năng : {NinjaUtil.getMoneys(Char.myPetz().cTiemNang)}", w1 + 12 + 100, H / 4 + 37 + 20, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"HP : {NinjaUtil.getMoneys(Char.myPetz().cHP)}/{NinjaUtil.getMoneys(Char.myPetz().cHPFull)}", w1 + 12 + 100, H / 4 + 37 + 30, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"MP : {NinjaUtil.getMoneys(Char.myPetz().cMP)}/{NinjaUtil.getMoneys(Char.myPetz().cMPFull)}", w1 + 12 + 100, H / 4 + 37 + 40, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"SĐ : {NinjaUtil.getMoneys(Char.myPetz().cDamFull)}", w1 + 12 + 100, H / 4 + 37 + 50, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Giáp: {NinjaUtil.getMoneys(Char.myPetz().cDefull)}, CM : {Char.myPetz().cCriticalFull} %", w1 + 12 + 100, H / 4 + 37 + 60, mFont.LEFT);
        }

        public void resetTranslate(mGraphics g)
        {
            g.translate(-g.getTranslateX(), -g.getTranslateY());
            g.translate(X, Y);
        }

        public void show()
        {
            ChatPopup.currChatPopup = null;
            InfoDlg.hide();
            isShow = true;
        }

        public void hide()
        {
            isShow = false;
        }
    }

}
