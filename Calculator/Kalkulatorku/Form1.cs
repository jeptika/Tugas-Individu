using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulatorku
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operation = "";
        bool isOperation = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void click_button(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (isOperation))
                textBox1.Clear();

            isOperation = false;
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if(!textBox1.Text.Contains(","))
                    textBox1.Text = textBox1.Text + button.Text;
            }
            else
            textBox1.Text = textBox1.Text + button.Text;
        }
        
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                samadengan.PerformClick();
                operation = button.Text;
                label1.Text = resultValue + " " + operation;
                isOperation = true;
            }
            else
            {
                operation = button.Text;
                resultValue = Double.Parse(textBox1.Text);
                label1.Text = resultValue + " " + operation;
                isOperation = true; 
            }
        }

        private void ce_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void c_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
        }

        private void samadengan_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                    break;

                case "-":
                    textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                    break;

                case "/":
                    textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                    break;

                case "*":
                    textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                    break;

                default:
                    break;

            }
            resultValue = Double.Parse(textBox1.Text);
            label1.Text = "";
        }
    }
}
