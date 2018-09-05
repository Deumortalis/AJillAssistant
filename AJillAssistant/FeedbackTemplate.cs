using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJillAssistant
{
    public partial class FeedbackTemplate : Form
    {
        public string ReturnResult = "";

        public FeedbackTemplate()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (tbcTemplateSelect.SelectedTab == tabRecognition)
            {
                ReturnResult = "I was " + cmbRecEmotion.Text +
                    " when you " + txtRecBehaviour.Text +
                    " because " + txtRecImpact.Text;
            }
            else if(tbcTemplateSelect.SelectedTab == tabImprovement)
            {
                ReturnResult = "I was " + cmbImpEmotion.Text +
                    " when you " + txtImpBehaviour.Text +
                    " because " + txtImpImpact.Text +
                    " and if you " + txtImpDesired.Text +
                    " then " + txtImpResult.Text;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
