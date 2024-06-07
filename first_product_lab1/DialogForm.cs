using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_product_lab1
{
    public partial class DialogForm : Form
    {
        private Person person;
        public Person Answer { get; set; }

        private LogPassForm logPass;
        

        private Timer timer;

        private bool isCardNumberChanged = false;

        public DialogForm(Person curPerson)
        {
            InitializeComponent();

            birthdayDateTimePicker1.MaxDate = DateTime.Now;

            logPass = new LogPassForm();
            logPass.IsPasswordCorrect = false;

            timer = new Timer();
            timer.Interval = 1; // Интервал в миллисекундах
            timer.Tick += timer1_Tick;

            this.person = curPerson;

            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialogFromKeyDown);

            this.MouseMove += DialogForm_MouseMove;

            if (person != null)
            {
                nameTextBox.Text = person.Name;
                birthdayDateTimePicker1.Value = person.Bithday;
                cardTextBox.Text = person.CardNumber.ToString();

                cardTextBox.Enabled = false;
                birthdayDateTimePicker1.Enabled = false;

            }


        }

        private void DialogFromKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.Shift && e.KeyValue == 'L') && (person != null))
            {
                logPass = new LogPassForm();
                logPass.FormClosing += LogPass_FormClosing;
                logPass.Show();

            }
        }
  

        private void LogPassForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void acceptDialog_Click(object sender, EventArgs e)
        {
            try
            {
                acceptDialog.ForeColor = Color.Red;

                Person person = new Person();
                person.Name = nameTextBox.Text;

                for (int i = 0; i != person.Name.Length; ++i)
                {
                    if (!(char.IsLetter(person.Name[i])))
                    {
                        throw new CustomError(ErrorType.InvalidInput,
                            "В имени могут быть только буквы русского/латинского алфавита");
                    }
                }

                if (person.Name.Length < 2)
                    throw new CustomError(ErrorType.InvalidInput,
                        "Имя не может быть меньше двух букв!");

                person.Bithday = birthdayDateTimePicker1.Value;

                if (person.calcAge(DateTime.Now) < 0 || person.calcAge(DateTime.Now) > 115)
                {
                    throw new CustomError(ErrorType.BirthdayBeyond,
                        "Возраст пользователя должен быть в отрезке (0, 115)!");
                }


                if (Int32.TryParse(cardTextBox.Text, out int cardNumber) && cardNumber.ToString()[0] != '-')
                {
                    person.CardNumber = cardNumber;

                    if (person.CardNumber.ToString().Length != 5)
                        throw new CustomError(ErrorType.IncorrectLength,
                            "Номер карты должен состоять из пяти цифр и не содержать нулей в начале!");

                    Answer = person;
                    isCardNumberChanged = false;
                    timer.Stop();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                else
                {
                    throw new CustomError(ErrorType.InvalidInput, "Номер карты введён неправильно!");
                }
            }
            catch(CustomError error) 
            { 
                ErrorHandler.HandleError(error);
            }           
        }


        private void LogPass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(logPass.IsPasswordCorrect)
            {
                BackColor = Color.Green;

                cardTextBox.Enabled = true;
                birthdayDateTimePicker1.Enabled = true;

                acceptDialog.BackColor = Color.Blue;
                cancelDialog.BackColor = Color.Blue;
                acceptDialog.ForeColor = Color.White;
                cancelDialog.ForeColor = Color.White;
            }
            else
            {
                BackColor = Color.White;

                cardTextBox.Enabled = false;
                birthdayDateTimePicker1.Enabled = false;

                acceptDialog.BackColor = Color.White;
                cancelDialog.BackColor = Color.White;
                acceptDialog.ForeColor = Color.Black;
                cancelDialog.ForeColor = Color.Black;
                timer.Stop();
            }
        }




        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cardTextBox_TextChanged(object sender, EventArgs e)
        {
            if (logPass.IsPasswordCorrect)
            {
                timer.Start();
            }
            isCardNumberChanged = true;
        }

        private void dialogForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelDialog_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void acceptDialog_MouseMove(object sender, MouseEventArgs e)
        {
            //acceptDialog.Location = new Point(rand.Next(ClientRectangle.Width - 5), rand.Next(ClientRectangle.Height - 5));
        }

        private void DialogForm_MouseMove(object sender, MouseEventArgs e)
        {
            //if (logPass.IsPasswordCorrect && isCardNumberChanged)
            //{
            //    timer.Start();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            int deltaX = Cursor.Position.X - acceptDialog.Location.X - acceptDialog.Width / 2 - Location.X;

            int smoothness = 1; // Плавность движения

            int newX = acceptDialog.Left + deltaX / smoothness;

            if (newX >= 0 && newX + acceptDialog.Width <= this.ClientSize.Width)
            {
                acceptDialog.Left = newX;
            }

            int DistanceToBottom = this.ClientSize.Height - Cursor.Position.Y;

            // Перекидываю кнопку чуть выше курсора(53)
            if (DistanceToBottom < acceptDialog.Height)
            {
                acceptDialog.Top = Cursor.Position.Y - acceptDialog.Height - 35;
            }
            
            int deltaY = Cursor.Position.Y - acceptDialog.Location.Y - acceptDialog.Height / 2 - Location.Y;

            int newY = acceptDialog.Top + deltaY / smoothness;

            if (newY >= 0 && newY + acceptDialog.Height <= this.ClientSize.Height)
            {
                acceptDialog.Top = newY;
            }
        }

    }
}
