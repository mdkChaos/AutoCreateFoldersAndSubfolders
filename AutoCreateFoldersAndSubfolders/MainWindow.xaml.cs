using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace AutoCreateFoldersAndSubfolders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                PathFolder.Content = dialog.SelectedPath;
            }
            else
            {
                PathFolder.Content = "The folder was not selected!";
            }
        }

        private void CreateFolder_Click(object sender, RoutedEventArgs e)
        {
            string path = (string)PathFolder.Content;
            string folderName = NewFolderName.Text;
            string subFolderName = NewSubFolderName.Text;
            int count = Convert.ToInt32(NumberOfSubFolders.Text);
            if (path != null && folderName != null && subFolderName != null)
            {
                string newPath = $"{path}\\{folderName}";
                if (Directory.Exists(newPath))
                {
                    System.Windows.MessageBox.Show("Folder already exists!");
                    return;
                }
                else
                {
                    Directory.CreateDirectory(newPath);
                }
                for (int i = 1; i <= count; i++)
                {
                    if (i < 10)
                    {
                        Directory.CreateDirectory($"{newPath}\\{subFolderName} 0{i}");
                    }
                    else
                    {
                        Directory.CreateDirectory($"{newPath}\\{subFolderName} {i}");
                    }
                }
                System.Windows.MessageBox.Show("Create folders completed!");
                PathFolder.Content = "";
                NewFolderName.Clear();
                NewSubFolderName.Clear();
                NumberOfSubFolders.Clear();
            }
        }
    }
}
