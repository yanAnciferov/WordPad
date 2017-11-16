namespace WordPad
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.CreateFileButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.OpenFileButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.SaveFileButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.SaveAsButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.PrintButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.MainTab = new System.Windows.Forms.RibbonTab();
            this.Buffer = new System.Windows.Forms.RibbonPanel();
            this.Paste = new System.Windows.Forms.RibbonButton();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.Cut = new System.Windows.Forms.RibbonButton();
            this.Copy = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.Pravka = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ViewTab = new System.Windows.Forms.RibbonTab();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Text = "ribbonTab2";
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Margin = new System.Windows.Forms.Padding(6);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.CreateFileButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.OpenFileButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.SaveFileButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.SaveAsButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.PrintButton);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.OptionItemsPadding = 2;
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 295);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "Файл";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbon1.Size = new System.Drawing.Size(842, 140);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.MainTab);
            this.ribbon1.Tabs.Add(this.ViewTab);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(0, 2, 20, 0);
            this.ribbon1.TabSpacing = 1;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // CreateFileButton
            // 
            this.CreateFileButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CreateFileButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateFileButton.Image")));
            this.CreateFileButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("CreateFileButton.SmallImage")));
            this.CreateFileButton.Text = "Создать";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.SmallImage")));
            this.OpenFileButton.Text = "Открыть";
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.SaveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveFileButton.Image")));
            this.SaveFileButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("SaveFileButton.SmallImage")));
            this.SaveFileButton.Text = "Сохранить";
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.SaveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsButton.Image")));
            this.SaveAsButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("SaveAsButton.SmallImage")));
            this.SaveAsButton.Text = "Сохранить как";
            // 
            // PrintButton
            // 
            this.PrintButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.PrintButton.Image = ((System.Drawing.Image)(resources.GetObject("PrintButton.Image")));
            this.PrintButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("PrintButton.SmallImage")));
            this.PrintButton.Text = "Печать";
            // 
            // MainTab
            // 
            this.MainTab.Panels.Add(this.Buffer);
            this.MainTab.Panels.Add(this.ribbonPanel1);
            this.MainTab.Panels.Add(this.ribbonPanel2);
            this.MainTab.Panels.Add(this.ribbonPanel3);
            this.MainTab.Panels.Add(this.Pravka);
            this.MainTab.Text = "Главная";
            // 
            // Buffer
            // 
            this.Buffer.Items.Add(this.Paste);
            this.Buffer.Items.Add(this.Cut);
            this.Buffer.Items.Add(this.Copy);
            this.Buffer.Text = "Буфер обмена";
            // 
            // Paste
            // 
            this.Paste.DropDownItems.Add(this.ribbonButton7);
            this.Paste.Image = ((System.Drawing.Image)(resources.GetObject("Paste.Image")));
            this.Paste.SmallImage = ((System.Drawing.Image)(resources.GetObject("Paste.SmallImage")));
            this.Paste.Text = "Вставить";
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "ribbonButton7";
            // 
            // Cut
            // 
            this.Cut.Image = ((System.Drawing.Image)(resources.GetObject("Cut.Image")));
            this.Cut.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.Cut.SmallImage = ((System.Drawing.Image)(resources.GetObject("Cut.SmallImage")));
            this.Cut.Text = "Вырезать";
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // Copy
            // 
            this.Copy.Image = ((System.Drawing.Image)(resources.GetObject("Copy.Image")));
            this.Copy.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.Copy.SmallImage = ((System.Drawing.Image)(resources.GetObject("Copy.SmallImage")));
            this.Copy.Text = "Копировать";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Text = "Шрифт";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Text = "Абзац";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Text = "Вставка";
            // 
            // Pravka
            // 
            this.Pravka.Items.Add(this.ribbonButton3);
            this.Pravka.Items.Add(this.ribbonButton4);
            this.Pravka.Items.Add(this.ribbonButton6);
            this.Pravka.Text = "Правка";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Поиск";
            this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.DropDownItems.Add(this.ribbonButton5);
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.DropDown;
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Замена";
            this.ribbonButton4.Click += new System.EventHandler(this.ribbonButton4_Click);
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.DropDown;
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "Выделить все";
            this.ribbonButton6.Click += new System.EventHandler(this.ribbonButton6_Click);
            // 
            // ViewTab
            // 
            this.ViewTab.Text = "Вид";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.78788F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.21212F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.MainTextBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 138);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.10762F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.89238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(842, 467);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainTextBox.HideSelection = false;
            this.MainTextBox.Location = new System.Drawing.Point(193, 57);
            this.MainTextBox.MinimumSize = new System.Drawing.Size(100, 4);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.Size = new System.Drawing.Size(465, 386);
            this.MainTextBox.TabIndex = 0;
            this.MainTextBox.Text = "";
            this.MainTextBox.SelectionChanged += new System.EventHandler(this.MainTextBox_SelectionChanged);
            this.MainTextBox.TextChanged += new System.EventHandler(this.MainTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 605);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonTab MainTab;
        private System.Windows.Forms.RibbonTab ViewTab;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonOrbMenuItem CreateFileButton;
        private System.Windows.Forms.RibbonOrbMenuItem OpenFileButton;
        private System.Windows.Forms.RibbonOrbMenuItem SaveFileButton;
        private System.Windows.Forms.RibbonOrbMenuItem SaveAsButton;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem PrintButton;
        private System.Windows.Forms.RibbonPanel Buffer;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel Pravka;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox MainTextBox;
        private System.Windows.Forms.RibbonButton Paste;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonButton Cut;
        private System.Windows.Forms.RibbonButton Copy;
    }
}

