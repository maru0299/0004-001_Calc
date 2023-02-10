using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
        // キー入力を許可する記号のリスト（ダブりNG）
        List<char> AllowedSynbol1 = new List<char>() { '+', '-', '*', '/', '=', '.', '\b', '^','√'};
        // キー入力を許可する記号のリスト（ダブりOK）
        List<char> AllowedSynbol2 = new List<char>() {'(', ')'};
        // 入力を許可する文字のリスト
        List<char> AllowedChar = new List<char>();
        // 式入力バーのキャレット位置
        int CaretIndex = 0;
        // 演算子の多重入力エラーを検出する際に正規表現に使うキーワード
        string keyword = "";
        string pattern;

        public Form1()
        {
            InitializeComponent();
            // キーイベントハンドラ設定
            this.KeyPreview = true;

            // 入力を許可する文字の定義
            AllowedChar.AddRange(AllowedNum);
            AllowedChar.AddRange(AllowedSynbol1);
            AllowedChar.AddRange(AllowedSynbol2);

            // debug
            debug_table.Rows.Add();
            debug_table.Rows[0].HeaderCell.Value = "key";
            debug_table.Rows.Add();
            debug_table.Rows[1].HeaderCell.Value = "caret.index";
            debug_table.Rows.Add();
            debug_table.Rows[2].HeaderCell.Value = "caret.X";
            debug_table.Rows.Add();
            debug_table.Rows[3].HeaderCell.Value = "caret.Y";

            // 正規表現に使う
            foreach (char i in AllowedSynbol1)
            {
                keyword = keyword +"\\"+ i.ToString();
            }
            pattern = "[" + keyword + "][" + keyword + "]";

            // キャレットの描画
            drawcaret();
        }

        //// 関数 ////

        // 式テキストボックスのキャレット位置を移動する
        // numで指定された移動する。
        private void movecaret(int num)
        {
            if (CaretIndex == 0 && num < 0)
            {
                return;
            }
            else if (CaretIndex == textBox_formula.Text.Length && num > 0)
            {
                return;
            }
            else
            {
                CaretIndex += num;
            }

            // debug
            debug_table[0, 1].Value = CaretIndex.ToString();

            //キャレット描画
            drawcaret();
        }

        private void drawcaret()
        {
            // テキストボックス内のキャレット座標を取得
            Point point1 = textBox_formula.GetPositionFromCharIndex(CaretIndex);
            Point point2 = point1;
            point2.Y += 20;

            // debug
            debug_table[0, 2].Value = point1.X.ToString();
            debug_table[0, 3].Value = point1.Y.ToString();

            // キャレットの描画
            var pen = new Pen(Color.Black, 1);
            Graphics caret = textBox_formula.CreateGraphics();
            textBox_formula.Refresh();  // 古い描画物を消す
            caret.DrawLine(pen, point1, point2);    // キャレット表示
        }

        // バックスペース処理
        private void backspace()
        {
            if (textBox_formula.Text.Length != 0 && CaretIndex != 0)
            {
                textBox_formula.Text = textBox_formula.Text.Remove(CaretIndex-1,1);
                movecaret(-1);
            }
        }

        // 式のクリア
        private void clear_formula()
        {
            textBox_formula.ResetText();
            CaretIndex = 0;
        }

        // 式入力
        private void inputformula(char key)
        {
            textBox_formula.Text = textBox_formula.Text.Insert(CaretIndex, key.ToString());
            movecaret(1);
        }

        // 式計算
        private void calc()
        {
            //// エラー処理 式に何も入力されていないときは何も処理せずreturn
            //if (textBox_formula.TextLength == 0)
            //{
            //    textBox_result.ResetText();
            //    return;
            //}

            // 計算→解を表示

            try
            {
                // 演算子の多重入力チェック
                if (Regex.IsMatch(textBox_formula.Text, pattern))
                {
                    throw new Exception("演算子の多重入力です");
                }

                // 計算
                System.Data.DataTable dt = new System.Data.DataTable();
                string result = dt.Compute(textBox_formula.Text, null).ToString();
                textBox_result.Text = result.ToString();
            }
            catch   
            {
                // 例外が出たら解テキストを空欄にする
                textBox_result.Text = "";
            }
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

            debug_table[0,0].Value = e.KeyChar.ToString();

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

        // 式テキストボックスの内容が変更されたら都度calc関数を実行
        private void textBox_formula_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        // エンターキー、矢印キーの処理　ProcessDialogKeyをオーバーライド
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
            else if ((keyData & Keys.KeyCode) == Keys.Left)
            {
                //Enterキー
                movecaret(-1);
                //本来の処理はさせない
                return true;
            }
            else if ((keyData & Keys.KeyCode) == Keys.Right)
            {
                //Enterキー
                movecaret(1);
                //本来の処理はさせない
                return true;
            }
            else if ((keyData & Keys.KeyCode) == Keys.Escape)
            {
                this.button_C.Focus();
                this.button_C.PerformClick();
                return true;
            }
            else if ((keyData & Keys.KeyCode) == Keys.Space)
            {
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void textBox_formula_MouseClick(object sender, MouseEventArgs e)
        {
            CaretIndex = textBox_formula.SelectionStart;
            drawcaret();
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