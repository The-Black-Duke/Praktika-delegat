using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountClass;

namespace Praktika_delegat
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        Account ac;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ac = new Account(Convert.ToInt32(textBox2.Text), textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {ac.fio}, состояние счета: {ac.sum}");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ac.Add(Convert.ToInt32(textBox3.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {ac.fio}, состояние счета: {ac.sum}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            if (ac.sum < x)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("На счету недосатточно средств");
            }
            else
            {
                ac.Take(Convert.ToInt32(textBox3.Text));
                listBox1.Items.Clear();
                listBox1.Items.Add($"Владелец счёта: {ac.fio}, состояние счета: {ac.sum}");
            }
        }
    }
}
