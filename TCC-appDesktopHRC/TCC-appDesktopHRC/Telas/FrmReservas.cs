using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmReservas : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; }
        public string CPFCliente { get; set; }
        public DateTime DataReserva { get; set; }
        public string HoraReserva { get; set; }
        public string ResumoMesa { get; set; }
        public int QuantidadePessoas { get; set; }
        public FrmMesaReserva FormularioMesaReserva { get; set; }
        public FrmHistoricoMesa FormularioHistoricoMesa { get; set; }

        public FrmReservas()
        {
            InitializeComponent();
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {
            HabilitarDesabilitarControles(false);
        }

        public void LimparCamposReserva()
        {
            // Define as variáveis como vazias ou com valores padrão
            NomeCliente = string.Empty;
            CPFCliente = string.Empty;
            DataReserva = DateTime.MinValue;
            HoraReserva = string.Empty;
            ResumoMesa = string.Empty;
            QuantidadePessoas = 0;

            if (FormularioMesaReserva != null)
            {
                FormularioMesaReserva.NovoNomeCliente = string.Empty;
                FormularioMesaReserva.NovoCPFCliente = string.Empty;
                FormularioMesaReserva.NovaDataReserva = DateTime.MinValue;
                FormularioMesaReserva.NovaHoraReserva = string.Empty;
                FormularioMesaReserva.NovaQuantidadePessoas = 0;

                // Limpe os campos no formulário de reserva
                if (FormularioMesaReserva.TxtNomeDoCliente != null)
                    FormularioMesaReserva.TxtNomeDoCliente.Text = string.Empty;
                if (FormularioMesaReserva.TxtCPFdoCliente != null)
                    FormularioMesaReserva.TxtCPFdoCliente.Text = string.Empty;
                if (FormularioMesaReserva.TxtDataReserva != null)
                    FormularioMesaReserva.TxtDataReserva.Text = string.Empty;
                if (FormularioMesaReserva.KbcLugares != null)
                    FormularioMesaReserva.KbcLugares.Text = "";
                if (FormularioMesaReserva.KbcHora != null)
                    FormularioMesaReserva.KbcHora.Text = "";
                if (FormularioMesaReserva.LblResumoMesa != null)
                    FormularioMesaReserva.LblResumoMesa.Text = string.Empty;
            }
        }

        public void CarregarDadosReserva()
        {
            string query = "SELECT cpf, quantidade_pessoas, data_reserva FROM Reserva WHERE numero_mesa = @NumeroMesa AND ativo = 1";
            SqlParameter[] parametros = { new SqlParameter("@NumeroMesa", this.NumeroMesa) };

            DataTable resultado = conexao.ExecutarConsultaParametros(query, parametros);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];

                CPFCliente = row["cpf"].ToString();
                QuantidadePessoas = Convert.ToInt32(row["quantidade_pessoas"]);

                DateTime dataHoraReserva = Convert.ToDateTime(row["data_reserva"]);
                DataReserva = dataHoraReserva;

                // Extrair a hora da reserva a partir da data
                HoraReserva = dataHoraReserva.ToString("HH:mm");

                string queryNomeCliente = "SELECT nome FROM Cliente WHERE cpf = @CPF";
                SqlParameter[] parametrosNomeCliente = { new SqlParameter("@CPF", CPFCliente) };

                NomeCliente = conexao.ExecutarConsultaScalarG<string>(queryNomeCliente, parametrosNomeCliente);

                if (string.IsNullOrEmpty(NomeCliente))
                {
                    NomeCliente = "Nome não encontrado"; // Ou outra mensagem de erro apropriada
                }

                string textoResumo = $"Reserva da mesa {NumeroMesa} para {NomeCliente} em {DataReserva.ToString("dd/MM/yyyy")}, horário {HoraReserva} com {QuantidadePessoas} pessoas.";

                ResumoMesa = textoResumo;

            }
        }

        public void CarregarDadosReservaCliente(string cpfCliente)
        {
            string query = "SELECT numero_mesa, quantidade_pessoas, data_reserva FROM Reserva WHERE cpf = @CPF AND ativo = 1";
            SqlParameter[] parametros = { new SqlParameter("@CPF", cpfCliente) };

            DataTable resultado = conexao.ExecutarConsultaParametros(query, parametros);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];

                NumeroMesa = Convert.ToInt32(row["numero_mesa"]);
                QuantidadePessoas = Convert.ToInt32(row["quantidade_pessoas"]);
                DataReserva = Convert.ToDateTime(row["data_reserva"]);

                HoraReserva = DataReserva.ToString("HH:mm");

                string queryNomeCliente = "SELECT nome FROM Cliente WHERE cpf = @CPF";
                SqlParameter[] parametrosNomeCliente = { new SqlParameter("@CPF", cpfCliente) };

                NomeCliente = conexao.ExecutarConsultaScalarG<string>(queryNomeCliente, parametrosNomeCliente);

                if (string.IsNullOrEmpty(NomeCliente))
                {
                    NomeCliente = "Nome não encontrado";
                }

                string textoResumo = $"Reserva da mesa {NumeroMesa} para {NomeCliente} em {DataReserva.ToString("dd/MM/yyyy")}, horário {HoraReserva} com {QuantidadePessoas} pessoas.";

                ResumoMesa = textoResumo;
            }
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

        private void HabilitarDesabilitarControles(bool habilitar)
        {
            btnHistoricoMesa.Enabled = habilitar;
            btnEditarReserva.Enabled = habilitar;
            btnCancelarReserva.Enabled = habilitar;
            lblVoltar.Enabled = habilitar;
        }

        private void TrocarFormulario(Form novoFormulario)
        {
            Form formularioAtual = null;

            if (panelMesas.Controls.Count > 0)
            {
                formularioAtual = panelMesas.Controls[0] as Form;
            }

            if (formularioAtual != null)
            {
                formularioAtual.Dispose();
            }

            novoFormulario.TopLevel = false;
            novoFormulario.Dock = DockStyle.Fill;
            panelMesas.Controls.Clear();
            panelMesas.Controls.Add(novoFormulario);
            novoFormulario.Show();
        }

        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (NumeroMesa > 0)
            {
                if (FormularioMesaReserva != null)
                {
                    // Obtenha os dados atualizados do formulário
                    string novoNomeCliente = FormularioMesaReserva.NovoNomeCliente;
                    string novoCPFCliente = ConverterCpfParaBanco(FormularioMesaReserva.NovoCPFCliente);
                    DateTime novaDataReserva = FormularioMesaReserva.NovaDataReserva;
                    string novaHoraReserva = FormularioMesaReserva.NovaHoraReserva;
                    int novaQuantidadePessoas = FormularioMesaReserva.NovaQuantidadePessoas;

                    // Combine a data e a hora em um único valor de data/hora
                    DateTime novaDataHoraReserva = novaDataReserva.Date + TimeSpan.Parse(novaHoraReserva);

                    // Crie os parâmetros da procedure
                    SqlParameter[] parametros =
                    {
                        new SqlParameter("@CPFCliente", SqlDbType.VarChar, 20) { Value = novoCPFCliente },
                        new SqlParameter("@NomeCliente", SqlDbType.VarChar, 100) { Value = novoNomeCliente },
                        new SqlParameter("@NumeroMesa", SqlDbType.Int) { Value = NumeroMesa },
                        new SqlParameter("@NovaDataHoraReserva", SqlDbType.DateTime) { Value = novaDataHoraReserva },
                        new SqlParameter("@NovaQuantidadePessoas", SqlDbType.Int) { Value = novaQuantidadePessoas }
                    };

                    try
                    {
                        // Execute a procedure no banco de dados
                        int linhasAfetadas = conexao.ExecutarComando("usp_AtualizarClienteEReserva", parametros);

                        if (linhasAfetadas > 0)
                        {
                            // Atualize os valores nas variáveis do formulário atual
                            NomeCliente = novoNomeCliente;
                            CPFCliente = novoCPFCliente;
                            DataReserva = novaDataReserva;
                            HoraReserva = novaHoraReserva;
                            QuantidadePessoas = novaQuantidadePessoas;

                            FormularioMesaReserva.PreencherDataGridViewProximasReservas(NumeroMesa);

                            // Selecione a primeira linha do DataGridView e acione o evento CellClick
                            if (FormularioMesaReserva.DataGridViewProximasReservas.Rows.Count > 0)
                            {
                                FormularioMesaReserva.DataGridViewProximasReservas.Rows[0].Selected = true;
                                FormularioMesaReserva.dataGridViewProximasReservas_CellClick(FormularioMesaReserva.DataGridViewProximasReservas, new DataGridViewCellEventArgs(0, 0));
                            }

                            MessageBox.Show("Reserva atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Nenhuma reserva foi atualizada. Verifique seus parâmetros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao atualizar a reserva: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Trate o caso em que o formulário FrmMesaReserva não está definido
                    MessageBox.Show("O formulário FrmMesaReserva não está disponível.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Trate o caso em que não há reserva selecionada
                MessageBox.Show("Selecione uma reserva antes de editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (FormularioMesaReserva != null && FormularioMesaReserva.DataGridViewProximasReservas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = FormularioMesaReserva.DataGridViewProximasReservas.SelectedRows[0];

                if (selectedRow != null)
                {
                    // Obtenha os valores da linha selecionada
                    string cpfCliente = selectedRow.Cells["cpf"].Value.ToString();
                    int numeroMesa = Convert.ToInt32(selectedRow.Cells["numero_mesa"].Value);
                    DateTime dataReserva = (DateTime)selectedRow.Cells["data_reserva"].Value;
                    string horaReserva = dataReserva.ToString("HH:mm"); // Suponho que a coluna "data_reserva" seja um DateTime

                    SqlParameter[] parametros =
                    {
                        new SqlParameter("@cpf", SqlDbType.VarChar, 11) { Value = cpfCliente },
                        new SqlParameter("@numero_mesa", SqlDbType.Int) { Value = numeroMesa },
                        new SqlParameter("@data_reserva", SqlDbType.DateTime) { Value = dataReserva }
                    };

                    try
                    {
                        int linhasAfetadas = conexao.ExecutarComando("usp_cancelar_reserva", parametros);

                        if (linhasAfetadas > 0)
                        {
                            FormularioMesaReserva.PreencherDataGridViewProximasReservas(numeroMesa);

                            MessageBox.Show("Reserva cancelada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma reserva foi cancelada. Verifique os dados da reserva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro ao cancelar a reserva: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao cancelar a reserva: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma reserva no DataGridView para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clickMesas(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBoxMesa)
            {
                int mesaClicada = 0;

                switch (pictureBoxMesa.Name)
                {
                    case "pictureBoxMesa1":
                        mesaClicada = 1;
                        break;
                    case "pictureBoxMesa2":
                        mesaClicada = 2;
                        break;
                    case "pictureBoxMesa3":
                        mesaClicada = 3;
                        break;
                    case "pictureBoxMesa4":
                        mesaClicada = 4;
                        break;
                    case "pictureBoxMesa5":
                        mesaClicada = 5;
                        break;
                    case "pictureBoxMesa6":
                        mesaClicada = 6;
                        break;
                    case "pictureBoxMesa7":
                        mesaClicada = 7;
                        break;
                    case "pictureBoxMesa8":
                        mesaClicada = 8;
                        break;
                    case "pictureBoxMesa9":
                        mesaClicada = 9;
                        break;
                    case "pictureBoxMesa10":
                        mesaClicada = 10;
                        break;
                    case "pictureBoxMesa11":
                        mesaClicada = 11;
                        break;
                    case "pictureBoxMesa12":
                        mesaClicada = 12;
                        break;
                    case "pictureBoxMesa13":
                        mesaClicada = 13;
                        break;
                    case "pictureBoxMesa14":
                        mesaClicada = 14;
                        break;
                    case "pictureBoxMesa15":
                        mesaClicada = 15;
                        break;
                    case "pictureBoxMesa16":
                        mesaClicada = 16;
                        break;
                    case "pictureBoxMesa17":
                        mesaClicada = 17;
                        break;
                    case "pictureBoxMesa18":
                        mesaClicada = 18;
                        break;
                }

                if (mesaClicada > 0)
                {
                    HabilitarDesabilitarControles(true);

                    NumeroMesa = mesaClicada;
                    CarregarDadosReserva();

                    FrmMesaReserva frmMesaReserva = new FrmMesaReserva();
                    frmMesaReserva.NumeroMesa = mesaClicada;
                    frmMesaReserva.LblMesa.Text = "Mesa " + NumeroMesa;
                    frmMesaReserva.PreencherDadosReserva(NomeCliente, CPFCliente, DataReserva, HoraReserva, QuantidadePessoas, ResumoMesa);

                    frmMesaReserva.FormularioReservas = this;
                    FormularioMesaReserva = frmMesaReserva;

                    TrocarFormulario(frmMesaReserva);

                    frmMesaReserva.KbcHora.Text = HoraReserva;
                    frmMesaReserva.KbcLugares.Text = QuantidadePessoas.ToString();
                }
            }
        }

        private void btnHistoricoMesa_Click(object sender, EventArgs e)
        {
            HabilitarDesabilitarControles(false);
            lblVoltar.Enabled = true;
            TrocarFormulario(new FrmHistoricoMesa(NumeroMesa));
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            HabilitarDesabilitarControles(false);
            panelMesas.Controls.Clear();
            panelMesas.Controls.Add(tableLayoutPanelMesas);
        }

        private void lblVoltar_MouseEnter(object sender, EventArgs e)
        {
            lblVoltar.Font = new Font(lblVoltar.Font, lblVoltar.Font.Style | FontStyle.Underline);
        }

        private void lblVoltar_MouseLeave(object sender, EventArgs e)
        {
            lblVoltar.Font = new Font(lblVoltar.Font, lblVoltar.Font.Style & ~FontStyle.Underline);
        }
    }
}