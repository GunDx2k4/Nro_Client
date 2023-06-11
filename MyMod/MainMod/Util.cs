using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UnityEngine;

namespace MyMod.MainMod
{
    public class Util
    {
        public static void openUIPet()
        {
            if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
            {
                GameCanvas.panel2 = new Panel();
                GameCanvas.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
                GameCanvas.panel2.setTypeBodyOnly();
                GameCanvas.panel2.show();
                GameCanvas.panel.setTypePetMain();
                GameCanvas.panel.show();
            }
            else
            {
                GameCanvas.panel.tabName[21] = mResources.petMainTab;
                GameCanvas.panel.setTypePetMain();
                GameCanvas.panel.show();
            }
        }

        public static void saveResources(string filename, Texture2D texture2D)
        {
            string[] array = filename.Split('/');
            var dirPath = $"Resources/{Res.join(array, "/", 1)}";
            byte[] bytes = texture2D.EncodeToPNG();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            File.WriteAllBytes(dirPath + array[array.Length - 1] + ".png", bytes);
        }
        public static void draw2ColorBD(mGraphics g, string text1, string text2, mFont font1, mFont font2, int x, int y)
        {

            font1.drawString(g, text1, x, y, mFont.LEFT, mFont.tahoma_7_grey);
            var width1 = font1.getWidth(text1);
            font2.drawString(g, text2, x + width1, y, mFont.LEFT, mFont.tahoma_7_grey);
        }
        public static void draw2Color(mGraphics g, string text1, string text2, mFont font1, mFont font2, int x, int y)
        {

            font1.drawString(g, text1, x, y, mFont.LEFT);
            var width1 = font1.getWidth(text1);
            font2.drawString(g, text2, x + width1, y, mFont.LEFT);
        }
    }
}
