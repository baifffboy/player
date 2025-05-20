using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace player
{
    public partial class Form1 : Form
    {
        List<Class1> list;
        public const string path = "C:\\Users\\ilya_\\source\\repos\\player\\player\\Resources\\песни\\";
        textic textbox1;
        public int h = 0;
        public bool t = false;
        List<int> nums;
        List<string> pesni;

        public Form1()
        {
            InitializeComponent();
            list = new List<Class1>();
            list.Add(new Class1(0, 0, 407, 705, this));
            list.Add(new Class1(154, 380, 92, 31, this));
            list.Add(new Class1(269, 480, 57, 46, this));
            list.Add(new Class1(164, 588, 72, 37, this));
            list.Add(new Class1(72, 476, 64, 50, this));
            textbox1 = new textic(350, 257, this, list[0].x, list[0].y);
            nums = new List<int>();
            pesni = new List<string>();
            pesni.Add("PHARAOH_-_JEmi_72837550.wav");
            pesni.Add("PHARAOH_Noa_-_Pornozvezda_47828840.wav");
            pesni.Add("PHARAOH_-_Plombir_58182827.wav");
            pesni.Add("PHARAOH_-_Caramel_64407433.wav");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0) e.Graphics.DrawImage(global::player.Properties.Resources._2024_03_26_10_04_26, list[i].x, list[i].y, list[i].dx, list[i].dy);
                if (i == 1) e.Graphics.DrawImage(global::player.Properties.Resources.меню, list[i].x, list[i].y, list[i].dx, list[i].dy);
                if (i == 2) e.Graphics.DrawImage(global::player.Properties.Resources.вправо, list[i].x, list[i].y, list[i].dx, list[i].dy);
                if (i == 3) e.Graphics.DrawImage(global::player.Properties.Resources.пауза, list[i].x, list[i].y, list[i].dx, list[i].dy);
                if (i == 4) e.Graphics.DrawImage(global::player.Properties.Resources.влево, list[i].x, list[i].y, list[i].dx, list[i].dy);
            }
            Graphics g = this.CreateGraphics();
            textbox1.Printer(g);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            {
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].isInside(e.X, e.Y))
                    {
                        if (e.Button == MouseButtons.Right && i == 4)
                        {
                            t = true;
                        }
                        else { 
                            t = false;
                        }
                        if (i == 2 || i == 4)
                        {
                            Random rnd = new Random(Guid.NewGuid().GetHashCode());
                            int choices = rnd.Next(0, 4);
                            switch (choices)
                            {
                                case 0:
                                    h = textbox1.vibor(nums, 0, h, path, pesni, textbox1, i, t);
                                    break;
                                case 1:
                                    h = textbox1.vibor(nums, 1, h, path, pesni, textbox1, i, t);
                                    break;
                                case 2:
                                    h = textbox1.vibor(nums, 2, h, path, pesni, textbox1, i, t);
                                    break;
                                case 3:
                                    h = textbox1.vibor(nums, 3, h, path, pesni, textbox1, i, t);
                                    break;
                            }
                        }
                        if (i == 1)
                        {
                            textbox1.menue(path, list, e);
                        }
                        if (i == 3)
                        {
                            if (textbox1.textboxtext() != "" && textbox1.textboxtext() != "Готов к использованию!")
                            {
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer(path + textbox1.textboxtext());
                                player.Play();
                                textbox1.Pr();
                                for (int k = 0; k < pesni.Count; k++)
                                {
                                    if (pesni[k] == textbox1.textboxtext())
                                    {
                                        nums.Add(k);
                                        h++;
                                        break;
                                    }
                                }
                            }
                            else MessageBox.Show("Вы не указали песню!");
                        }
                    }
                }
            }
        }
    }
}
