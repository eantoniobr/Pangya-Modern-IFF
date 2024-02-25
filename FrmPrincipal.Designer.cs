using Pangya_Modern_Editor.My;
using Pangya_Modern_Editor.Properties;
using System;
using System.Windows.Forms;

namespace Pangya_Modern_Editor
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lbModificado = new System.Windows.Forms.Label();
            this.lbCriado = new System.Windows.Forms.Label();
            this.lbTamanho = new System.Windows.Forms.Label();
            this.BtnOpenPath = new System.Windows.Forms.Button();
            this.btnUnpak = new System.Windows.Forms.Button();
            this.btnPak = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.gbEditores = new System.Windows.Forms.GroupBox();
            this.btnClubSet = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.btnSkin = new System.Windows.Forms.Button();
            this.btnMascot = new System.Windows.Forms.Button();
            this.btnCaudronRandon = new System.Windows.Forms.Button();
            this.btnCauldron = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnBall = new System.Windows.Forms.Button();
            this.btnClub = new System.Windows.Forms.Button();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnCaddieItem = new System.Windows.Forms.Button();
            this.btnCaddie = new System.Windows.Forms.Button();
            this.btnSetItem = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnPart = new System.Windows.Forms.Button();
            this.AppNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.ckOffLine = new System.Windows.Forms.CheckBox();
            this.ckImagensGit = new System.Windows.Forms.CheckBox();
            this.Button9 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1.SuspendLayout();
            this.gbEditores.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.lbModificado);
            this.GroupBox1.Controls.Add(this.lbCriado);
            this.GroupBox1.Controls.Add(this.lbTamanho);
            this.GroupBox1.Controls.Add(this.BtnOpenPath);
            this.GroupBox1.Controls.Add(this.btnUnpak);
            this.GroupBox1.Controls.Add(this.btnPak);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btnNovo);
            this.GroupBox1.Controls.Add(this.txtDir);
            this.GroupBox1.Location = new System.Drawing.Point(12, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(391, 161);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Arquivo";
            // 
            // lbModificado
            // 
            this.lbModificado.AutoSize = true;
            this.lbModificado.Location = new System.Drawing.Point(291, 47);
            this.lbModificado.Name = "lbModificado";
            this.lbModificado.Size = new System.Drawing.Size(16, 13);
            this.lbModificado.TabIndex = 3;
            this.lbModificado.Text = "---";
            this.lbModificado.Visible = false;
            // 
            // lbCriado
            // 
            this.lbCriado.AutoSize = true;
            this.lbCriado.Location = new System.Drawing.Point(224, 48);
            this.lbCriado.Name = "lbCriado";
            this.lbCriado.Size = new System.Drawing.Size(16, 13);
            this.lbCriado.TabIndex = 3;
            this.lbCriado.Text = "---";
            // 
            // lbTamanho
            // 
            this.lbTamanho.AutoSize = true;
            this.lbTamanho.Location = new System.Drawing.Point(63, 47);
            this.lbTamanho.Name = "lbTamanho";
            this.lbTamanho.Size = new System.Drawing.Size(16, 13);
            this.lbTamanho.TabIndex = 3;
            this.lbTamanho.Text = "---";
            // 
            // BtnOpenPath
            // 
            this.BtnOpenPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.BtnOpenPath.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpenPath.Location = new System.Drawing.Point(10, 112);
            this.BtnOpenPath.Name = "BtnOpenPath";
            this.BtnOpenPath.Size = new System.Drawing.Size(372, 41);
            this.BtnOpenPath.TabIndex = 2;
            this.BtnOpenPath.TabStop = false;
            this.BtnOpenPath.Text = "Explorar Pasta";
            this.BtnOpenPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOpenPath.UseVisualStyleBackColor = true;
            this.BtnOpenPath.Click += new System.EventHandler(this.BtnExplorerFolder_Click);
            // 
            // btnUnpak
            // 
            this.btnUnpak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnpak.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUnpak.Image = global::Pangya_Modern_Editor.Properties.Resources.winrar_extract;
            this.btnUnpak.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnpak.Location = new System.Drawing.Point(10, 69);
            this.btnUnpak.Name = "btnUnpak";
            this.btnUnpak.Size = new System.Drawing.Size(182, 41);
            this.btnUnpak.TabIndex = 2;
            this.btnUnpak.TabStop = false;
            this.btnUnpak.Text = "Descompactar";
            this.btnUnpak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnpak.UseVisualStyleBackColor = true;
            this.btnUnpak.Click += new System.EventHandler(this.btnUnpak_Click);
            // 
            // btnPak
            // 
            this.btnPak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPak.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPak.Image = global::Pangya_Modern_Editor.Properties.Resources.winrar_add;
            this.btnPak.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPak.Location = new System.Drawing.Point(198, 69);
            this.btnPak.Name = "btnPak";
            this.btnPak.Size = new System.Drawing.Size(184, 41);
            this.btnPak.TabIndex = 2;
            this.btnPak.TabStop = false;
            this.btnPak.Text = "Compactar";
            this.btnPak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPak.UseVisualStyleBackColor = true;
            this.btnPak.Click += new System.EventHandler(this.btnPak_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(156, 48);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(62, 13);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Modificado:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Tamanho:";
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::Pangya_Modern_Editor.Properties.Resources.folder_explore;
            this.btnNovo.Location = new System.Drawing.Point(360, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(25, 24);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.TabStop = false;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtDir
            // 
            this.txtDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir.Location = new System.Drawing.Point(13, 21);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(341, 20);
            this.txtDir.TabIndex = 0;
            this.txtDir.TextChanged += new System.EventHandler(this.txtDir_TextChanged);
            // 
            // gbEditores
            // 
            this.gbEditores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditores.Controls.Add(this.btnClubSet);
            this.gbEditores.Controls.Add(this.btnDesc);
            this.gbEditores.Controls.Add(this.btnSkin);
            this.gbEditores.Controls.Add(this.btnMascot);
            this.gbEditores.Controls.Add(this.btnCaudronRandon);
            this.gbEditores.Controls.Add(this.btnCauldron);
            this.gbEditores.Controls.Add(this.btnCard);
            this.gbEditores.Controls.Add(this.btnBall);
            this.gbEditores.Controls.Add(this.btnClub);
            this.gbEditores.Controls.Add(this.btnMatch);
            this.gbEditores.Controls.Add(this.btnCaddieItem);
            this.gbEditores.Controls.Add(this.btnCaddie);
            this.gbEditores.Controls.Add(this.btnSetItem);
            this.gbEditores.Controls.Add(this.btnItem);
            this.gbEditores.Controls.Add(this.btnPart);
            this.gbEditores.Location = new System.Drawing.Point(12, 170);
            this.gbEditores.Name = "gbEditores";
            this.gbEditores.Size = new System.Drawing.Size(391, 328);
            this.gbEditores.TabIndex = 1;
            this.gbEditores.TabStop = false;
            this.gbEditores.Text = "Editores disponíveis";
            // 
            // btnClubSet
            // 
            this.btnClubSet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClubSet.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_18;
            this.btnClubSet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClubSet.Location = new System.Drawing.Point(198, 19);
            this.btnClubSet.Name = "btnClubSet";
            this.btnClubSet.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnClubSet.Size = new System.Drawing.Size(88, 70);
            this.btnClubSet.TabIndex = 3;
            this.btnClubSet.TabStop = false;
            this.btnClubSet.Text = "ClubSet";
            this.btnClubSet.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClubSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClubSet.UseVisualStyleBackColor = true;
            // 
            // btnDesc
            // 
            this.btnDesc.Enabled = false;
            this.btnDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesc.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_22;
            this.btnDesc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDesc.Location = new System.Drawing.Point(10, 247);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnDesc.Size = new System.Drawing.Size(88, 70);
            this.btnDesc.TabIndex = 3;
            this.btnDesc.TabStop = false;
            this.btnDesc.Text = "Desc";
            this.btnDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDesc.UseVisualStyleBackColor = true;
            // 
            // btnSkin
            // 
            this.btnSkin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkin.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_22;
            this.btnSkin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSkin.Location = new System.Drawing.Point(198, 171);
            this.btnSkin.Name = "btnSkin";
            this.btnSkin.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnSkin.Size = new System.Drawing.Size(88, 70);
            this.btnSkin.TabIndex = 3;
            this.btnSkin.TabStop = false;
            this.btnSkin.Text = "Skin";
            this.btnSkin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSkin.UseVisualStyleBackColor = true;
            // 
            // btnMascot
            // 
            this.btnMascot.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMascot.Image = global::Pangya_Modern_Editor.Properties.Resources.mascot_02;
            this.btnMascot.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMascot.Location = new System.Drawing.Point(292, 171);
            this.btnMascot.Name = "btnMascot";
            this.btnMascot.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMascot.Size = new System.Drawing.Size(88, 70);
            this.btnMascot.TabIndex = 3;
            this.btnMascot.TabStop = false;
            this.btnMascot.Text = "Mascot";
            this.btnMascot.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMascot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMascot.UseVisualStyleBackColor = true;
            // 
            // btnCaudronRandon
            // 
            this.btnCaudronRandon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaudronRandon.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_26;
            this.btnCaudronRandon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaudronRandon.Location = new System.Drawing.Point(292, 95);
            this.btnCaudronRandon.Name = "btnCaudronRandon";
            this.btnCaudronRandon.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnCaudronRandon.Size = new System.Drawing.Size(88, 70);
            this.btnCaudronRandon.TabIndex = 3;
            this.btnCaudronRandon.TabStop = false;
            this.btnCaudronRandon.Text = "C. Random";
            this.btnCaudronRandon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaudronRandon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaudronRandon.UseVisualStyleBackColor = true;
            // 
            // btnCauldron
            // 
            this.btnCauldron.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCauldron.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_26;
            this.btnCauldron.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCauldron.Location = new System.Drawing.Point(198, 95);
            this.btnCauldron.Name = "btnCauldron";
            this.btnCauldron.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnCauldron.Size = new System.Drawing.Size(88, 70);
            this.btnCauldron.TabIndex = 3;
            this.btnCauldron.TabStop = false;
            this.btnCauldron.Text = "Cauldron";
            this.btnCauldron.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCauldron.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCauldron.UseVisualStyleBackColor = true;
            // 
            // btnCard
            // 
            this.btnCard.Enabled = false;
            this.btnCard.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCard.Image = global::Pangya_Modern_Editor.Properties.Resources.card_icon_pack_04;
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCard.Location = new System.Drawing.Point(198, 247);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(88, 70);
            this.btnCard.TabIndex = 3;
            this.btnCard.TabStop = false;
            this.btnCard.Text = "Card";
            this.btnCard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // btnBall
            // 
            this.btnBall.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBall.Image = global::Pangya_Modern_Editor.Properties.Resources.ball_03;
            this.btnBall.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBall.Location = new System.Drawing.Point(104, 95);
            this.btnBall.Name = "btnBall";
            this.btnBall.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnBall.Size = new System.Drawing.Size(88, 70);
            this.btnBall.TabIndex = 3;
            this.btnBall.TabStop = false;
            this.btnBall.Text = "Ball";
            this.btnBall.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBall.UseVisualStyleBackColor = true;
            // 
            // btnClub
            // 
            this.btnClub.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClub.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_18;
            this.btnClub.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClub.Location = new System.Drawing.Point(292, 19);
            this.btnClub.Name = "btnClub";
            this.btnClub.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnClub.Size = new System.Drawing.Size(88, 70);
            this.btnClub.TabIndex = 3;
            this.btnClub.TabStop = false;
            this.btnClub.Text = "Club";
            this.btnClub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClub.UseVisualStyleBackColor = true;
            // 
            // btnMatch
            // 
            this.btnMatch.Enabled = false;
            this.btnMatch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatch.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_15;
            this.btnMatch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMatch.Location = new System.Drawing.Point(104, 247);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.btnMatch.Size = new System.Drawing.Size(88, 70);
            this.btnMatch.TabIndex = 3;
            this.btnMatch.TabStop = false;
            this.btnMatch.Text = "Match";
            this.btnMatch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMatch.UseVisualStyleBackColor = true;
            // 
            // btnCaddieItem
            // 
            this.btnCaddieItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaddieItem.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_19;
            this.btnCaddieItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaddieItem.Location = new System.Drawing.Point(104, 171);
            this.btnCaddieItem.Name = "btnCaddieItem";
            this.btnCaddieItem.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.btnCaddieItem.Size = new System.Drawing.Size(88, 70);
            this.btnCaddieItem.TabIndex = 3;
            this.btnCaddieItem.TabStop = false;
            this.btnCaddieItem.Text = "CaddieItem";
            this.btnCaddieItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaddieItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaddieItem.UseVisualStyleBackColor = true;
            // 
            // btnCaddie
            // 
            this.btnCaddie.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaddie.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_19;
            this.btnCaddie.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaddie.Location = new System.Drawing.Point(10, 171);
            this.btnCaddie.Name = "btnCaddie";
            this.btnCaddie.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.btnCaddie.Size = new System.Drawing.Size(88, 70);
            this.btnCaddie.TabIndex = 3;
            this.btnCaddie.TabStop = false;
            this.btnCaddie.Text = "Caddie";
            this.btnCaddie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaddie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaddie.UseVisualStyleBackColor = true;
            this.btnCaddie.Click += new System.EventHandler(this.btnCaddie_Click);
            // 
            // btnSetItem
            // 
            this.btnSetItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetItem.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_11;
            this.btnSetItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetItem.Location = new System.Drawing.Point(104, 19);
            this.btnSetItem.Name = "btnSetItem";
            this.btnSetItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnSetItem.Size = new System.Drawing.Size(88, 70);
            this.btnSetItem.TabIndex = 2;
            this.btnSetItem.TabStop = false;
            this.btnSetItem.Text = "SetItem";
            this.btnSetItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSetItem.UseVisualStyleBackColor = true;
            // 
            // btnItem
            // 
            this.btnItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItem.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_29;
            this.btnItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnItem.Location = new System.Drawing.Point(10, 95);
            this.btnItem.Name = "btnItem";
            this.btnItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnItem.Size = new System.Drawing.Size(88, 70);
            this.btnItem.TabIndex = 3;
            this.btnItem.TabStop = false;
            this.btnItem.Text = "Item";
            this.btnItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // btnPart
            // 
            this.btnPart.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPart.Image = global::Pangya_Modern_Editor.Properties.Resources.ico_44;
            this.btnPart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPart.Location = new System.Drawing.Point(10, 19);
            this.btnPart.Name = "btnPart";
            this.btnPart.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnPart.Size = new System.Drawing.Size(88, 70);
            this.btnPart.TabIndex = 2;
            this.btnPart.TabStop = false;
            this.btnPart.Text = "Part";
            this.btnPart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPart.UseVisualStyleBackColor = true;
            this.btnPart.Click += new System.EventHandler(this.btnPart_Click);
            // 
            // AppNotify
            // 
            this.AppNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("AppNotify.Icon")));
            this.AppNotify.Text = "Editor IFF";
            this.AppNotify.Visible = true;
            this.AppNotify.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.Button1);
            this.GroupBox2.Controls.Add(this.ckOffLine);
            this.GroupBox2.Controls.Add(this.ckImagensGit);
            this.GroupBox2.Location = new System.Drawing.Point(12, 499);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(391, 81);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Opções";
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.Location = new System.Drawing.Point(277, 16);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(103, 56);
            this.Button1.TabIndex = 3;
            this.Button1.TabStop = false;
            this.Button1.Text = "Visualizar Cache";
            this.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // ckOffLine
            // 
            this.ckOffLine.AutoSize = true;
            this.ckOffLine.Checked = true;
            this.ckOffLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOffLine.Location = new System.Drawing.Point(10, 42);
            this.ckOffLine.Name = "ckOffLine";
            this.ckOffLine.Size = new System.Drawing.Size(111, 17);
            this.ckOffLine.TabIndex = 0;
            this.ckOffLine.Text = "Trabalhar Off-Line";
            this.ckOffLine.UseVisualStyleBackColor = true;
            this.ckOffLine.CheckedChanged += new System.EventHandler(this.ckOffLine_CheckedChanged);
            // 
            // ckImagensGit
            // 
            this.ckImagensGit.AutoSize = true;
            this.ckImagensGit.Location = new System.Drawing.Point(10, 19);
            this.ckImagensGit.Name = "ckImagensGit";
            this.ckImagensGit.Size = new System.Drawing.Size(131, 17);
            this.ckImagensGit.TabIndex = 0;
            this.ckImagensGit.Text = "Buscar Imagens no git";
            this.ckImagensGit.UseVisualStyleBackColor = true;
            this.ckImagensGit.CheckedChanged += new System.EventHandler(this.ckImagensGit_CheckedChanged);
            // 
            // Button9
            // 
            this.Button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button9.Image = global::Pangya_Modern_Editor.Properties.Resources.application_put;
            this.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button9.Location = new System.Drawing.Point(12, 586);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(192, 41);
            this.Button9.TabIndex = 2;
            this.Button9.TabStop = false;
            this.Button9.Text = "Ocultar";
            this.Button9.UseVisualStyleBackColor = true;
            this.Button9.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // Button5
            // 
            this.Button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button5.Image = global::Pangya_Modern_Editor.Properties.Resources.disconnect;
            this.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button5.Location = new System.Drawing.Point(210, 586);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(193, 41);
            this.Button5.TabIndex = 2;
            this.Button5.TabStop = false;
            this.Button5.Text = "Sair";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Pangya File (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Abrir arquivo (Part.iff)";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 639);
            this.ControlBox = false;
            this.Controls.Add(this.Button9);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.gbEditores);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de IFF";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.gbEditores.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
 private GroupBox GroupBox1;
    private Label lbModificado;
    private Label lbCriado;
    private Label lbTamanho;
    private Button BtnOpenPath;
    private Button btnUnpak;
    private Button btnPak;
    private Label Label5;
    private Label Label1;
    private Button btnNovo;
    private TextBox txtDir;
    private GroupBox gbEditores;
    private Button btnClubSet;
    private Button btnDesc;
    private Button btnSkin;
    private Button btnMascot;
    private Button btnCaudronRandon;
    private Button btnCauldron;
    private Button btnCard;
    private Button btnBall;
    private Button btnClub;
    private Button btnMatch;
    private Button btnCaddieItem;
    private Button btnCaddie;
    private Button btnSetItem;
    private Button btnItem;
    private Button btnPart;
    private NotifyIcon AppNotify;
    private GroupBox GroupBox2;
    private Button Button1;
    private CheckBox ckOffLine;
    private CheckBox ckImagensGit;
    private OpenFileDialog diagAbrirArquivo;
    private Button Button9;
    private Button Button5;
        #endregion
    }
}