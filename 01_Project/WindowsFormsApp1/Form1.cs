using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            inpuformula("1");// 入力処理を行う関数を呼ぶ
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            inpuformula("2");// 入力処理を行う関数を呼ぶ
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            inpuformula("3");// 入力処理を行う関数を呼ぶ
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            inpuformula("4");// 入力処理を行う関数を呼ぶ
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            inpuformula("5");// 入力処理を行う関数を呼ぶ
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            inpuformula("6");// 入力処理を行う関数を呼ぶ
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            inpuformula("7");// 入力処理を行う関数を呼ぶ
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            inpuformula("8");// 入力処理を行う関数を呼ぶ
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            inpuformula("9");// 入力処理を行う関数を呼ぶ
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            inpuformula("0");// 入力処理を行う関数を呼ぶ
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            inpuformula("=");// 入力処理を行う関数を呼ぶ
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            inpuformula(".");// 入力処理を行う関数を呼ぶ
        }

        private void button_tasu_Click(object sender, EventArgs e)
        {
            inpuformula("+");// 入力処理を行う関数を呼ぶ
        }

        private void button_hiku_Click(object sender, EventArgs e)
        {
            inpuformula("-");// 入力処理を行う関数を呼ぶ
        }

        private void button_kakeru_Click(object sender, EventArgs e)
        {
            inpuformula("*");// 入力処理を行う関数を呼ぶ
        }

        private void button_waru_Click(object sender, EventArgs e)
        {
            inpuformula("/");// 入力処理を行う関数を呼ぶ
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            backspace();
        }
        
        private void inpuformula(string str)
        {
            textBox_formula.AppendText(str);
        }

        private void backspace()
        {
            int Length = textBox_formula.Text.Length;
            if(Length != 0)
            {
                textBox_formula.Text = textBox_formula.Text.Substring(0, Length - 1);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                // 数字とバックスペース以外は処理しない
                e.Handled = true;
            }

            textBox_formula.AppendText(e.KeyChar.ToString());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                // 数字とバックスペース以外は処理しない
                e.Handled = true;
            }
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    this.button_1.Focus();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    this.button_2.Focus();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    this.button_3.Focus();
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    this.button_4.Focus();
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    this.button_1.Focus();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    this.button_6.Focus();
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    this.button_7.Focus();
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    this.button_8.Focus();
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    this.button_9.Focus();
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    this.button_0.Focus();
                    break;
            }
        }
    }
}
