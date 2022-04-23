using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Model
{
    public class MenuModel : IMenuModel
    {
        private bool isWelcomePage;

        public MenuModel()
        {
        }

        public bool IsWelcomePage
        {
            get { return isWelcomePage; }
            set { isWelcomePage = value; }
        }

    }
}
