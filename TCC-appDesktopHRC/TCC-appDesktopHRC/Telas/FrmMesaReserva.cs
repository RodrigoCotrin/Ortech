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
    public partial class FrmMesaReserva : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        public int NumeroMesa { get; set; }
        public FrmReservas FormularioReservas { get; set; }

        public string NovoNomeCliente
        {
            get { return TxtNomeDoCliente.Text; }
            set { TxtNomeDoCliente.Text = value; }
        }

        public string NovoCPFCliente
        {
            get { return TxtCPFdoCliente.Text; }
            set { TxtCPFdoCliente.Text = value; }
        }

        public DateTime NovaDataReserva
        {
            get { return DateTime.ParseExact(TxtDataReserva.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { TxtDataReserva.Text = value.ToString("dd/MM/yyyy"); }
        }

        public string NovaHoraReserva
        {
            get { return KbcHora.Text; }
            set { KbcHora.Text = value; }
        }

        public int NovaQuantidadePessoas
        {
            get { return int.Parse(KbcLugares.Text); }
            set { KbcLugares.Text = value.ToString(); }
        }

        public FrmMesaReserva()
        {
            InitializeComponent();
        }

        private void FrmMesaReserva_Load(object sender, EventArgs e)
        {
            PreencherDataGridViewProximasReservas(NumeroMesa);
            PreencherItensComboBoxReserva();

            //dataGridViewProximasReservas - config

            dataGridViewProximasReservas.BackgroundColor = Color.White;
            dataGridViewProximasReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 27, 27);
            dataGridViewProximasReservas.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewProximasReservas.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewProximasReservas.RowTemplate.Height = 30;
            dataGridViewProximasReservas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewProximasReservas.RowHeadersVisible = false;

            dataGridViewProximasReservas.ReadOnly = true;
            dataGridViewProximasReservas.AllowUserToResizeColumns = false;
            dataGridViewProximasReservas.AllowUserToResizeRows = false;
            dataGridViewProximasReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProximasReservas.AllowUserToAddRows = false;
            dataGridViewProximasReservas.AllowUserToDeleteRows = false;

            dataGridViewProximasReservas.Columns[0].HeaderText = "Número da mesa";
            dataGridViewProximasReservas.Columns[1].HeaderText = "CPF";
            dataGridViewProximasReservas.Columns[2].HeaderText = "Nome do cliente";
            dataGridViewProximasReservas.Columns[3].HeaderText = "Data da reserva";
            dataGridViewProximasReservas.Columns[4].HeaderText = "Quantidade de pessoas";

            foreach (DataGridViewColumn col in dataGridViewProximasReservas.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (FormularioReservas != null && dataGridViewProximasReservas.Rows.Count == 0)
            {
                FormularioReservas.LimparCamposReserva();
            }
            else if (NumeroMesa > 0)
            {
                FormularioReservas.CarregarDadosReserva();
            }
        }

        public KryptonTextBox TxtNomeDoCliente
        {
            get { return txtNomeDoCliente; }
            set { txtNomeDoCliente = value; }
        }

        public KryptonMaskedTextBox TxtCPFdoCliente
        {
            get { return txtCPFdoCliente; }
            set { txtCPFdoCliente = value; }
        }

        public KryptonMaskedTextBox TxtDataReserva
        {
            get { return txtDataReserva; }
            set { txtDataReserva = value; }
        }

        public KryptonComboBox KbcHora
        {
            get { return kbcHora; }
            set { kbcHora = value; }
        }

        public KryptonComboBox KbcLugares
        {
            get { return kbcLugares; }
            set { kbcLugares = value; }
        }

        public Label LblMesa
        {
            get { return lblMesa; }
            set { lblMesa = value; }
        }

        public Label LblResumoMesa
        {
            get { return lblResumoMesa; }
            set { lblResumoMesa = value; }
        }

        public DataGridView DataGridViewProximasReservas
        {
            get { return dataGridViewProximasReservas; }
            set { dataGridViewProximasReservas = value; }
        }

        private string FormatarData(string data)
        {
            if (DateTime.TryParse(data, out DateTime dataConvertida))
            {
                return dataConvertida.ToString("dd/MM/yyyy");
            }
            return data;
        }

        private string FormatarHora(string hora)
        {
            if (hora != null && TimeSpan.TryParse(hora, out TimeSpan horaConvertida))
            {
                return horaConvertida.ToString("hh':'mm");
            }
            return hora;
        }

        public void PreencherDadosReserva(string nomeCliente, string cpfCliente, DateTime dataReserva, string horaReserva, int quantidadePessoas, string resumoMesa)
        {
            txtNomeDoCliente.Text = nomeCliente;
            txtCPFdoCliente.Text = cpfCliente;
            txtDataReserva.Text = FormatarData(dataReserva.ToString());
            if (horaReserva != null)
            {
                kbcHora.Text = FormatarHora(horaReserva.ToString());
            }
            kbcLugares.Text = quantidadePessoas.ToString();
            lblResumoMesa.Text = resumoMesa;
        }

        public void PreencherDataGridViewProximasReservas(int numeroMesa)
        {
            string query = @"SELECT R.numero_mesa, R.cpf, C.nome, R.data_reserva, R.quantidade_pessoas
                    FROM Reserva AS R
                    INNER JOIN Cliente AS C ON R.cpf = C.cpf
                    WHERE R.numero_mesa = @NumeroMesa
                    AND R.data_reserva >= GETDATE()
                    AND R.Ativo = 1
                    ORDER BY R.data_reserva";

            SqlParameter[] parametros = { new SqlParameter("@NumeroMesa", numeroMesa) };

            DataTable resultado = conexao.ExecutarConsultaParametros(query, parametros);

            dataGridViewProximasReservas.DataSource = resultado;
        }

        public void dataGridViewProximasReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string numeroMesa = dataGridViewProximasReservas.Rows[e.RowIndex].Cells["numero_mesa"].Value.ToString();
                string cpfCliente = dataGridViewProximasReservas.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
                string nomeCliente = dataGridViewProximasReservas.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                string dataReservaStr = dataGridViewProximasReservas.Rows[e.RowIndex].Cells["data_reserva"].Value.ToString();
                string quantidadePessoas = dataGridViewProximasReservas.Rows[e.RowIndex].Cells["quantidade_pessoas"].Value.ToString();

                DateTime dataReserva;

                if (DateTime.TryParse(dataReservaStr, out dataReserva))
                {
                    NovoNomeCliente = nomeCliente;
                    NovoCPFCliente = cpfCliente;
                    NovaDataReserva = dataReserva;
                    NovaHoraReserva = dataReserva.ToString("HH:mm"); // Preencher com a hora da reserva
                    NovaQuantidadePessoas = int.Parse(quantidadePessoas);

                    string resumoMesa = $"Reserva da mesa {numeroMesa} para {NovoNomeCliente} em {NovaDataReserva.ToString("dd/MM/yyyy")}, horário {NovaHoraReserva} com {NovaQuantidadePessoas} pessoas.";
                    LblResumoMesa.Text = resumoMesa;

                    if (FormularioReservas != null)
                    {
                        FormularioReservas.CarregarDadosReservaCliente(cpfCliente);
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao converter a data da reserva.");
                }
            }
        }


        public void PreencherItensComboBoxReserva()
        {
            kbcLugares.Items.Add("2");
            kbcLugares.Items.Add("4");
            kbcLugares.Items.Add("8");

            kbcHora.Items.Add("10:00");
            kbcHora.Items.Add("11:00");
            kbcHora.Items.Add("12:00");
            kbcHora.Items.Add("13:00");
            kbcHora.Items.Add("14:00");
            kbcHora.Items.Add("15:00");
            kbcHora.Items.Add("16:00");
            kbcHora.Items.Add("17:00");
            kbcHora.Items.Add("18:00");
            kbcHora.Items.Add("19:00");
            kbcHora.Items.Add("20:00");
            kbcHora.Items.Add("21:00");
            kbcHora.Items.Add("22:00");
        }
    }
}
