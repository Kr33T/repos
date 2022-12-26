namespace test
{
    partial class tasks
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
            this.listNameTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listNameTB
            // 
            this.listNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listNameTB.Location = new System.Drawing.Point(12, 12);
            this.listNameTB.Name = "listNameTB";
            this.listNameTB.Size = new System.Drawing.Size(338, 38);
            this.listNameTB.TabIndex = 0;
            this.listNameTB.TextChanged += new System.EventHandler(this.listNameTB_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 353);
            this.panel1.TabIndex = 1;
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(275, 415);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(75, 23);
            this.closeBTN.TabIndex = 0;
            this.closeBTN.Text = "Закрыть";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 445);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listNameTB);
            this.Name = "tasks";
            this.Text = "tasks";
            this.Load += new System.EventHandler(this.tasks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox listNameTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelWithAddP;
    }
}