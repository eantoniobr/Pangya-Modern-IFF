using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangLib.IFF;
using PangLib.IFF.Models.Data;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.My;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmItemEditor : Form
    {
        public FrmItemEditor()
        {
            InitializeComponent();
        }

        private void FrmItemEditor_Load(object sender, EventArgs e)
        {
            if (this.Arquivo != "")
            {
                this.lsItens = new IFFFile<Item>();
                this.lsTemp = new IFFFile<Item>();
                MySettings.Default.ArquivoIff = this.Arquivo;
                try
                {
                    this.lsItens = new IFFFile<Item>(Arquivo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.lsTemp = this.lsItens;

                int length = 0x19;
                if (Strings.Len(this.Arquivo) > 0x19)
                {
                    this.lbArquivo.Text = "..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length);
                }
                else
                {
                    this.lbArquivo.Text = this.Arquivo;
                }
                this.ListaItem.DataSource = null;
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            }
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<Item>();
                this.lsTemp = new IFFFile<Item>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                Settings.Default.ArquivoIff = this.Arquivo;
                try
                {
                    this.lsItens = new IFFFile<Item>(Arquivo);
                }
                catch
                {
                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                this.ListaItem.DataSource = null;
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem = lsItens.Count);
            }
        }

        public void nomeArquivo()
        {
            int num = 25;
            if (Strings.Len(Arquivo) > 25)
            {
                lbArquivo.Text = "..." + Arquivo.Substring(checked(Strings.Len(Arquivo) - num), num);
            }
            else
            {
                lbArquivo.Text = Arquivo;
            }
        }

        public void CarregarGrid(List<Item> Lista)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));

            for (int num3 = 0; num3 < Lista.Count; num3++)
            {
                oIff = Lista[num3];
                Image statusImage = (oIff.Active == 1) ? Properties.Resources.accept1 : Properties.Resources.delete1;
                Image tipoImage = Resources.eye__minus;
                var item_type = 0;
                switch (oIff.GetTypeCash())
                {
                    case 0:
                        tipoImage = Resources.eye__minus;
                        break;
                    case 1:
                        tipoImage = Resources.points;
                        break;
                    case 2:
                        tipoImage = Resources.Pang;
                        break;
                }

                switch (oIff.ItemType)
                {
                    case 0:
                        item_type = 1;     //active =0
                        break;
                    case 1:
                        item_type = 2;//box
                        break;
                    case 2:
                        item_type = 3;
                        break;
                    case 4:
                        item_type = 4; //artifact
                        break;
                    case 10:
                        item_type = 5; //mana
                        break;
                    case 16:
                        item_type = 6;       //memorial
                        break;
                    case 128:
                        item_type = 7;//item gm
                        break;
                    //case 252:
                    //    item_type = 8;//desconhecido
                    //    break;
                    //default:
                    //    item_type = (int)oIff.ItemType;
                    //    break;
                }
                int num4 = 0;

                try
                {
                    // Obtenha o valor da célula "Alterado"
                    object alteradoCellValue = null;

                    if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                    {
                        alteradoCellValue = ListaItem["Alterado", num3].Value;
                    }

                    if (alteradoCellValue != null)
                    {
                        if (int.TryParse(alteradoCellValue.ToString(), out int result))
                        {
                            num4 = result;
                        }
                        else
                        {
                            // Lidar com a situação em que não é possível converter para int
                            num4 = 0; // Ou outra ação apropriada
                        }
                    }
                    else
                    {
                        // Lidar com a situação em que o valor é nulo
                        num4 = 0; // Ou outra ação apropriada
                    }
                }
                catch (Exception projectError2)
                {
                    num4 = 0;
                    ProjectData.SetProjectError(projectError2);
                    ProjectData.ClearProjectError();
                }
                table.Rows.Add(new object[] { num3, oIff.Name.Replace("\0", ""), statusImage, item_type, oIff.Active, tipoImage, num4 });
            }

            ListaItem.DataSource = null;
            bs = new BindingSource();
            bs.DataSource = table;
            ListaItem.DataMember = table.TableName;
            ListaItem.DataSource = bs;

            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);

            ListaItem.Columns[0].Width = 0x2d;
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[5].Width = 30;

            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[5].HeaderText = "   ";

            for (int i = 0; i < ListaItem.Rows.Count; i++)
            {
                ListaItem.Rows[i].Selected = false;
            }

            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[6].Visible = false;

            filtrar();

            try
            {
                if (ListaItem.Rows.Count > 0 && lastRow < ListaItem.Rows.Count)
                {
                    ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                    ListaItem.Rows[lastRow].Selected = true;
                }
            }
            catch (Exception)
            {
                // Lidar com a exceção, se necessário
            }

            pintarLinhas();
        }
        public void pintarLinhas()
        {
            checked
            {
                int num = ListaItem.Rows.Count - 1;
                int num2 = 0;
                while (true)
                {
                    int num3 = num2;
                    int num4 = num;
                    if (num3 > num4)
                    {
                        break;
                    }
                    ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 1, TextCompare: false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                    }
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 2, TextCompare: false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33CCFF");
                    }
                    num2++;
                }
                ListaItem.Columns[0].Width = 45;
                ListaItem.Columns[2].Width = 30;
                ListaItem.Columns[5].Width = 30;
            }
        }

        private void CarregarItem()
        {
            if (ListaItem.SelectedCells[0].RowIndex > -1)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                txtNome.Text = lsTemp[index].Name;
                txtTypeID.Text = Conversions.ToString(lsTemp[index].ID);
                ckAtivo.Checked = lsTemp[index].isValid != 0;
                txtIcone.Text = lsTemp[index].Icon;
                txtPreco.Text = Conversions.ToString(lsTemp[index].Price);
                txtDesconto.Text = Conversions.ToString(lsTemp[index].DiscountPrice);
                txtQtd.Value = new decimal(lsTemp[index].Power);
                txtSprite.Text = lsTemp[index].Model;
                if (!lsTemp[index].Level.is_max)
                {
                    cbLevel.SelectedIndex = lsTemp[index].Level.level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    cbLevel.SelectedIndex = lsTemp[index].Level.level;
                    rbLevelMax.Checked = true;
                }
                switch (lsTemp[index].ItemType)
                {
                    case 0:
                        cbTipo2.SelectedIndex = 0;
                        break;
                    case 1:
                        cbTipo2.SelectedIndex = 1;
                        break;
                    case 2:
                        cbTipo2.SelectedIndex = 2;
                        break;
                    case 4:
                        cbTipo2.SelectedIndex = 3;
                        break;
                    case 10:
                        cbTipo2.SelectedIndex = 4;
                        break;
                    case 16:
                        cbTipo2.SelectedIndex = 5;
                        break;
                    case 128:
                        cbTipo2.SelectedIndex = 6;//item gm
                        break;
                    default:
                        cbTipo2.Items.AddRange(new object[] { $"Unknown - {lsTemp[index].ItemType}" });
                        break;
                }
                cbTipo.SelectedIndex = lsTemp[index].GetTypeCash();
                dtInicio.Value = lsTemp[index].date.Start.Time;
                dtTermino.Value = lsTemp[index].date.End.Time;
                ckNormal.Checked = lsTemp[index].Shop.flag_shop.IsNormal || lsTemp[index].Shop.flag_shop.is_saleable;
                ckDesativado.Checked = lsTemp[index].Shop.flag_shop.IsHide;
                ckNew.Checked = lsTemp[index].Shop.flag_shop.IsNew;
                ckGift.Checked = lsTemp[index].Shop.flag_shop.IsGift;
                ckHot.Checked = lsTemp[index].Shop.flag_shop.IsHot;
                ckTempoAtivo.Checked = lsTemp[index].date.Check();
            }
            Alterado = false;
        }

        private void carregarImagem(Image img, ref PictureBox obj)
        {
            try
            {
                obj.Image = Resources.ajax_loader;
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            try
            {
                obj.Image = img;
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                obj.Image = Resources._error;
                ProjectData.ClearProjectError();
            }
        }
        private void listaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
                if (ListaItem.SelectedRows.Count > 1)
                {
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = false;
                    menuSalvarComo.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;
                    menuDividir.Enabled = true;
                    menuGerarCache.Enabled = true;
                }
                else if (ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;
                    menuDividir.Enabled = true;
                    menuGerarCache.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                    menuTypeid.Enabled = false;
                    menuBackup.Enabled = false;
                    menuGerarSql.Enabled = false;
                    menuMassa.Enabled = false;
                    menuDividir.Enabled = false;
                    menuGerarCache.Enabled = false;
                }
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
                if (verificarTYPEID())
                {
                    txtTypeID.BackColor = Color.LightSalmon;
                }
                else
                {
                    txtTypeID.BackColor = Color.White;
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            var img = Util.getImage(txtIcone.Text) as Image;
            PictureBox obj = imgIcone;
            carregarImagem(img, ref obj);
            imgIcone = obj;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/40";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox2.SelectedIndex = 0;
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            salvarAlteracoes();
            pintarLinhas();
        }

        private void salvarAlteracoes()
        {
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);

            lsTemp[index].Active = (uint)(ckAtivo.Checked == true ? 1 : 0);

            lsTemp[index].Name = txtNome.Text;
            lsTemp[index].Shop.Price = Conversions.ToUInteger(txtPreco.Text);
            lsTemp[index].ID = Conversions.ToUInteger(txtTypeID.Text);
            lsTemp[index].Icon = txtIcone.Text;
            lsTemp[index].Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
            lsTemp[index].Power = Convert.ToByte(txtQtd.Value);

            lsTemp[index].Shop.flag_shop.time_shop.active = ckTempoAtivo.Checked;
            lsTemp[index].Model = txtSprite.Text;
            if (this.rbLevelMin.Checked)
            {
                if (lsTemp[index].Level.is_max)
                {
                    lsTemp[index].Level.is_max = false;
                }
                else
                    lsTemp[index].ItemLevel = (byte)this.cbLevel.SelectedIndex;
            }
            else
            {
                //set level max is 70 (INFINITY)
                lsTemp[index].Level.is_max = true;
            }
            if (ckTempoAtivo.Checked)
            {
                lsTemp[index].date.active = 1;
                lsTemp[index].date.Start.Time = this.dtInicio.Value;
                lsTemp[index].date.End.Time = this.dtInicio.Value;
            }
            uint ItemType = 0;
            switch (ComboBox1.SelectedIndex)
            {
                case 1:
                    ItemType = 0;
                    break;
                case 2:
                    ItemType = 1;
                    break;
                case 3:
                    ItemType = 2;
                    break;
                case 4:
                    ItemType = 3;   //gameplay         =3 or 4
                    break;
                case 5:
                    ItemType = 10;
                    break;
                case 6:
                    ItemType = 16;
                    break;
                case 7:
                    ItemType = 128;
                    break;
                case 8:
                    ItemType = 252;
                    break;
            }
            lsTemp[index].ItemType = ItemType;
            ListaItem.SelectedRows[0].Cells[1].Value = txtNome.Text;
            ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
            CarregarItem();
        }

        private void Alterou()
        {
            Alterado = true;
        }

        private void gerarBarra(Control Barra, object sender1, object sender2)
        {
            try
            {
                double num5 = 5.9;
                Barra.Width = Conversions.ToInteger(Operators.MultiplyObject(Operators.AddObject(NewLateBinding.LateGet(sender1, null, "value", new object[0], null, null, null), NewLateBinding.LateGet(sender2, null, "value", new object[0], null, null, null)), num5));
            }
            catch (Exception ex)
            {
                // Lida com a exceção, se necessário
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void ckNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNew.Checked)
            {
                ckHot.Checked = false;
                ckNormal.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNormal.Checked)
            {
                ckHot.Checked = false;
                ckNew.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckHot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHot.Checked)
            {
                ckNew.Checked = false;
                ckNormal.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckDesativado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDesativado.Checked)
            {
                ckNew.Checked = false;
                ckNormal.Checked = false;
                ckHot.Checked = false;
                ckGift.Checked = false;
                ckNew.Enabled = false;
                ckNormal.Enabled = false;
                ckHot.Enabled = false;
                ckGift.Enabled = false;
            }
            else
            {
                ckNew.Checked = true;
                ckNormal.Checked = true;
                ckHot.Checked = true;
                ckGift.Checked = true;
                ckNew.Enabled = true;
                ckNormal.Enabled = true;
                ckHot.Enabled = true;
                ckGift.Enabled = true;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            checked
            {
                if (ListaItem.SelectedRows.Count > 1)
                {
                    lastRow = ListaItem.SelectedRows[0].Index - 1;
                    if (MessageBox.Show("Deseja remover os " + Conversions.ToString(ListaItem.SelectedRows.Count) + " itens selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    {
                        return;
                    }
                    int num = ListaItem.SelectedRows.Count - 1;
                    int num2 = 0;
                    while (true)
                    {
                        int num3 = num2;
                        int num4 = num;
                        if (num3 > num4)
                        {
                            break;
                        }
                        try
                        {
                            lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[num2].Cells[0].Value)]);
                        }
                        catch (Exception projectError)
                        {
                            ProjectData.SetProjectError(projectError);
                            ProjectData.ClearProjectError();
                        }
                        num2++;
                    }
                    CarregarGrid(lsTemp);
                }
                else
                {
                    lastRow = ListaItem.SelectedCells[0].RowIndex - 1;
                    if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                        lsTemp.Remove(lsTemp[index]);
                        CarregarGrid(lsTemp);
                    }
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            checked
            {
                if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Item item = new Item();
                    item.Name = "[NOVO ITEM]";
                    Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex + 1, item);
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex, item);
                        ProjectData.ClearProjectError();
                    }
                    lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
                    CarregarGrid(lsTemp);
                    try
                    {
                        ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                        ListaItem.Rows[lastRow].Selected = true;
                    }
                    catch (Exception projectError2)
                    {
                        ProjectData.SetProjectError(projectError2);
                        ListaItem.FirstDisplayedScrollingRowIndex = lastRow - 1;
                        ListaItem.Rows[lastRow - 1].Selected = true;
                        ProjectData.ClearProjectError();
                    }
                }
            }
        }

        private void MenuSalvar_Click(object sender, EventArgs e)
        {
            caminho = Conversions.ToString((int)diagSalvarArquivo.ShowDialog());
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                bs.Filter = "";
                ComboBox2.SelectedIndex = 0;
                salvarAlteracoes();
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
            }
        }

        private void ListaItem_MouseHover(object sender, EventArgs e)
        {
            if (Alterado)
            {
                if (MessageBox.Show("Existem alterações que não foram salvas, desaja salva-las agora?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    salvarAlteracoes();
                }
                else
                {
                    Alterado = false;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Item item = new Item();
                lastRow = checked(ListaItem.SelectedCells[0].RowIndex + 1);
                item = (Item)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)].Clone();
                try
                {
                    lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(ListaItem.SelectedRows[0].Cells[0].Value, 1)), item);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), item);
                    ProjectData.ClearProjectError();
                }
                CarregarGrid(lsTemp);
            }
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            gbTempoVenda.Enabled = ckTempoAtivo.Checked;
        }

        private void MenuSalvarSQL_Click(object sender, EventArgs e)
        {
            caminho = Conversions.ToString((int)diagSalvarSql.ShowDialog());
            Arquivo = diagSalvarSql.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                if (File.Exists(Arquivo))
                {
                    File.Delete(Arquivo);
                }
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bwGerarSql.RunWorkerAsync();
            }
        }

        private void FrmItemEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
            {
                MessageBox.Show("Existem tarefas ainda em execução, é necessário aguardar o término destas tarefas", "Tarefas pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            MyProject.Forms.frmPrincipal.Show();
        }

        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            gerarSql(backgroundWorker);
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            lbStatus.Text = "Gerando arquivo SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Value = 0;
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbStatus.Text = "parado";
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            lbStatus.Text = "Salvando...";
            salvar(backgroundWorker);
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Salvando...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "parado";
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbIndices.Text = Conversions.ToString(qtdItem);
            nomeArquivo();
        }

        public void salvar(BackgroundWorker BW)
        {
            byte[] array = (byte[])Util.setValues(lsTemp, bStart, qtdItem);
            byte[] array2 = (byte[])Util.setValues(lsItens, bStart, lsItens.Count);
            Util.gravarArquivo(array, Arquivo, ref BW);
            string arquivo = Arquivo;
            bool Data = false;
            int TotalProc = 0;
            Util.gerarBackup(array2, arquivo, Data, TotalProc);
        }

        public void gerarSql(BackgroundWorker BW)
        {
            if (Operators.CompareString(Arquivo, null, TextCompare: false) == 0)
            {
                MessageBox.Show("Arquivo inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Conversions.ToBoolean(Util.Item_gerarSql(lsTemp, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Arquivo salvo com erro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void MenuBackup_Click(object sender, EventArgs e)
        {
            byte[] array = (byte[])Util.setValues(lsTemp, bStart, qtdItem);
            string arquivoIff = MySettingsProperty.Settings.ArquivoIff;
            bool Data = true;
            int TotalProc = 0;
            if (Conversions.ToBoolean(Util.gerarBackup(array, arquivoIff, Data, TotalProc)))
            {
                MessageBox.Show("Backup gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Erro ao gerar o backup", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {
            checked
            {
                try
                {
                    int num = 0;
                    num = ((ComboBox2.SelectedIndex == 1) ? 1 : 0);
                    if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        var index = ComboBox1.SelectedIndex;
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(index) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        var index = ComboBox1.SelectedIndex;
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(index);
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        var index = ComboBox1.SelectedIndex;
                        bs.Filter = "Personagem = " + Conversions.ToString(index) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (ComboBox1.SelectedIndex > 0)
                    {
                        var index = ComboBox1.SelectedIndex;
                        bs.Filter = "Personagem = " + Conversions.ToString(index);
                    }
                    else if (ComboBox2.SelectedIndex > 0)
                    {
                        bs.Filter = "Status2 = " + Conversions.ToString(num);
                    }
                    else
                    {
                        bs.Filter = "";
                    }
                    Label33.Text = Conversions.ToString(bs.Count);
                    ListaItem.Columns[0].Width = 45;
                    ListaItem.Columns[2].Width = 30;
                    ListaItem.Columns[5].Width = 30;
                    ListaItem.Columns[0].ValueType = typeof(int);
                    ListaItem.Columns[2].HeaderText = "   ";
                    ListaItem.Columns[5].HeaderText = "   ";
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            if (ComboBox2.SelectedIndex == 0)
            {
                imgStatus.Image = ImageList2.Images[0];
            }
            else if (ComboBox2.SelectedIndex == 1)
            {
                imgStatus.Image = ImageList2.Images[1];
            }
            else
            {
                imgStatus.Image = ImageList2.Images[2];
            }
        }

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            pintarLinhas();
        }

        private bool verificarTYPEID(int typeid = 0)
        {
            int num = 0;
            bool flag = false;
            if (typeid == 0)
            {
                typeid = Conversions.ToInteger(txtTypeID.Text);
            }
            else
            {
                flag = true;
            }
            foreach (Item item in lsTemp)
            {
                if (item.ID == typeid)
                {
                    num = checked(num + 1);
                }
            }
            if (flag)
            {
                if (num >= 1)
                {
                    return true;
                }
                return false;
            }
            if (num > 1)
            {
                return true;
            }
            return false;
        }

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (verificarTYPEID())
            {
                MessageBox.Show("Este TYPEID já está em uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.LightSalmon;
            }
            else
            {
                MessageBox.Show("TYPEID disponível para uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.White;
            }
        }

        private void ListaItem_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            pintarLinhas();
        }

        private void ListaItem_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            try
            {
                pintarLinhas();
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }
    }
}
