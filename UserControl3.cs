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
    public partial class UserControl3 : UserControl
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
        private double num_end; //Zmienna, która przyjmie parametr losowy decydujący o rozpoczęciu gry przez danego gracza.
        public UserControl3()
        {
            InitializeComponent();
        }
        private void Poss_moves()
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
            Array.Clear(Free_Space, 0, Free_Space.Length); //Czyszczenie tablicy dla zasady
        }
        private void Choice_move()//Funkcja mająca na celu wybranie jednego z pozostałych ruchów względem losowej liczby, która później posłuży do odczytania pozycji z tablicy
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
        private void Draw_move()
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
        private void Table_String()
        {
            string result;
            result = string.Join(".", Free_Space);
            MessageBox.Show(result);
        }
        private void Button_click(object sender1, EventArgs e)
        {
            Button b = (Button)sender1;

            if (!turn)
            {
                b.Text = "X";
                turn_count++;
                WriteToTable(); //Moja kolej minęła, więc muszę dodać że zrobiłem ruch
                CheckForWinner();
                CheckForDraw();
            }
            if (winner == false)
            {
                Poss_moves();
                Draw_move();
                turn_count++;
                CheckForWinner();
                CheckForDraw();
            }
            b.Enabled = false; //"Zgaszenie" przycisku tego co kliknął użytkownik
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
                    if (A_row[0] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            if ((B_row[0] == B_row[1]) && (B_row[1] == B_row[2]))
            {
                if ((B_row[0] == 1) || (B_row[0] == 2))
                {
                    winner = true;
                    if (B_row[0] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            if ((C_row[0] == C_row[1]) && (C_row[1] == C_row[2]))
            {
                if ((C_row[0] == 1) || (C_row[0] == 2))
                {
                    winner = true;
                    if (C_row[0] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            // vertical
            if ((A_row[0] == B_row[0]) && (B_row[0] == C_row[0]))
            {
                if ((A_row[0] == 1) || (A_row[0] == 2))
                {
                    winner = true;
                    if (A_row[0] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            if ((A_row[1] == B_row[1]) && (B_row[1] == C_row[1]))
            {
                if ((A_row[1] == 1) || (A_row[1] == 2))
                {
                    winner = true;
                    if (A_row[1] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            if ((A_row[2] == B_row[2]) && (B_row[2] == C_row[2]))
            {
                if ((A_row[2] == 1) || (A_row[2] == 2))
                {
                    winner = true;
                    if (A_row[2] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            // diagonal
            if ((A_row[0] == B_row[1]) && (B_row[1] == C_row[2]))
            {
                if ((A_row[0] == 1) || (A_row[0] == 2))
                {
                    winner = true;
                    if (A_row[0] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            if ((A_row[2] == B_row[1]) && (B_row[1] == C_row[0]))
            {
                if ((A_row[2] == 1) || (A_row[2] == 2))
                {
                    winner = true;
                    if (A_row[2] == 1)
                        winner_symbol = "X";
                    else
                        winner_symbol = "O";
                }
            }
            if (winner == true)
            {
                DisableButtons();
                button_pa.Enabled = true;
                button_back.Enabled = true;
                MessageBox.Show(winner_symbol + " Wins!", "Good Job!");
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
        private void CheckForDraw()
        {
            if ((turn_count == 9) && (winner == false))
            {
                MessageBox.Show("Draw!", "So close...");
            }
        }
        private void Label_Button_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            num_end = rnd.NextDouble();
            if (num_end >= 0.5)
            {
                button_label.Text = "PLAYER";
            }
            if (num_end < 0.5)
            {
                turn = false;
                button_label.Text = "COMPUTER";
                Poss_moves();
                Draw_move();
                turn_count++;
            }
            button_label.Enabled = false;
        }
        private void PA_Button_Click(object sender, EventArgs e)
        {
            UserControl3 third = new UserControl3();
            this.Controls.Add(third);
            this.Hide();//Ponieważ usercontrols nie mają Close() właściwości jak forms
            this.Parent.Controls.Add(third);
        }
        private void Button_back_Click(object sender, EventArgs e)
        {
            UserControl3 third = new UserControl3();
            this.Controls.Add(third);
            UserControl1 first = new UserControl1();
            this.Hide();//Ponieważ usercontrols nie mają Close() właściwości jak forms
            this.Parent.Controls.Add(first);
        }
    }
}
