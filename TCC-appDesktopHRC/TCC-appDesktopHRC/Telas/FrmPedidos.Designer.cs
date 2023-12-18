namespace TCC_appDesktopHRC.Telas
{
    partial class FrmPedidos
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
            this.panelCima = new System.Windows.Forms.Panel();
            this.controleChegadaPedido = new System.Windows.Forms.Timer(this.components);
            this.chegadaPedido = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // panelCima
            // 
            this.panelCima.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCima.Location = new System.Drawing.Point(0, 0);
            this.panelCima.Margin = new System.Windows.Forms.Padding(2);
            this.panelCima.Name = "panelCima";
            this.panelCima.Size = new System.Drawing.Size(826, 100);
            this.panelCima.TabIndex = 4;
            // 
            // controleChegadaPedido
            // 
            this.controleChegadaPedido.Tick += new System.EventHandler(this.controleChegadaPedido_Tick);
            // 
            // chegadaPedido
            // 
            this.chegadaPedido.AutoScroll = true;
            this.chegadaPedido.AutoSize = true;
            this.chegadaPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chegadaPedido.ColumnCount = 7;
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.chegadaPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chegadaPedido.Location = new System.Drawing.Point(0, 100);
            this.chegadaPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chegadaPedido.Name = "chegadaPedido";
            this.chegadaPedido.RowCount = 4;
            this.chegadaPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.chegadaPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.chegadaPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.chegadaPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.chegadaPedido.Size = new System.Drawing.Size(826, 665);
            this.chegadaPedido.TabIndex = 5;
            // 
            // FrmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(826, 765);
            this.Controls.Add(this.chegadaPedido);
            this.Controls.Add(this.panelCima);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPedidos";
            this.ShowIcon = false;
            this.Text = "Hot Rolls Club";
            this.Load += new System.EventHandler(this.FrmPedidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelCima;
        private System.Windows.Forms.Timer controleChegadaPedido;
        private System.Windows.Forms.TableLayoutPanel chegadaPedido;
    }
}