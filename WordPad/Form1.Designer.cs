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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainTab = new System.Windows.Forms.RibbonTab();
            this.ViewTab = new System.Windows.Forms.RibbonTab();
            this.CreateFileButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.OpenFileButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.SaveFileButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.SaveAsButton = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.PrintButton = new System.Windows.Forms.RibbonOrbMenuItem();
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
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.CreateFileButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.OpenFileButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.SaveFileButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.SaveAsButton);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.PrintButton);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 295);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "Файл";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1105, 143);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.MainTab);
            this.ribbon1.Tabs.Add(this.ViewTab);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(0, 2, 20, 0);
            this.ribbon1.TabSpacing = 1;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 467);
            this.panel1.TabIndex = 1;
            // 
            // MainTab
            // 
            this.MainTab.Text = "Главная";
            // 
            // ViewTab
            // 
            this.ViewTab.Text = "Вид";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 605);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RibbonTab MainTab;
        private System.Windows.Forms.RibbonTab ViewTab;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonOrbMenuItem CreateFileButton;
        private System.Windows.Forms.RibbonOrbMenuItem OpenFileButton;
        private System.Windows.Forms.RibbonOrbMenuItem SaveFileButton;
        private System.Windows.Forms.RibbonOrbMenuItem SaveAsButton;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem PrintButton;


    }
}

