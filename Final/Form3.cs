using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text)) 
            {
                if (!int.TryParse(textBox1.Text, out int studentId))
                {
                    MessageBox.Show("Некорректное значение ID студента. Введите целое число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool isDeleted = DatabaseManager.DeleteStudent(studentId);

                if (isDeleted)
                {
                    MessageBox.Show("Студент успешно удален");
                }
                else
                {
                    MessageBox.Show("Не удалось найти студента с указанным ID");
                }
            }
            else
            {
                MessageBox.Show("Некорректное значение ID студента");
            }

        }

    }
}