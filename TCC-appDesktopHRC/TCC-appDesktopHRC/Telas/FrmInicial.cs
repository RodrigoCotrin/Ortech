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
    public partial class FrmInicial : KryptonForm
    {
        private Control conteudoOriginal;

        public FrmInicial()
        {
            InitializeComponent();
        }

        private void FrmInicial_Load(object sender, EventArgs e)
        {
            conteudoOriginal = panelPrincipal.Controls[0];
        }

        public void AtualizarImagemFuncionario()
        {
            pictureBoxImgFunc.Image = FrmCadastroFuncionarios.ImagemFuncionarioAtt;
        }

        public void AtualizarNomeFuncionario()
        {
            lblNome.Text = FrmCadastroFuncionarios.NomeFuncionarioAtt;
        }

        public void SetInfosFunc(string nomeAcaoFunc)
        {
            lblNome.Text = nomeAcaoFunc;

            pictureBoxImgFunc.Image = FrmLogin.ImagemFuncionario;
        }

        public void TrocarFormulario(Form novoFormulario)
        {
            Form formularioAtual = null;

            if (panelPrincipal.Controls.Count > 0)
            {
                formularioAtual = panelPrincipal.Controls[0] as Form;
            }

            if (formularioAtual != null)
            {
                formularioAtual.Dispose();
            }

            novoFormulario.TopLevel = false;
            novoFormulario.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Clear(); // Limpar todos os controles antes de adicionar o novo formulário
            panelPrincipal.Controls.Add(novoFormulario);
            novoFormulario.Show();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            TrocarFormulario(new FrmPedidos());
            btnPedidos.Enabled = false;
            btnHistoricoPedidos.Enabled = true;
            btnFuncionarios.Enabled = true;
            btnReservas.Enabled = true;
            btnEstoque.Enabled = true;
            btnProdutos.Enabled = true;
            pictureBoxHRC.Enabled = true;
        }

        private void btnHistoricoPedidos_Click(object sender, EventArgs e)
        {
            TrocarFormulario(new FrmHistoricoPedidos());
            btnPedidos.Enabled = true;
            btnHistoricoPedidos.Enabled = false;
            btnFuncionarios.Enabled = true;
            btnReservas.Enabled = true;
            btnEstoque.Enabled = true;
            btnProdutos.Enabled = true;
            pictureBoxHRC.Enabled = true;
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            TrocarFormulario(new FrmFuncionarios());
            btnPedidos.Enabled = true;
            btnHistoricoPedidos.Enabled = true;
            btnFuncionarios.Enabled = false;
            btnReservas.Enabled = true;
            btnEstoque.Enabled = true;
            btnProdutos.Enabled = true;
            pictureBoxHRC.Enabled = true;
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            TrocarFormulario(new FrmReservas());
            btnPedidos.Enabled = true;
            btnHistoricoPedidos.Enabled = true;
            btnFuncionarios.Enabled = true;
            btnReservas.Enabled = false;
            btnEstoque.Enabled = true;
            btnProdutos.Enabled = true;
            pictureBoxHRC.Enabled = true;
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            TrocarFormulario(new FrmEstoque());
            btnPedidos.Enabled = true;
            btnHistoricoPedidos.Enabled = true;
            btnFuncionarios.Enabled = true;
            btnReservas.Enabled = true;
            btnEstoque.Enabled = false;
            btnProdutos.Enabled = true;
            pictureBoxHRC.Enabled = true;
        }

        private void btnPratos_Click(object sender, EventArgs e)
        {
            TrocarFormulario(new FrmProdutos());
            btnPedidos.Enabled = true;
            btnHistoricoPedidos.Enabled = true;
            btnFuncionarios.Enabled = true;
            btnReservas.Enabled = true;
            btnEstoque.Enabled = true;
            btnProdutos.Enabled = false;
            pictureBoxHRC.Enabled = true;
        }

        private void pictureBoxHRC_Click(object sender, EventArgs e)
        {
            btnPedidos.Enabled = true;
            btnHistoricoPedidos.Enabled = true;
            btnFuncionarios.Enabled = true;
            btnReservas.Enabled = true;
            btnEstoque.Enabled = true;
            btnProdutos.Enabled = true;
            pictureBoxHRC.Enabled = false;

            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(conteudoOriginal);
        }

        private void pictureBoxHRC_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBoxHRC_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void kryptonPanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSair_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        private void lblSair_MouseEnter(object sender, EventArgs e)
        {
            lblSair.Font = new Font(lblSair.Font, lblSair.Font.Style | FontStyle.Underline);
        }

        private void lblSair_MouseLeave(object sender, EventArgs e)
        {
            lblSair.Font = new Font(lblSair.Font, lblSair.Font.Style & ~FontStyle.Underline);
        }
    }
}
