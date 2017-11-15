namespace WordPad
{
    partial class FindEndReplace
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
            this.label1 = new System.Windows.Forms.Label();
            this.FindText = new System.Windows.Forms.TextBox();
            this.WithRegister = new System.Windows.Forms.CheckBox();
            this.OnlyFullWord = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplaceText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ReplaceAll = new System.Windows.Forms.Button();
            this.Replace = new System.Windows.Forms.Button();
            this.FindNext = new System.Windows.Forms.Button();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-34, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Что:";
            // 
            // FindText
            // 
            this.FindText.Location = new System.Drawing.Point(41, 12);
            this.FindText.Name = "FindText";
            this.FindText.Size = new System.Drawing.Size(189, 20);
            this.FindText.TabIndex = 12;
            this.FindText.TextChanged += new System.EventHandler(this.FindText_TextChanged);
            // 
            // WithRegister
            // 
            this.WithRegister.AutoSize = true;
            this.WithRegister.Location = new System.Drawing.Point(9, 97);
            this.WithRegister.Name = "WithRegister";
            this.WithRegister.Size = new System.Drawing.Size(120, 17);
            this.WithRegister.TabIndex = 9;
            this.WithRegister.Text = "С учетом регистра";
            this.WithRegister.UseVisualStyleBackColor = true;
            // 
            // OnlyFullWord
            // 
            this.OnlyFullWord.AutoSize = true;
            this.OnlyFullWord.Location = new System.Drawing.Point(9, 74);
            this.OnlyFullWord.Name = "OnlyFullWord";
            this.OnlyFullWord.Size = new System.Drawing.Size(143, 17);
            this.OnlyFullWord.TabIndex = 8;
            this.OnlyFullWord.Text = "Только слово целиком";
            this.OnlyFullWord.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Что:";
            // 
            // ReplaceText
            // 
            this.ReplaceText.Location = new System.Drawing.Point(41, 42);
            this.ReplaceText.Name = "ReplaceText";
            this.ReplaceText.Size = new System.Drawing.Size(189, 20);
            this.ReplaceText.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Чем:";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(263, 97);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(95, 23);
            this.Cancel.TabIndex = 16;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.ReplaceAll);
            this.ButtonPanel.Controls.Add(this.FindNext);
            this.ButtonPanel.Controls.Add(this.Replace);
            this.ButtonPanel.Location = new System.Drawing.Point(248, 4);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(123, 95);
            this.ButtonPanel.TabIndex = 17;
            // 
            // ReplaceAll
            // 
            this.ReplaceAll.Location = new System.Drawing.Point(14, 66);
            this.ReplaceAll.Name = "ReplaceAll";
            this.ReplaceAll.Size = new System.Drawing.Size(95, 23);
            this.ReplaceAll.TabIndex = 20;
            this.ReplaceAll.Text = "Заменить все";
            this.ReplaceAll.UseVisualStyleBackColor = true;
            // 
            // Replace
            // 
            this.Replace.Location = new System.Drawing.Point(15, 37);
            this.Replace.Name = "Replace";
            this.Replace.Size = new System.Drawing.Size(95, 23);
            this.Replace.TabIndex = 19;
            this.Replace.Text = "Заменить";
            this.Replace.UseVisualStyleBackColor = true;
            // 
            // FindNext
            // 
            this.FindNext.Location = new System.Drawing.Point(15, 8);
            this.FindNext.Name = "FindNext";
            this.FindNext.Size = new System.Drawing.Size(95, 23);
            this.FindNext.TabIndex = 18;
            this.FindNext.Text = "Найти далее";
            this.FindNext.UseVisualStyleBackColor = true;
            // 
            // FindEndReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 132);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ReplaceText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FindText);
            this.Controls.Add(this.WithRegister);
            this.Controls.Add(this.OnlyFullWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindEndReplace";
            this.Text = "Заменить";
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FindText;
        private System.Windows.Forms.CheckBox WithRegister;
        private System.Windows.Forms.CheckBox OnlyFullWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReplaceText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button ReplaceAll;
        private System.Windows.Forms.Button FindNext;
        private System.Windows.Forms.Button Replace;
    }
}