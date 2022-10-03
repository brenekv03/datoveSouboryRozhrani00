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
    }
}
