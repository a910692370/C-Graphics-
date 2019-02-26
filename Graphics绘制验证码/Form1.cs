using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics绘制验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }
        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <returns></returns>
        private string CheckCode()
        {
            int num;
            char code;
            string str = "";
            Random rd = new Random();
            for (int i = 0; i < 4; i++)
            {
                num = rd.Next();
                if (num % 2 == 0)
                    code = (char)('0' + (char)(num % 10));
                else
                    code = (char)('A' + (char)(num % 26));
                str += code.ToString();
            }
            return str;
        }
        private void CodeImage(string a)
        {
            if (a.Trim() == "")
            {
                MessageBox.Show("生成验证码失败！");
                return;
            }
            Bitmap image = new Bitmap(180, 80);
            Graphics g = Graphics.FromImage(image);

            Random rd = new Random();
            g.Clear(Color.White);
            g.DrawString(a, new Font("楷体", 60, FontStyle.Italic), new SolidBrush(Color.Red), -10, 0);
            //绘制随机干扰线段
            for (int i = 0; i < 20; i++)
            {
                int x1 = rd.Next(image.Width);
                int x2 = rd.Next(image.Width);
                int y1 = rd.Next(image.Height);
                int y2 = rd.Next(image.Height);
                g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            }
            //绘制随机干扰点
            for (int i = 0; i < 500; i++)
            {
                int x1 = rd.Next(image.Width);
                int y1 = rd.Next(image.Height);
                g.DrawLine(new Pen(Color.Black), x1, y1, (x1 + 1), y1);
            }
            pb1.BackgroundImageLayout = ImageLayout.Center;
            pb1.BackgroundImage = image;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }
    }
}
