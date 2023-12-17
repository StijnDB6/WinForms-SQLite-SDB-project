namespace WinForms_SQLite_SDB_project
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            clearDatabase = new Button();
            addPatient = new Button();
            greetingLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 84);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 143);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 203);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 2;
            label3.Text = "Medical condition:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(271, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(271, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(271, 203);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // clearDatabase
            // 
            clearDatabase.BackColor = SystemColors.ActiveBorder;
            clearDatabase.Location = new Point(1058, 12);
            clearDatabase.Name = "clearDatabase";
            clearDatabase.Size = new Size(132, 79);
            clearDatabase.TabIndex = 6;
            clearDatabase.Text = "Clear database";
            clearDatabase.UseVisualStyleBackColor = false;
            clearDatabase.Click += clearDatabase_Click;
            // 
            // addPatient
            // 
            addPatient.BackColor = SystemColors.ActiveBorder;
            addPatient.Location = new Point(271, 272);
            addPatient.Name = "addPatient";
            addPatient.Size = new Size(125, 72);
            addPatient.TabIndex = 7;
            addPatient.Text = "Add patient";
            addPatient.UseVisualStyleBackColor = false;
            addPatient.Click += addPatient_Click;
            // 
            // greetingLabel
            // 
            greetingLabel.AutoSize = true;
            greetingLabel.BackColor = Color.White;
            greetingLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            greetingLabel.Location = new Point(612, 251);
            greetingLabel.Name = "greetingLabel";
            greetingLabel.Size = new Size(0, 28);
            greetingLabel.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 549);
            Controls.Add(greetingLabel);
            Controls.Add(addPatient);
            Controls.Add(clearDatabase);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Dokterspraktijk";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button clearDatabase;
        private Button addPatient;
        private Label greetingLabel;
    }
}