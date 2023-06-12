using MyMod.Interfaces;
using MyMod.MainMod;
using MyMod.Model;
using System;
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
        public CommandMod cmdDefendPet;
        public CommandMod cmdFollowPet;
        public CommandMod cmdGoHomePet;

        public bool isShow;

        public Image imgTitle;

        public string[][] tabName;
        public int currentTabIndex;
        public int selected;

        public string[] strStatus;

        public Item currItem;
        public ChatPopup cp;

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
            cmdAttackPet.setType(1);
            cmdAttackPet.x = X + W / 2 - 9 + 12 + 10;
            cmdAttackPet.y = Y + H / 4 + 37 + 90;

            cmdDefendPet = new CommandMod("Bảo Vệ", this, 5);
            cmdDefendPet.setType(1);
            cmdDefendPet.x = cmdAttackPet.x + cmdAttackPet.w + 2;
            cmdDefendPet.y = Y + H / 4 + 37 + 90;

            cmdFollowPet = new CommandMod("Đi Theo", this, 6);
            cmdFollowPet.setType(1);
            cmdFollowPet.x = cmdDefendPet.x + cmdDefendPet.w + 2;
            cmdFollowPet.y = Y + H / 4 + 37 + 90;

            cmdGoHomePet = new CommandMod("Về Nhà", this, 7);
            cmdGoHomePet.setType(1);
            cmdGoHomePet.x = cmdFollowPet.x + cmdFollowPet.w + 2;
            cmdGoHomePet.y = Y + H / 4 + 37 + 90;

            imgTitle = GameCanvas.loadImage("/mainImage/logo1.png");

            strStatus = new string[5]
            {
                "Đi Theo",
                "Bảo Vệ",
                "Tấn Công",
                "Về Nhà",
                "Hợp Thể"
            };

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

            selected = -1;
            currentTabIndex = 0;
        }

        public void update()
        {
            switch (currentTabIndex)
            {
                case 0:
                    {
                        doFireInfo();
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
                    GameCanvas.clearAllPointerEvent();
                    return;
                }
            }

            if (cp != null)
            {
                int x = 6 + 15;
                int y = H / 4 + 37 + 85; 

                if (!GameCanvas.isPointer(X + x + (2 + 34 + 4) * selected, Y + y, 34 + 4, 24 + 4))
                {
                    cp = null;
                    return;
                }
                cp.updateKey();
            }

            if (cmdAttackPet.isPointerPressInside())
            {
                cmdAttackPet.performAction();
                return;
            }
            if (cmdDefendPet.isPointerPressInside())
            {
                cmdDefendPet.performAction();
                return;
            }
            if (cmdFollowPet.isPointerPressInside())
            {
                cmdFollowPet.performAction();
                return;
            }
            if (cmdGoHomePet.isPointerPressInside())
            {
                cmdGoHomePet.performAction();
                return;
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
                case 4:
                    {
                        //Attack
                        Service.gI().petStatus((sbyte)2);
                    }
                    break;
                case 5:
                    {
                        //Defend
                        Service.gI().petStatus((sbyte)1);
                    }
                    break;
                case 6:
                    {
                        //Follow
                        Service.gI().petStatus((sbyte)0);
                    }
                    break;
                case 7:
                    {
                        //Go Home
                        Service.gI().petStatus((sbyte)3);
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
                paintDetail(g);

            }
        }

        public void paintTopInfo(mGraphics g)
        {
            paintFrame(g, 1, 1, W - 2, H / 4 - 2);

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

            g.setClip(5, H / 4 + 36, w1 * 2 + 12 + 2, h1 + 2);
            //Ve Thong Tin Su Phu
            paintFrame(g, 6, H / 4 + 38, w1, h1);

            SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), 6 + 5, H / 4 + 37 + 65, 0, StaticObj.BOTTOM_LEFT);
            Util.draw2ColorBD(g, $"Sư Phụ : ", $"{Char.myCharz().cName}", mFont.tahoma_7b_yellow, mFont.tahoma_7b_white, 6 + 100, H / 4 + 37);
            mFont.tahoma_7_yellow.drawString(g, $"Sức Mạnh : {NinjaUtil.getMoneys(Char.myCharz().cPower)}", 6 + 100, H / 4 + 37 + 10, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Tiềm năng : {NinjaUtil.getMoneys(Char.myCharz().cTiemNang)}", 6 + 100, H / 4 + 37 + 20, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"HP : {NinjaUtil.getMoneys(Char.myCharz().cHP)}/{NinjaUtil.getMoneys(Char.myCharz().cHPFull)}", 6 + 100, H / 4 + 37 + 30, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"MP : {NinjaUtil.getMoneys(Char.myCharz().cMP)}/{NinjaUtil.getMoneys(Char.myCharz().cMPFull)}", 6 + 100, H / 4 + 37 + 40, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"SĐ : {NinjaUtil.getMoneys(Char.myCharz().cDamFull)}", 6 + 100, H / 4 + 37 + 50, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Giáp: {NinjaUtil.getMoneys(Char.myCharz().cDefull)}, CM : {Char.myCharz().cCriticalFull} %", 6 + 100, H / 4 + 37 + 60, mFont.LEFT);

            mFont.tahoma_7b_white.drawString(g, $"Set Đồ :", 6 + 15, H / 4 + 37 + 70, mFont.LEFT);
            int x = 6 + 15;
            int y = H / 4 + 37 + 85;
            for(int i = 0; i < 5; i++)
            {
                g.setColor(14338484);
                g.fillRect(x + (2 + 34 + 4) * i - 2, y - 2, 34 + 4, 24 + 4);
                g.setColor(i == selected ? 16383818 : 15723751);
                g.fillRect(x + (2 + 34 + 4) * i, y, 34, 24);
                SmallImage.drawSmallImage(g, Char.myCharz().arrItemBody[i].template.iconID, x + (2 + 34 + 4) * i + 34 / 2, y + 24 / 2, 0, 3);
            }

            //Ve Thong Tin De Tu
            paintFrame(g, w1 + 12, H / 4 + 38, w1, h1);

            SmallImage.drawSmallImage(g, Char.myPetz().avatarz(), w1 + 12 + 5, H / 4 + 37 + 65, 0, StaticObj.BOTTOM_LEFT);
            Util.draw2ColorBD(g, $"Đệ Tử : ", $"{Char.myPetz().cName}", mFont.tahoma_7b_yellow, mFont.tahoma_7b_white, w1 + 12 + 100, H / 4 + 37);
            mFont.tahoma_7_yellow.drawString(g, $"Sức Mạnh : {NinjaUtil.getMoneys(Char.myPetz().cPower)}", w1 + 12 + 100, H / 4 + 37 + 10, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"Tiềm năng : {NinjaUtil.getMoneys(Char.myPetz().cTiemNang)}", w1 + 12 + 100, H / 4 + 37 + 20, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"HP : {NinjaUtil.getMoneys(Char.myPetz().cHP)}/{NinjaUtil.getMoneys(Char.myPetz().cHPFull)}", w1 + 12 + 100, H / 4 + 37 + 30, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"MP : {NinjaUtil.getMoneys(Char.myPetz().cMP)}/{NinjaUtil.getMoneys(Char.myPetz().cMPFull)}", w1 + 12 + 100, H / 4 + 37 + 40, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"SĐ : {NinjaUtil.getMoneys(Char.myPetz().cDamFull)}, Giáp: {NinjaUtil.getMoneys(Char.myPetz().cDefull)}", w1 + 12 + 100, H / 4 + 37 + 50, mFont.LEFT);
            mFont.tahoma_7_yellow.drawString(g, $"CM : {Char.myPetz().cCriticalFull}%, Trạng thái : {strStatus[Char.myPetz().petStatus]}", w1 + 12 + 100, H / 4 + 37 + 60, mFont.LEFT);
            mFont.tahoma_7b_white.drawString(g, $"Đổi trạng thái :", w1 + 12 + 15, H / 4 + 37 + 70, mFont.LEFT);


            GameScr.resetTranslate(g);

            cmdAttackPet.paint(g);
            cmdDefendPet.paint(g);
            cmdFollowPet.paint(g);
            cmdGoHomePet.paint(g);

        }

        public void doFireInfo()
        {
            int x = 6 + 15;
            int y = H / 4 + 37 + 85;
            for (int i = 0; i < 5; i++)
            {
                if (!GameCanvas.isPointer(X + x + (2 + 34 + 4) * i, Y + y, 34, 24))
                {
                    continue;
                }
                if (GameCanvas.isPointerJustRelease)
                {
                    selected = i;
                    GameCanvas.isPointerJustRelease = false;
                    currItem = Char.myCharz().arrItemBody[i];
                    Char.myCharz().setPartTemp(currItem.headTemp, currItem.bodyTemp, currItem.legTemp, currItem.bagTemp);
                    addItemDetail(currItem);
                    break;
                }
            }
            
        }

        public void paintDetail(mGraphics g)
        {
            if (cp == null)
                return;
            cp.paint(g);
        }

        public void addItemDetail(Item item)
        {
            try
            {
                cp = new ChatPopup();
                string empty = string.Empty;
                string text = string.Empty;
                if (item.template.gender != Char.myCharz().cgender)
                {
                    if (item.template.gender == 0)
                    {
                        text = text + "\n|7|1|" + mResources.from_earth;
                    }
                    else if (item.template.gender == 1)
                    {
                        text = text + "\n|7|1|" + mResources.from_namec;
                    }
                    else if (item.template.gender == 2)
                    {
                        text = text + "\n|7|1|" + mResources.from_sayda;
                    }
                }
                string text2 = string.Empty;
                if (item.itemOption != null)
                {
                    for (int i = 0; i < item.itemOption.Length; i++)
                    {
                        if (item.itemOption[i].optionTemplate.id == 72)
                        {
                            text2 = " [+" + item.itemOption[i].param + "]";
                        }
                    }
                }
                bool flag = false;
                if (item.itemOption != null)
                {
                    for (int j = 0; j < item.itemOption.Length; j++)
                    {
                        if (item.itemOption[j].optionTemplate.id == 41)
                        {
                            flag = true;
                            if (item.itemOption[j].param == 1)
                            {
                                text = text + "|0|1|" + item.template.name + text2;
                            }
                            if (item.itemOption[j].param == 2)
                            {
                                text = text + "|2|1|" + item.template.name + text2;
                            }
                            if (item.itemOption[j].param == 3)
                            {
                                text = text + "|8|1|" + item.template.name + text2;
                            }
                            if (item.itemOption[j].param == 4)
                            {
                                text = text + "|7|1|" + item.template.name + text2;
                            }
                        }
                    }
                }
                if (!flag)
                {
                    text = text + "|0|1|" + item.template.name + text2;
                }
                if (item.itemOption != null)
                {
                    for (int k = 0; k < item.itemOption.Length; k++)
                    {
                        if (item.itemOption[k].optionTemplate.name.StartsWith("$") ? true : false)
                        {
                            empty = item.itemOption[k].getOptiongColor();
                            if (item.itemOption[k].param == 1)
                            {
                                text = text + "\n|1|1|" + empty;
                            }
                            if (item.itemOption[k].param == 0)
                            {
                                text = text + "\n|0|1|" + empty;
                            }
                            continue;
                        }
                        empty = item.itemOption[k].getOptionString();
                        if (!empty.Equals(string.Empty) && item.itemOption[k].optionTemplate.id != 72)
                        {
                            if (item.itemOption[k].optionTemplate.id == 102)
                            {
                                cp.starSlot = (sbyte)item.itemOption[k].param;
                                Res.outz("STAR SLOT= " + cp.starSlot);
                            }
                            else if (item.itemOption[k].optionTemplate.id == 107)
                            {
                                cp.maxStarSlot = (sbyte)item.itemOption[k].param;
                                Res.outz("STAR SLOT= " + cp.maxStarSlot);
                            }
                            else
                            {
                                text = text + "\n|1|1|" + empty;
                            }
                        }
                    }
                }
                if (currItem.template.strRequire > 1)
                {
                    string text3 = mResources.pow_request + ": " + currItem.template.strRequire;
                    if (currItem.template.strRequire > Char.myCharz().cPower)
                    {
                        text = text + "\n|3|1|" + text3;
                        string text4 = text;
                        text = text4 + "\n|3|1|" + mResources.your_pow + ": " + Char.myCharz().cPower;
                    }
                    else
                    {
                        text = text + "\n|6|1|" + text3;
                    }
                }
                else
                {
                    text += "\n|6|1|";
                }
                currItem.compare = getCompare(currItem);
                text += "\n--";
                text = text + "\n|6|" + item.template.description;
                if (!item.reason.Equals(string.Empty))
                {
                    if (!item.template.description.Equals(string.Empty))
                    {
                        text += "\n--";
                    }
                    text = text + "\n|2|" + item.reason;
                }
                if (cp.maxStarSlot > 0)
                {
                    text += "\n\n";
                }
                popUpDetailInit(cp, text);
            }
            catch (Exception ex)
            {
                Res.outz("ex " + ex.StackTrace);
            }
        }

        public void popUpDetailInit(ChatPopup cp, string chat)
        {
            int x = X + 6 + 15;
            int y = Y + H / 4 + 37 + 85;
            cp.isClip = false;
            cp.sayWidth = 180;
            cp.cx = x + (2 + 34 + 4) * selected - 2;
            cp.says = mFont.tahoma_7_red.splitFontArray(chat, cp.sayWidth - 10);
            cp.delay = 10000000;
            cp.c = null;
            cp.sayRun = 7;
            cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
            if (cp.ch > GameCanvas.h - 80)
            {
                cp.ch = GameCanvas.h - 80;
                cp.lim = cp.says.Length * 12 - cp.ch + 17;
                if (cp.lim < 0)
                {
                    cp.lim = 0;
                }
                ChatPopup.cmyText = 0;
                cp.isClip = true;
            }
            cp.cy = y - cp.ch - 5 - 28;
            cp.mH = 0;
            cp.strY = 10;
        }

        public int getCompare(Item item)
        {
            if (item == null)
            {
                return -1;
            }
            if (item.isTypeBody())
            {
                if (item.itemOption == null)
                {
                    return -1;
                }
                ItemOption itemOption = item.itemOption[0];
                if (itemOption.optionTemplate.id == 22)
                {
                    itemOption.optionTemplate = GameScr.gI().iOptionTemplates[6];
                    itemOption.param *= 1000;
                }
                if (itemOption.optionTemplate.id == 23)
                {
                    itemOption.optionTemplate = GameScr.gI().iOptionTemplates[7];
                    itemOption.param *= 1000;
                }
                Item item2 = null;
                for (int i = 0; i < Char.myCharz().arrItemBody.Length; i++)
                {
                    Item item3 = Char.myCharz().arrItemBody[i];
                    if (itemOption.optionTemplate.id == 22)
                    {
                        itemOption.optionTemplate = GameScr.gI().iOptionTemplates[6];
                        itemOption.param *= 1000;
                    }
                    if (itemOption.optionTemplate.id == 23)
                    {
                        itemOption.optionTemplate = GameScr.gI().iOptionTemplates[7];
                        itemOption.param *= 1000;
                    }
                    if (item3 != null && item3.itemOption != null && item3.template.type == item.template.type)
                    {
                        item2 = item3;
                        break;
                    }
                }
                if (item2 == null)
                {
                    Res.outz("5");
                    //isUp = true;
                    return itemOption.param;
                }
                int num = ((item2 == null || item2.itemOption == null) ? itemOption.param : (itemOption.param - item2.itemOption[0].param));
                if (num < 0)
                {
                    //isUp = false;
                }
                else
                {
                    //isUp = true;
                }
                return num;
            }
            return 0;
        }

        public void paintFrame(mGraphics g, int x, int y, int w, int h)
        {
            g.setColor(6702080);
            g.fillRect(x-1, y - 1, w + 2, h + 2);
            g.setColor(9993045);
            g.fillRect(x, y, w, h);
        }

        public void paintFrame2(mGraphics g, int x, int y, int w, int h)
        {
            g.setColor(14338484); 
            g.fillRect(x - 2, y - 2, w + 4, h + 4);
            g.setColor(15723751);
            g.fillRect(x, y, w, h);
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
            cp = null;
        }
    }

}
