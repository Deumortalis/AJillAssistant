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
    public partial class FeedbackEntry : Form
    {
        public FeedbackEntry()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(string.Format("http://{0}:{1}/feedback", "127.0.0.1", "8080"));
            string message = txtRecipients.Text.Replace(';', ',') + ";" + txtFeedback.Text;
            HTTP.GetPOSTResponse(uri, message, (x) =>
            {

            });

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            FeedbackTemplate ft = new FeedbackTemplate();
            if (ft.ShowDialog() == DialogResult.OK)
            {
                txtFeedback.Text = ft.ReturnResult;
            }
        }

        private void btnRecipients_Click(object sender, EventArgs e)
        {
            Recipients rec = new Recipients(txtRecipients.Text);
            if(rec.ShowDialog() == DialogResult.OK)
            {
                txtRecipients.Text = rec.ReturnResult;
            }

        }
    }
}
