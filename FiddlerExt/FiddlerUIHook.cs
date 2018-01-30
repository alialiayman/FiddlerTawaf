using System.Windows.Forms;
using Fiddler;

[assembly: RequiredVersion("5.0.20173.50948")]

namespace onSoft
{
    public class FiddlerUIHook : IFiddlerExtension
    {
        public void OnLoad()
        {
            var oPage = new TabPage("Tawaf#") {ImageIndex = (int) SessionIcons.Script};
            //This sets the Icon image used in the tab
            var oView = new UserControl1 {Dock = DockStyle.Fill}; //UserControl1 is a Windows Forms UserControl class
            oPage.Controls.Add(oView);
            FiddlerApplication.UI.tabsViews.TabPages.Add(oPage);
        }

        public void OnBeforeUnload()
        {
           
        }
    }
}