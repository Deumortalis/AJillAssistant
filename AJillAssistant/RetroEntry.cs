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
    public partial class RetroEntry : Form
    {
        public enum Type
        {
            Good = 0,
            Bad,
            Action,
            Question,
            COUNT,
        }

        readonly string[] c_typeNames = { "What went Well?", "What could be Improved?", "Action Item", "Question" };

        Type m_currentType;

        public RetroEntry(Type mytype)
        {
            InitializeComponent();

            m_currentType = mytype;
            Text = c_typeNames[(int)mytype];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
