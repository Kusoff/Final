using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(FullNameTextBox.Text) &&
            !string.IsNullOrWhiteSpace(FullNameTextBox.Text) &&
            !string.IsNullOrEmpty(dateTimePicker1.Text) &&
            !string.IsNullOrWhiteSpace(dateTimePicker1.Text) &&
            !string.IsNullOrEmpty(GenderTextBox.Text) &&
            !string.IsNullOrWhiteSpace(GenderTextBox.Text) &&
            !string.IsNullOrEmpty(AddressTextBox.Text) &&
            !string.IsNullOrWhiteSpace(AddressTextBox.Text) &&
            !string.IsNullOrEmpty(PassportTextBox.Text) &&
            !string.IsNullOrWhiteSpace(PassportTextBox.Text) &&
            !string.IsNullOrEmpty(TotalScoreTextBox.Text) &&
            !string.IsNullOrWhiteSpace(TotalScoreTextBox.Text) &&
            !string.IsNullOrEmpty(comboBox1.Text) &&
            !string.IsNullOrWhiteSpace(comboBox1.Text) &&
            !string.IsNullOrEmpty(comboBox1.Text) &&
            !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                string fullName = FullNameTextBox.Text;
                DateTime dateOfBirth = dateTimePicker1.Value;
                string gender = GenderTextBox.Text;
                string address = AddressTextBox.Text;
                string passport = PassportTextBox.Text;
                int totalScore = Convert.ToInt32(TotalScoreTextBox.Text);
                string groupName = comboBox1.Text;
                string Money;
                if (radioButton1.Checked == true)
                {
                    Money = "Да";
                }
                else
                {
                    Money = "Нет";
                }

                Student student = new Student();
                {
                    student.FullName= fullName;
                    student.DateOfBirth=dateOfBirth;
                    student.Gender= gender;
                    student.Address= address;
                    student.Passport= passport;
                    student.TotalScore= totalScore;
                    student.GroupName= groupName;
                    student.Money= Money;

                    DatabaseManager dbManager = new DatabaseManager();
                    dbManager.AddStudent(student);

                    MessageBox.Show("Успешное добавление");
                    Hide();
                    Form1 home = new Form1();
                    home.ShowDialog();

                    Close();

                }

            }
            else //если все строки не заполнены, выдаем ошибку
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("3-1 ИС");
            comboBox1.Items.Add("3-2 ИС");
            comboBox1.Items.Add("2 ИС");
        }
    }
}
