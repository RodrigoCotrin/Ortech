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
using System.Data.SqlClient;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmCadastroFornecedores : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");

        private int _fornecedorID;

        public int FornecedorID
        {
            get { return _fornecedorID; }
            set { _fornecedorID = value; }
        }

        public FrmCadastroFornecedores()
        {
            InitializeComponent();
        }

        private void FrmCadastroFornecedores_Load(object sender, EventArgs e)
        {
            if (FornecedorID > 0)
            {
                CarregarDadosDoFornecedor(FornecedorID);
                lblNomeAcaoCF.Text = "Edição de Fornecedor";
            }
            else
            {
                lblNomeAcaoCF.Text = "Cadastro de Fornecedor";
            }

            FrmEstoque frmEstoque = (FrmEstoque)Application.OpenForms["FrmEstoque"];
            frmEstoque.BtnCadastrarInsumo.Enabled = false;
            frmEstoque.BtnCadastrarFornecedor.Enabled = false;
            frmEstoque.BtnEditarInsumo.Enabled = false;
            frmEstoque.BtnEditarFornecedor.Enabled = false;
            frmEstoque.BtnDesativarInsumo.Enabled = false;
            frmEstoque.BtnDesativarFornecedor.Enabled = false;
            frmEstoque.BtnCriarGrafico.Enabled = false;
        }

        private void FrmCadastroFornecedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmEstoque frmEstoque = (FrmEstoque)Application.OpenForms["FrmEstoque"];
            frmEstoque.BtnCadastrarInsumo.Enabled = true;
            frmEstoque.BtnCadastrarFornecedor.Enabled = true;
            frmEstoque.BtnEditarInsumo.Enabled = true;
            frmEstoque.BtnEditarFornecedor.Enabled = true;
            frmEstoque.BtnDesativarInsumo.Enabled = true;
            frmEstoque.BtnDesativarFornecedor.Enabled = true;
            frmEstoque.BtnCriarGrafico.Enabled = true;
            frmEstoque.CarregarDadosInsumos();
            frmEstoque.CarregarDadosAviso();
        }

        private void CarregarDadosDoFornecedor(int fornecedorID)
        {
            try
            {
                string query = "SELECT nome_fornecedor, telefone, email, endereco " +
                               "FROM Fornecedor " +
                               "WHERE id_fornecedor = @fornecedorID AND ativo = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@fornecedorID", fornecedorID)
                };

                DataTable dataTable = conexao.ExecutarConsultaParametros(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    txtNomeFornecedor.Text = row["nome_fornecedor"].ToString();
                    txtTelefoneFornec.Text = row["telefone"].ToString();
                    txtEmailFornecedor.Text = row["email"].ToString();
                    txtEnderecoFornec.Text = row["endereco"].ToString();
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do fornecedor: " + ex.Message);
            }
        }

        private void InserirFornecedor()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeFornecedor.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefoneFornec.Text) ||
                    string.IsNullOrWhiteSpace(txtEmailFornecedor.Text) ||
                    string.IsNullOrWhiteSpace(txtEnderecoFornec.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                string nomeFornecedor = txtNomeFornecedor.Text;
                string telefone = txtTelefoneFornec.Text;
                string email = txtEmailFornecedor.Text;
                string endereco = txtEnderecoFornec.Text;

                SqlParameter[] parametros =
                {
                    new SqlParameter("@nome_fornecedor", nomeFornecedor),
                    new SqlParameter("@telefone", telefone),
                    new SqlParameter("@email", email),
                    new SqlParameter("@endereco", endereco)
                };

                int linhasAfetadas = conexao.ExecutarComando("usp_InserirFornecedor", parametros);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Erro ao inserir fornecedor.");
                }
                else
                {
                    MessageBox.Show("Fornecedor inserido com sucesso!");
                    this.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Erro no SQL: " + sqlEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarFornecedor()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeFornecedor.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefoneFornec.Text) ||
                    string.IsNullOrWhiteSpace(txtEmailFornecedor.Text) ||
                    string.IsNullOrWhiteSpace(txtEnderecoFornec.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                string nomeFornecedor = txtNomeFornecedor.Text;
                string telefone = txtTelefoneFornec.Text;
                string email = txtEmailFornecedor.Text;
                string endereco = txtEnderecoFornec.Text;

                SqlParameter[] parametros =
                {
                    new SqlParameter("@FornecedorID", FornecedorID),
                    new SqlParameter("@nome_fornecedor", nomeFornecedor),
                    new SqlParameter("@telefone", telefone),
                    new SqlParameter("@email", email),
                    new SqlParameter("@endereco", endereco)
                };

                int linhasAfetadas = conexao.ExecutarComando("usp_AtualizarFornecedor", parametros);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Fornecedor atualizado com sucesso!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar fornecedor.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Erro no SQL: " + sqlEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblNomeAcaoCF.Text == "Cadastro de Fornecedor")
                {
                    InserirFornecedor();
                }
                else if (lblNomeAcaoCF.Text == "Edição de Fornecedor")
                {
                    AtualizarFornecedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtNomeFornecedor.Text = "Fornecedor C";
            txtEmailFornecedor.Text = "fornecedorc@gmail.com";
            txtEnderecoFornec.Text = "Rua C, 123";
            txtTelefoneFornec.Text = "11981234567";
        }
    }
}
