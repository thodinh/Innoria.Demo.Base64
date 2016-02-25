using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innoria.Demo.Base64
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drop");
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Enter");
            label1.ForeColor = Color.Gray;
            e.Effect = DragDropEffects.All;
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
    }
}
