namespace TCC_appDesktopHRC.Telas
{
    partial class FrmHistoricoPedidos
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
            this.panelCima = new System.Windows.Forms.Panel();
            this.historicoPedido = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // panelCima
            // 
            this.panelCima.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCima.Location = new System.Drawing.Point(0, 0);
            this.panelCima.Margin = new System.Windows.Forms.Padding(2);
            this.panelCima.Name = "panelCima";
            this.panelCima.Size = new System.Drawing.Size(882, 100);
            this.panelCima.TabIndex = 5;
            // 
            // historicoPedido
            // 
            this.historicoPedido.AutoScroll = true;
            this.historicoPedido.AutoSize = true;
            this.historicoPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.historicoPedido.ColumnCount = 7;
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.historicoPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historicoPedido.Location = new System.Drawing.Point(0, 100);
            this.historicoPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historicoPedido.Name = "historicoPedido";
            this.historicoPedido.RowCount = 9;
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.historicoPedido.Size = new System.Drawing.Size(882, 652);
            this.historicoPedido.TabIndex = 6;
            // 
            // FrmHistoricoPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 752);
            this.Controls.Add(this.historicoPedido);
            this.Controls.Add(this.panelCima);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmHistoricoPedidos";
            this.ShowIcon = false;
            this.Text = "Hot Rolls Club";
            this.Load += new System.EventHandler(this.FrmHistoricoPedidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCima;
        private System.Windows.Forms.TableLayoutPanel historicoPedido;
    }
}