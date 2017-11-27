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

        FindWindow finder = null;
        FindEndReplace findeReplacer = null;
        RibbonButton currentAlignCheked = null;

        bool isSave = false;
        bool isChanged = false;
        string path;

        public Form1()
        {
            InitializeComponent();
            CheckStateMainTextBox();
            MainTextBox_SelectionChanged(null, null);
            FontCombo.Text = "Отображаемые диалоговые окна и команды меню могут отличаться от описанных в справке в зависимости от текущих настроек или редации Visual Studio. Чтобы изменить параметры, в меню Сервис выберите команду Импорт и экспорт параметров. Дополнительные сведения см. в разделе Customizing Development Settings in Visual Studio.";
            List<string> values = new List<string>();
            values.AddRange(new string[]{
                "8","9","10","11","12","14","16","18","20","22","24","26"
                ,"28","36","48","72"
            });

            foreach (var item in values)
            {
                RibbonButton ribbonItem = new RibbonButton();
                ribbonItem.Text = item;
                ribbonItem.MaxSizeMode = RibbonElementSizeMode.Medium;
                FontSizeCombo.DropDownItems.Add(ribbonItem);
            }

            Form1_Resize(null, null);
            FontCombo.Font = null;
            currentAlignCheked = alignLeft;
            currentAlignCheked.Checked = true;
            FontCombo_Click(null, null);

            KeyPreview = true;
            KeyDown += Form1_KeyDown;

            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily font in fonts.Families)
            {
                
                RibbonButton ribbonItem = new RibbonButton();
                ribbonItem.Text = font.Name;
                ribbonItem.Click += FontItem_Click;
                FontComboBox.DropDownItems.Add(ribbonItem);
            }
        }

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
            if (Clipboard.ContainsText())
                FontCombo.SelectedText = Clipboard.GetText();
            

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

        private void FontItem_Click(object sender, EventArgs e)
        {
            var btn = sender as RibbonButton;
            using (RichTextBox tmpRB = new RichTextBox())
            {
                tmpRB.SelectAll();
                tmpRB.SelectedRtf = FontCombo.SelectedRtf;
                for (int i = 0; i < tmpRB.TextLength; ++i)
                {
                    tmpRB.Select(i, 1);
                    tmpRB.SelectionFont = new Font(btn.Text, tmpRB.SelectionFont.Size, tmpRB.SelectionFont.Style);
                }
                tmpRB.SelectAll();
                FontCombo.SelectedRtf = tmpRB.SelectedRtf;
            }
        }

        private void MainTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (FontCombo.SelectedText.Length == 0)
            {
                Copy.Enabled = false;
                Cut.Enabled = false;
            }
            else
            {
                Copy.Enabled = true;
                Cut.Enabled = true;
            }


            if (FontCombo.SelectionFont != null)
            {
                if (FontCombo.SelectionFont.Size.ToString() == FontSizeCombo.TextBoxText
                    || FontSizeCombo.TextBoxText == ""
                    || FontCombo.SelectionLength == 0
                    )
                {
                    if(FontSizeCombo.TextBoxText != FontCombo.SelectionFont.Size.ToString())
                        FontSizeCombo.TextBoxText = FontCombo.SelectionFont.Size.ToString();
                    FontComboBox.TextBoxText = FontCombo.SelectionFont.Name;

                }
                else
                {
                    FontSizeCombo.TextBoxText = "";
                }


                ItalicText.Checked = FontCombo.SelectionFont.Italic;
                Bold.Checked = FontCombo.SelectionFont.Bold;
                UnderlineText.Checked = FontCombo.SelectionFont.Underline;
                StrikeOut.Checked = FontCombo.SelectionFont.Strikeout;
            }
            else
            {
                FontSizeCombo.TextBoxText = "";
                FontComboBox.TextBoxText = "";
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int margin = ((Width - FontCombo.Width) / 2) - 10;
            if (margin < 0)
            {
                FontCombo.Width = Width - 16;
                FontCombo.Location = new Point(0, 0);
            }
            else
            {
                FontCombo.Width = 820;
                FontCombo.Location = new Point(margin, 0);
            }
            FontCombo.Height = WorkPanel.Height;

            if (Width < 500)
            {
                WorkPanel.Height = Height;
                ribbon1.Visible = false;
                FontCombo.Height = WorkPanel.Height;
            }
            else
            {
                ribbon1.Visible = true;
                WorkPanel.Height = Height - ribbon1.Height;
            }
        }

        private void FontSizeCombo_TextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                //Font fnt = new Font(FontCombo.SelectionFont.FontFamily, Int32.Parse(FontSizeCombo.TextBoxText), FontCombo.SelectionFont.Style);
                //FontCombo.SelectionFont = fnt;

                int start = FontCombo.SelectionStart;
                int length = FontCombo.SelectionLength;

                using (RichTextBox tmpRB = new RichTextBox())
                {
                    tmpRB.SelectAll();
                    tmpRB.SelectedRtf = FontCombo.SelectedRtf;
                    for (int i = 0; i < tmpRB.TextLength; ++i)
                    {
                        tmpRB.Select(i, 1);
                        tmpRB.SelectionFont = new Font(tmpRB.SelectionFont.FontFamily, float.Parse(FontSizeCombo.TextBoxText), tmpRB.SelectionFont.Style);
                    }
                    tmpRB.SelectAll();
                    FontCombo.SelectedRtf = tmpRB.SelectedRtf;
                }
              


            }
            catch (Exception ex) {
               // MessageBox.Show(ex.Message);
            }

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

        private void FontCombo_Click(object sender, EventArgs e)
        {
            currentAlignCheked.Checked = false;
            switch (FontCombo.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    alignLeft.Checked = true;
                    currentAlignCheked = alignLeft;
                    break;
                case HorizontalAlignment.Right:
                    alignRigth.Checked = true;
                    currentAlignCheked = alignRigth;
                    break;
                case HorizontalAlignment.Center:
                    alignCenter.Checked = true;
                    currentAlignCheked = alignCenter;
                    break;
                default:
                    break;
            }


        }

        private void alignJustify_Click(object sender, EventArgs e)
        {
        }

        private void Bold_Click(object sender, EventArgs e)
        {
            Bold.Checked = !Bold.Checked;
            var font = FontCombo.SelectionFont;
            Font fnt = new Font(font, GetStyleText());
            FontCombo.SelectionFont = fnt;
            
        }

        private void ItalicText_Click(object sender, EventArgs e)
        {
            ItalicText.Checked = !ItalicText.Checked;


            var font = FontCombo.SelectionFont;
            Font fnt = new Font(font, GetStyleText());
            FontCombo.SelectionFont = fnt;
            
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

        private void UnderlineText_Click(object sender, EventArgs e)
        {
            UnderlineText.Checked = !UnderlineText.Checked;


            var font = FontCombo.SelectionFont;
            Font fnt = new Font(font, GetStyleText());
            FontCombo.SelectionFont = fnt;
            
        }

        private void StrikeOut_Click(object sender, EventArgs e)
        {
            StrikeOut.Checked = !StrikeOut.Checked;


            var font = FontCombo.SelectionFont;
            Font fnt = new Font(font, GetStyleText());
            FontCombo.SelectionFont = fnt;
           

        }

        private void Superscript_Click(object sender, EventArgs e)
        {
            // Get the selected rich text data and selected character data
            string selectedRtf = FontCombo.SelectedRtf;
            string selectedText = FontCombo.SelectedText;

            // Now lets insert \super
            selectedRtf = selectedRtf.Insert(selectedRtf.IndexOf(selectedText), "\\super");

            // Now set the Rtf back to the control
            FontCombo.SelectedRtf = selectedRtf;
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
                if(path.Split('.').Last() == "txt")
                {
                    File.WriteAllLines(path, FontCombo.Lines,Encoding.UTF8);
                }else if (path.Split('.').Last() == "rtf")
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

        private void FontDown_Click(object sender, EventArgs e)
        {
            float currentValue = float.Parse(FontSizeCombo.TextBoxText);

            if (currentValue == 1)
                return;

            if (currentValue <= 8 && currentValue > 1)
                currentValue--;
            else if (currentValue == 80)
                currentValue -= 8;
            else if (currentValue >= 90)
            {
                if (currentValue % 10 == 0)
                    currentValue -= 10;
                else currentValue -= currentValue % 10;
            }
            else
            {
                float prevValue = 8;
                foreach (var item in FontSizeCombo.DropDownItems)
                {
                    if (float.Parse(item.Text) == currentValue)
                    {
                        FontSizeCombo.TextBoxText = prevValue.ToString();
                        return;
                    }
                    else if (float.Parse(item.Text) <= currentValue)
                        prevValue = float.Parse(item.Text);
                    else
                    {
                        FontSizeCombo.TextBoxText = prevValue.ToString();
                        return;
                    }
                }
            }

            FontSizeCombo.TextBoxText = currentValue.ToString();
        }

        private void FontUp_Click(object sender, EventArgs e)
        {
            float currentValue = float.Parse(FontSizeCombo.TextBoxText);

            if (currentValue == 1630)
                return;

            if (currentValue <= 8 && currentValue > 1)
                currentValue++;
            else if (currentValue == 72)
            {
                currentValue += 8;
            }
            else if (currentValue >= 80)
            {
                if (currentValue % 10 == 0)
                    currentValue += 10;
                else currentValue += 10 - currentValue % 10;
            }
            else
            {
                bool flag = false;
                foreach (var item in FontSizeCombo.DropDownItems)
                {
                    if (flag)
                    {
                        currentValue = float.Parse(item.Text);
                        break;
                    }

                    if (float.Parse(item.Text) == currentValue)
                    {
                        flag = true;
                    }
                    if (float.Parse(item.Text) > currentValue)
                    {
                        currentValue = float.Parse(item.Text);
                        break;
                    }
                }
            }

            FontSizeCombo.TextBoxText = currentValue.ToString();
        }

        //private void Subscript_Click(object sender, EventArgs e)
        //{
        //    // Get the selected rich text data and selected character data
        //    string selectedRtf = FontCombo.SelectedRtf;
        //    string selectedText = FontCombo.SelectedText;

        //    // Now lets insert \super
        //    selectedRtf = selectedRtf.Insert(selectedRtf.IndexOf(selectedText), "\\sub");

        //    // Now set the Rtf back to the control
        //    FontCombo.SelectedRtf = selectedRtf;
        //}
    }
}
