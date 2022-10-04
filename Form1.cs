using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datoveSouboryRozhrani00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("celaCisla.dat", FileMode.Create,FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < textBox1.Lines.Count(); ++i)
            {
                int cislo = int.Parse(textBox1.Lines[i]);
                bw.Write(cislo);
            }
            bw.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream fs = new FileStream("celaCisla.dat",FileMode.Open,FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            while(fs.Position<fs.Length)
            {
                //double cislo = br.ReadDouble();
                int cislo = br.ReadInt32();
                listBox1.Items.Add(cislo);
            }
            br.Close();
            fs.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //všechna lichá čísla oprav vynásobením 2 na sudá
            FileStream fs = new FileStream("celaCisla.dat",FileMode.Open,FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            while(br.BaseStream.Position <br.BaseStream.Length)
            {
                int pos = (int)br.BaseStream.Position;

                int cislo = br.ReadInt32();
                if(cislo %2!=0)
                {
                    cislo *= 2;
                }
                //bw.BaseStream.Position -= 4;
                //bw.BaseStream.Position -= sizeof(Int32);
                //bw.Seek(-4, SeekOrigin.Current);
                //bw.Seek(-sizeof(Int32), SeekOrigin.Current);
                bw.Seek(pos,SeekOrigin.Begin);
                bw.Write(cislo);
            }
            //br.Close();
            //bw.Close();
            fs.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Všechna záporná čísla vynásob -1
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            while(br.BaseStream.Position<br.BaseStream.Length)
            {
                int pos = (int)br.BaseStream.Position;
                double cislo = br.ReadDouble();
                if (cislo < 0)
                {
                    cislo *= -1;
                    //bw.BaseStream.Position -= 8;
                    //bw.BaseStream.Position -= sizeof(Double);
                    //bw.Seek(-8, SeekOrigin.Current);
                    //bw.Seek(-sizeof(Double), SeekOrigin.Current);
                    bw.Seek(pos, SeekOrigin.Begin);
                    bw.Write(cislo);
                }
            }
            fs.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("realnaCisla.dat",FileMode.Create,FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            Random rnd = new Random();
            int n = int.Parse(textBox2.Text);
            for(int i =0; i<n;i++)
            {
                bw.Write(rnd.NextDouble()*(1000-(-1000))-1000); 
            }
            bw.Close();
            fs.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            while(br.BaseStream.Position<br.BaseStream.Length)
            {
                double cislo = br.ReadDouble();
                listBox2.Items.Add(cislo);
            }
            fs.Close();
        }   
    }
}
