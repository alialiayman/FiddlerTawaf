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
            dfsThirtyTwoCode.Text = tawafConfig.ContainsKey("ThirtyTwoCode") ? tawafConfig["ThirtyTwoCode"] : string.Empty;
            dfsRep_Mofa_Wrapper.Text = tawafConfig.ContainsKey("Rep_Mofa_Wrapper") ? tawafConfig["Rep_Mofa_Wrapper"] : string.Empty;
            dfsV_Mut_Groups_Wrapper.Text = tawafConfig.ContainsKey("V_Mut_Groups_Wrapper") ? tawafConfig["V_Mut_Groups_Wrapper"] : string.Empty;
            dfsRep_Mofa_BoxVer.Text = tawafConfig.ContainsKey("Rep_Mofa_BoxVer") ? tawafConfig["Rep_Mofa_BoxVer"] : string.Empty;
            dfsv_Mut_Groups_CodeToGetGroups.Text = tawafConfig.ContainsKey("v_Mut_Groups_CodeToGetGroups") ? tawafConfig["v_Mut_Groups_CodeToGetGroups"] : string.Empty;
            dfsjavautilArrayList.Text = tawafConfig.ContainsKey("javautilArrayList") ? tawafConfig["javautilArrayList"] : string.Empty;
            dfsjavalangString.Text = tawafConfig.ContainsKey("javalangString") ? tawafConfig["javalangString"] : string.Empty;



            dfsSQL.Text = "Update [dbo].[TawafConfig] set IsEnabled = 0;" + Environment.NewLine +
                " INSERT INTO [dbo].[TawafConfig] ([ThirtyTwoCode],[Rep_Mofa_Wrapper],[V_Mut_Groups_Wrapper],[Rep_Mofa_BoxVer],[v_Mut_Groups_CodeToGetGroups],[IsEnabled],[javautilArrayList],[javalangString]) VALUES ('" +
                dfsThirtyTwoCode.Text + "','" +
dfsRep_Mofa_Wrapper.Text + "','" +
dfsV_Mut_Groups_Wrapper.Text + "','" +
dfsRep_Mofa_BoxVer.Text + "','" +
dfsv_Mut_Groups_CodeToGetGroups.Text + "',1,'" +
dfsjavautilArrayList.Text + "','" +
dfsjavalangString.Text + "');";



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