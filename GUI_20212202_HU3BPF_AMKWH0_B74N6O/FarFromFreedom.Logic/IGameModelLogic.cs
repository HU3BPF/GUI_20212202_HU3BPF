using FarFromFreedom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Logic
{
    public interface IGameModelLogic
    {
        IGameModel[,] Map { get; set; }
    }
}
