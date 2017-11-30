using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPad
{
    public class Tab
    {
        public Tab()
        {
            _page = new TabPage();
            _textBox = new RichTextBox();
            _page.Controls.Add(_textBox);
            _textBox.Location = _page.Location;
            _textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            _textBox.Width = _page.Width;
        }

        public Tab(string tabName): this()
        {
            _page.Text = tabName;
        }

        public Tab(TabPage page, RichTextBox textBox, string tabName)
        {
            _page = page;
            _textBox = textBox;
            _page.Controls.Add(_textBox);
            _textBox.Location = _page.Location;
            _textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            _textBox.Width = _page.Width;
            _page.Text = tabName;
        }

        TabPage _page;
        RichTextBox _textBox;

        void SetName(string tabName)
        {
            _page.Text = tabName;
        }

        public TabPage Page { get { return _page; } }
        public RichTextBox TextBox { get { return _textBox; } }

    }
}
