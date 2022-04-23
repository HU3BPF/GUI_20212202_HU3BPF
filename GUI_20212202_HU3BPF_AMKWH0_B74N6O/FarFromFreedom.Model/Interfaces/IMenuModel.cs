using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Model
{
    public interface IMenuModel : IModel
    {
        bool IsWelcomePage { get; set; }
    }
}
