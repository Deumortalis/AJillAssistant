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
    public partial class Recipients : Form
    {
        public string ReturnResult = "";

        public Recipients(string existing)
        {
            InitializeComponent();

            string[] StartingList = existing.Split(',');

            // Add the options to the list
            Uri uri = new Uri(string.Format("http://{0}:{1}/recipients", "127.0.0.1", "8080"));
            HTTP.GetGETResponse(uri, (x) =>
            {
                string[] namelist = x.Split('\r');
                foreach (string name in namelist)
                {
                    string[] parts = name.Split(',');
                    lstRecipients.Items.Add(parts[0]);
                }

                // Select those that already exist - Add if don't
                foreach (string reci in StartingList)
                {
                    if (!lstRecipients.Items.Contains(reci))
                    {
                        lstRecipients.Items.Add(reci);
                    }
                    lstRecipients.SelectedItems.Add(reci);
                }
            });
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            ReturnResult = "";
            foreach (string reci in lstRecipients.SelectedItems)
            {
                if (ReturnResult != "")
                    ReturnResult += ",";
                ReturnResult += reci;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
