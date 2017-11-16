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
    public partial class Form1 : Form
    {
       
        FindWindow finder = null;
        FindEndReplace findeReplacer = null;
        public Form1()
        {
            InitializeComponent();
            CheckStateMainTextBox();
            MainTextBox_SelectionChanged(null, null);
            MainTextBox.Text = "Отображаемые диалоговые окна и команды меню могут отличаться от описанных в справке в зависимости от текущих настроек или редации Visual Studio. Чтобы изменить параметры, в меню Сервис выберите команду Импорт и экспорт параметров. Дополнительные сведения см. в разделе Customizing Development Settings in Visual Studio.";
        }

        private void ribbonButton6_Click(object sender, EventArgs e)
        {
            MainTextBox.SelectAll();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            if (finder == null)
            {
                finder = new FindWindow();
                finder.Find += FindEventHandler;
                finder.FormClosed += (s, args) => finder = null;
                finder.Show();
            }
            else
            {
                finder.BringToFront();
            }
        }

        private bool FindEventHandler(object obj, FindEventArgs args)
        {
            int posCurrent = MainTextBox.SelectionStart + MainTextBox.SelectionLength;

            RichTextBoxFinds argFind = RichTextBoxFinds.None;
            if (args.IsOnlyFullWord && args.IsWithRegister)
                argFind = RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase;
            else if (args.IsOnlyFullWord)
                argFind = RichTextBoxFinds.WholeWord;
            else if (args.IsWithRegister)
                argFind = RichTextBoxFinds.MatchCase;



            int posFind = MainTextBox.Find(
                args.FindValue,
                posCurrent,
                argFind
                );

            if (posFind == -1)
            {
                MainTextBox.SelectionStart = 0;
                MainTextBox.SelectionLength = 0;
                MessageBox.Show("Достигнут конец документа.");
                return false;
            }
            
            MainTextBox.Select(posFind, args.FindValue.Length);
            return true;
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckStateMainTextBox();
        }

        private void CheckStateMainTextBox()
        {
            if (MainTextBox.TextLength == 0)
            {
                Pravka.Enabled = false;
            }
            else
            {
                Pravka.Enabled = true;
            }
        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            
            if (findeReplacer == null)
            {
                findeReplacer = new FindEndReplace();
                findeReplacer.Replaced += ReplaceEventHandler;
                findeReplacer.Find += FindEventHandler;
                findeReplacer.ReplacedAll += ReplaceAllEventHandler;
                findeReplacer.FormClosed += (s, args) => findeReplacer = null;
                findeReplacer.Show();
            }
            else
            {
                findeReplacer.BringToFront();
            }
        }

        private bool ReplaceEventHandler(object obj, FindReplaceEventArgs args)
        {
           if(MainTextBox.SelectedText.ToLower() == args.FindValue.ToLower())
            {
                MainTextBox.SelectedText = args.ReplaceValue;
            }
            return FindEventHandler(obj,args);
        }

        private bool ReplaceAllEventHandler(object obj, FindReplaceEventArgs args)
        {
            while (ReplaceEventHandler(obj, args)) { }
            return false;
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                MainTextBox.SelectedText = Clipboard.GetText();


        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (MainTextBox.SelectionLength > 0)
            {
                Clipboard.SetText(MainTextBox.SelectedText);
            }
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            Copy_Click(sender, e);
            MainTextBox.SelectedText = "";
        }

        private void MainTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if(MainTextBox.SelectedText.Length == 0)
            {
                Copy.Enabled = false;
                Cut.Enabled = false;
            }
            else
            {
                Copy.Enabled = true;
                Cut.Enabled = true;
            }
        }
    }
}
