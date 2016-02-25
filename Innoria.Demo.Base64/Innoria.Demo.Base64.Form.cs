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
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drop");
            var file = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            var base64Text = Base64Algorithm.EncodeFromFile(file);
            System.IO.File.WriteAllText(@".\data-encoded.txt", base64Text);
            System.Diagnostics.Process.Start(@".\data-encoded.txt");
            //MessageBox.Show(rs, "Data Encoded");
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Enter");
            label1.ForeColor = Color.Gray;
            // Check if the Dataformat of the data can be accepted
            // (we only accept file drops from Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
    }
}
