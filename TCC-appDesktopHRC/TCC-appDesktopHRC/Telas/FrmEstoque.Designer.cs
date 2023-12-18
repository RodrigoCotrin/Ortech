namespace TCC_appDesktopHRC.Telas
{
    partial class FrmEstoque
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.kbcFiltroInsumos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisaInsumos = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewInsumosDisp = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDesativarFornecedor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDesativarInsumo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEditarFornecedor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEditarInsumo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCadastrarFornecedor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCriarGrafico = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCadastrarInsumo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewInsumos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbcFiltroInsumos)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInsumosDisp)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.kbcFiltroInsumos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPesquisaInsumos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 100);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(632, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 28);
            this.label4.TabIndex = 90;
            this.label4.Text = "Filtros:";
            // 
            // kbcFiltroInsumos
            // 
            this.kbcFiltroInsumos.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlAlternate;
            this.kbcFiltroInsumos.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.FormClose;
            this.kbcFiltroInsumos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kbcFiltroInsumos.DropDownWidth = 168;
            this.kbcFiltroInsumos.Location = new System.Drawing.Point(637, 42);
            this.kbcFiltroInsumos.Margin = new System.Windows.Forms.Padding(2);
            this.kbcFiltroInsumos.Name = "kbcFiltroInsumos";
            this.kbcFiltroInsumos.Size = new System.Drawing.Size(168, 38);
            this.kbcFiltroInsumos.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.White;
            this.kbcFiltroInsumos.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbcFiltroInsumos.StateCommon.ComboBox.Border.Rounding = 10;
            this.kbcFiltroInsumos.StateCommon.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.kbcFiltroInsumos.StateCommon.Item.Back.Color1 = System.Drawing.Color.White;
            this.kbcFiltroInsumos.StateCommon.Item.Back.Color2 = System.Drawing.Color.White;
            this.kbcFiltroInsumos.StateCommon.Item.Border.Color1 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.Item.Border.Color2 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.Item.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbcFiltroInsumos.StateCommon.Item.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kbcFiltroInsumos.StateCommon.Item.Border.Rounding = 10;
            this.kbcFiltroInsumos.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.Item.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kbcFiltroInsumos.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.kbcFiltroInsumos.TabIndex = 89;
            this.kbcFiltroInsumos.SelectedIndexChanged += new System.EventHandler(this.kbcFiltroInsumos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "Pesquisa de insumos:";
            // 
            // txtPesquisaInsumos
            // 
            this.txtPesquisaInsumos.Location = new System.Drawing.Point(51, 42);
            this.txtPesquisaInsumos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPesquisaInsumos.Name = "txtPesquisaInsumos";
            this.txtPesquisaInsumos.Size = new System.Drawing.Size(581, 40);
            this.txtPesquisaInsumos.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtPesquisaInsumos.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.txtPesquisaInsumos.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.txtPesquisaInsumos.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPesquisaInsumos.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtPesquisaInsumos.StateCommon.Border.Rounding = 10;
            this.txtPesquisaInsumos.StateCommon.Content.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.txtPesquisaInsumos.TabIndex = 19;
            this.txtPesquisaInsumos.TextChanged += new System.EventHandler(this.txtPesquisaInsumos_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 653);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewInsumosDisp);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(362, 100);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 653);
            this.panel3.TabIndex = 18;
            // 
            // dataGridViewInsumosDisp
            // 
            this.dataGridViewInsumosDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInsumosDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInsumosDisp.Location = new System.Drawing.Point(20, 40);
            this.dataGridViewInsumosDisp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInsumosDisp.Name = "dataGridViewInsumosDisp";
            this.dataGridViewInsumosDisp.RowHeadersWidth = 51;
            this.dataGridViewInsumosDisp.RowTemplate.Height = 24;
            this.dataGridViewInsumosDisp.Size = new System.Drawing.Size(480, 199);
            this.dataGridViewInsumosDisp.TabIndex = 35;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(20, 239);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(480, 20);
            this.panel9.TabIndex = 34;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(20, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(480, 40);
            this.panel8.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(480, 40);
            this.label3.TabIndex = 28;
            this.label3.Text = "Avisos sobre insumos:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(500, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(20, 259);
            this.panel7.TabIndex = 32;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 259);
            this.panel6.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDesativarFornecedor);
            this.panel5.Controls.Add(this.btnDesativarInsumo);
            this.panel5.Controls.Add(this.btnEditarFornecedor);
            this.panel5.Controls.Add(this.btnEditarInsumo);
            this.panel5.Controls.Add(this.btnCadastrarFornecedor);
            this.panel5.Controls.Add(this.btnCriarGrafico);
            this.panel5.Controls.Add(this.btnCadastrarInsumo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 259);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(520, 394);
            this.panel5.TabIndex = 30;
            // 
            // btnDesativarFornecedor
            // 
            this.btnDesativarFornecedor.Location = new System.Drawing.Point(342, 300);
            this.btnDesativarFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesativarFornecedor.Name = "btnDesativarFornecedor";
            this.btnDesativarFornecedor.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnDesativarFornecedor.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarFornecedor.OverrideDefault.Back.ColorAngle = 45F;
            this.btnDesativarFornecedor.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.OverrideDefault.Border.ColorAngle = 45F;
            this.btnDesativarFornecedor.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarFornecedor.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesativarFornecedor.OverrideDefault.Border.Rounding = 40;
            this.btnDesativarFornecedor.OverrideDefault.Border.Width = 2;
            this.btnDesativarFornecedor.Size = new System.Drawing.Size(174, 64);
            this.btnDesativarFornecedor.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnDesativarFornecedor.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarFornecedor.StateCommon.Back.ColorAngle = 45F;
            this.btnDesativarFornecedor.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StateCommon.Border.ColorAngle = 45F;
            this.btnDesativarFornecedor.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnDesativarFornecedor.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarFornecedor.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesativarFornecedor.StateCommon.Border.Rounding = 40;
            this.btnDesativarFornecedor.StateCommon.Border.Width = 2;
            this.btnDesativarFornecedor.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnDesativarFornecedor.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnDesativarFornecedor.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnDesativarFornecedor.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDesativarFornecedor.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarFornecedor.StatePressed.Back.ColorAngle = 135F;
            this.btnDesativarFornecedor.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarFornecedor.StatePressed.Border.Rounding = 40;
            this.btnDesativarFornecedor.StatePressed.Border.Width = 2;
            this.btnDesativarFornecedor.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnDesativarFornecedor.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnDesativarFornecedor.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarFornecedor.StateTracking.Back.ColorAngle = -45F;
            this.btnDesativarFornecedor.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarFornecedor.StateTracking.Border.ColorAngle = 45F;
            this.btnDesativarFornecedor.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarFornecedor.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesativarFornecedor.StateTracking.Border.Rounding = 40;
            this.btnDesativarFornecedor.StateTracking.Border.Width = 2;
            this.btnDesativarFornecedor.TabIndex = 37;
            this.btnDesativarFornecedor.Values.Text = "Gerar gráfico";
            this.btnDesativarFornecedor.Visible = false;
            this.btnDesativarFornecedor.Click += new System.EventHandler(this.btnCriarGrafico_Click);
            // 
            // btnDesativarInsumo
            // 
            this.btnDesativarInsumo.Location = new System.Drawing.Point(158, 208);
            this.btnDesativarInsumo.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesativarInsumo.Name = "btnDesativarInsumo";
            this.btnDesativarInsumo.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnDesativarInsumo.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarInsumo.OverrideDefault.Back.ColorAngle = 45F;
            this.btnDesativarInsumo.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.OverrideDefault.Border.ColorAngle = 45F;
            this.btnDesativarInsumo.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarInsumo.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesativarInsumo.OverrideDefault.Border.Rounding = 40;
            this.btnDesativarInsumo.OverrideDefault.Border.Width = 2;
            this.btnDesativarInsumo.Size = new System.Drawing.Size(205, 64);
            this.btnDesativarInsumo.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnDesativarInsumo.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarInsumo.StateCommon.Back.ColorAngle = 45F;
            this.btnDesativarInsumo.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StateCommon.Border.ColorAngle = 45F;
            this.btnDesativarInsumo.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnDesativarInsumo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarInsumo.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesativarInsumo.StateCommon.Border.Rounding = 40;
            this.btnDesativarInsumo.StateCommon.Border.Width = 2;
            this.btnDesativarInsumo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnDesativarInsumo.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnDesativarInsumo.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnDesativarInsumo.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDesativarInsumo.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarInsumo.StatePressed.Back.ColorAngle = 135F;
            this.btnDesativarInsumo.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarInsumo.StatePressed.Border.Rounding = 40;
            this.btnDesativarInsumo.StatePressed.Border.Width = 2;
            this.btnDesativarInsumo.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnDesativarInsumo.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnDesativarInsumo.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesativarInsumo.StateTracking.Back.ColorAngle = -45F;
            this.btnDesativarInsumo.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesativarInsumo.StateTracking.Border.ColorAngle = 45F;
            this.btnDesativarInsumo.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesativarInsumo.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesativarInsumo.StateTracking.Border.Rounding = 40;
            this.btnDesativarInsumo.StateTracking.Border.Width = 2;
            this.btnDesativarInsumo.TabIndex = 36;
            this.btnDesativarInsumo.Values.Text = "Desativar Insumo";
            this.btnDesativarInsumo.Click += new System.EventHandler(this.btnDesativarInsumo_Click);
            // 
            // btnEditarFornecedor
            // 
            this.btnEditarFornecedor.Location = new System.Drawing.Point(261, 116);
            this.btnEditarFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarFornecedor.Name = "btnEditarFornecedor";
            this.btnEditarFornecedor.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnEditarFornecedor.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarFornecedor.OverrideDefault.Back.ColorAngle = 45F;
            this.btnEditarFornecedor.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.OverrideDefault.Border.ColorAngle = 45F;
            this.btnEditarFornecedor.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditarFornecedor.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditarFornecedor.OverrideDefault.Border.Rounding = 40;
            this.btnEditarFornecedor.OverrideDefault.Border.Width = 2;
            this.btnEditarFornecedor.Size = new System.Drawing.Size(174, 64);
            this.btnEditarFornecedor.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnEditarFornecedor.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarFornecedor.StateCommon.Back.ColorAngle = 45F;
            this.btnEditarFornecedor.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StateCommon.Border.ColorAngle = 45F;
            this.btnEditarFornecedor.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnEditarFornecedor.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditarFornecedor.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditarFornecedor.StateCommon.Border.Rounding = 40;
            this.btnEditarFornecedor.StateCommon.Border.Width = 2;
            this.btnEditarFornecedor.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnEditarFornecedor.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnEditarFornecedor.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnEditarFornecedor.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEditarFornecedor.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarFornecedor.StatePressed.Back.ColorAngle = 135F;
            this.btnEditarFornecedor.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditarFornecedor.StatePressed.Border.Rounding = 40;
            this.btnEditarFornecedor.StatePressed.Border.Width = 2;
            this.btnEditarFornecedor.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnEditarFornecedor.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnEditarFornecedor.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarFornecedor.StateTracking.Back.ColorAngle = -45F;
            this.btnEditarFornecedor.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarFornecedor.StateTracking.Border.ColorAngle = 45F;
            this.btnEditarFornecedor.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditarFornecedor.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditarFornecedor.StateTracking.Border.Rounding = 40;
            this.btnEditarFornecedor.StateTracking.Border.Width = 2;
            this.btnEditarFornecedor.TabIndex = 35;
            this.btnEditarFornecedor.Values.Text = "Editar Fornecedor";
            this.btnEditarFornecedor.Click += new System.EventHandler(this.btnEditarFornecedor_Click);
            // 
            // btnEditarInsumo
            // 
            this.btnEditarInsumo.Location = new System.Drawing.Point(85, 116);
            this.btnEditarInsumo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarInsumo.Name = "btnEditarInsumo";
            this.btnEditarInsumo.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnEditarInsumo.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarInsumo.OverrideDefault.Back.ColorAngle = 45F;
            this.btnEditarInsumo.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarInsumo.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarInsumo.OverrideDefault.Border.ColorAngle = 45F;
            this.btnEditarInsumo.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnEditarInsumo.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditarInsumo.OverrideDefault.Border.Rounding = 40;
            this.btnEditarInsumo.OverrideDefault.Border.Width = 2;
            this.btnEditarInsumo.Size = new System.Drawing.Size(174, 64);
            this.btnEditarInsumo.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnEditarInsumo.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarInsumo.StateCommon.Back.ColorAngle = 45F;
            this.btnEditarInsumo.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StateCommon.Border.ColorAngle = 45F;
            this.btnEditarInsumo.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnEditarInsumo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnEditarInsumo.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditarInsumo.StateCommon.Border.Rounding = 40;
            this.btnEditarInsumo.StateCommon.Border.Width = 2;
            this.btnEditarInsumo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnEditarInsumo.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnEditarInsumo.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnEditarInsumo.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEditarInsumo.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarInsumo.StatePressed.Back.ColorAngle = 135F;
            this.btnEditarInsumo.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnEditarInsumo.StatePressed.Border.Rounding = 40;
            this.btnEditarInsumo.StatePressed.Border.Width = 2;
            this.btnEditarInsumo.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnEditarInsumo.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnEditarInsumo.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditarInsumo.StateTracking.Back.ColorAngle = -45F;
            this.btnEditarInsumo.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditarInsumo.StateTracking.Border.ColorAngle = 45F;
            this.btnEditarInsumo.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnEditarInsumo.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditarInsumo.StateTracking.Border.Rounding = 40;
            this.btnEditarInsumo.StateTracking.Border.Width = 2;
            this.btnEditarInsumo.TabIndex = 34;
            this.btnEditarInsumo.Values.Text = "Editar Insumo";
            this.btnEditarInsumo.Click += new System.EventHandler(this.btnEditarInsumo_Click);
            // 
            // btnCadastrarFornecedor
            // 
            this.btnCadastrarFornecedor.Location = new System.Drawing.Point(261, 24);
            this.btnCadastrarFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastrarFornecedor.Name = "btnCadastrarFornecedor";
            this.btnCadastrarFornecedor.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrarFornecedor.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarFornecedor.OverrideDefault.Back.ColorAngle = 45F;
            this.btnCadastrarFornecedor.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.OverrideDefault.Border.ColorAngle = 45F;
            this.btnCadastrarFornecedor.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrarFornecedor.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrarFornecedor.OverrideDefault.Border.Rounding = 40;
            this.btnCadastrarFornecedor.OverrideDefault.Border.Width = 2;
            this.btnCadastrarFornecedor.Size = new System.Drawing.Size(174, 64);
            this.btnCadastrarFornecedor.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrarFornecedor.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarFornecedor.StateCommon.Back.ColorAngle = 45F;
            this.btnCadastrarFornecedor.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StateCommon.Border.ColorAngle = 45F;
            this.btnCadastrarFornecedor.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnCadastrarFornecedor.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrarFornecedor.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrarFornecedor.StateCommon.Border.Rounding = 40;
            this.btnCadastrarFornecedor.StateCommon.Border.Width = 2;
            this.btnCadastrarFornecedor.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnCadastrarFornecedor.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnCadastrarFornecedor.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnCadastrarFornecedor.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCadastrarFornecedor.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarFornecedor.StatePressed.Back.ColorAngle = 135F;
            this.btnCadastrarFornecedor.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrarFornecedor.StatePressed.Border.Rounding = 40;
            this.btnCadastrarFornecedor.StatePressed.Border.Width = 2;
            this.btnCadastrarFornecedor.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnCadastrarFornecedor.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrarFornecedor.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarFornecedor.StateTracking.Back.ColorAngle = -45F;
            this.btnCadastrarFornecedor.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarFornecedor.StateTracking.Border.ColorAngle = 45F;
            this.btnCadastrarFornecedor.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrarFornecedor.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrarFornecedor.StateTracking.Border.Rounding = 40;
            this.btnCadastrarFornecedor.StateTracking.Border.Width = 2;
            this.btnCadastrarFornecedor.TabIndex = 33;
            this.btnCadastrarFornecedor.Values.Text = "Cadastrar Fornecedor";
            this.btnCadastrarFornecedor.Click += new System.EventHandler(this.btnCadastrarFornecedor_Click);
            // 
            // btnCriarGrafico
            // 
            this.btnCriarGrafico.Location = new System.Drawing.Point(158, 300);
            this.btnCriarGrafico.Margin = new System.Windows.Forms.Padding(4);
            this.btnCriarGrafico.Name = "btnCriarGrafico";
            this.btnCriarGrafico.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnCriarGrafico.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCriarGrafico.OverrideDefault.Back.ColorAngle = 45F;
            this.btnCriarGrafico.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnCriarGrafico.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnCriarGrafico.OverrideDefault.Border.ColorAngle = 45F;
            this.btnCriarGrafico.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCriarGrafico.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCriarGrafico.OverrideDefault.Border.Rounding = 40;
            this.btnCriarGrafico.OverrideDefault.Border.Width = 2;
            this.btnCriarGrafico.Size = new System.Drawing.Size(205, 64);
            this.btnCriarGrafico.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCriarGrafico.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCriarGrafico.StateCommon.Back.ColorAngle = 45F;
            this.btnCriarGrafico.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StateCommon.Border.ColorAngle = 45F;
            this.btnCriarGrafico.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnCriarGrafico.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCriarGrafico.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCriarGrafico.StateCommon.Border.Rounding = 40;
            this.btnCriarGrafico.StateCommon.Border.Width = 2;
            this.btnCriarGrafico.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCriarGrafico.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnCriarGrafico.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnCriarGrafico.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCriarGrafico.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCriarGrafico.StatePressed.Back.ColorAngle = 135F;
            this.btnCriarGrafico.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCriarGrafico.StatePressed.Border.Rounding = 40;
            this.btnCriarGrafico.StatePressed.Border.Width = 2;
            this.btnCriarGrafico.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.1F, System.Drawing.FontStyle.Bold);
            this.btnCriarGrafico.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnCriarGrafico.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCriarGrafico.StateTracking.Back.ColorAngle = -45F;
            this.btnCriarGrafico.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnCriarGrafico.StateTracking.Border.ColorAngle = 45F;
            this.btnCriarGrafico.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCriarGrafico.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCriarGrafico.StateTracking.Border.Rounding = 40;
            this.btnCriarGrafico.StateTracking.Border.Width = 2;
            this.btnCriarGrafico.TabIndex = 32;
            this.btnCriarGrafico.Values.Text = "Gráficos";
            this.btnCriarGrafico.Visible = false;
            this.btnCriarGrafico.Click += new System.EventHandler(this.btnCriarGrafico_Click);
            // 
            // btnCadastrarInsumo
            // 
            this.btnCadastrarInsumo.Location = new System.Drawing.Point(85, 24);
            this.btnCadastrarInsumo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastrarInsumo.Name = "btnCadastrarInsumo";
            this.btnCadastrarInsumo.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrarInsumo.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarInsumo.OverrideDefault.Back.ColorAngle = 45F;
            this.btnCadastrarInsumo.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.OverrideDefault.Border.ColorAngle = 45F;
            this.btnCadastrarInsumo.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnCadastrarInsumo.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrarInsumo.OverrideDefault.Border.Rounding = 40;
            this.btnCadastrarInsumo.OverrideDefault.Border.Width = 2;
            this.btnCadastrarInsumo.Size = new System.Drawing.Size(174, 64);
            this.btnCadastrarInsumo.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrarInsumo.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarInsumo.StateCommon.Back.ColorAngle = 45F;
            this.btnCadastrarInsumo.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StateCommon.Border.ColorAngle = 45F;
            this.btnCadastrarInsumo.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnCadastrarInsumo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnCadastrarInsumo.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrarInsumo.StateCommon.Border.Rounding = 40;
            this.btnCadastrarInsumo.StateCommon.Border.Width = 2;
            this.btnCadastrarInsumo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnCadastrarInsumo.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnCadastrarInsumo.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnCadastrarInsumo.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCadastrarInsumo.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarInsumo.StatePressed.Back.ColorAngle = 135F;
            this.btnCadastrarInsumo.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnCadastrarInsumo.StatePressed.Border.Rounding = 40;
            this.btnCadastrarInsumo.StatePressed.Border.Width = 2;
            this.btnCadastrarInsumo.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnCadastrarInsumo.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrarInsumo.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrarInsumo.StateTracking.Back.ColorAngle = -45F;
            this.btnCadastrarInsumo.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrarInsumo.StateTracking.Border.ColorAngle = 45F;
            this.btnCadastrarInsumo.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.btnCadastrarInsumo.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrarInsumo.StateTracking.Border.Rounding = 40;
            this.btnCadastrarInsumo.StateTracking.Border.Width = 2;
            this.btnCadastrarInsumo.TabIndex = 29;
            this.btnCadastrarInsumo.Values.Text = "Cadastrar Insumo";
            this.btnCadastrarInsumo.Click += new System.EventHandler(this.btnCadastrarInsumo_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(20, 703);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 50);
            this.panel4.TabIndex = 19;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(51, 41);
            this.kryptonTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(581, 40);
            this.kryptonTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.kryptonTextBox1.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.kryptonTextBox1.TabIndex = 19;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(20, 100);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(342, 40);
            this.panel10.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 40);
            this.label2.TabIndex = 27;
            this.label2.Text = "Insumos:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewInsumos
            // 
            this.dataGridViewInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInsumos.Location = new System.Drawing.Point(20, 140);
            this.dataGridViewInsumos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInsumos.Name = "dataGridViewInsumos";
            this.dataGridViewInsumos.RowHeadersWidth = 51;
            this.dataGridViewInsumos.RowTemplate.Height = 24;
            this.dataGridViewInsumos.Size = new System.Drawing.Size(342, 563);
            this.dataGridViewInsumos.TabIndex = 36;
            // 
            // FrmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.dataGridViewInsumos);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.Name = "FrmEstoque";
            this.ShowIcon = false;
            this.Text = "Hot Rolls Club";
            this.Load += new System.EventHandler(this.FrmEstoque_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbcFiltroInsumos)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInsumosDisp)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInsumos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPesquisaInsumos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCadastrarInsumo;
        private System.Windows.Forms.DataGridView dataGridViewInsumosDisp;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewInsumos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCriarGrafico;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kbcFiltroInsumos;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCadastrarFornecedor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDesativarFornecedor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDesativarInsumo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditarFornecedor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditarInsumo;
    }
}