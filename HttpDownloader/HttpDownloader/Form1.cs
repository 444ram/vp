using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim(); 
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a valid URL.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "downloadedFile";
            saveFileDialog.Filter = "All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string localPath = saveFileDialog.FileName;

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        // Optional: Show progress in Status TextBox
                        client.DownloadProgressChanged += (s, ev) =>
                        {
                            textBox2.Text = $"Downloading... {ev.ProgressPercentage}%";
                        };

                        client.DownloadFileCompleted += (s, ev) =>
                        {
                            textBox2.Text = "Download completed!";
                        };

                        client.DownloadFileAsync(new Uri(url), localPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
