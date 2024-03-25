using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace FontManager
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog dialog;
        private List<string> files = new List<string>();
        private PrivateFontCollection fonts;

        private string tempDir = Path.Combine(Environment.CurrentDirectory, "temp");

        private bool isErase = false;
        private bool isEveryone = false;
        private bool isZip = false;
        private string sysLoc = "";
        private string regLoc = "";

        public Form1()
        {
            InitializeComponent();
            
            dialog = new FolderBrowserDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            files.Clear();

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbLocation.Text = dialog.SelectedPath;
                    
                    Directory.CreateDirectory(tempDir);
                    
                    if (Path.GetExtension(Directory.GetFiles(tbLocation.Text)[0]).Equals(".zip")) isZip = true;
                    else
                    {
                        isZip = false;
                        files = GetFileList(tbLocation.Text, files);

                        foreach (string f in files)
                        {
                            File.Copy(f, Path.Combine(tempDir, Path.GetFileName(f)));
                        }

                        files.Clear();
                        files = GetFileList(tempDir, files);
                    }

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            tbResults.Clear();

            if (isZip)
            {
                try
                {
                    using (ZipArchive archive = ZipFile.OpenRead(Directory.GetFiles(tbLocation.Text)[0]))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.Name.EndsWith("\\")) continue;
                            else
                            {
                                string ext = Path.GetExtension(entry.Name);
                                
                                if (ext.Equals(".ttf", StringComparison.CurrentCultureIgnoreCase) || ext.Equals(".otf", StringComparison.CurrentCultureIgnoreCase))
                                    entry.ExtractToFile(tempDir);
                            }
                        }
                    }

                    files = GetFileList(tempDir, files);

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            try
            {
                if (isEveryone)
                {
                    sysLoc = Path.Combine(Environment.GetFolderPath(SpecialFolder.Windows), "Fonts");
                    regLoc = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
                }
                else
                {
                    sysLoc = Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), "Microsoft", "Windows", "Fonts");
                    regLoc = @"Software\Microsoft\Windows NT\CurrentVersion\Fonts";
                }

                foreach (string file in files)
                {
                    string ext = Path.GetExtension(file);

                    try
                    {
                        if (ext.Equals(".ttf", StringComparison.CurrentCultureIgnoreCase) || ext.Equals(".otf", StringComparison.CurrentCultureIgnoreCase))
                        {
                            tbResults.Text += file + " => ";

                            fonts = new PrivateFontCollection();
                            fonts.AddFontFile(file);

                            string newLoc = Path.Combine(sysLoc, Path.GetFileName(file));

                            File.Copy(file, newLoc, true);

                            Microsoft.Win32.RegistryKey key;

                            if (isEveryone)
                            {
                                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(regLoc);
                                key.SetValue(fonts.Families[0].Name, Path.GetFileName(file));
                            }
                            else
                            {
                                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(regLoc);
                                key.SetValue(fonts.Families[0].Name, newLoc);
                            }

                            key.Close();

                            fonts.Dispose();

                            tbResults.Text += "Installed" + Environment.NewLine;
                        }

                    } catch (Exception ex)
                    {
                        tbResults.Text += "Already Installed Or Using" + Environment.NewLine;

                        Console.WriteLine(ex.Message);
                    }
                    
                }

                MessageBox.Show("Installation Complete", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception ex)
            {
                

                Console.WriteLine(ex.Message);

                MessageBox.Show("Installation Failed" + Environment.NewLine + ex.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (isErase)
            {
                Directory.Delete(Path.Combine(Environment.CurrentDirectory, "temp"), true);
            }
        }

        private List<string> GetFileList(string path, List<string> list)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string[] dirList = Directory.GetDirectories(path);
                    
                    foreach (string p in dirList)
                    {
                        list = GetFileList(p, list);
                    }

                    string[] fileList = Directory.GetFiles(path);

                    foreach (string f in fileList)
                    {
                        list.Add(f);
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        private void cbErase_CheckedChanged(object sender, EventArgs e)
        {
            isErase = !isErase;
        }

        private void cbEveryone_CheckedChanged(object sender, EventArgs e)
        {
            isEveryone = !isEveryone;
        }
    }
}
