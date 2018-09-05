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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void goodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetroEntry re = new RetroEntry(RetroEntry.Type.Good);
            re.ShowDialog();
        }

        private void badToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetroEntry re = new RetroEntry(RetroEntry.Type.Bad);
            re.ShowDialog();
        }

        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetroEntry re = new RetroEntry(RetroEntry.Type.Action);
            re.ShowDialog();
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetroEntry re = new RetroEntry(RetroEntry.Type.Question);
            re.ShowDialog();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeedbackEntry fe = new FeedbackEntry();
            fe.ShowDialog();
        }
    }
}
