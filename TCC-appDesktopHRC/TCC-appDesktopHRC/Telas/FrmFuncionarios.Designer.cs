namespace TCC_appDesktopHRC.Telas
{
    partial class FrmFuncionarios
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
            this.panelFuncionarios = new System.Windows.Forms.Panel();
            this.dataGridViewFuncionarios = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDesabilitar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEditar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCadastrar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisa = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panelFuncionarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuncionarios)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFuncionarios
            // 
            this.panelFuncionarios.BackColor = System.Drawing.Color.White;
            this.panelFuncionarios.Controls.Add(this.dataGridViewFuncionarios);
            this.panelFuncionarios.Controls.Add(this.panel4);
            this.panelFuncionarios.Controls.Add(this.panel3);
            this.panelFuncionarios.Controls.Add(this.panel2);
            this.panelFuncionarios.Controls.Add(this.panel1);
            this.panelFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFuncionarios.Location = new System.Drawing.Point(0, 0);
            this.panelFuncionarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFuncionarios.Name = "panelFuncionarios";
            this.panelFuncionarios.Size = new System.Drawing.Size(883, 753);
            this.panelFuncionarios.TabIndex = 0;
            // 
            // dataGridViewFuncionarios
            // 
            this.dataGridViewFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFuncionarios.Location = new System.Drawing.Point(51, 100);
            this.dataGridViewFuncionarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewFuncionarios.Name = "dataGridViewFuncionarios";
            this.dataGridViewFuncionarios.RowHeadersWidth = 51;
            this.dataGridViewFuncionarios.RowTemplate.Height = 24;
            this.dataGridViewFuncionarios.Size = new System.Drawing.Size(581, 603);
            this.dataGridViewFuncionarios.TabIndex = 15;
            this.dataGridViewFuncionarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewFuncionarios_CellFormatting);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(51, 703);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(581, 50);
            this.panel4.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDesabilitar);
            this.panel3.Controls.Add(this.btnEditar);
            this.panel3.Controls.Add(this.btnCadastrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(632, 100);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 653);
            this.panel3.TabIndex = 13;
            // 
            // btnDesabilitar
            // 
            this.btnDesabilitar.Location = new System.Drawing.Point(21, 206);
            this.btnDesabilitar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesabilitar.Name = "btnDesabilitar";
            this.btnDesabilitar.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnDesabilitar.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesabilitar.OverrideDefault.Back.ColorAngle = 45F;
            this.btnDesabilitar.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesabilitar.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesabilitar.OverrideDefault.Border.ColorAngle = 45F;
            this.btnDesabilitar.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesabilitar.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesabilitar.OverrideDefault.Border.Rounding = 40;
            this.btnDesabilitar.OverrideDefault.Border.Width = 2;
            this.btnDesabilitar.Size = new System.Drawing.Size(205, 64);
            this.btnDesabilitar.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnDesabilitar.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesabilitar.StateCommon.Back.ColorAngle = 45F;
            this.btnDesabilitar.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesabilitar.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesabilitar.StateCommon.Border.ColorAngle = 45F;
            this.btnDesabilitar.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnDesabilitar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesabilitar.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesabilitar.StateCommon.Border.Rounding = 40;
            this.btnDesabilitar.StateCommon.Border.Width = 2;
            this.btnDesabilitar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDesabilitar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnDesabilitar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesabilitar.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDesabilitar.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesabilitar.StatePressed.Back.ColorAngle = 135F;
            this.btnDesabilitar.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesabilitar.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesabilitar.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesabilitar.StatePressed.Border.Rounding = 40;
            this.btnDesabilitar.StatePressed.Border.Width = 2;
            this.btnDesabilitar.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.1F, System.Drawing.FontStyle.Bold);
            this.btnDesabilitar.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnDesabilitar.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDesabilitar.StateTracking.Back.ColorAngle = -45F;
            this.btnDesabilitar.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnDesabilitar.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnDesabilitar.StateTracking.Border.ColorAngle = 45F;
            this.btnDesabilitar.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDesabilitar.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDesabilitar.StateTracking.Border.Rounding = 40;
            this.btnDesabilitar.StateTracking.Border.Width = 2;
            this.btnDesabilitar.TabIndex = 28;
            this.btnDesabilitar.Values.Text = "Desabilitar";
            this.btnDesabilitar.Click += new System.EventHandler(this.btnDesabilitar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(21, 117);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnEditar.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.OverrideDefault.Back.ColorAngle = 45F;
            this.btnEditar.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditar.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditar.OverrideDefault.Border.ColorAngle = 45F;
            this.btnEditar.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditar.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditar.OverrideDefault.Border.Rounding = 40;
            this.btnEditar.OverrideDefault.Border.Width = 2;
            this.btnEditar.Size = new System.Drawing.Size(205, 64);
            this.btnEditar.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnEditar.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.StateCommon.Back.ColorAngle = 45F;
            this.btnEditar.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditar.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditar.StateCommon.Border.ColorAngle = 45F;
            this.btnEditar.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnEditar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditar.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditar.StateCommon.Border.Rounding = 40;
            this.btnEditar.StateCommon.Border.Width = 2;
            this.btnEditar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnEditar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnEditar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnEditar.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnEditar.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEditar.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.StatePressed.Back.ColorAngle = 135F;
            this.btnEditar.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditar.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditar.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditar.StatePressed.Border.Rounding = 40;
            this.btnEditar.StatePressed.Border.Width = 2;
            this.btnEditar.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.1F, System.Drawing.FontStyle.Bold);
            this.btnEditar.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnEditar.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.StateTracking.Back.ColorAngle = -45F;
            this.btnEditar.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnEditar.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnEditar.StateTracking.Border.ColorAngle = 45F;
            this.btnEditar.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEditar.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEditar.StateTracking.Border.Rounding = 40;
            this.btnEditar.StateTracking.Border.Width = 2;
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Values.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(21, 28);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrar.OverrideDefault.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrar.OverrideDefault.Back.ColorAngle = 45F;
            this.btnCadastrar.OverrideDefault.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrar.OverrideDefault.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrar.OverrideDefault.Border.ColorAngle = 45F;
            this.btnCadastrar.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrar.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrar.OverrideDefault.Border.Rounding = 40;
            this.btnCadastrar.OverrideDefault.Border.Width = 2;
            this.btnCadastrar.Size = new System.Drawing.Size(205, 64);
            this.btnCadastrar.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrar.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrar.StateCommon.Back.ColorAngle = 45F;
            this.btnCadastrar.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrar.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrar.StateCommon.Border.ColorAngle = 45F;
            this.btnCadastrar.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.btnCadastrar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrar.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrar.StateCommon.Border.Rounding = 40;
            this.btnCadastrar.StateCommon.Border.Width = 2;
            this.btnCadastrar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnCadastrar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnCadastrar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCadastrar.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.btnCadastrar.StateDisabled.Back.Color2 = System.Drawing.Color.Silver;
            this.btnCadastrar.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCadastrar.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrar.StatePressed.Back.ColorAngle = 135F;
            this.btnCadastrar.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrar.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrar.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrar.StatePressed.Border.Rounding = 40;
            this.btnCadastrar.StatePressed.Border.Width = 2;
            this.btnCadastrar.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.1F, System.Drawing.FontStyle.Bold);
            this.btnCadastrar.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnCadastrar.StateTracking.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrar.StateTracking.Back.ColorAngle = -45F;
            this.btnCadastrar.StateTracking.Border.Color1 = System.Drawing.Color.Black;
            this.btnCadastrar.StateTracking.Border.Color2 = System.Drawing.Color.Black;
            this.btnCadastrar.StateTracking.Border.ColorAngle = 45F;
            this.btnCadastrar.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCadastrar.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCadastrar.StateTracking.Border.Rounding = 40;
            this.btnCadastrar.StateTracking.Border.Width = 2;
            this.btnCadastrar.TabIndex = 26;
            this.btnCadastrar.Values.Text = "Cadastrar";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 653);
            this.panel2.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPesquisa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 100);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "Pesquisa de funcionários:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(51, 41);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(581, 40);
            this.txtPesquisa.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtPesquisa.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.txtPesquisa.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.txtPesquisa.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPesquisa.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtPesquisa.StateCommon.Border.Rounding = 10;
            this.txtPesquisa.StateCommon.Content.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.txtPesquisa.TabIndex = 19;
            // 
            // FrmFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 753);
            this.Controls.Add(this.panelFuncionarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmFuncionarios";
            this.ShowIcon = false;
            this.Text = "Hot Rolls Club";
            this.Load += new System.EventHandler(this.FrmFuncionarios_Load);
            this.panelFuncionarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuncionarios)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFuncionarios;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDesabilitar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCadastrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPesquisa;
        private System.Windows.Forms.DataGridView dataGridViewFuncionarios;
    }
}