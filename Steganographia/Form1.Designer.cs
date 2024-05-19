namespace Steganographia
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnWrite = new Button();
            btnRead = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnWrite
            // 
            btnWrite.BackColor = SystemColors.Control;
            btnWrite.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnWrite.Location = new Point(206, 111);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(130, 40);
            btnWrite.TabIndex = 0;
            btnWrite.Text = "Записать";
            btnWrite.UseVisualStyleBackColor = false;
            btnWrite.Click += btnWrite_Click;
            // 
            // btnRead
            // 
            btnRead.Font = new Font("Book Antiqua", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRead.Location = new Point(342, 111);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(130, 40);
            btnRead.TabIndex = 1;
            btnRead.Text = "Прочитать";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Book Antiqua", 48F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox1.Location = new Point(31, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(632, 93);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "STEGANOGRAPHIA";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(btnRead);
            Controls.Add(btnWrite);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnWrite;
        private Button btnRead;
        private RichTextBox richTextBox1;
    }
}
