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

namespace PylsRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in openFileDialog.FileNames)
                {
                    try
                    {
                        string oldFileName = Path.GetFileName(item);
                        lbListFileNames.Items.Add($"Файл: {oldFileName}");
                        string path = item.Substring(0, item.Length - oldFileName.Length);
                        File.Move(item, path + oldFileName.Replace(' ', '_'));
                        lbListFileNames.Items.Add($"Переименован");
                    }
                    catch (Exception ex)
                    {
                        lbListFileNames.Items.Add($"Ошибка!");
                        MessageBox.Show(ex.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
