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

        RichTextBox FontCombo;
        List<Tab> tabs = new List<Tab>();

        public Form1()
        {
            InitializeComponent();
            FontCombo = new RichTextBox();
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
                ribbonItem.Click += FontSizeComboButton_click;
                ribbonItem.Text = item;
                ribbonItem.MaxSizeMode = RibbonElementSizeMode.Medium;
                FontSizeCombo.DropDownItems.Add(ribbonItem);
            }

            //Form1_Resize(null, null);
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

            CreateTab("Новая вкладка");
            //CreateTab("Новая вкладка2");
            ribbonButton13.Enabled = false;
            ribbonButton8.Enabled = false;
            ribbonButton9.Enabled = false;
            ribbonButton12.Enabled = false;
            ribbonButton14.Enabled = false;
            alignJustify.Enabled = false;
        }


        private void CreateTab(string tabName)
        {
            RichTextBox rich = new RichTextBox();
            rich.Click += FontCombo_Click;
            rich.SelectionChanged += MainTextBox_SelectionChanged;
            rich.TextChanged += MainTextBox_TextChanged;
            rich.EnableAutoDragDrop = true;
            Tab newTab = new Tab(new TabPage(), rich, tabName);
            newTab.IsChanged = false;
            newTab.IsSave = false;
            newTab.Path = tabName;
            CreateTab(newTab);
        }

        private void CreateTab(Tab newTab)
        {

            if (TabGroup.TabPages.Count == 0)
            {
                CloseTab.Enabled = true;
                foreach (var item in MainTab.Panels)
                {
                    item.Enabled = true;
                }
                Save.Enabled = true;
                SaveAs.Enabled = true;
            }

            TabGroup.TabPages.Add(newTab.Page);
            tabs.Add(newTab);

            TabGroup.SelectedIndex = tabs.Count - 1;
            TabGroup_SelectedIndexChanged(null, null);
        }

        private void onSelectTab(Tab selectTab)
        {
            FontCombo = selectTab.TextBox;
            isChanged = selectTab.IsChanged;
            isSave = selectTab.IsSave;
            path = selectTab.Path;
            FontCombo.Focus();
            MainTextBox_SelectionChanged(null,null);
            MainTextBox_TextChanged(null,null);

           

        }


        public void FontOptionChanged()
        {
            FontFamily ff;
            float size;
            if (FontCombo.SelectionLength == 0)
            {

                ff = new FontFamily(FontComboBox.TextBoxText);
                size = float.Parse(FontSizeCombo.TextBoxText);
                FontCombo.SelectionFont = new Font(ff, size, GetStyleText());

            }

        }


        private void FontItem_Click(object sender, EventArgs e)
        {
            var btn = sender as RibbonButton;
            int start = FontCombo.SelectionStart;
            int length = FontCombo.SelectionLength;
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
                FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
                FontCombo.SelectedRtf = tmpRB.SelectedRtf;



               

            }

            FontCombo.SelectionStart = start;
            FontCombo.SelectionLength = length;
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
            FontComboBox.TextBoxText = btn.Text;

            FontOptionChanged();
        }

        private void MainTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (FontCombo.SelectedText.Length == 0)
            {
                Cop.Enabled = false;
                Cu.Enabled = false;
            }
            else
            {
                if(Cop.Enabled != true)
                    Cop.Enabled = true;
                if(Cu.Enabled != true)
                    Cu.Enabled = true;
            }


            if (FontCombo.SelectionFont != null)
            {
                if (FontCombo.SelectionFont.Size.ToString() == FontSizeCombo.TextBoxText
                    || (FontSizeCombo.TextBoxText == "" && FontCombo.SelectionFont.Size.ToString() == FontSizeCombo.TextBoxText)
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

                if(ItalicText.Checked != FontCombo.SelectionFont.Italic)
                    ItalicText.Checked = FontCombo.SelectionFont.Italic;
                if (Bold.Checked != FontCombo.SelectionFont.Bold)
                    Bold.Checked = FontCombo.SelectionFont.Bold;
                if (UnderlineText.Checked != FontCombo.SelectionFont.Underline)
                    UnderlineText.Checked = FontCombo.SelectionFont.Underline;
                if (StrikeOut.Checked != FontCombo.SelectionFont.Strikeout)
                    StrikeOut.Checked = FontCombo.SelectionFont.Strikeout;
                
            }
            else
            {
                chekStyleSelect();
                FontSizeCombo.TextBoxText = "";
                FontComboBox.TextBoxText = "";
            }

        }

        void chekStyleSelect()
        {

            bool isItalic = true;
            bool isBold = true;
            bool isUnderline= true;
            bool isStrike = true;
            int start = FontCombo.SelectionStart;
            int length = FontCombo.SelectionLength;
            using (RichTextBox tmpRB = new RichTextBox())
            {
                tmpRB.SelectAll();
                tmpRB.SelectedRtf = FontCombo.SelectedRtf;
                for (int i = 0; i < tmpRB.TextLength; ++i)
                {
                    tmpRB.Select(i, 1);
                    if (isBold == true)
                    {
                       isBold = Convert.ToBoolean(tmpRB.SelectionFont.Style & FontStyle.Bold);
                    }

                    if (isItalic == true)
                    {
                        isItalic = Convert.ToBoolean(tmpRB.SelectionFont.Style & FontStyle.Italic);
                    }

                    if (isUnderline == true)
                    {
                        isUnderline = Convert.ToBoolean(tmpRB.SelectionFont.Style & FontStyle.Underline);
                    }

                    if (isStrike == true)
                    {
                        isStrike = Convert.ToBoolean(tmpRB.SelectionFont.Style & FontStyle.Strikeout);
                    }
                }
            }

            if(isItalic != ItalicText.Checked)
                ItalicText.Checked = isItalic;
            if (isBold != Bold.Checked)
                Bold.Checked = isBold;
            if (isUnderline != UnderlineText.Checked)
                UnderlineText.Checked = isUnderline;
            if (isStrike != StrikeOut.Checked)
                StrikeOut.Checked = isStrike;
        }

        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    int margin = ((Width - FontCombo.Width) / 2) - 10;
        //    if (margin < 0)
        //    {
        //        FontCombo.Width = Width - 16;
        //        FontCombo.Location = new Point(0, 0);
        //    }
        //    else
        //    {
        //        FontCombo.Width = 820;
        //        FontCombo.Location = new Point(margin, 0);
        //    }
        //    FontCombo.Height = WorkPanel.Height;

        //    if (Width < 500)
        //    {
        //        WorkPanel.Height = Height;
        //        ribbon1.Visible = false;
        //        FontCombo.Height = WorkPanel.Height;
        //    }
        //    else
        //    {
        //        ribbon1.Visible = true;
        //        WorkPanel.Height = Height - ribbon1.Height;
        //    }
        //}

        private void FontSizeComboButton_click(object sender, EventArgs e)
        {
             //Font fnt = new Font(FontCombo.SelectionFont.FontFamily, Int32.Parse(FontSizeCombo.TextBoxText), FontCombo.SelectionFont.Style);
                //FontCombo.SelectionFont = fnt;

            var btn = sender as RibbonButton;
            fontReSize(float.Parse(btn.Text));

            FontSizeCombo.TextBoxText = btn.Text;

            FontOptionChanged();
           
        }


        void fontReSize(float newSize)
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
                    tmpRB.SelectionFont = new Font(tmpRB.SelectionFont.FontFamily, newSize, tmpRB.SelectionFont.Style);
                }
                tmpRB.SelectAll();
                FontCombo.TextChanged -= this.MainTextBox_TextChanged;
                FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
                FontCombo.SelectedRtf = tmpRB.SelectedRtf;

                
            }
            FontCombo.SelectionStart = start;
            FontCombo.SelectionLength = length;
           
            FontCombo.TextChanged += this.MainTextBox_TextChanged;
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
        }
       
        private void FontCombo_Click(object sender, EventArgs e)
        {
            //currentAlignCheked.Checked = false;
            switch (FontCombo.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    if (alignLeft.Checked != true && alignLeft != currentAlignCheked)
                    {
                        alignLeft.Checked = true;
                        currentAlignCheked = alignLeft;
                    }
                    break;
                case HorizontalAlignment.Right:
                    if (alignRigth.Checked != true && alignRigth != currentAlignCheked)
                    {
                        alignRigth.Checked = true;
                        currentAlignCheked = alignRigth;
                    }
                    break;
                case HorizontalAlignment.Center:
                    if (alignCenter.Checked != true && alignCenter != currentAlignCheked)
                    {
                        alignCenter.Checked = true;
                        currentAlignCheked = alignCenter;
                    }
                    break;
                default:
                    break;
            }


        }

        private void alignJustify_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionCharOffset = 2;
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

        float getDownFontSize(float currentValue)
        {

            if (currentValue == 1)
                return 1;

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
                        return prevValue;
                    }
                    else if (float.Parse(item.Text) <= currentValue)
                        prevValue = float.Parse(item.Text);
                    else
                    {
                        return prevValue;
                    }
                }
            }
            return currentValue;
        }

        private void TextFontDown()
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
                    float currentValue = tmpRB.SelectionFont.Size;
                    tmpRB.SelectionFont = new Font(tmpRB.SelectionFont.FontFamily, getDownFontSize(currentValue), tmpRB.SelectionFont.Style);

                }
                tmpRB.SelectAll();
                FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
                FontCombo.SelectedRtf = tmpRB.SelectedRtf;
                
            }

            FontCombo.SelectionStart = start;
            FontCombo.SelectionLength = length;
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
        }

        private void FontDown_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
            if (FontSizeCombo.TextBoxText == "")
            {
                TextFontDown();
            }
            else
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

                            fontReSize(prevValue);
                            FontSizeCombo.TextBoxText = prevValue.ToString();
                            return;
                        }
                        else if (float.Parse(item.Text) <= currentValue)
                            prevValue = float.Parse(item.Text);
                        else
                        {

                            fontReSize(prevValue);
                            FontSizeCombo.TextBoxText = prevValue.ToString();
                            return;
                        }
                    }
                }
                fontReSize(currentValue);
                FontSizeCombo.TextBoxText = currentValue.ToString();
                
            }
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
            FontOptionChanged();
        }
        private void TextFontUp()
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
                    float currentValue = tmpRB.SelectionFont.Size;
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

                    tmpRB.SelectionFont = new Font(tmpRB.SelectionFont.FontFamily, currentValue, tmpRB.SelectionFont.Style);

                }
                tmpRB.SelectAll();
                FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
                FontCombo.SelectedRtf = tmpRB.SelectedRtf;
               
            }

            FontCombo.SelectionStart = start;
            FontCombo.SelectionLength = length;
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
        }

        private void FontUp_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionChanged -= this.MainTextBox_SelectionChanged;
            if (FontSizeCombo.TextBoxText == "")
            {
                TextFontUp();
            }
            else
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
                fontReSize(currentValue);
                FontSizeCombo.TextBoxText = currentValue.ToString();
                
            }
            FontCombo.SelectionChanged += this.MainTextBox_SelectionChanged;
            FontOptionChanged();
        }

        private void FontSizeCombo_TextBoxValidating(object sender, EventArgs e)
        {
            float f;
            if(float.TryParse(FontSizeCombo.TextBoxText,out f))
            {
                if (f > 1630)
                    FontSizeCombo.TextBoxText = "1630";
                FontOptionChanged();
            }else
            {
                FontSizeCombo.TextBoxText = FontCombo.Font.Size.ToString();
            }
        }

        private void FontComboBox_TextBoxValidating(object sender, EventArgs e)
        {
            foreach (var item in FontComboBox.DropDownItems)
            {
                if(item.Text == FontComboBox.TextBoxText)
                {
                    FontOptionChanged();
                    return;
                }
            }
            FontComboBox.TextBoxText = FontCombo.Font.FontFamily.GetName(0);
        }

        private void TextColor_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionColor = TextColor.Color;
        }

        private void TextColor_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = TextColor.Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TextColor.Color = colorDialog.Color;
                FontCombo.SelectionColor = TextColor.Color;
            }
            else
            {
                FontCombo.Undo();
            }
        }

        private void BgColor_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionBackColor = BgColor.Color;
        }

        private void BgColor_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = BgColor.Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BgColor.Color = colorDialog.Color;
                FontCombo.SelectionBackColor = BgColor.Color;
            }
            else
            {
                FontCombo.Undo();
            }
        }

        private void DatePaste_Click(object sender, EventArgs e)
        {
            DateFomats DF = new DateFomats();
            if(DF.ShowDialog() == DialogResult.OK)
            {
                FontCombo.SelectedText = DF.SelectedFormat;
            }
        }

        private void PasteImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = open.Filter = "BMP|*.bmp|JPEG|*.jpeg|PNG|*.png|JPEG|*.jpeg|EMF|*.emf|WMF|*.wmf|TIFF|*.tiff|ICO|*.ico|Все файлы изображений|*.BMP;*.JPG;*.GIF;*.PNG;*.ICO;*.EMF;*.WMF;*.TIFF";
            open.FilterIndex = 100;

            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            if (open.ShowDialog() == DialogResult.OK)
            {
                var tmp = Clipboard.GetDataObject();
                Bitmap img = new Bitmap(open.FileName, false);
                Clipboard.SetDataObject(img);
                FontCombo.Paste(format);
                Clipboard.SetDataObject(tmp);
            }
        }

        private void IndentRigth_Click(object sender, EventArgs e)
        {
            
            FontCombo.SelectionIndent += 50;
        }

        private void IndentLeft_Click(object sender, EventArgs e)
        {
            FontCombo.SelectionIndent -= 50;
        }

        private void TabGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabGroup.SelectedIndex != -1)
                onSelectTab(tabs[TabGroup.SelectedIndex]);
        }

        private void CloseTab_Click(object sender, EventArgs e)
        {
            var tab = TabGroup.SelectedTab;
            Tab deletedTab = null;
            foreach (var item in tabs)
            {
                if (item.Page == tab)
                    deletedTab = item;
            }

            if (deletedTab != null)
            {
                if (deletedTab.TextBox.CanUndo == false || SaveFile() != false)
                {
                     TabGroup.TabPages.Remove(TabGroup.SelectedTab);
                     tabs.Remove(deletedTab);
                     if (tabs.Count == 0)
                     {
                         CloseTab.Enabled = false;
                         foreach (var item in MainTab.Panels)
                         {
                             item.Enabled = false;
                         }
                         Save.Enabled = false;
                         SaveAs.Enabled = false;
                     }
                }               
            }
        }

        private void CreateTa_Click(object sender, EventArgs e)
        {
            CreateFileButton_Click(null, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            while (TabGroup.TabPages.Count != 0)
            {
                var tab = TabGroup.SelectedTab;
                Tab deletedTab = null;
                foreach (var item in tabs)
                {
                    if (item.Page == tab)
                        deletedTab = item;
                }

                if (deletedTab != null)
                {
                    path = deletedTab.Path;
                    if (path == "")
                        path = deletedTab.Page.Text;
                    bool result;
                        

                    if (deletedTab.TextBox.CanUndo == false || (result = SaveFile()) != false)
                    {
                        TabGroup.TabPages.Remove(TabGroup.SelectedTab);
                        tabs.Remove(deletedTab);
                        
                    }
                    else if (result == false) { 
                        e.Cancel = true; 
                        TabGroup_SelectedIndexChanged(null, null); 
                        return;
                    }
                }
            }
               
        }

        

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
