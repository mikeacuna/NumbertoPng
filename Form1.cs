using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumbertoPNG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fontname = "Garamond";
            int fontsize = 25;
            int maxwidth = 500;
            int maxheight = 80;

            
            if (fldBrowdlg.ShowDialog() == DialogResult.OK)
            {
                Font f = new Font(fontname, fontsize);
                Bitmap bmp = new Bitmap(maxwidth, maxheight);
                Graphics g = Graphics.FromImage(bmp);

                string folder = fldBrowdlg.SelectedPath;
                for (int i = 0; i <= 10000; i++)
                {
                    string s = i.ToString();
                    SizeF szf = g.MeasureString(s, f);

                    Bitmap bpng = new Bitmap((int)szf.Width, (int)szf.Height);

                    Graphics gg = Graphics.FromImage(bpng);
                    gg.Clear(Color.White);
                    gg.DrawString(s, f, Brushes.DarkRed, new PointF(0.0f, 0.0f));

                    string savepath = folder + "\\" + s + ".png";
                    bpng.Save(savepath, System.Drawing.Imaging.ImageFormat.Png);
                    bpng.Dispose();
                }

                bmp.Dispose();
            }

        }
    }
}
