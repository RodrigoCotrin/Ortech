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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Globalization;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmCadastroFuncionarios : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        DataTable dt;
        private string caminhoImagem = null;
        int posMAX = 0;
        int pos = 0;
        public static Image ImagemFuncionarioAtt { get; set; }
        public static String NomeFuncionarioAtt { get; set; }


        public int FuncionarioID { get; set; }

        public FrmCadastroFuncionarios()
        {
            //this.TopMost = true;
            InitializeComponent();
        }

        private void FrmCadastroFuncionarios_Load(object sender, EventArgs e)
        {
            if (FuncionarioID > 0)
            {
                CarregarDadosDoFuncionario(FuncionarioID);
                lblNomeAcao.Text = "Edição de Funcionários";
            }
            else
            {
                lblNomeAcao.Text = "Cadastro de Funcionários";
            }

            FrmFuncionarios frmFunc = (FrmFuncionarios)Application.OpenForms["FrmFuncionarios"];
            frmFunc.BtnCadastrar.Enabled = false;
            frmFunc.BtnEditar.Enabled = false;

            AdicionarItensComboBox();

        }

        private void FrmCadastroFuncionarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmFuncionarios frmFunc = (FrmFuncionarios)Application.OpenForms["FrmFuncionarios"];
            frmFunc.BtnCadastrar.Enabled = true;
            frmFunc.BtnEditar.Enabled = true;
            frmFunc.CarregarDados();
        }

        private void AtualizarImagemFuncNoFrmInicial()
        {
            FrmInicial frmInicial = (FrmInicial)Application.OpenForms["FrmInicial"];
            if (frmInicial != null)
            {
                frmInicial.AtualizarImagemFuncionario();
            }
        }

        private void AtualizaNomeFuncNoFrmInicial()
        {
            FrmInicial frmInicial = (FrmInicial)Application.OpenForms["FrmInicial"];
            if (frmInicial != null)
            {
                frmInicial.AtualizarNomeFuncionario();
            }
        }

        private void AdicionarItensComboBox()
        {
            kbcSexo.Items.Add("F");
            kbcSexo.Items.Add("M");

            kbcCargo.Items.Add("Atendente");
            kbcCargo.Items.Add("Administrador");
            kbcCargo.Items.Add("Cozinheiro");

            kbcTurno.Items.Add("Diurno");
            kbcTurno.Items.Add("Noturno");
        }



        private void CarregarDadosDoFuncionario(int funcionarioID)
        {
            try
            {
                string query = "SELECT * FROM Funcionario WHERE id_funcionario = @funcionarioID AND ativo = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@funcionarioID", funcionarioID)
                };

                DataTable dataTable = conexao.ExecutarConsultaParametros(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    txtNome.Text = row["nome"].ToString();
                    txtTelefone.Text = row["telefone"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    txtSalario.Text = row["salario"].ToString();
                    txtEndereco.Text = row["endereco"].ToString();
                    txtCEP.Text = row["CEP"].ToString();
                    txtCPF.Text = FormatarCPF(row["cpf"].ToString());
                    txtDataNascimento.Text = FormatarData(row["data_nascimento"].ToString());
                    txtSenha.Text = row["senha"].ToString();
                    txtDataContratacao.Text = FormatarData(row["data_contratacao"].ToString());

                    if (row["img_func"] != DBNull.Value)
                    {
                        byte[] imagemBytes = (byte[])row["img_func"];
                        using (MemoryStream ms = new MemoryStream(imagemBytes))
                        {
                            pictureBoxImgFunc.Image = Image.FromStream(ms);
                        }
                    }

                    AdicionarItensComboBox();

                    DefinirValoresSelecionadosComboBoxes(row);
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do funcionário: " + ex.Message);
            }
        }

        private void DefinirValoresSelecionadosComboBoxes(DataRow row)
        {
            kbcCargo.Text = row["cargo"].ToString();
            kbcTurno.Text = row["turno"].ToString();
            kbcSexo.Text = row["sexo"].ToString();
        }

        private string FormatarData(string data)
        {
            if (DateTime.TryParse(data, out DateTime dataConvertida))
            {
                return dataConvertida.ToString("dd/MM/yyyy");
            }
            return data;
        }

        private string FormatarCPF(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Length == 11)
            {
                return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
            return cpf;
        }

        private string ConverterDataParaBanco(string data)
        {
            if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida))
            {
                return dataConvertida.ToString("dd-MM-yyyy");
            }

            throw new ArgumentException("Data inválida. Certifique-se de que está no formato dd/MM/yyyy.");
        }

        private string ConverterSalarioParaBanco(string salario)
        {
            // Remova o "R$" e os caracteres de formatação (pontos e vírgulas)
            string salarioLimpo = salario.Replace("R$", "").Replace(".", "").Replace(",", ".");

            // Tente converter para decimal
            if (decimal.TryParse(salarioLimpo, out decimal salarioConvertido))
            {
                // Formate o valor com duas casas decimais e retorne
                return salarioConvertido.ToString("0.00");
            }

            throw new ArgumentException("Salário inválido. Certifique-se de que está no formato correto.");
        }

        private string ConverterCpfParaBanco(string cpf)
        {
            string cpfLimpo = cpf.Replace(".", "").Replace("-", "");

            if (cpfLimpo.Length == 11)
            {
                return cpfLimpo;
            }

            throw new ArgumentException("CPF inválido. Certifique-se de que está no formato correto.");
        }

        private void InserirFuncionario()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCPF.Text) ||
                    string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                    kbcSexo.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtDataNascimento.Text) ||
                    string.IsNullOrWhiteSpace(txtCEP.Text) ||
                    string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text) ||
                    string.IsNullOrWhiteSpace(txtDataContratacao.Text) ||
                    kbcCargo.SelectedItem == null ||
                    kbcTurno.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                string cpf = ConverterCpfParaBanco(txtCPF.Text);
                string nome = txtNome.Text;
                string telefone = txtTelefone.Text;
                string sexo = kbcSexo.SelectedItem.ToString();
                string dataNascimento = ConverterDataParaBanco(txtDataNascimento.Text);
                string salario = ConverterSalarioParaBanco(txtSalario.Text);
                string cep = txtCEP.Text;
                string endereco = txtEndereco.Text;
                string email = txtEmail.Text;
                string senha = txtSenha.Text;
                string dataContratacao = ConverterDataParaBanco(txtDataContratacao.Text);
                string cargo = kbcCargo.SelectedItem.ToString();
                string turno = kbcTurno.SelectedItem.ToString();

                byte[] imagemBytes = null;
                if (!string.IsNullOrEmpty(caminhoImagem))
                {
                    imagemBytes = File.ReadAllBytes(caminhoImagem);
                }


                SqlParameter[] parametros =
                {
                    new SqlParameter("@cpf", cpf),
                    new SqlParameter("@nome", nome),
                    new SqlParameter("@telefone", telefone),
                    new SqlParameter("@sexo", sexo),
                    new SqlParameter("@dataNascimento", dataNascimento),
                    new SqlParameter("@cep", cep),
                    new SqlParameter("@endereco", endereco),
                    new SqlParameter("@email", email),
                    new SqlParameter("@senha", senha),
                    new SqlParameter("@dataContratacao", dataContratacao),
                    new SqlParameter("@cargo", cargo),
                    new SqlParameter("@turno", turno),
                    new SqlParameter("@salario", salario),
                    new SqlParameter("@img_func", imagemBytes)
                };

                int linhasAfetadas = conexao.ExecutarComando("usp_InserirFuncionario", parametros);

                if (linhasAfetadas > 0)
                {
                    this.Close();
                    MessageBox.Show("Funcionário inserido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao inserir funcionário.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao inserir funcionário: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir funcionário: " + ex.Message);
            }
        }

        private void AtualizarFuncionario()
        {
            try
            {
                // Valide se algum campo obrigatório está em branco
                if (string.IsNullOrWhiteSpace(txtCPF.Text) ||
                    string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                    kbcSexo.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtDataNascimento.Text) ||
                    string.IsNullOrWhiteSpace(txtCEP.Text) ||
                    string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text) ||
                    string.IsNullOrWhiteSpace(txtDataContratacao.Text) ||
                    kbcCargo.SelectedItem == null ||
                    kbcTurno.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                // Obtenha os valores dos campos do formulário
                string cpf = ConverterCpfParaBanco(txtCPF.Text);
                string nome = txtNome.Text;
                string telefone = txtTelefone.Text;
                string sexo = kbcSexo.SelectedItem.ToString();
                string dataNascimento = ConverterDataParaBanco(txtDataNascimento.Text);
                string salario = ConverterSalarioParaBanco(txtSalario.Text);
                string cep = txtCEP.Text;
                string endereco = txtEndereco.Text;
                string email = txtEmail.Text;
                string senha = txtSenha.Text;
                string dataContratacao = ConverterDataParaBanco(txtDataContratacao.Text);
                string cargo = kbcCargo.SelectedItem.ToString();
                string turno = kbcTurno.SelectedItem.ToString();

                // Monta a consulta SQL de atualização com parâmetros
                string query = $"UPDATE Funcionario SET " +
                               $"CPF = @cpf, " +
                               $"nome = @nome, " +
                               $"telefone = @telefone, " +
                               $"sexo = @sexo, " +
                               $"data_nascimento = @dataNascimento, " +
                               $"CEP = @cep, " +
                               $"endereco = @endereco, " +
                               $"email = @email, " +
                               $"senha = @senha, " +
                               $"data_contratacao = @dataContratacao, " +
                               $"cargo = @cargo, " +
                               $"turno = @turno, " +
                               $"salario = @salario, " +
                               $"img_func = @img_func " +
                               $"WHERE ID_Funcionario = @id_funcionario";

                byte[] imagemBytes = null;
                if (!string.IsNullOrEmpty(caminhoImagem))
                {
                    imagemBytes = File.ReadAllBytes(caminhoImagem);
                }

                // Crie uma instância de SqlParameter para os parâmetros de atualização
                SqlParameter[] parametros =
                {
                    new SqlParameter("@cpf", SqlDbType.NVarChar) { Value = cpf },
                    new SqlParameter("@nome", SqlDbType.NVarChar) { Value = nome },
                    new SqlParameter("@telefone", telefone),
                    new SqlParameter("@sexo", sexo),
                    new SqlParameter("@dataNascimento", dataNascimento),
                    new SqlParameter("@cep", cep),
                    new SqlParameter("@endereco", endereco),
                    new SqlParameter("@email", email),
                    new SqlParameter("@senha", senha),
                    new SqlParameter("@dataContratacao", dataContratacao),
                    new SqlParameter("@cargo", cargo),
                    new SqlParameter("@turno", turno),
                    new SqlParameter("@salario", salario),
                    new SqlParameter("@id_funcionario", FuncionarioID),
                    new SqlParameter("@img_func", SqlDbType.VarBinary) { Value = imagemBytes ?? (object)DBNull.Value }
                };

                int linhasAfetadas = conexao.ExecutarComandoComImagem(query, parametros);

                if (linhasAfetadas > 0)
                {
                    this.Close();
                    MessageBox.Show("Funcionário atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar funcionário.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao atualizar funcionário: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar funcionário: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            // Limpa todos os campos do formulário após a inserção
            txtCPF.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            kbcSexo.SelectedIndex = -1;
            txtDataNascimento.Clear();
            txtCEP.Clear();
            txtEndereco.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtDataContratacao.Clear();
            kbcCargo.SelectedIndex = -1;
            kbcTurno.SelectedIndex = -1;
            txtSalario.Clear();
            pictureBoxImgFunc.Image = null; // Limpa a imagem
            caminhoImagem = null; // Limpa o caminho da imagem
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblNomeAcao.Text == "Cadastro de Funcionários")
                {
                    InserirFuncionario();
                }
                else if (lblNomeAcao.Text == "Edição de Funcionários")
                {
                    AtualizarFuncionario();

                    if (FuncionarioID > 0)
                    {
                        string queryInfosFunc = "SELECT nome, img_func FROM Funcionario WHERE id_funcionario = @funcionarioID";
                        SqlParameter[] parametrosConsulta = new SqlParameter[]
                        {
                            new SqlParameter("@funcionarioID", FuncionarioID)
                        };

                        DataTable dtInfosFunc = conexao.ExecutarConsultaParametros(queryInfosFunc, parametrosConsulta);

                        if (dtInfosFunc.Rows.Count > 0)
                        {
                            DataRow row = dtInfosFunc.Rows[0];

                            if (row["img_func"] != DBNull.Value)
                            {
                                byte[] imagemBytes = (byte[])row["img_func"];
                                using (MemoryStream ms = new MemoryStream(imagemBytes))
                                {
                                    ImagemFuncionarioAtt = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                ImagemFuncionarioAtt = Properties.Resources.ImagemAusente;
                            }

                            if (row["nome"] != DBNull.Value)
                            {
                                NomeFuncionarioAtt = row["nome"].ToString();
                            }
                            else
                            {
                                NomeFuncionarioAtt = string.Empty;
                            }
                        }
                    }

                }
                AtualizarImagemFuncNoFrmInicial();
                AtualizaNomeFuncNoFrmInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarCEP_Click(object sender, EventArgs e)
        {
            string pesquisaCEP = txtCEP.Text;

            if (pesquisaCEP.Length == 9)
            {
                string cep = txtCEP.Text.Trim().Replace("-", "");

                if (string.IsNullOrEmpty(cep))
                {
                    txtEndereco.Clear();
                    return;
                }

                try
                {
                    string url = $"https://viacep.com.br/ws/{cep}/json/";
                    WebClient client = new WebClient();
                    string json = client.DownloadString(url);

                    // Faz o parsing do JSON para um objeto dynamic
                    dynamic endereco = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                    if (endereco.erro != null)
                    {
                        txtEndereco.Clear();
                    }
                    else
                    {
                        string logradouro = endereco.logradouro;
                        string bairro = endereco.bairro;
                        string cidade = endereco.localidade;
                        string uf = endereco.uf;

                        string enderecoCompleto = $"{logradouro}, {bairro}, {cidade} - {uf}";

                        byte[] bytes = Encoding.Default.GetBytes(enderecoCompleto);
                        enderecoCompleto = Encoding.UTF8.GetString(bytes);

                        txtEndereco.Text = enderecoCompleto;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao consultar o CEP: " + ex.Message);
                }
            }
        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = openFileDialog.FileName;
                pictureBoxImgFunc.Image = Image.FromFile(caminhoImagem);
            }
        }

        private void panelModFuncionarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtNome.Text = "João Souza";
            txtTelefone.Text = "11912345678";
            txtEmail.Text = "joao.souza@gmail.com";
            txtSalario.Text = "200000";
            txtCEP.Text = "01101010";
            txtCPF.Text = "11122233344";
            txtDataNascimento.Text = "10051995";
            txtSenha.Text = "15519889";
            txtDataContratacao.Text = "05122023";
        }
    }
}