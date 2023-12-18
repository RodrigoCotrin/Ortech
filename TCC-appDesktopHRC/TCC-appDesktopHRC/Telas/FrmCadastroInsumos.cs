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
using System.Globalization;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmCadastroInsumos : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        
        private int _insumoID;

        public int InsumoID
        {
            get { return _insumoID; }
            set { _insumoID = value; }
        }

        public FrmCadastroInsumos()
        {
            InitializeComponent();
            txtDataEntrada.Text = DateTime.Now.ToString("dd/MM/yyyy");
            PreencherComboFornecedor();
            PreencherComboUnidadeMedida();
        }

        private void FrmCadastroInsumos_Load(object sender, EventArgs e)
        {
            if (InsumoID > 0)
            {
                CarregarDadosDoInsumo(InsumoID);
                lblNomeAcaoCI.Text = "Edição de Insumo";
            }
            else
            {
                lblNomeAcaoCI.Text = "Cadastro de Insumo";
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

        private void FrmCadastroInsumos_FormClosed(object sender, FormClosedEventArgs e)
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

        private void CarregarDadosDoInsumo(int insumoID)
        {
            try
            {
                string query = "SELECT I.*, F.nome_fornecedor " +
                               "FROM Insumos AS I " +
                               "INNER JOIN Fornecedor AS F ON I.id_fornecedor = F.id_fornecedor " +
                               "WHERE I.id_insumo = @insumoID AND I.ativo = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@insumoID", insumoID)
                };

                DataTable dataTable = conexao.ExecutarConsultaParametros(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    txtNomeInsumo.Text = row["nome_insumo"].ToString();
                    txtDescricaoInsumo.Text = row["descricao"].ToString();
                    txtEstoque.Text = row["estoque"].ToString();
                    kbcFornecedor.Text = row["nome_fornecedor"].ToString();
                    kbcUnidadeMedida.Text = row["unidade_medida"].ToString();
                    txtDataEntrada.Text = FormatarData(row["data_entrada"].ToString());
                    txtDataValidade.Text = FormatarData(row["data_validade"].ToString());
                }
                else
                {
                    MessageBox.Show("Insumo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do insumo: " + ex.Message);
            }
        }

        private void PreencherComboFornecedor()
        {
            try
            {
                string query = "SELECT id_fornecedor, nome_fornecedor FROM Fornecedor WHERE ativo = 1";
                DataTable dataTable = conexao.ExecutarConsulta(query);

                kbcFornecedor.DisplayMember = "nome_fornecedor";
                kbcFornecedor.ValueMember = "id_fornecedor";
                kbcFornecedor.DataSource = dataTable;

                // Adicione um valor padrão, se necessário
                kbcFornecedor.SelectedIndex = -1; // Desseleciona qualquer item selecionado, ou defina para o valor desejado.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher combo de fornecedores: " + ex.Message);
            }
        }

        private void PreencherComboUnidadeMedida()
        {
            try
            {
                // Suponha que você tenha uma lista de unidades de medida. Aqui estão algumas unidades de exemplo.
                List<string> unidades = new List<string> { "Unidade", "Gramas" };

                kbcUnidadeMedida.DataSource = unidades;

                // Adicione um valor padrão, se necessário
                kbcUnidadeMedida.SelectedIndex = -1; // Define para a unidade padrão, ou defina para o valor desejado.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher combo de unidades de medida: " + ex.Message);
            }
        }

        private string FormatarData(string data)
        {
            if (DateTime.TryParse(data, out DateTime dataConvertida))
            {
                return dataConvertida.ToString("dd/MM/yyyy");
            }
            return data;
        }

        private string ConverterDataParaBanco(string data)
        {
            if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida))
            {
                return dataConvertida.ToString("dd-MM-yyyy");
            }

            throw new ArgumentException("Data inválida. Certifique-se de que está no formato dd/MM/yyyy.");
        }

        private string ConverterEstoqueParaBanco(string estoque)
        {
            // Remova todos os pontos do valor do estoque
            string estoqueLimpo = estoque.Replace(".", "");

            // Tente converter para decimal
            if (decimal.TryParse(estoqueLimpo, out decimal estoqueConvertido))
            {
                // Formate o valor como um número inteiro
                return estoqueConvertido.ToString("0");
            }

            throw new ArgumentException("Estoque inválido. Certifique-se de que está no formato correto.");
        }

        private void InserirInsumo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeInsumo.Text) ||
                    string.IsNullOrWhiteSpace(txtDescricaoInsumo.Text) ||
                    string.IsNullOrWhiteSpace(txtEstoque.Text) ||
                    kbcFornecedor.SelectedItem == null ||
                    kbcUnidadeMedida.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtDataEntrada.Text) ||
                    string.IsNullOrWhiteSpace(txtDataValidade.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                // Obtenha os valores dos campos do formulário
                string nomeInsumo = txtNomeInsumo.Text;
                string descricao = txtDescricaoInsumo.Text;

                if (!decimal.TryParse(txtEstoque.Text, out decimal estoque) || estoque < 0)
                {
                    MessageBox.Show("Estoque inválido. Certifique-se de que o estoque seja um número válido maior ou igual a zero.");
                    return;
                }

                if (!int.TryParse(kbcFornecedor.SelectedValue.ToString(), out int idFornecedor))
                {
                    MessageBox.Show("Fornecedor inválido. Selecione um fornecedor válido.");
                    return;
                }

                string unidadeMedida = kbcUnidadeMedida.SelectedItem.ToString();
                string dataEntrada = ConverterDataParaBanco(txtDataEntrada.Text);
                string dataValidade = ConverterDataParaBanco(txtDataValidade.Text);

                // Montar os parâmetros para a inserção
                SqlParameter[] parametros =
                {
                    new SqlParameter("@nome_insumo", nomeInsumo),
                    new SqlParameter("@descricao", descricao),
                    new SqlParameter("@estoque", estoque),
                    new SqlParameter("@id_fornecedor", idFornecedor),
                    new SqlParameter("@unidade_medida", unidadeMedida),
                    new SqlParameter("@data_entrada", dataEntrada),
                    new SqlParameter("@data_validade", dataValidade)
                };

                int linhasAfetadas = conexao.ExecutarComando("usp_InserirInsumo", parametros);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Erro ao inserir insumo.");
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Insumo inserido com sucesso!");
                }

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Erro no SQL: " + sqlEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarInsumo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeInsumo.Text) ||
                    string.IsNullOrWhiteSpace(txtDescricaoInsumo.Text) ||
                    string.IsNullOrWhiteSpace(txtEstoque.Text) ||
                    kbcFornecedor.SelectedItem == null ||
                    kbcUnidadeMedida.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtDataEntrada.Text) ||
                    string.IsNullOrWhiteSpace(txtDataValidade.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                string nomeInsumo = txtNomeInsumo.Text;
                string descricao = txtDescricaoInsumo.Text;
                decimal estoque = Convert.ToDecimal(txtEstoque.Text);
                int idFornecedor = Convert.ToInt32(kbcFornecedor.SelectedValue);
                string unidadeMedida = kbcUnidadeMedida.SelectedItem.ToString();
                DateTime dataEntrada = Convert.ToDateTime(txtDataEntrada.Text);
                DateTime dataValidade = Convert.ToDateTime(txtDataValidade.Text);

                SqlParameter[] parametros =
                {
                    new SqlParameter("@InsumoID", InsumoID),
                    new SqlParameter("@NomeInsumo", nomeInsumo),
                    new SqlParameter("@Descricao", descricao),
                    new SqlParameter("@Estoque", estoque),
                    new SqlParameter("@IdFornecedor", idFornecedor),
                    new SqlParameter("@UnidadeMedida", unidadeMedida),
                    new SqlParameter("@DataEntrada", dataEntrada),
                    new SqlParameter("@DataValidade", dataValidade)
                };

                int linhasAfetadas = conexao.ExecutarComando("usp_AtualizarInsumo", parametros);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Insumo atualizado com sucesso!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar insumo.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Erro no SQL: " + sqlEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AdicionarEstoque(decimal quantidade)
        {
            try
            {
                decimal estoqueAtual = Convert.ToDecimal(txtEstoque.Text);

                decimal novoEstoque = estoqueAtual + quantidade;

                txtEstoque.Text = novoEstoque.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Estoque inválido. Certifique-se de que o estoque seja um número válido.");
            }
        }

        private void SubtrairEstoque(decimal quantidade)
        {
            try
            {
                decimal estoqueAtual = Convert.ToDecimal(txtEstoque.Text);

                if (estoqueAtual >= quantidade)
                {
                    decimal novoEstoque = estoqueAtual - quantidade;

                    txtEstoque.Text = novoEstoque.ToString();
                }
                else
                {
                    MessageBox.Show("Não é possível subtrair a quantidade especificada. O estoque não pode ser negativo.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Estoque inválido. Certifique-se de que o estoque seja um número válido.");
            }
        }

        private void txtDataValidade_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDataEntrada.Text) && !string.IsNullOrWhiteSpace(txtDataValidade.Text))
            {
                if (DateTime.TryParseExact(txtDataEntrada.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataEntrada) &&
                    DateTime.TryParseExact(txtDataValidade.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataValidade))
                {
                    if (dataValidade < dataEntrada)
                    {
                        MessageBox.Show("A data de validade não pode ser anterior à data de entrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDataValidade.Focus();
                        txtDataValidade.Clear(); // Limpa o campo de data de validade
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblNomeAcaoCI.Text == "Cadastro de Insumo")
                {
                    InserirInsumo();
                }
                else if (lblNomeAcaoCI.Text == "Edição de Insumo")
                {
                    AtualizarInsumo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            if (kbcUnidadeMedida.Text == "Unidade")
            {
                AdicionarEstoque(100);
            }
            else if (kbcUnidadeMedida.Text == "Gramas")
            {
                AdicionarEstoque(1000);
            }
            else
            {
                MessageBox.Show("Unidade de medida desconhecida.");
            }
        }

        private void btnSubtrairEstoque_Click(object sender, EventArgs e)
        {
            if (kbcUnidadeMedida.Text == "Unidade")
            {
                SubtrairEstoque(100);
            }
            else if (kbcUnidadeMedida.Text == "Gramas")
            {
                SubtrairEstoque(1000);
            }
            else
            {
                MessageBox.Show("Unidade de medida desconhecida.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtDataValidade.Text = "04042024";
            txtDescricaoInsumo.Text = "Descrição do insumo teste";
            txtNomeInsumo.Text = "Insumo Teste";
        }
    }
}
