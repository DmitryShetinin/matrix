using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace matrix
{
    public partial class Form1 : Form
    {
        int p = 0;
        int stroka = 0;
        int stolbec = 0;
        int SSS = 0;
        int SSS1 = 0;
        int[] AxB = new int[100];
        int[] AxB2 = new int[100];
        bool z = true;
        int k2 = 0;
        TabPage[] t1 = new TabPage[2];
        Button[] bs = new Button[2];
        TextBox[,] arr3 = new TextBox[200, 200];
        TextBox[,] arr4 = new TextBox[200, 200];


        int zxc1 = 0;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    TextBox zxc = new TextBox();
                    zxc.Text = "123";
                    arr3[i, j] = zxc;
                    arr4[i, j] = zxc;
                }
            }

            for (int i = 0; i < AxB.Length; i++)
            {
                AxB[i] = 999;
                AxB2[i] = 999;
            }


        }
        int s = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int ZXC(ref int[] array)
        {

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] != 999)
                {
                    return i;
                }
            }
            return 0;
        }

        int h = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (s == 0)
            {
                TabPage newTabPage = new TabPage();
                newTabPage.Text = "Матрица А";

                t1[0] = newTabPage;
                tabControl1.TabPages.Add(newTabPage);


                Button b1 = new Button();
                b1.Width = 150;
                b1.Text = "Произвести расчеты";



                tabControl1.TabPages[1].Controls.Add(b1);

                bs[0] = b1;

                TextBox[,] arr1 = new TextBox[Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)];

                SSS = Convert.ToInt32(textBox2.Text); // СТРОКИ 1-ой матрицы
                stolbec = Convert.ToInt32(textBox1.Text);// СТОЛБЦЫ матрицы 1 
                for (int i = 0; i < arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < arr1.GetLength(1); j++)
                    {
                        TextBox s1 = new TextBox();
                        s1.KeyPress += (object sender1, KeyPressEventArgs es) =>
                        {
                            char number = es.KeyChar;
                            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
                            {
                                es.Handled = true;
                            }
                        };
                        s1.Text = "";
                        arr1[i, j] = s1;
                        arr3[i, j] = s1;
                    }

                }

                s++;
                int k = 100, k1 = 0;
                for (int i = 0; i < arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < arr1.GetLength(1); j++)
                    {
                        arr1[i, j].Location = new Point(k, k1 += 50);

                        tabControl1.TabPages[1].Controls.Add(arr1[i, j]);
                    }
                    k += 150;
                    k1 = 0;
                }

                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;

            }
            else if (s == 1)
            {




                SSS1 = Convert.ToInt32(textBox1.Text); // СТОЛБЦЫ 2-ой матрицы
                stroka = Convert.ToInt32(textBox2.Text); // CТРОКИ 2 матрицы
                if (stolbec != stroka)
                {
                    MessageBox.Show("Операция умножения двух матриц выполнима только в том случае, если число столбцов в первом сомножителе равно числу строк во втором");

                }
                else
                {
                    TextBox[,] arr2 = new TextBox[Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)];
                    TabPage newTabPage = new TabPage();
                    newTabPage.Text = "Матрица Б";

                    t1[1] = newTabPage;
                    tabControl1.TabPages.Add(newTabPage);
                    Button b2 = new Button();
                    b2.Width = 150; 
                    b2.Text = "Произвести расчеты";
                    tabControl1.TabPages[2].Controls.Add(b2);
                    for (int i = 0; i < arr2.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr2.GetLength(1); j++)
                        {
                            TextBox s1 = new TextBox();
                            s1.KeyPress += (object sender1, KeyPressEventArgs es) =>
                            {
                                char number = es.KeyChar;
                                if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
                                {
                                    es.Handled = true;
                                }
                            };
                            s1.Text = "";
                            arr2[i, j] = s1;
                            arr4[i, j] = s1;
                        }

                    }




                    s++;
                    int k = 100, k1 = 0;
                    for (int i = 0; i < arr2.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr2.GetLength(1); j++)
                        {
                            arr2[i, j].Location = new Point(k, k1 += 50);
                            tabControl1.TabPages[2].Controls.Add(arr2[i, j]);
                        }
                        k += 150;
                        k1 = 0;
                    }

                    bs[1] = b2;
                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    zxc1++;
                    bs[0].Click += (s, ef) =>
                    {
                        if (p > 0)
                        {
                            MessageBox.Show("Расчеты уже были произведены");
                        }
                        else
                        {


                            p++;
                            k1 = 0;
                            k2 = 0;

                            //===========================AxB=======================================================
                            for (int z = 0; z < SSS1; z++)
                            {
                                for (int i = 0; i < SSS; i++) // ОТВЕЧАЕТ ЗА СТРОКИ
                                {
                                    for (int j = 0; j < stroka; j++) // ОТВЕЧАЕТ ЗА СТОЛБЦЫ
                                    {

                                        k1 = k1 + (Convert.ToInt32(arr3[j, i].Text) * Convert.ToInt32(arr4[z, j].Text));


                                    }
                                    p++;

                                    AxB[h] = k1;
                                    h++;

                                    k1 = 0;

                                }
                                h++;

                                k1 = 0;

                            }
                            //==========================================================================================
                            h = 0;
                            if (SSS1 == SSS)
                            {
                                for (int z = 0; z < stroka; z++)
                                {
                                    for (int i = 0; i < stroka; i++) // ОТВЕЧАЕТ ЗА СТРОКИ
                                    {
                                        for (int j = 0; j < SSS1; j++) // ОТВЕЧАЕТ ЗА СТОЛБЦЫ
                                        {
                                            k2 = k2 + (Convert.ToInt32(arr4[j, i].Text) * Convert.ToInt32(arr3[z, j].Text));

                                        }
                                        AxB2[h] = k2;
                                        h++;
                                        k2 = 0;
                                    }
                                    h++;

                                    k2 = 0;

                                }
                            }
                            else
                            {
                                MessageBox.Show("число столбцов матрицы A должно совпадать с числом строк матрицы B!");
                                z = false;
                            }
                            //===================================================================================================
                            TabPage newTabPage1 = new TabPage();
                            newTabPage1.Text = "Матрица A x Б";
                            TabPage newTabPage2 = new TabPage();
                            newTabPage2.Text = "Матрица Б x A";
                            tabControl1.TabPages.Add(newTabPage1);
                            tabControl1.TabPages.Add(newTabPage2);

                            int zc = 100, zc1 = 0;
                            for (int ip = 0; ip <= ZXC(ref AxB); ip++)
                            {
                                TextBox t3 = new TextBox();
                                t3.ReadOnly = true;
                                if (999 == AxB[ip])
                                {
                                    t3.Location = new Point(zc += 150, zc1 += 50);
                                    zc1 = 0;
                                }
                                else
                                {
                                    t3.Text = AxB[ip].ToString();
                                    t3.Location = new Point(zc, zc1 += 50);
                                    tabControl1.TabPages[3].Controls.Add(t3);
                                }
                            }
                            zc = 100; zc1 = 0;
                            if (z == true)
                            {
                                for (int ip = 0; ip <= ZXC(ref AxB2); ip++)
                                {
                                    TextBox t3 = new TextBox();
                                    t3.ReadOnly = true;
                                    if (999 == AxB2[ip])
                                    {
                                        t3.Location = new Point(zc += 150, zc1 += 50);
                                        zc1 = 0;
                                    }
                                    else
                                    {
                                        t3.Text = AxB2[ip].ToString();
                                        t3.Location = new Point(zc, zc1 += 50);
                                        tabControl1.TabPages[4].Controls.Add(t3);
                                    }
                                }
                            }
                            else
                            {
                                Label l1 = new Label();
                                l1.Text = " число столбцов A должно совпадать с числом строк B! ";
                                l1.Location = new Point(100, 200);
                                tabControl1.TabPages[4].Controls.Add(l1);
                            }
                        }
                    };
                    bs[1].Click += (s, ef) =>
                    {
                        if (p > 0)
                        {
                            MessageBox.Show("Расчеты уже были произведены");
                        }
                        else
                        {
                            p++;
                            h = 0;
                            k1 = 0;
                            k2 = 0;

                            //===========================AxB=======================================================
                            for (int z = 0; z < SSS1; z++)
                            {
                                for (int i = 0; i < SSS; i++) // ОТВЕЧАЕТ ЗА СТРОКИ
                                {
                                    for (int j = 0; j < stroka; j++) // ОТВЕЧАЕТ ЗА СТОЛБЦЫ
                                    {

                                        k1 = k1 + (Convert.ToInt32(arr3[j, i].Text) * Convert.ToInt32(arr4[z, j].Text));


                                    }
                                    p++;

                                    AxB[h] = k1;
                                    h++;

                                    k1 = 0;

                                }
                                h++;

                                k1 = 0;

                            }
                            //==========================================================================================
                            h = 0;
                            if (SSS1 == SSS)
                            {
                                for (int z = 0; z < stroka; z++)
                                {
                                    for (int i = 0; i < stroka; i++) // ОТВЕЧАЕТ ЗА СТРОКИ
                                    {
                                        for (int j = 0; j < SSS1; j++) // ОТВЕЧАЕТ ЗА СТОЛБЦЫ
                                        {
                                            k2 = k2 + (Convert.ToInt32(arr4[j, i].Text) * Convert.ToInt32(arr3[z, j].Text));

                                        }
                                        AxB2[h] = k2;
                                        h++;
                                        k2 = 0;
                                    }
                                    h++;

                                    k2 = 0;

                                }
                            }
                            else
                            {
                                MessageBox.Show("число столбцов матрицы A должно совпадать с числом строк матрицы B!");
                                z = false;
                            }
                            //===================================================================================================
                            TabPage newTabPage1 = new TabPage();
                            newTabPage1.Text = "Матрица A x Б";
                            TabPage newTabPage2 = new TabPage();
                            newTabPage2.Text = "Матрица Б x A";
                            tabControl1.TabPages.Add(newTabPage1);
                            tabControl1.TabPages.Add(newTabPage2);

                            int zc = 100, zc1 = 0;
                            for (int ip = 0; ip <= ZXC(ref AxB); ip++)
                            {
                                TextBox t3 = new TextBox();
                                t3.ReadOnly = true;
                                if (999 == AxB[ip])
                                {
                                    t3.Location = new Point(zc += 150, zc1 += 50);
                                    zc1 = 0;
                                }
                                else
                                {
                                    t3.Text = AxB[ip].ToString();
                                    t3.Location = new Point(zc, zc1 += 50);
                                    tabControl1.TabPages[3].Controls.Add(t3);
                                }
                            }
                            zc = 100; zc1 = 0;
                            if (z == true)
                            {
                                for (int ip = 0; ip <= ZXC(ref AxB2); ip++)
                                {
                                    TextBox t3 = new TextBox();
                                    t3.ReadOnly = true;

                                    if (999 == AxB2[ip])
                                    {
                                        t3.Location = new Point(zc += 150, zc1 += 50);
                                        zc1 = 0;
                                    }
                                    else
                                    {
                                        t3.Text = AxB2[ip].ToString();
                                        t3.Location = new Point(zc, zc1 += 50);
                                        tabControl1.TabPages[4].Controls.Add(t3);
                                    }
                                }
                            }
                            else
                            {
                                Label l1 = new Label();
                                l1.Text = " число столбцов A должно совпадать с числом строк B! ";
                                l1.Location = new Point(100, 200);
                                tabControl1.TabPages[4].Controls.Add(l1);
                            }
                        }
                    };
                }
            }
        }




        public delegate void b1zxc(Button b1);


        public delegate void HelloWorld(Button b1);

   
           



        private void Form1_Load(object sender, EventArgs e)
        {
       
            int zxc = 0; 
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        for (int i = 0; i < arr3.GetLength(0); i++)
                        {
                            for (int j = 0; j < arr3.GetLength(1); j++)
                            {
                                if (arr4[i, j].Text == String.Empty || arr3[i, j].Text == String.Empty)
                                {
                                    b1zxc f = new b1zxc((Button s) => { s.Visible = false; });
                                    BeginInvoke(f, new object[] { bs[0] });
                                    break;
                                }
                                else if (arr4[i, j].Text != String.Empty || arr3[i, j].Text != String.Empty)
                                {
                                    if (arr3[i, j].Text != "123" || arr4[i, j].Text != "123")
                                    {
                                        if (foo(ref arr4, ref arr3))
                                        {
                                            b1zxc f = new b1zxc((Button s) => { s.Visible = true; });
                                            BeginInvoke(f, new object[] { bs[0] });
                                        }
                                    }
                                }
                                

                            }

                        }

                        if (zxc1 == 1)
                        {
                            for (int i = 0; i < arr3.GetLength(0); i++)
                            {
                                for (int j = 0; j < arr3.GetLength(1); j++)
                                {
                                    if (arr4[i, j].Text == String.Empty || arr3[i, j].Text == String.Empty)
                                    {
                                        b1zxc f = new b1zxc((Button s) => { s.Visible = false; });
                                        BeginInvoke(f, new object[] { bs[1] });
                                    }
                                    else if (arr4[i, j].Text != String.Empty || arr3[i, j].Text != String.Empty)
                                    {
                                        if (arr3[i, j].Text != "123" || arr4[i, j].Text != "123")
                                        {
                                            if (foo(ref arr4, ref arr3))
                                            {
                                                b1zxc f = new b1zxc((Button s) => { s.Visible = true; });
                                                BeginInvoke(f, new object[] { bs[1] });
                                            }
                                        }
                                    }


                                }

                            }
                        }
                    }
                    catch { }; 
                      
                    



                }


            }).Start();
         
            

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
                 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Clear(ref int[] array)
        {
            for(int i =0; i < array.Length; i++)
            {
                array[i] = 999; 
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            int sx = tabControl1.TabPages.Count;
            for (int i = sx - 1;  i > 0;  i--)
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages[i]);
            }
            s = 0;
            Clear(ref AxB2);
            Clear(ref AxB);
            h = 0;
            p = 0;
            zxc1 = 0; 
        }

        private bool foo(ref TextBox[,] array, ref TextBox[,] array2)
        {
            int k = 0;
            int k1 = 0;
            for (int i = 0; i < SSS; i++)
            {
                for (int j = 0; j < stolbec; j++)
                {
                    if (array[i, j].Text == "123" || array[i, j].Text == "")
                    {
                        k++; 
                    }
                  
                }
            }

            for (int i = 0; i < stroka ; i++)
            {
                for (int j = 0; j < SSS1; j++)
                {
                    if (array2[i, j].Text == "123" || array2[i, j].Text == "")
                    {
                        k1++;
                    }

                }
            }

            if (k > 0 || k1 > 0)
            {
                return false;
            }
            else if (k == 0 && k1 ==0)
            {
                return true; 
            }
        

            return false;
        }



    

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }
    }
}
