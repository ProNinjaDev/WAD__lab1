using first_product_lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_product_lab1
{
    public partial class MainForm : Form
    {

        //private List<Person> persons = new List<Person>();
        private Dictionary<ListBox, List<Person>> listBoxPersonDictionary = new Dictionary<ListBox, List<Person>>();

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(50, 30);
            NewTabButton.Location = new Point(88, 15);

            string path = "C:\\Users\\Anton\\source\\repos\\first_product_lab1\\first_product_lab1\\MainFormData.txt";

            StreamReader reader = new StreamReader(path);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] boxRecord = line.Split('|');

                if (boxRecord.Length > 1)
                {
                    Person newPerson = new Person();
                    newPerson.Name = boxRecord[1];
                    newPerson.Bithday = DateTime.Parse(boxRecord[2]);
                    newPerson.CardNumber = int.Parse(boxRecord[3]);

                    int tabID = int.Parse(boxRecord[0]);
                    if (tabID >= tabControl1.TabPages.Count)
                    {
                        for (int i = tabControl1.TabPages.Count; i <= tabID; i++)
                        {
                            NewTabButton_Click(null, EventArgs.Empty);
                        }
                    }

                    ListBox curListBox = tabControl1.TabPages[tabID].Controls.OfType<ListBox>().FirstOrDefault();

                    if (curListBox != null)
                    {
                        curListBox.Items.Add($"{newPerson.Name} - {newPerson.calcAge(DateTime.Now)}");

                        // Проверяем, есть ли текущий листбоксик в словаре
                        if (!listBoxPersonDictionary.ContainsKey(curListBox))
                        {
                            // Если нет, создаем новый список Person и добавляем наш листбокс в словарь
                            listBoxPersonDictionary[curListBox] = new List<Person>();
                        }

                        // Добавляем новую запись в ListBox и в связанный список Person
                        listBoxPersonDictionary[curListBox].Add(newPerson);
                    }
                }
            }
            reader.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {            
            DialogForm dialog = new DialogForm(null);
            dialog.ShowDialog();

            Person answerOfDialogForm = dialog.Answer;            

            if (answerOfDialogForm != null)
            {
                TabPage curTabPage = tabControl1.SelectedTab;
                ListBox curListBox = curTabPage.Controls.OfType<ListBox>().FirstOrDefault();

                // Проверяем, есть ли текущий листбоксик в словаре
                if (!listBoxPersonDictionary.ContainsKey(curListBox))
                {
                    // Если нет, создаем новый список Person и добавляем наш листбокс в словарь
                    listBoxPersonDictionary[curListBox] = new List<Person>();
                }

                // Добавляем новую запись в ListBox и в связанный список Person
                CreateRecordToCurListBox(answerOfDialogForm, curListBox);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            TabPage curTabPage = tabControl1.SelectedTab;

            if (curTabPage != null)
            {
                ListBox curListBox = curTabPage.Controls.OfType<ListBox>().FirstOrDefault();

                if (curListBox != null && curListBox.SelectedIndex != -1)
                {
                    int index = curListBox.SelectedIndex;

                    // Список, связанный с текущим листбоксом
                    List<Person> personsList = listBoxPersonDictionary[curListBox];

                    // Удаляем Person из списка
                    personsList.RemoveAt(index);

                    // Удаляем запись из ListBox
                    curListBox.Items.RemoveAt(index);
                }
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            TabPage curTabPage = tabControl1.SelectedTab;
            if (curTabPage != null)
            {
                ListBox curListBox = curTabPage.Controls.OfType<ListBox>().FirstOrDefault();
                if (curListBox != null && curListBox.SelectedIndex != -1)
                {
                    int indexSelectedItem = curListBox.SelectedIndex;

                    // Получаем список person, связанный с текущим ListBox
                    List<Person> personsList = listBoxPersonDictionary[curListBox];

                    DialogForm dialog = new DialogForm(personsList[indexSelectedItem]);
                    dialog.ShowDialog();

                    Person answerOfDialogForm = dialog.Answer;
                    if (answerOfDialogForm != null)
                    {
                        // Обновляем person в списке
                        personsList[indexSelectedItem] = answerOfDialogForm;
                        curListBox.Items[indexSelectedItem] = $"{answerOfDialogForm.Name} - {answerOfDialogForm.calcAge(DateTime.Now)}";
                    }
                    else
                    {
                        // Если диалог был закрыт без изменений, не обновляем запись
                    }
                }
            }
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            Person newPerson = new Person();
            newPerson.Name = "Default";
            newPerson.Bithday = DateTime.Now;
            newPerson.CardNumber = 11111;

            TabPage curTabPage = tabControl1.SelectedTab;
            ListBox curListBox = curTabPage.Controls.OfType<ListBox>().FirstOrDefault();

            if (!listBoxPersonDictionary.ContainsKey(curListBox))
            {
                listBoxPersonDictionary[curListBox] = new List<Person>();
            }

            CreateRecordToCurListBox(newPerson, curListBox);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewTabButton_Click(object sender, EventArgs e)
        {
            TabPage newTabPage = new TabPage($"Вкладка {tabControl1.TabPages.Count + 1}");

            tabControl1.TabPages.Add(newTabPage);

            ListBox newListBox = new ListBox();

            newListBox.Dock = DockStyle.Fill;
            newListBox.Font = new Font(newListBox.Font.FontFamily, 12);

            if (tabControl1.TabPages.Count < 9)
            {
                NewTabButton.Location = new Point(NewTabButton.Location.X + 63, NewTabButton.Location.Y);
            }
            else if(tabControl1.TabPages.Count == 9)
            {
                NewTabButton.Location = new Point(NewTabButton.Location.X + 33, NewTabButton.Location.Y);
            }

            newTabPage.Controls.Add(newListBox);

            List<Person> personsList = new List<Person>();
            listBoxPersonDictionary.Add(newListBox, personsList);
        }

        private void CreateRecordToCurListBox(Person newPerson, ListBox curListBox)
        {
            curListBox.Items.Add($"{newPerson.Name} - {newPerson.calcAge(DateTime.Now)}");
            listBoxPersonDictionary[curListBox].Add(newPerson);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = "C:\\Users\\Anton\\source\\repos\\first_product_lab1\\first_product_lab1\\MainFormData.txt";
            FileInfo fileInfo = new FileInfo(path);

            StreamWriter writer = fileInfo.CreateText();

            foreach (KeyValuePair<ListBox, List<Person>> entry in listBoxPersonDictionary)
            {
                ListBox curListBox = entry.Key;
                List<Person> personsList = entry.Value;
                TabPage curTabPage = curListBox.Parent as TabPage;

                if (curListBox != null && curTabPage != null)
                {
                    foreach (Person person in personsList)
                    {
                        int tabID = tabControl1.TabPages.IndexOf(curTabPage);
                        writer.WriteLine($"{tabID}|{person.Name}|{person.Bithday}|{person.CardNumber}");
                    }
                }
            }

            writer.Close();
        }

    }
}


