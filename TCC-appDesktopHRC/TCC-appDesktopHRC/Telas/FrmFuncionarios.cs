using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmFuncionarios : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            CarregarDados();

            dataGridViewFuncionarios.BackgroundColor = Color.White;
            dataGridViewFuncionarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 27, 27);
            dataGridViewFuncionarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewFuncionarios.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewFuncionarios.RowTemplate.Height = 30;
            dataGridViewFuncionarios.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewFuncionarios.RowHeadersVisible = false;

            dataGridViewFuncionarios.ReadOnly = true;
            dataGridViewFuncionarios.AllowUserToResizeColumns = false;
            dataGridViewFuncionarios.AllowUserToResizeRows = false;
            dataGridViewFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFuncionarios.AllowUserToAddRows = false;
            dataGridViewFuncionarios.AllowUserToDeleteRows = false;

            dataGridViewFuncionarios.Columns[0].HeaderText = "ID do funcionário";
            dataGridViewFuncionarios.Columns[1].HeaderText = "Nome";
            dataGridViewFuncionarios.Columns[2].HeaderText = "Telefone";
            dataGridViewFuncionarios.Columns[3].HeaderText = "Email";
            dataGridViewFuncionarios.Columns[4].HeaderText = "Cargo";
            dataGridViewFuncionarios.Columns[5].HeaderText = "Turno";
            dataGridViewFuncionarios.Columns[6].HeaderText = "Salário";
            dataGridViewFuncionarios.Columns[7].HeaderText = "Endereço";
            dataGridViewFuncionarios.Columns[8].HeaderText = "CEP";
            dataGridViewFuncionarios.Columns[9].HeaderText = "CPF";
            dataGridViewFuncionarios.Columns[10].HeaderText = "Data de nascimento";
            dataGridViewFuncionarios.Columns[11].HeaderText = "Sexo";
            dataGridViewFuncionarios.Columns[12].HeaderText = "Senha";
            dataGridViewFuncionarios.Columns[13].HeaderText = "Imagem";
            dataGridViewFuncionarios.Columns[14].HeaderText = "Data de contratação";
            dataGridViewFuncionarios.Columns[15].HeaderText = "Ativo";

            foreach (DataGridViewColumn col in dataGridViewFuncionarios.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
        }

        private bool DesabilitarFuncionario(int funcionarioID)
        {
            try
            {
                SqlParameter parametroID = new SqlParameter("@funcionarioID", SqlDbType.Int);
                parametroID.Value = funcionarioID;

                // Chama a stored procedure de desativação do funcionário
                int linhasAfetadas = conexao.ExecutarComando("usp_DesabilitarFuncionario", new SqlParameter[] { parametroID });

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Funcionário desativado com sucesso.");

                    // Remove a linha selecionada do DataGridView
                    dataGridViewFuncionarios.Rows.RemoveAt(dataGridViewFuncionarios.SelectedRows[0].Index);

                    return true;
                }
                else
                {
                    MessageBox.Show("Falha ao desativar o funcionário.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desativar funcionário: " + ex.Message);
                MessageBox.Show("Erro ao desativar o funcionário.");
                return false;
            }
        }

        public KryptonButton BtnCadastrar
        {
            get { return btnCadastrar; }
            set { btnCadastrar = value; }
        }

        public KryptonButton BtnEditar
        {
            get { return btnEditar; }
            set { btnEditar = value; }
        }

        public void CarregarDados()
        {
            string query = "SELECT * FROM Funcionario WHERE ativo = 1";

            DataTable dataTable = conexao.ExecutarConsulta(query);

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["img_func"] != DBNull.Value)
                {
                    row["img_func"] = ImagemParaArrayDeBytes(Properties.Resources.ImagemPresente);
                }
                else
                {
                    row["img_func"] = ImagemParaArrayDeBytes(Properties.Resources.ImagemAusente);
                }
            }

            dataGridViewFuncionarios.DataSource = dataTable;
        }

        private byte[] ImagemParaArrayDeBytes(Image imagem)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagem.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtPesquisa.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = "SELECT * FROM Funcionario WHERE nome LIKE @searchTerm"
                + " AND ativo = 1";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@searchTerm", "%" + searchTerm + "%")
                };

                DataTable dataTable = conexao.ExecutarConsultaParametros(query, parameters);
                dataGridViewFuncionarios.DataSource = dataTable;
            }
            else
            {
                CarregarDados();
            }
        }

        public void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastroFuncionarios frmCF = new FrmCadastroFuncionarios();
            frmCF.Show();
        }

        public void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFuncionarios.SelectedRows.Count > 0)
            {
                int funcionarioID = Convert.ToInt32(dataGridViewFuncionarios.SelectedRows[0].Cells["id_funcionario"].Value);

                FrmCadastroFuncionarios frmCF = new FrmCadastroFuncionarios();
                frmCF.FuncionarioID = funcionarioID;

                frmCF.Show();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para editar.");
            }
        }

        private void DataGridViewFuncionarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewFuncionarios.Columns[e.ColumnIndex].Name == "senha")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "●●●●●";
                }
            }
        }

        private void btnDesabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFuncionarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um funcionário para desativar.");
                return;
            }

            int funcionarioID = Convert.ToInt32(dataGridViewFuncionarios.SelectedRows[0].Cells["id_funcionario"].Value);

            DesabilitarFuncionario(funcionarioID);

            CarregarDados();
        }
    }
}
