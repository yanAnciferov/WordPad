using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPad
{
    public partial class Form1 : Form
    {
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveFileButton.PerformClick();
            }

          
        }

        private void ribbonButton6_Click(object sender, EventArgs e)
        {
            FontCombo.SelectAll();
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
            int posCurrent = FontCombo.SelectionStart + FontCombo.SelectionLength;

            RichTextBoxFinds argFind = RichTextBoxFinds.None;
            if (args.IsOnlyFullWord && args.IsWithRegister)
                argFind = RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase;
            else if (args.IsOnlyFullWord)
                argFind = RichTextBoxFinds.WholeWord;
            else if (args.IsWithRegister)
                argFind = RichTextBoxFinds.MatchCase;



            int posFind = FontCombo.Find(
                args.FindValue,
                posCurrent,
                argFind
                );

            if (posFind == -1)
            {
                FontCombo.SelectionStart = 0;
                FontCombo.SelectionLength = 0;
                MessageBox.Show("Достигнут конец документа.");
                return false;
            }

            FontCombo.Select(posFind, args.FindValue.Length);
            return true;
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {

            CheckStateMainTextBox();
        }

        private void CheckStateMainTextBox()
        {
            if (FontCombo.TextLength == 0)
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
            if (FontCombo.SelectedText.ToLower() == args.FindValue.ToLower())
            {

                FontCombo.SelectedText = args.ReplaceValue;
            }
            return FindEventHandler(obj, args);
        }

        private bool ReplaceAllEventHandler(object obj, FindReplaceEventArgs args)
        {
            while (ReplaceEventHandler(obj, args)) { }
            return false;
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            FontCombo.Paste();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (FontCombo.SelectionLength > 0)
            {
                Clipboard.SetText(FontCombo.SelectedText);
            }
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            Copy_Click(sender, e);
            FontCombo.SelectedText = "";

        }

        private void alignCenter_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionAlignment = HorizontalAlignment.Center;

            currentAlignCheked.Checked = false;
            alignCenter.Checked = true;
            currentAlignCheked = alignCenter;

        }

        private void alignRigth_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionAlignment = HorizontalAlignment.Right;

            currentAlignCheked.Checked = false;
            alignRigth.Checked = true;
            currentAlignCheked = alignRigth;

        }

        private void alignLeft_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionAlignment = HorizontalAlignment.Left;

            currentAlignCheked.Checked = false;
            alignLeft.Checked = true;
            currentAlignCheked = alignLeft;

        }

      

        private void StyleText_Click(object sender, EventArgs e)
        {
            var btn = sender as RibbonButton;
            btn.Checked = !btn.Checked;
            UpdateSelectTextStyle();
            FontOptionChanged();
        }

        FontStyle GetStyleText()
        {
            FontStyle newStyle = FontStyle.Regular;
            if (ItalicText.Checked == true)
            {
                newStyle |= FontStyle.Italic;
            }

            if (Bold.Checked == true)
            {
                newStyle |= FontStyle.Bold;
            }

            if (UnderlineText.Checked == true)
            {
                newStyle |= FontStyle.Underline;
            }

            if (StrikeOut.Checked == true)
            {
                newStyle |= FontStyle.Strikeout;
            }

            return newStyle;
        }

        private void UpdateSelectTextStyle()
        {
            int start = FontCombo.SelectionStart;
            int length = FontCombo.SelectionLength;
            using (RichTextBox tmpRB = new RichTextBox())
            {
                tmpRB.SelectAll();
                tmpRB.SelectedRtf = FontCombo.SelectedRtf;
               
                for (int i = 0; i < tmpRB.TextLength; ++i)
                {
                    tmpRB.Select(i, 1);
                    tmpRB.SelectionFont = new Font(tmpRB.SelectionFont, GetStyleText());
                }
                tmpRB.SelectAll();
                FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
                FontCombo.SelectedRtf = tmpRB.SelectedRtf;
               
            }

            FontCombo.SelectionStart = start;
            FontCombo.SelectionLength = length;
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
        }

       

        private void text_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "txt files (*.txt)|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, FontCombo.Text);
            }
        }

        private void rtf_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "rtf files (*.rtf)|*.rtf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, FontCombo.Rtf);
            }
        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                if (!SaveFile())
                    return;
            }

            FontCombo.Rtf = "";
            isSave = false;
            isChanged = false;
            path = "";
            Text = "Документ - WordPad";
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            if (isSave == false)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (save.FilterIndex == 1)
                        File.WriteAllText(save.FileName, FontCombo.Text);
                    else if (save.FilterIndex == 2)
                        File.WriteAllText(save.FileName, FontCombo.Rtf);

                    isSave = true;
                    path = save.FileName;
                }
            }
            else
            {
                if (path.Split('.').Last() == "txt")
                {
                    File.WriteAllLines(path, FontCombo.Lines, Encoding.UTF8);
                }
                else if (path.Split('.').Last() == "rtf")
                {
                    File.WriteAllText(path, FontCombo.Rtf);
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {


            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.FileName == path)
                    return;

                if (FontCombo.CanUndo)
                {
                    if (!SaveFile())
                    {
                        return;
                    }
                }

                try
                {
                    FileInfo file = new FileInfo(open.FileName);

                    if (open.FilterIndex == 1)
                    {
                        FontCombo.Text = File.ReadAllText(open.FileName, Encoding.Default);
                    }
                    if (open.FilterIndex == 2)
                        FontCombo.Rtf = File.ReadAllText(open.FileName, Encoding.Default);

                    path = open.FileName;
                    isChanged = false;
                    isSave = true;
                    Text = file.Name.Split('.')[0] + " - WordPad";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        bool SaveFile()
        {
            var result = MessageBox.Show("Вы хотите сохранить изменения в файле " + path + "?", "WordPad", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Cancel:
                    return false;
                case DialogResult.Yes:
                    SaveFileButton_Click(null, null);
                    break;
                default:
                    break;
            }
            return true;
        }


    }
}
