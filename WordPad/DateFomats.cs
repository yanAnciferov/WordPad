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
    public partial class DateFomats : Form
    {
        public DateFomats()
        {
            InitializeComponent();

            foreach (var item in DateTime.Now.GetDateTimeFormats())
            {
                List.Items.Add(item);
            }
            List.SelectedIndex = 0;
        }

        public string SelectedFormat {
            get
            {
                return (string)List.SelectedItem;
            }
        }
    }
}
