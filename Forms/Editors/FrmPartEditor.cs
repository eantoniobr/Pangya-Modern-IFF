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
    public partial class FrmPartEditor : Form
    {
        public FrmPartEditor()
        {
            bs = new BindingSource();
            InitializeComponent();

        }

        private void FrmPartEditor_Load(object sender, EventArgs e)
        {
            if (this.Arquivo != "")
            {
                this.lsItens = new IFFFile<Part>();
                this.lsTemp = new IFFFile<Part>();
                MySettings.Default.ArquivoIff = this.Arquivo;
                try
                {
                    this.lsItens = new IFFFile<Part>(Arquivo);
                }
                catch(Exception ex)
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
                this.lsItens = new IFFFile<Part>();
                this.lsTemp = new IFFFile<Part>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                Settings.Default.ArquivoIff = this.Arquivo;
                try
                {
                    this.lsItens = new IFFFile<Part>(Arquivo);
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

        public void CarregarGrid(List<Part> Lista)
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
                    imgPersonagem2.Image = ImageList1.Images[0];
                    ProjectData.ClearProjectError();
                }
                var id = oIff.CharacterType == 14 ? (int)oIff.CharacterType : (int)oIff.CharacterType + 1;

                table.Rows.Add(new object[] { num3, oIff.Name.Replace("\0", ""), statusImage, id, oIff.Active, tipoImage, num4 });
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
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 1, false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                    }
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 2, false))
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
            var id = 0;
            if (ListaItem.SelectedRows.Count > 0)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                var selectedItem = lsTemp[index];

                id = selectedItem.CharacterType == 14 ? (int)selectedItem.CharacterType : (int)selectedItem.CharacterType + 1;
                txtNome.Text = selectedItem.Name;
                txtTypeID.Text = Conversions.ToString(selectedItem.ID);
                ckAtivo.Checked = selectedItem.isValid != 0;
                txtIcone.Text = selectedItem.Icon;
                txtPreco.Text = Conversions.ToString(selectedItem.Price);
                txtDesconto.Text = Conversions.ToString(selectedItem.DiscountPrice);
                att2Forca.Value = new decimal(selectedItem.PowerSlot);
                attForca.Value = new decimal(selectedItem.Power);
                att2Controle.Value = new decimal(selectedItem.ControlSlot);
                attControle.Value = new decimal(selectedItem.Control);
                att2Precisao.Value = new decimal(selectedItem.ImpactSlot);
                attPrecisao.Value = new decimal(selectedItem.Impact);
                att2Spin.Value = new decimal(selectedItem.SpinSlot);
                attSpin.Value = new decimal(selectedItem.Spin);
                att2Curva.Value = new decimal(selectedItem.CurveSlot);
                attCurva.Value = new decimal(selectedItem.Curve);
                txtSlotAssistente.Value = new decimal(selectedItem._CardSlot.CaddieSlot);
                txtSlotPersonagem.Value = new decimal(selectedItem._CardSlot.CharSlot);
                txtSubParte1.Text = Conversions.ToString(selectedItem.SubPart1);
                txtSubParte2.Text = Conversions.ToString(selectedItem.SubPart2);
                txtTextura1.Text = selectedItem.Texture1;
                txtTextura2.Text = selectedItem.Texture2;
                txtTextura3.Text = selectedItem.Texture3;
                txtTextura4.Text = selectedItem.Texture4;
                txtTextura5.Text = selectedItem.Texture5;
                txtTextura6.Text = selectedItem.Texture6;
                txtModelo.Text = selectedItem.MPet;
                txtAddCom.Text = selectedItem.EquippableWith.Replace(",", ".");
                cbTipo.SelectedIndex = selectedItem.GetTypeCash();
                dtInicio.Value = selectedItem.date.Start.Time;
                dtTermino.Value = selectedItem.date.End.Time;
                ckNormal.Checked = selectedItem.Shop.flag_shop.IsNormal || selectedItem.Shop.flag_shop.is_saleable;
                ckDesativado.Checked = selectedItem.Shop.flag_shop.IsHide;
                ckNew.Checked = selectedItem.Shop.flag_shop.IsNew;
                ckGift.Checked = selectedItem.Shop.flag_shop.IsGift;
                ckHot.Checked = selectedItem.Shop.flag_shop.IsHot;
                ckTempoAtivo.Checked = selectedItem.date.Check();
                if (!selectedItem.Level.is_max)
                {
                    cbLevel.SelectedIndex = selectedItem.Level.level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    cbLevel.SelectedIndex = selectedItem.Level.level;
                    rbLevelMax.Checked = true;
                }
                int itemType = (int)selectedItem.type_item;
                if (itemType > 7)
                {
                    cbCategoria.SelectedIndex = unchecked((int)selectedItem.type_item) - 2;
                }
                else if (unchecked(itemType < 6 && itemType < 7))
                {
                    cbCategoria.SelectedIndex = (int)selectedItem.type_item;
                }
                else
                {
                    cbCategoria.SelectedIndex = -1;
                }
            }
            Alterado = false;
            try
            {
                imgPersonagem2.Image = ImageList1.Images[id];
                imgPersonagem2.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                imgPersonagem2.Image = ImageList1.Images[0];
                ProjectData.ClearProjectError();
            }
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
                    menuMassa.Enabled = false;//menuMassa.Enabled = true;
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
                    menuMassa.Enabled = false;//menuMassa.Enabled = true;
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
            var img = Util.getImage(txtIcone.Text);
            PictureBox obj = imgIcone;
            carregarImagem(img as Image, ref obj);
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
            ComboBox1.SelectedIndex = 0;
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
            lsTemp[index].Power = Convert.ToByte(attForca.Value);
            lsTemp[index].Control = Convert.ToByte(attControle.Value);
            lsTemp[index].Impact = Convert.ToByte(attPrecisao.Value);
            lsTemp[index].Spin = Convert.ToByte(attSpin.Value);
            lsTemp[index].Curve = Convert.ToByte(attCurva.Value);
            lsTemp[index].PowerSlot = Convert.ToByte(att2Forca.Value);
            lsTemp[index].ControlSlot = Convert.ToByte(att2Controle.Value);
            lsTemp[index].ImpactSlot = Convert.ToByte(att2Precisao.Value);
            lsTemp[index].SpinSlot = Convert.ToByte(att2Spin.Value);
            lsTemp[index].CurveSlot = Convert.ToByte(att2Curva.Value);
            lsTemp[index].Shop.flag_shop.time_shop.active = ckTempoAtivo.Checked;
            lsTemp[index].EquipmentCategory = (uint)cbCategoria.SelectedIndex;
            lsTemp[index].SubPart1 = Conversions.ToUInteger(txtSubParte1.Text);
            lsTemp[index].SubPart2 = Conversions.ToUInteger(txtSubParte2.Text);
            lsTemp[index].Texture1 = txtTextura1.Text;
            lsTemp[index].Texture1 = txtTextura2.Text;
            lsTemp[index].Texture3 = txtTextura3.Text;
            lsTemp[index].Texture4 = txtTextura4.Text;
            lsTemp[index].Texture5 = txtTextura5.Text;
            lsTemp[index].Texture6 = txtTextura6.Text;
            lsTemp[index].MPet = txtModelo.Text;
            lsTemp[index].EquippableWith = txtAddCom.Text;
            lsTemp[index]._CardSlot.CaddieSlot = Convert.ToUInt16(txtSlotAssistente.Value);
            lsTemp[index]._CardSlot.CharSlot = Convert.ToUInt16(txtSlotPersonagem.Value);
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
            ListaItem.SelectedRows[0].Cells[1].Value = txtNome.Text;
            ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;

        }

        private void Alterou()
        {
            Alterado = true;
        }

        private void gerarBarra(Control barra, object sender1, object sender2)
        {
            try
            {
                double num5 = 5.9;
                double value1 = Convert.ToDouble(sender1.GetType().GetProperty("Value").GetValue(sender1, null));
                double value2 = Convert.ToDouble(sender2.GetType().GetProperty("Value").GetValue(sender2, null));

                barra.Width = (int)((value1 + value2) * num5);
            }
            catch (Exception ex)
            {
                // Lida com a exceção, se necessário
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void att2Curva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), attCurva);
        }

        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), att2Curva);
        }

        private void att2Spin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), attSpin);
        }

        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), att2Spin);
        }

        private void att2Precisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), attPrecisao);
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), att2Precisao);
        }

        private void att2Controle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), attControle);
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), att2Controle);
        }

        private void att2Forca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), attForca);
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), att2Forca);
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
            if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            Part part = new Part();
            part.Name = "[NOVO ITEM]";
            part.EquippableWith = "0.0";
            bool flag = false;
            int num = 0;
            int num2 = 0;
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            checked
            {
                while (!flag)
                {
                    num2++;
                    int num3 = Conversions.ToInteger(part.newTypeid(lsTemp[index].getPersonagemNome(), num, 2, (int)part.type_item, num2));
                    if (num2 < 999)
                    {
                        if (!verificarTYPEID(num3))
                        {
                            flag = true;
                            part.ID = (uint)num3;
                        }
                        else
                        {
                            flag = false;
                        }
                        continue;
                    }
                    MessageBox.Show("Não foi possivel gerar um novo ID unico para o item automaticamente, tenta novamente ou faça manualmente!", "Erro ao gerar um novo ID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                }
                try
                {
                    lsTemp.Add(part);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    lsTemp.Add(part);
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

        private void MenuSalvarComo_Click(object sender, EventArgs e)
        {
            caminho = Conversions.ToString((int)diagSalvarArquivo.ShowDialog());
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, false) != 0)
            {
                bs.Filter = "";
                ComboBox1.SelectedIndex = 0;
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
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
            var part = (Part)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)].Clone();
            bool flag = false;
            int num = 0;
            int num2 = 0;
            while (!flag)
            {
                num2++;
                int num3 = Conversions.ToInteger(part.newTypeid(part.getPersonagemNome(), num, 2, (int)part.type_item, num2));
                if (num2 < 999)
                {
                    if (!verificarTYPEID(num3))
                    {
                        flag = true;
                        part.ID = (uint)num3;
                    }
                    else
                    {
                        flag = false;
                    }
                    continue;
                }
                MessageBox.Show("Não foi possivel gerar um novo ID unico para o item automaticamente, tenta novamente ou faça manualmente!", "Erro ao gerar um novo ID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                break;
            }
            try
            {
                lsTemp.Add(part);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                lsTemp.Add(part);
                ProjectData.ClearProjectError();
            }
            CarregarGrid(lsTemp);
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            gbTempoVenda.Enabled = ckTempoAtivo.Checked;
        }

        private void menuGerarSql_Click(object sender, EventArgs e)
        {
            caminho = Conversions.ToString((int)diagSalvarSql.ShowDialog());
            Arquivo = diagSalvarSql.FileName;
            if (Operators.CompareString(Arquivo, null, false) != 0)
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

        private void FrmPartEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
            {
                MessageBox.Show("Existem tarefas ainda em execução, é necessário aguardar o término destas tarefas", "Tarefas pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
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
            var bck = Path.ChangeExtension(Arquivo, ".bak");
            lsItens.Save(bck);
            lsTemp.Save(Arquivo);
        }

        public void gerarSql(BackgroundWorker BW)
        {
            if (Operators.CompareString(Arquivo, null, false) == 0)
            {
                MessageBox.Show("Arquivo inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Conversions.ToBoolean(Util.Part_gerarSql(lsTemp, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Arquivo salvo com erro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void menuBackup_Click(object sender, EventArgs e)
        {
            string arquivoIff = Settings.Default.ArquivoIff;
            bool Data = true;
            int TotalProc = 0;
            if (Conversions.ToBoolean(Util.gerarBackup(lsItens.GetBytes(), arquivoIff, Data, TotalProc)))
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
            var _img = ImageList1.Images[ComboBox1.SelectedIndex];
            imgPersonagem.Image = _img;
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
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex);
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        bs.Filter = "Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (ComboBox1.SelectedIndex > 0)
                    {
                        bs.Filter = "Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex);
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
            foreach (Part item in lsTemp)
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
        private void menuGerarCache_Click(object sender, EventArgs e)
        {
            //List<int> list = new List<int>();
            //List<string> list2 = new List<string>();
            //foreach (var item in lsTemp)
            //{
            //    list.Add(checked((int)item.ID));
            //    list2.Add(item.Icon);
            //}
            //frmCache frmCache2 = new frmCache();
            //frmCache2.ls = list;
            //frmCache2.ls1 = list2;
            //frmCache2.tipo = 1;
            //frmCache2.TopMost = true;
            //frmCache2.Show();
        }
        private void DividirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.diagPasta.ShowDialog() == DialogResult.OK)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processando...";
                bool flag2 = this.diagPasta.SelectedPath != "";
                if (flag2)
                {
                    IFFFile<Part> itens = new IFFFile<Part>();
                    IFFFile<Part> list2 = new IFFFile<Part>();
                    IFFFile<Part> list3 = new IFFFile<Part>();
                    IFFFile<Part> list4 = new IFFFile<Part>();
                    IFFFile<Part> list5 = new IFFFile<Part>();
                    IFFFile<Part> list6 = new IFFFile<Part>();
                    IFFFile<Part> list7 = new IFFFile<Part>();
                    IFFFile<Part> list8 = new IFFFile<Part>();
                    IFFFile<Part> list9 = new IFFFile<Part>();
                    IFFFile<Part> list10 = new IFFFile<Part>();
                    string selectedPath = this.diagPasta.SelectedPath;
                    Settings.Default.DiretorioDividir = selectedPath;
                    try
                    {
                        int num5;
                        using (List<Part>.Enumerator enumerator = this.lsTemp.GetEnumerator())
                        {
                            while (true)
                            {
                                flag2 = enumerator.MoveNext();
                                if (!flag2)
                                {
                                    break;
                                }
                                Part current = enumerator.Current;
                                num5 = (int)current.CharacterType;
                                switch (num5)
                                {
                                    case 0:
                                        {
                                            itens.Add(current);
                                            continue;
                                        }
                                    case 1:
                                        {
                                            list2.Add(current);
                                            continue;
                                        }
                                    case 2:
                                        {
                                            list3.Add(current);
                                            continue;
                                        }
                                    case 3:
                                        {
                                            list4.Add(current);
                                            continue;
                                        }
                                    case 4:
                                        {
                                            list5.Add(current);
                                            continue;
                                        }
                                    case 5:
                                        {
                                            list6.Add(current);
                                            continue;
                                        }
                                    case 6:
                                        {
                                            list7.Add(current);
                                            continue;
                                        }
                                    case 7:
                                        {
                                            list8.Add(current);
                                            continue;
                                        }
                                    case 8:
                                        {
                                            list9.Add(current);
                                            continue;
                                        }
                                    case 9:
                                        {
                                            list10.Add(current);
                                            continue;
                                        }
                                }
                            }
                        }
                        int num2 = 0;
                        while (true)
                        {
                            switch (num2)
                            {
                                case 0:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(itens as IFFFile<Part>, itens.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", itens[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 1:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list2 as IFFFile<Part>, list2.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list2[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 2:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list3 as IFFFile<Part>, list3.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list3[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 3:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list4 as IFFFile<Part>, list4.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list4[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 4:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list5 as IFFFile<Part>, list5.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list5[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 5:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list6 as IFFFile<Part>, list6.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list6[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 6:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list7 as IFFFile<Part>, list7.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list7[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 7:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list8 as IFFFile<Part>, list8.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list8[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 8:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list9 as IFFFile<Part>, list9.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list9[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                case 9:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list10 as IFFFile<Part>, list10.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list10[0].getPersonagemNome()), "_Part.iff")));
                                    break;

                                default:
                                    break;
                            }
                            num2++;
                            num5 = 9;
                            if (num2 > num5)
                            {
                                if (MessageBox.Show("Arquivo dividido com sucesso, deseja vizualizar a pasta?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    Process.Start(selectedPath);
                                }
                                break;
                            }
                        }
                        pbStatus.Style = ProgressBarStyle.Blocks;
                        pbStatus.Value = 0;
                        lbStatus.Text = "Stop";
                    }
                    catch (Exception exception1)
                    {
                        Exception ex = exception1;
                        ProjectData.SetProjectError(ex);
                        Exception exception = ex;
                        MessageBox.Show("Erro ao dividir o arquivo", "Erro grava\x00e7\x00e3o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ProjectData.ClearProjectError();
                    }
                }
            }

        }

        private void UnirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.diagPasta.ShowDialog() == DialogResult.OK)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processando...";
                bool flag2 = this.diagPasta.SelectedPath != "";
                if (flag2)
                {
                    try
                    {
                        this.lsItens = new IFFFile<Part>();
                        string selectedPath = this.diagPasta.SelectedPath;
                        int num = 0;
                        this.qtdItem = 0L;
                        string[] files = Directory.GetFiles(selectedPath);
                        int index = 0;
                        string[] strArray = new string[2];
                        while (true)
                        {
                            flag2 = index < files.Length;
                            if (!flag2)
                            {
                                this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                                int length = 0x19;
                                this.Arquivo = selectedPath + @"\" + strArray[2];
                                this.lbArquivo.Text = (Strings.Len(this.Arquivo) <= length) ? this.Arquivo : ("..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length));
                                this.ListaItem.DataSource = null;
                                this.CarregarGrid(this.lsTemp);
                                this.lbIndices.Text = Conversions.ToString(this.qtdItem);
                                break;
                            }
                            string path = files[index];
                            if (Path.GetExtension(path) == ".iff")
                            {
                                strArray = Path.GetFileName(path).Split(new char[] { '_' });
                                long qtd = num;
                                num = (int)qtd;
                                lsItens.Load(File.ReadAllBytes(path));
                                this.qtdItem += num;
                            }
                            index++;
                        }
                    }
                    catch (Exception exception1)
                    {
                        Exception ex = exception1;
                        ProjectData.SetProjectError(ex);
                        Exception exception = ex;
                        MessageBox.Show("Erro ao dividir o arquivo", "Erro grava\x00e7\x00e3o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ProjectData.ClearProjectError();
                    }
                }

                pbStatus.Style = ProgressBarStyle.Blocks;
                pbStatus.Value = 0;
                lbStatus.Text = "Parado";
            }
        }
    }
}
