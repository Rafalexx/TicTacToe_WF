using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_TicTacToe
{
    public partial class UserControl2 : UserControl
    {
        private bool turn; //Jeżeli "X" to true, a jak false to "O"
        private int turn_count = 0;
        private bool winner = false; //Zmienna która oznacza, że ktoś wygrał
        private string winner_symbol; //Zmienna która będzie przechowywała znak wygranej osoby
        public int[] A_row = { 0, 0, 0 };
        public int[] B_row = { 0, 0, 0 };
        public int[] C_row = { 0, 0, 0 };
        public UserControl2()
        {
            InitializeComponent();
        }
        private void Button_click(object sender1, EventArgs e)
        {
            Button b = (Button)sender1;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            WriteToTable();
            CheckForWinner();
            turn_count++;
            CheckForDraw();
            turn = !turn;
            b.Enabled = false;//"Zgaszenie" przycisku tego co kliknął użytkownik
        }
        private void WriteToTable()
        {
            for (int i = 0; i < 3; i++)
            {
                if (A1.Text == "X" | A2.Text == "X" | A3.Text == "X")
                {
                    if (A1.Text == "X")
                    {
                        A_row[0] = 1;
                    }
                    if (A2.Text == "X")
                    {
                        A_row[1] = 1;
                    }
                    if (A3.Text == "X")
                    {
                        A_row[2] = 1;
                    };
                }
                if (B1.Text == "X" | B2.Text == "X" | B3.Text == "X")
                {
                    if (B1.Text == "X")
                    {
                        B_row[0] = 1;
                    }
                    if (B2.Text == "X")
                    {
                        B_row[1] = 1;
                    }
                    if (B3.Text == "X")
                    {
                        B_row[2] = 1;
                    };
                }
                if (C1.Text == "X" | C2.Text == "X" | C3.Text == "X")
                {
                    if (C1.Text == "X")
                    {
                        C_row[0] = 1;
                    }
                    if (C2.Text == "X")
                    {
                        C_row[1] = 1;
                    }
                    if (C3.Text == "X")
                    {
                        C_row[2] = 1;
                    };
                }
                if (A1.Text == "O" | A2.Text == "O" | A3.Text == "O")
                {
                    if (A1.Text == "O")
                    {
                        A_row[0] = 2;
                    }
                    if (A2.Text == "O")
                    {
                        A_row[1] = 2;
                    }
                    if (A3.Text == "O")
                    {
                        A_row[2] = 2;
                    };
                }
                if (B1.Text == "O" | B2.Text == "O" | B3.Text == "O")
                {
                    if (B1.Text == "O")
                    {
                        B_row[0] = 2;
                    }
                    if (B2.Text == "O")
                    {
                        B_row[1] = 2;
                    }
                    if (B3.Text == "O")
                    {
                        B_row[2] = 2;
                    };
                }
                if (C1.Text == "O" | C2.Text == "O" | C3.Text == "O")
                {
                    if (C1.Text == "O")
                    {
                        C_row[0] = 2;
                    }
                    if (C2.Text == "O")
                    {
                        C_row[1] = 2;
                    }
                    if (C3.Text == "O")
                    {
                        C_row[2] = 2;
                    };
                }
            }
        }
        private void CheckForWinner()
        {
            // horizontal 
            if ((A_row[0] == A_row[1]) && (A_row[1] == A_row[2]))//Zabezpiecznie się przed znakiem 0 (którym wypełniona jest macierz)
            {
                if ((A_row[0] == 1) || (A_row[0] == 2))
                {
                    winner = true;
                }
            }
            if ((B_row[0] == B_row[1]) && (B_row[1] == B_row[2]))
            {
                if ((B_row[0] == 1) || (B_row[0] == 2))
                {
                    winner = true;
                }
            }
            if ((C_row[0] == C_row[1]) && (C_row[1] == C_row[2]))
            {
                if ((C_row[0] == 1) || (C_row[0] == 2))
                {
                    winner = true;
                }
            }
            // vertical
            if ((A_row[0] == B_row[0]) && (B_row[0] == C_row[0]))
            {
                if ((A_row[0] == 1) || (A_row[0] == 2))
                {
                    winner = true;
                }
            }
            if ((A_row[1] == B_row[1]) && (B_row[1] == C_row[1]))
            {
                if ((A_row[1] == 1) || (A_row[1] == 2))
                {
                    winner = true;
                }
            }
            if ((A_row[2] == B_row[2]) && (B_row[2] == C_row[2]))
            {
                if ((A_row[2] == 1) || (A_row[2] == 2))
                {
                    winner = true;
                }
            }
            // diagonal
            if ((A_row[0] == B_row[1]) && (B_row[1] == C_row[2]))
            {
                if ((A_row[0] == 1) || (A_row[0] == 2))
                {
                    winner = true;
                }
            }
            if ((A_row[2] == B_row[1]) && (B_row[1] == C_row[0]))
            {
                if ((A_row[2] == 1) || (A_row[2] == 2))
                {
                    winner = true;
                }
            }
            if (winner == true)
            {
                DisableButtons();
                if (turn)
                    winner_symbol = "X";
                else
                    winner_symbol = "O";
                MessageBox.Show(winner_symbol + " Wins!", "Good Job!");
                button_pa.Enabled = true;
                button_back.Enabled = true;
            }
        }
        private void DisableButtons()//Funkcja pozwająca "zgasić" wszystkie przyciski
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }
        public void CheckForDraw()
        {
            if ((turn_count == 9) && (winner == false))
            {
                MessageBox.Show("Draw!", "So close...");
            }
        }
        private void Label_Button_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double num = rnd.NextDouble();
            if (num >= 0.5)
            {
                turn = false;
            }
            if (num < 0.5)
            {
                turn = true;
            }
            if (turn == false)
            {
                button_label.Text = "O";
            }
            if (turn == true)
            {
                button_label.Text = "X";
            }
            button_label.Enabled = false;
        }
        private void PA_Button_Click(object sender, EventArgs e)
        {
            UserControl2 second = new UserControl2();
            this.Controls.Add(second);
            this.Hide();//Ponieważ usercontrols nie mają Close() właściwości jak forms
            this.Parent.Controls.Add(second);
        }
        private void Button_back_Click(object sender, EventArgs e)
        {
            UserControl2 second = new UserControl2();
            this.Controls.Add(second);
            UserControl1 first = new UserControl1();
            this.Hide();//Ponieważ usercontrols nie mają Close() właściwości jak forms
            this.Parent.Controls.Add(first);
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
