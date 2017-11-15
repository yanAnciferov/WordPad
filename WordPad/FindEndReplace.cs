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
    public partial class FindEndReplace : Form
    {
        public FindEndReplace()
        {
            InitializeComponent();
            ChekStateFindText();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public event FindEvent Find;
        public event FindReplaceEvent Replaced;
        public event FindReplaceEvent ReplacedAll;

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

        private void Replace_Click(object sender, EventArgs e)
        {
            Replaced(this,
                new FindReplaceEventArgs
                {
                    IsOnlyFullWord = OnlyFullWord.Checked,
                    IsWithRegister = WithRegister.Checked,
                    FindValue = FindText.Text,
                    ReplaceValue = ReplaceText.Text
                });
        }

        private void ReplaceAll_Click(object sender, EventArgs e)
        {
            ReplacedAll(this,
               new FindReplaceEventArgs
               {
                   IsOnlyFullWord = OnlyFullWord.Checked,
                   IsWithRegister = WithRegister.Checked,
                   FindValue = FindText.Text,
                   ReplaceValue = ReplaceText.Text
               });
        }

        private void FindText_TextChanged(object sender, EventArgs e)
        {
            ChekStateFindText();
        }

        private void ChekStateFindText()
        {
            if (FindText.TextLength == 0)
            {
                ButtonPanel.Enabled = false;
            }
            else ButtonPanel.Enabled = true;
        }
    }
}
