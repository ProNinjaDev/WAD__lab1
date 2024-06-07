using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace first_product_lab1


{
    public partial class LogPassForm : Form
    {

        public bool IsPasswordCorrect { get; set; }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        public LogPassForm()
        {
            InitializeComponent();

            usersComboBox.SelectedIndex = 0;
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.Enabled = false;
        }

        private void LogPassForm_Load(object sender, EventArgs e)
        {

        }

        private void usersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersComboBox.SelectedIndex == 1)
            {
                PasswordTextBox.Enabled = true;
            }
            else PasswordTextBox.Enabled = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (usersComboBox.SelectedIndex == 0)
                {
                    IsPasswordCorrect = false;
                    this.Close();
                    return;
                }
                else
                {
                    string enteredPassword = GetHash(PasswordTextBox.Text + "admin");

                    string path = "C:\\Users\\Anton\\source\\repos\\first_product_lab1\\first_product_lab1\\passwords.txt";
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        if (line == enteredPassword)
                        {
                            MessageBox.Show("Пароль верный!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IsPasswordCorrect = true;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                    }
                }
                throw new CustomError(ErrorType.IncorrectPassword, "Пароль неверный!");
            }
            catch (CustomError error)
            {
                ErrorHandler.HandleError(error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
