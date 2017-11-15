using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPad
{
    public partial class FindWindow : Form
    {
      
        public FindWindow()
        {
            InitializeComponent();
            ChekStateFindText();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public event FindEvent Find;

        private void FindNext_Click(object sender, EventArgs e)
        {
            Find(this,
                new FindEventArgs
                {
                    IsOnlyFullWord = OnlyFullWord.Checked,
                    IsWithRegister = WithRegister.Checked,
                    FindValue = FindText.Text
                });
        }

        private void ChekStateFindText()
        {
            if (FindText.TextLength == 0)
            {
                FindNext.Enabled = false;
            }
            else FindNext.Enabled = true;
        }

        private void FindText_TextChanged(object sender, EventArgs e)
        {
            ChekStateFindText();
        }
    }

}
