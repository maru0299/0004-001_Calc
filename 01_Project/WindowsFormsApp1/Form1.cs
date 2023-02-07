using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//追加


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // キー入力を許可する数字のリスト
        List<char> AllowedNum = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
        // キー入力を許可する記号のリスト
        List<char> AllowedSynbol = new List<char>() { '+', '-', '*', '/', '=', '.', '\b', '^', '(', ')','√'};
        // 入力を許可する文字のリスト
        List<char> AllowedChar = new List<char>();

        public Form1()
        {
            InitializeComponent();

            // 入力を許可する文字の定義
            AllowedChar.AddRange(AllowedNum);
            AllowedChar.AddRange(AllowedChar);
            this.KeyPreview = true;
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

        // 式のクリア
        private void clear_formula()
        {
            textBox_formula.ResetText();
        }

        // 式入力
        private void inputformula(char key)
        {
            textBox_formula.AppendText(key.ToString());
        }

        // 式計算
        private void calc()
        {
            // エラー処理 式に何も入力されていないときは何も処理せずreturn
            if (textBox_formula.TextLength == 0)
            {
                textBox_result.ResetText();
                return;
            }

            // 式を要素に分解
            // 数字
            var calc_num = textBox_formula.Text.Split(AllowedSynbol.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            // 演算子
            var calc_synbol = textBox_formula.Text.Split(calc_num, StringSplitOptions.RemoveEmptyEntries);
            // 式の項数
            int length_num = calc_num.Length;
            // 演算子の数
            int length_synbol = calc_synbol.Length;

            // 解を入れる変数
            double result = double.Parse(calc_num[0]);

            // 計算処理（i+1番目の演算子の処理）
            for (int i = 0; i < length_num-1; i++)
            {
                switch (calc_synbol[i])
                {
                    case "+":
                        result += double.Parse(calc_num[i + 1]);
                        break;
                    case "-":
                        result -= double.Parse(calc_num[i + 1]);
                        break;
                    case "*":
                        result *= double.Parse(calc_num[i + 1]);
                        break;
                    case "/":
                        result /= double.Parse(calc_num[i + 1]);
                        break;
                }
            }

            // 解をテキストボックスに表示
            textBox_result.Text = result.ToString();
        }






        //// イベントハンドラ ////

        // 文字・数字キーの処理
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 許可したキー以外の時は、イベントをキャンセルする
            if (!AllowedChar.Contains(e.KeyChar))
            {
                e.Handled = true;
            }

            textBox_debug.Text = e.KeyChar.ToString();

            // キーボード入力：文字・数字キー
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
                    this.button_dot.Focus();
                    this.button_dot.PerformClick();
                    break;
                case '=':
                    this.button_equal.Focus();
                    this.button_equal.PerformClick();
                    break;
                case '(':
                    this.button_kakko1.Focus();
                    this.button_kakko1.PerformClick();
                    break;
                case ')':
                    this.button_kakko2.Focus();
                    this.button_kakko2.PerformClick();
                    break;
            }
        }

        // 特殊キーの処理
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // デバッグ用
            //textBox_debug.Text = e.KeyCode.ToString();

            switch (e.KeyCode)
            {
                // BackSpace
                case Keys.Back:
                case Keys.Delete:
                    this.button_back.Focus();
                    this.button_back.PerformClick();
                    break;
            }
        }

        // エンターキーの処理
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //Returnキーが押されているか調べる
            if ((keyData & Keys.KeyCode) == Keys.Return)
            {
                //Enterキー
                this.button_equal.Focus();
                this.button_equal.PerformClick();
                //本来の処理はさせない
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        // 式テキストボックスの内容が変更されたら都度calc関数を実行
        private void textBox_formula_TextChanged(object sender, EventArgs e)
        {
            calc();
        }







        //// インターフェース ////

        private void button_1_Click(object sender, EventArgs e)
        {
            inputformula('1');// 入力処理を行う関数を呼ぶ
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            inputformula('2');// 入力処理を行う関数を呼ぶ
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            inputformula('3');// 入力処理を行う関数を呼ぶ
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            inputformula('4');// 入力処理を行う関数を呼ぶ
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            inputformula('5');// 入力処理を行う関数を呼ぶ
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            inputformula('6');// 入力処理を行う関数を呼ぶ
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            inputformula('7');// 入力処理を行う関数を呼ぶ
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            inputformula('8');// 入力処理を行う関数を呼ぶ
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            inputformula('9');// 入力処理を行う関数を呼ぶ
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            inputformula('0');// 入力処理を行う関数を呼ぶ
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            calc();// 計算関数を呼ぶ
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            inputformula('.');// 入力処理を行う関数を呼ぶ
        }

        private void button_tasu_Click(object sender, EventArgs e)
        {
            inputformula('+');// 入力処理を行う関数を呼ぶ
        }

        private void button_hiku_Click(object sender, EventArgs e)
        {
            inputformula('-');// 入力処理を行う関数を呼ぶ
        }

        private void button_kakeru_Click(object sender, EventArgs e)
        {
            inputformula('*');// 入力処理を行う関数を呼ぶ
        }

        private void button_waru_Click(object sender, EventArgs e)
        {
            inputformula('/');// 入力処理を行う関数を呼ぶ
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            backspace();
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            clear_formula();
        }

        private void button_kakko1_Click(object sender, EventArgs e)
        {
            inputformula('(');// 入力処理を行う関数を呼ぶ
        }

        private void button_kakko2_Click(object sender, EventArgs e)
        {
            inputformula(')');// 入力処理を行う関数を呼ぶ
        }
    }
}