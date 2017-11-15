namespace WordPad
{
    partial class FindWindow
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
            this.OnlyFullWord = new System.Windows.Forms.CheckBox();
            this.WithRegister = new System.Windows.Forms.CheckBox();
            this.FindNext = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.FindText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Что:";
            // 
            // OnlyFullWord
            // 
            this.OnlyFullWord.AutoSize = true;
            this.OnlyFullWord.Location = new System.Drawing.Point(13, 45);
            this.OnlyFullWord.Name = "OnlyFullWord";
            this.OnlyFullWord.Size = new System.Drawing.Size(143, 17);
            this.OnlyFullWord.TabIndex = 1;
            this.OnlyFullWord.Text = "Только слово целиком";
            this.OnlyFullWord.UseVisualStyleBackColor = true;
            // 
            // WithRegister
            // 
            this.WithRegister.AutoSize = true;
            this.WithRegister.Location = new System.Drawing.Point(13, 68);
            this.WithRegister.Name = "WithRegister";
            this.WithRegister.Size = new System.Drawing.Size(120, 17);
            this.WithRegister.TabIndex = 2;
            this.WithRegister.Text = "С учетом регистра";
            this.WithRegister.UseVisualStyleBackColor = true;
            // 
            // FindNext
            // 
            this.FindNext.Location = new System.Drawing.Point(268, 10);
            this.FindNext.Name = "FindNext";
            this.FindNext.Size = new System.Drawing.Size(95, 23);
            this.FindNext.TabIndex = 3;
            this.FindNext.Text = "Найти далее";
            this.FindNext.UseVisualStyleBackColor = true;
            this.FindNext.Click += new System.EventHandler(this.FindNext_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(268, 39);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(95, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // FindText
            // 
            this.FindText.Location = new System.Drawing.Point(45, 12);
            this.FindText.Name = "FindText";
            this.FindText.Size = new System.Drawing.Size(189, 20);
            this.FindText.TabIndex = 5;
            this.FindText.TextChanged += new System.EventHandler(this.FindText_TextChanged);
            // 
            // FindWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 98);
            this.Controls.Add(this.FindText);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.FindNext);
            this.Controls.Add(this.WithRegister);
            this.Controls.Add(this.OnlyFullWord);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindWindow";
            this.Text = "Найти";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox OnlyFullWord;
        private System.Windows.Forms.CheckBox WithRegister;
        private System.Windows.Forms.Button FindNext;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox FindText;
    }
}