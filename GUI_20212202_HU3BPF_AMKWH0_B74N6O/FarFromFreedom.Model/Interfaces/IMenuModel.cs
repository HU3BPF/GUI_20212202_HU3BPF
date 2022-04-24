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
        bool CanContiue { get; set; }
        int NewGameWidth { get; }
        int NewGameHeight { get; }
        double NewGameOpacity { get; set; }
        int ContinueWidth { get; }
        int ContinueHeight { get; }
        double ContinueOpacity { get; set; }
        int OptionsWidth { get; }
        int OptionsHeight { get; }
        double OptionsOpacity { get; set; }
        int StatsWidth { get; }
        int StatsHeight { get; }
        double StatsOpacity { get; set; }
        int ExitGameWidth { get; }
        int ExitGameHeight { get; }
        double ExitGameOpacity { get; set; }
        int SelectedIndex { get; set; }
        public void ResetParams();

    }
}
