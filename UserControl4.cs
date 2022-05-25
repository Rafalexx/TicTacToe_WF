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
    public partial class UserControl4 : UserControl
    {
        private bool turn; //Jeżeli "X" to true, a jak false to "O"
        private int turn_count = 0;
        private bool winner = false; //Zmienna która oznacza, że ktoś wygrał
        private string winner_symbol; //Zmienna która będzie przechowywała znak wygranej osoby
        public int[] A_row = { 0, 0, 0 };
        public int[] B_row = { 0, 0, 0 };
        public int[] C_row = { 0, 0, 0 };
        private string rand_choice; //Zmienna, która będzie ukazywała pozycję losowego wybranego ruchu przez komputer
        private string[] Free_Space; //Tablica wolnych miejsc
        private int z; //Licznik obiektów tablicy
        public UserControl4()
        {
            InitializeComponent();
        }
        public void Poss_moves()
        {
            Free_Space = new string[9 - turn_count]; //Za każdym razem tablica będzie miała mniej o liczbę ruchu każdego z graczy.
            if (A_row[0] == 0)
            {
                Free_Space[z] = "A1";
                z++;
            }
            if (A_row[1] == 0)
            {
                Free_Space[z] = "A2";
                z++;
            }
            if (A_row[2] == 0)
            {
                Free_Space[z] = "A3";
                z++;
            }
            if (B_row[0] == 0)
            {
                Free_Space[z] = "B1";
                z++;
            }
            if (B_row[1] == 0)
            {
                Free_Space[z] = "B2";
                z++;
            }
            if (B_row[2] == 0)
            {
                Free_Space[z] = "B3";
                z++;
            }
            if (C_row[0] == 0)
            {
                Free_Space[z] = "C1";
                z++;
            }
            if (C_row[1] == 0)
            {
                Free_Space[z] = "C2";
                z++;
            }
            if (C_row[2] == 0)
            {
                Free_Space[z] = "C3";
                z++;
            }
            //Table_String();
            z = 0; //Reset pozycji aby na nowo zaczynał się od początku tablicy algorytm
            Choice_move();
            Array.Clear(Free_Space, 0, Free_Space.Length);//Czyszczenie tablicy dla zasady
        }
        public void Choice_move()//Funkcja mająca na celu wybranie jednego z pozostałych ruchów względem losowej liczby, która później posłuży do odczytania pozycji z tablicy
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 9 - turn_count);
            //string resultXD = string.Join(".", num);//Przekonwertowanie wartość int na str metodą Join
            //MessageBox.Show(resultXD);
            try
            {
                rand_choice = Free_Space[num];
                //MessageBox.Show(rand_choice);//Ukazanie pozycji z tablicy np. A3, która została wybrana przez algorytm.
            }//Zapobieganie wykroczeniu po za index gdy tablica jest pusta bo już nie ma ruchów.
            catch
            {
            }
        }
        private void Table_String()//Funkcja ukazująca tablicę Free_Space, która jest tab. wszystkich możliwych ruchów komputera
        {
            string result;
            result = string.Join(".", Free_Space);
            MessageBox.Show(result);
        }
        public void Button_click(object sender1, EventArgs e)
        {
            if (turn==true)
            {
                Poss_moves();
                Draw_move_X();
            }
            if (turn==false)
            {
                Poss_moves();
                Draw_move_O();
            }
            WriteToTable();
            CheckForWinner();
            turn_count++;
            CheckForDraw();
            turn = !turn;
            button1.Text = ("TURN: " + turn_count);
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
            if ((A_row[0] == A_row[1]) && (A_row[1] == A_row[2]))
            {
                if ((A_row[0] == 1) || (A_row[0] == 2))//Zabezpiecznie się przed znakiem 0 (którym wypełniona jest macierz)
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
                button1.Enabled = false;
                if (turn)
                    winner_symbol = "X";
                else
                    winner_symbol = "O";
                MessageBox.Show(winner_symbol + " Wins!", "Good Job!");
            }
        }
        public void Draw_move_O()
        {
            if (rand_choice == "A1")
            {
                A_row[0] = 2;
                A1.Text = "O";
                A1.Enabled = false;
            }
            if (rand_choice == "A2")
            {
                A_row[1] = 2;
                A2.Text = "O";
                A2.Enabled = false;
            }
            if (rand_choice == "A3")
            {
                A_row[2] = 2;
                A3.Text = "O";
                A3.Enabled = false;
            }
            if (rand_choice == "B1")
            {
                B_row[0] = 2;
                B1.Text = "O";
                B1.Enabled = false;
            }
            if (rand_choice == "B2")
            {
                B_row[1] = 2;
                B2.Text = "O";
                B2.Enabled = false;
            }
            if (rand_choice == "B3")
            {
                B_row[2] = 2;
                B3.Text = "O";
                B3.Enabled = false;
            }
            if (rand_choice == "C1")
            {
                C_row[0] = 2;
                C1.Text = "O";
                C1.Enabled = false;
            }
            if (rand_choice == "C2")
            {
                C_row[1] = 2;
                C2.Text = "O";
                C2.Enabled = false;
            }
            if (rand_choice == "C3")
            {
                C_row[2] = 2;
                C3.Text = "O";
                C3.Enabled = false;
            }
        }
        public void Draw_move_X()
        {
            if (rand_choice == "A1")
            {
                A_row[0] = 2;
                A1.Text = "X";
            }
            if (rand_choice == "A2")
            {
                A_row[1] = 2;
                A2.Text = "X";
            }
            if (rand_choice == "A3")
            {
                A_row[2] = 2;
                A3.Text = "X";
            }
            if (rand_choice == "B1")
            {
                B_row[0] = 2;
                B1.Text = "X";
            }
            if (rand_choice == "B2")
            {
                B_row[1] = 2;
                B2.Text = "X";
            }
            if (rand_choice == "B3")
            {
                B_row[2] = 2;
                B3.Text = "X";
            }
            if (rand_choice == "C1")
            {
                C_row[0] = 2;
                C1.Text = "X";
            }
            if (rand_choice == "C2")
            {
                C_row[1] = 2;
                C2.Text = "X";
            }
            if (rand_choice == "C3")
            {
                C_row[2] = 2;
                C3.Text = "X";
            }
        }
        public void CheckForDraw()
        {
            if ((turn_count == 9) && (winner == false))
            {
                MessageBox.Show("Draw!", "So close...");
            }
        }
        private void Check_button_click(object sender0, EventArgs e)
        {
            Random rnd = new Random();
            Button a = (Button)sender0;
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
                a.Text = "O";
            }
            if (turn == true)
            {
                a.Text = "X";
            }
            a.Enabled = false;
            button1.Enabled = true;
        }
        private void PA_Button_Click(object sender, EventArgs e)
        {
            UserControl4 fourth = new UserControl4();
            this.Controls.Add(fourth);
            this.Hide();//Ponieważ usercontrols nie mają Close() właściwości jak forms
            this.Parent.Controls.Add(fourth);
        }
        private void Button_back_Click(object sender, EventArgs e)
        {
            UserControl4 fourth = new UserControl4();
            this.Controls.Add(fourth);
            UserControl1 first = new UserControl1();
            this.Hide();//Ponieważ usercontrols nie mają Close() właściwości jak forms
            this.Parent.Controls.Add(first);
        }
    }
}