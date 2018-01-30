using System;
using System.IO;
using System.Windows.Forms;
using Fiddler;
using System.Collections.Generic;

namespace onSoft
{
    public partial class UserControl1 : UserControl
    {
        private Session[] _sessionsData;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            _sessionsData = ((Session[]) e.Data.GetData("Fiddler.Session[]"));

            var tawafConfig = GenerateCode(_sessionsData);
            dfsThirtyTwoCode.Text = tawafConfig["ThirtyTwoCode"];
            dfsRep_Mofa_Wrapper.Text = tawafConfig["Rep_Mofa_Wrapper"];
            dfsV_Mut_Groups_Wrapper.Text = tawafConfig["V_Mut_Groups_Wrapper"];
            dfsRep_Mofa_BoxVer.Text = tawafConfig["Rep_Mofa_BoxVer"];
            dfsv_Mut_Groups_CodeToGetGroups.Text = tawafConfig["v_Mut_Groups_CodeToGetGroups"];
            dfsjavautilArrayList.Text = tawafConfig["javautilArrayList"];
            dfsjavalangString.Text = tawafConfig["javalangString"];




        }

        private Dictionary<string,string> GenerateCode(Session[] inputsession)
        {
            var cg = new TawafHelper();



                return 
                    cg.GetTawafConfig(
                        inputsession); 


        }

        private void UserControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent("Fiddler.Session[]") ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void UserControl1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent("Fiddler.Session[]") ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            
        }

    }
}