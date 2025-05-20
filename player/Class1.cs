using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace player
{
    internal class Class1: Form
    {
        public int x, y;
        public int dx, dy;

        public Class1(int x, int y, int dx, int dy, Form1 form)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
        }
        
        internal bool isInside(int x, int y)
        {
            if(x < this.x || x > this.x + dx) return false;
            if (y < this.y || y > this.y + dy) return false;
            return true;
        }
        ~Class1() { }
    }
    internal class textic: Form
    {
        private int m, n;
        private int dm, dn;
        private System.Windows.Forms.TextBox textbox1;
        List<string> pes;

        public textic(int dm, int dn, Form1 form, int x, int y)
        {
            this.m = x+19;
            this.n = y+22;
            this.dm = m+dm;
            this.dn = n + dn;
            textbox1 = new System.Windows.Forms.TextBox();
            textbox1.Location = new System.Drawing.Point(m, n);
            textbox1.MinimumSize = new System.Drawing.Size(dm, dn);
            textbox1.ForeColor = Color.White;
            textbox1.BackColor = Color.Black;
            textbox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            textbox1.Multiline = false;
            textbox1.ReadOnly = true;
            textbox1.TabStop = false;
            textbox1.Font = new System.Drawing.Font("Times New Roman", 12);
            textbox1.TextAlign = HorizontalAlignment.Center;
            textbox1.BorderStyle = BorderStyle.None;
            textbox1.Text = "Готов к использованию!";
            form.Controls.Add(textbox1);
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Add("PHARAOH_-_JEmi_72837550.wav");
            col.Add("PHARAOH_Noa_-_Pornozvezda_47828840.wav");
            col.Add("PHARAOH_-_Plombir_58182827.wav");
            col.Add("PHARAOH_-_Caramel_64407433.wav");
            textbox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textbox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textbox1.AutoCompleteCustomSource = col;
        }
        internal void menue(string path, List<Class1> list, MouseEventArgs e)
        {
            textbox1.ReadOnly = false;
        }

        internal void Pr()
        {
            textbox1.ReadOnly = true;
        }
        internal bool isInside(int m, int n)
        {
            if (m < this.m || m > this.m + dm) return false;
            if (n < this.n || n > this.n + dn) return false;
            return true;
        }
        internal void Print(string v)
        {
            textbox1.Text = v;
        }

        public string textboxtext() { 
            return textbox1.Text;
        }

        internal void Printer(Graphics g)
        {
            g.FillRectangle(Brushes.Black, m, n, dm, dn);
        }

        internal int vibor(List<int> nums, int count, int h, string path, List<string> pesni, textic textbox1, int i, bool t)
        {
            if (i == 2)
            {
                t = false;
                nums.Add(count);
                if ((h != 0) && (nums[h - 1] != nums[h]))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(path + pesni[count]);
                    player.Play();
                    textbox1.Print(pesni[count]);
                }
                else
                {
                    if (count != 3)
                    {
                        System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(path + pesni[count + 1]);
                        player1.Play();
                        nums[h] = count + 1;
                        textbox1.Print(pesni[count + 1]);
                    }
                    else
                    {
                        System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(path + pesni[count - 1]);
                        player1.Play();
                        nums[h] = count - 1;
                        textbox1.Print(pesni[count - 1]);
                    }
                }
                return ++h;
            }
            else
            {
                if (t == true)
                {
                    t = false;
                    h--;                    
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(path + pesni[nums[h]]);
                    player.Play();
                    textbox1.Print(pesni[nums[h]]);
                    return ++h;
                }
                else {
                    if (h != 0)
                    {
                        t = false;
                        nums.RemoveAt(h-1);
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(path + pesni[nums[h - 2]]);
                        player.Play();
                        textbox1.Print(pesni[nums[h - 2]]);
                        return --h;
                    }
                    else
                    {
                        MessageBox.Show("Предыдущей песни нет!");
                        return 0;
                    }
                }
            }
        }      

        ~textic() { }
    }
}
