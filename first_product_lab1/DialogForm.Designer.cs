namespace first_product_lab1
{
    partial class DialogForm
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
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.birthdayDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.acceptDialog = new System.Windows.Forms.Button();
            this.cancelDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cardTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(48, 116);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 22);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // birthdayDateTimePicker1
            // 
            this.birthdayDateTimePicker1.Location = new System.Drawing.Point(48, 213);
            this.birthdayDateTimePicker1.Name = "birthdayDateTimePicker1";
            this.birthdayDateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.birthdayDateTimePicker1.TabIndex = 1;
            // 
            // acceptDialog
            // 
            this.acceptDialog.Location = new System.Drawing.Point(188, 285);
            this.acceptDialog.Name = "acceptDialog";
            this.acceptDialog.Size = new System.Drawing.Size(120, 53);
            this.acceptDialog.TabIndex = 2;
            this.acceptDialog.Text = "Принять";
            this.acceptDialog.UseVisualStyleBackColor = true;
            this.acceptDialog.Click += new System.EventHandler(this.acceptDialog_Click);
            this.acceptDialog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.acceptDialog_MouseMove);
            // 
            // cancelDialog
            // 
            this.cancelDialog.Location = new System.Drawing.Point(351, 285);
            this.cancelDialog.Name = "cancelDialog";
            this.cancelDialog.Size = new System.Drawing.Size(120, 53);
            this.cancelDialog.TabIndex = 3;
            this.cancelDialog.Text = "Отмена";
            this.cancelDialog.UseVisualStyleBackColor = true;
            this.cancelDialog.Click += new System.EventHandler(this.cancelDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ваше имя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ваша дата рождения:";
            // 
            // cardTextBox
            // 
            this.cardTextBox.Location = new System.Drawing.Point(335, 165);
            this.cardTextBox.Name = "cardTextBox";
            this.cardTextBox.Size = new System.Drawing.Size(314, 22);
            this.cardTextBox.TabIndex = 6;
            this.cardTextBox.TextChanged += new System.EventHandler(this.cardTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Введите номер карты:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 385);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cardTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelDialog);
            this.Controls.Add(this.acceptDialog);
            this.Controls.Add(this.birthdayDateTimePicker1);
            this.Controls.Add(this.nameTextBox);
            this.KeyPreview = true;
            this.Name = "DialogForm";
            this.Text = "dialogForm";
            this.Load += new System.EventHandler(this.dialogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DateTimePicker birthdayDateTimePicker1;
        private System.Windows.Forms.Button acceptDialog;
        private System.Windows.Forms.Button cancelDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cardTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}