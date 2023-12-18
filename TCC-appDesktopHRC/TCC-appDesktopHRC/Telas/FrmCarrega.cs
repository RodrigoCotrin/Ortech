using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmCarrega : KryptonForm
    {
        public FrmCarrega()
        {
            InitializeComponent();
        }

        private void FrmCarrega_Load(object sender, EventArgs e)
        {
            // Configurações iniciais do formulário
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // Adicione um Label para exibir a mensagem de carregamento
            Label lblLoading = new Label();
            lblLoading.Text = "Carregando...";
            lblLoading.Font = new Font("Arial", 12, FontStyle.Bold);
            lblLoading.ForeColor = Color.Black;
            lblLoading.AutoSize = true;
            lblLoading.Location = new Point((this.Width - lblLoading.Width) / 2, (this.Height - lblLoading.Height) / 2);

            // Adicione um ProgressBar para mostrar o progresso (opcional)
            ProgressBar progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Width = 200;
            progressBar.Height = 30;
            progressBar.Location = new Point((this.Width - progressBar.Width) / 2, lblLoading.Bottom + 10);

            // Adicione os controles ao formulário
            this.Controls.Add(lblLoading);
            this.Controls.Add(progressBar);
        }
    }
}
