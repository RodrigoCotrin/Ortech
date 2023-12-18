using System;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmHistoricoMesa : KryptonForm
    {
        Conexao myconexao;
        private int numeroMesa;

        public FrmHistoricoMesa(int numeroMesa)
        {
            InitializeComponent();
            myconexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
            this.numeroMesa = numeroMesa;

            PreencherHistoricoMesa(this.numeroMesa);
        }

        public void PreencherHistoricoMesa(int numeroMesa)
        {
            string reservaQuery = "SELECT r.data_reserva, r.quantidade_pessoas, c.nome, r.cpf " +
                                  "FROM Reserva r " +
                                  "INNER JOIN Cliente c ON r.cpf = c.cpf " +
                                  "WHERE r.numero_mesa = " + numeroMesa + " AND r.ativo = 0 " +
                                  "ORDER BY r.data_reserva DESC";

            DataTable reservaData = myconexao.ExecutarConsulta(reservaQuery);

            foreach (DataRow row in reservaData.Rows)
            {
                // Crie um painel principal para cada entrada no histórico
                Panel painelPrincipal = new Panel();
                painelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                painelPrincipal.BackColor = System.Drawing.Color.Gray;
                painelPrincipal.Size = new System.Drawing.Size(250, 150);

                // Label para exibir o número da mesa
                Label lblNumeroMesa = new Label();
                lblNumeroMesa.Text = "Número da Mesa: " + numeroMesa;
                lblNumeroMesa.AutoSize = true;
                lblNumeroMesa.Location = new System.Drawing.Point(10, 10);

                // Label para exibir a data da reserva
                Label lblDataReserva = new Label();
                DateTime dataReserva = (DateTime)row["data_reserva"];
                lblDataReserva.Text = "Data da Reserva: " + dataReserva.ToString("dd/MM/yyyy") + " às " + dataReserva.ToString("HH:mm");
                lblDataReserva.AutoSize = true;
                lblDataReserva.Location = new System.Drawing.Point(10, 40);

                // Label para exibir a quantidade de pessoas
                Label lblQuantidadePessoas = new Label();
                lblQuantidadePessoas.Text = "Quantidade de Pessoas: " + row["quantidade_pessoas"].ToString();
                lblQuantidadePessoas.AutoSize = true;
                lblQuantidadePessoas.Location = new System.Drawing.Point(10, 70);

                // Label para exibir o nome do cliente
                Label lblNomeCliente = new Label();
                lblNomeCliente.Text = "Nome do Cliente: " + row["nome"].ToString();
                lblNomeCliente.AutoSize = true;
                lblNomeCliente.Location = new System.Drawing.Point(10, 100);

                // Label para exibir o CPF
                Label lblCPF = new Label();
                lblCPF.Text = "CPF: " + row["cpf"].ToString();
                lblCPF.AutoSize = true;
                lblCPF.Location = new System.Drawing.Point(10, 130);

                // Adicione os controles ao painel principal
                painelPrincipal.Controls.Add(lblNumeroMesa);
                painelPrincipal.Controls.Add(lblDataReserva);
                painelPrincipal.Controls.Add(lblCPF);
                painelPrincipal.Controls.Add(lblNomeCliente);
                painelPrincipal.Controls.Add(lblQuantidadePessoas);

                // Adicione o painel principal ao TableLayoutPanel
                tlpHistoricoMesa.Controls.Add(painelPrincipal);
            }
        }
    }
}
