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
        // キー入力を許可する文字
        List<char> AllowedNum = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
        List<char> AllowedSynbol = new List<char>() { '+', '-', '*', '/', '=', '.', '\b', '^' };
        List<char> AllowedChar = new List<char>();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            AllowedChar.AddRange(AllowedNum);
            AllowedChar.AddRange(AllowedChar);
        }

        //// 関数 ////
 
        // バックスペース処理
        private void backspace()
        {
            int Length = textBox_formula.Text.Length;
            if (Length != 0)
            {
                textBox_formula.Text = textBox_formula.Text.Substring(0, Length - 1);
            }
        }

        // 式入力
        private void inputformula(string str)
        {
            textBox_formula.AppendText(str);
        }

        // 式計算
        private void calc()
        {
            var calc_num = textBox_formula.Text.Split(AllowedSynbol.ToArray());
            var calc_synbol = textBox_formula.Text.Split(AllowedNum.ToArray());

            int length_num = calc_num.Length;
            int length_synbol = calc_synbol.Length;

            double result= double.Parse(calc_num[0]);

            for (int i = 1; i < length_num; i++)
            {
                switch (calc_synbol[i])
                {
                    case "+":
                        result += double.Parse(calc_num[i]);
                        break;
                    case "-":
                        result -= double.Parse(calc_num[i]);
                        break;
                    case "*":
                        result *= double.Parse(calc_num[i]);
                        break;
                    case "/":
                        result /= double.Parse(calc_num[i]);
                        break;
                }
            }

            textBox_result.Text = result.ToString();
        }

        //// インターフェース ////

        private void button_1_Click(object sender, EventArgs e)
        {
            inputformula("1");// 入力処理を行う関数を呼ぶ
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            inputformula("2");// 入力処理を行う関数を呼ぶ
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            inputformula("3");// 入力処理を行う関数を呼ぶ
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            inputformula("4");// 入力処理を行う関数を呼ぶ
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            inputformula("5");// 入力処理を行う関数を呼ぶ
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            inputformula("6");// 入力処理を行う関数を呼ぶ
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            inputformula("7");// 入力処理を行う関数を呼ぶ
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            inputformula("8");// 入力処理を行う関数を呼ぶ
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            inputformula("9");// 入力処理を行う関数を呼ぶ
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            inputformula("0");// 入力処理を行う関数を呼ぶ
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            calc();
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            inputformula(".");// 入力処理を行う関数を呼ぶ
        }

        private void button_tasu_Click(object sender, EventArgs e)
        {
            inputformula("+");// 入力処理を行う関数を呼ぶ
        }

        private void button_hiku_Click(object sender, EventArgs e)
        {
            inputformula("-");// 入力処理を行う関数を呼ぶ
        }

        private void button_kakeru_Click(object sender, EventArgs e)
        {
            inputformula("*");// 入力処理を行う関数を呼ぶ
        }

        private void button_waru_Click(object sender, EventArgs e)
        {
            inputformula("/");// 入力処理を行う関数を呼ぶ
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            backspace();
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            textBox_formula.ResetText();
        }


        //// イベントハンドラ ////

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 許可文字以外の時は、イベントをキャンセルする
            if (!AllowedChar.Contains(e.KeyChar))
            {
                e.Handled = true;
            }

            // キーボード入力：文字キー
            if (!textBox_formula.Focused)
            {
                switch (e.KeyChar)
                {
                    case '1':
                        this.button_1.Focus();
                        this.button_1.PerformClick();
                        break;
                    case '2':
                        this.button_2.Focus();
                        this.button_2.PerformClick();
                        break;
                    case '3':
                        this.button_3.Focus();
                        this.button_3.PerformClick();
                        break;
                    case '4':
                        this.button_4.Focus();
                        this.button_4.PerformClick();
                        break;
                    case '5':
                        this.button_5.Focus();
                        this.button_5.PerformClick();
                        break;
                    case '6':
                        this.button_6.Focus();
                        this.button_6.PerformClick();
                        break;
                    case '7':
                        this.button_7.Focus();
                        this.button_7.PerformClick();
                        break;
                    case '8':
                        this.button_8.Focus();
                        this.button_8.PerformClick();
                        break;
                    case '9':
                        this.button_9.Focus();
                        this.button_9.PerformClick();
                        break;
                    case '0':
                        this.button_0.Focus();
                        this.button_0.PerformClick();
                        break;
                    case '+':
                        this.button_tasu.Focus();
                        this.button_tasu.PerformClick();
                        break;
                    case '-':
                        this.button_hiku.Focus();
                        this.button_hiku.PerformClick();
                        break;
                    case '/':
                        this.button_waru.Focus();
                        this.button_waru.PerformClick();
                        break;
                    case '*':
                        this.button_kakeru.Focus();
                        this.button_kakeru.PerformClick();
                        break;
                    case '.':
                        this.button_kakeru.Focus();
                        this.button_kakeru.PerformClick();
                        break;
                    case '=':
                        this.button_equal.Focus();
                        this.button_equal.PerformClick();
                        break;
                }
            }
        }

        // キーボード入力：特殊キー
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!textBox_formula.Focused)
            {
                switch (e.KeyCode)
                {
                    // BackSpace
                    case Keys.Back:
                        this.button_back.Focus();
                        this.button_back.PerformClick();
                        break;
                }
            }
        }
    }
}
