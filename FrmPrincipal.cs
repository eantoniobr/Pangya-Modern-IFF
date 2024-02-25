using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Ionic.Zip;
using Pangya_Modern_Editor.My;

namespace Pangya_Modern_Editor
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() == DialogResult.OK && Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) != 0)
            {
                string fileName = diagAbrirArquivo.FileName;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                string directoryName = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(directoryName + "\\" + fileNameWithoutExtension))
                {
                    Directory.CreateDirectory(directoryName + "\\" + fileNameWithoutExtension);
                }
                txtDir.Text = fileName;
                txtDir_TextChanged(RuntimeHelpers.GetObjectValue(sender), e);
            }
        }

        private void txtDir_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
                string directoryName = Path.GetDirectoryName(text);
                if (!Directory.Exists(directoryName + "\\" + fileNameWithoutExtension))
                {
                    Directory.CreateDirectory(directoryName + "\\" + fileNameWithoutExtension);
                }
                FileInfo fileInfo = new FileInfo(text);
                lbTamanho.Text = Strings.FormatNumber(fileInfo.Length / 1024.0, 2) + " KB";
                lbCriado.Text = fileInfo.CreationTime.ToString();
                lbModificado.Text = Conversions.ToString(fileInfo.LastWriteTime);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void btnUnpak_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
                string directoryName = Path.GetDirectoryName(text);
                string text2 = text;
                string text3 = directoryName + "\\" + fileNameWithoutExtension;
                ZipFile val = ZipFile.Read(text2);
                try
                {
                    foreach (ZipEntry item in val)
                    {
                        FileAttributes attributes = item.Attributes;
                        attributes &= ~(FileAttributes.Hidden | FileAttributes.System);
                        item.Attributes = attributes;//muda o tipo de atributo antes
                        item.Extract(text3, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                finally
                {
                   val.Dispose();
                }
                MessageBox.Show("Arquivo descompactado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show("Ocorreu um erro ao descompactar o arquivo.Erro: " + ex2.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        private void btnPak_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                string path2 = directoryName + "\\" + fileNameWithoutExtension + "\\";
                ZipFile val = new ZipFile
                {
                    CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
                };
                string[] files = Directory.GetFiles(path2);
                foreach (string text in files)
                {
                    if (Operators.CompareString(Path.GetExtension(text), ".iff", TextCompare: false) == 0)
                    {
                        val.AddFile(text, "");
                    }
                    //memorial
                    if (Operators.CompareString(Path.GetExtension(text), ".sff", TextCompare: false) == 0)
                    {
                        val.AddFile(text, "");
                    }
                }
                string text2 = directoryName + "\\" + string.Format(fileNameWithoutExtension + "_{0}-{1}-{2}_{3}{4}{5}", DateAndTime.Now.Day, DateAndTime.Now.Month, DateAndTime.Now.Year, DateAndTime.Now.Hour, DateAndTime.Now.Minute, DateAndTime.Now.Second) + ".iff";
                val.Save(text2);
                MessageBox.Show("Arquivo compactado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show("Ocorreu um erro ao compactar o arquivo. Erro: " + ex2.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        private void BtnExplorerFolder_Click(object sender, EventArgs e)
        {
            string path = txtDir.Text;
            Path.GetFileNameWithoutExtension(path);
            string directoryName = Path.GetDirectoryName(path);
            Process.Start(directoryName, "/select");
        }
        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            Visible = true;
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
             MyProject.Forms.frmItem.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Item.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
              MyProject.Forms.frmItem.Show();
            }
        }

        private void btnBall_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmBall.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Ball.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmBall.Show();
            }
        }

        private void btnClubSet_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmClubSet.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\ClubSet.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmClubSet.Show();
            }
        }

        private void btnClub_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmClub.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Club.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmClub.Show();
            }
        }

        private void btnCauldron_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmCadieMagicBox.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\CadieMagicBox.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmCadieMagicBox.Show();
            }
        }

        private void BtnOpenCache_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Cache\\";
            string directoryName = Path.GetDirectoryName(path);
            Process.Start(directoryName, "/select");
        }

        private void ckImagensGit_CheckedChanged(object sender, EventArgs e)
        {
            ckOffLine.Checked = !ckImagensGit.Checked;
        }

        private void ckOffLine_CheckedChanged(object sender, EventArgs e)
        {
            ckImagensGit.Checked = !ckOffLine.Checked;
        }

        private void btnCaudronRandon_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmCadieMagicBoxRandon.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\CadieMagicBoxRandom.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmCadieMagicBoxRandon.Show();
            }
        }

        private void btnSetItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmSetItem.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\SetItem.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmSetItem.Show();
            }
        }

        private void btnPart_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                MyProject.Forms.frmPart.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Part.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                MyProject.Forms.frmPart.Show();
            }
        }

        private void btnCaddie_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                MyProject.Forms.frmCaddie.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Caddie.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                MyProject.Forms.frmCaddie.Show();
            }
        }

        private void btnCaddieItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmCaddieItem.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\CaddieItem.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmCaddieItem.Show();
            }
        }

        private void btnSkin_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                // MyProject.Forms.frmSkin.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Skin.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmSkin.Show();
            }
        }

        private void btnMascot_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtDir.Text;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                //MyProject.Forms.frmMascot.Arquivo = directoryName + "\\" + fileNameWithoutExtension + "\\Mascot.iff";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            finally
            {
                // MyProject.Forms.frmMascot.Show();
            }
        }

    }
}
