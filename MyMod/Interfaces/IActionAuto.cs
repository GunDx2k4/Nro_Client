using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMod.Interfaces
{
    public interface IActionAuto
    {
        void perform(int idAction);
        void setIsAuto(bool isAuto);
        bool getIsAuto();
    }

}
