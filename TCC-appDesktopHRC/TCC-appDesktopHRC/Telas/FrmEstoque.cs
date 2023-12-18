using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Xml.Linq;
using System.Drawing.Printing;
using PdfSharp.Pdf;
using PdfSharp.Drawing;


namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmEstoque : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        Dictionary<string, int> fornecedorIdMap = new Dictionary<string, int>();

        public FrmEstoque()
        {
            InitializeComponent();
        }

        private void FrmEstoque_Load(object sender, EventArgs e)
        {
            CarregarDadosInsumos();
            CarregarDadosAviso();

            PreencherComboBoxFornecedores();

            PreencherMapeamentoFornecedores();


            //dataGridViewInsumos - config

            dataGridViewInsumos.BackgroundColor = Color.White;
            dataGridViewInsumos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 27, 27);
            dataGridViewInsumos.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewInsumos.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewInsumos.RowTemplate.Height = 30;
            dataGridViewInsumos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewInsumos.RowHeadersVisible = false;

            dataGridViewInsumos.ReadOnly = true;
            dataGridViewInsumos.AllowUserToResizeColumns = false;
            dataGridViewInsumos.AllowUserToResizeRows = false;
            dataGridViewInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInsumos.AllowUserToAddRows = false;
            dataGridViewInsumos.AllowUserToDeleteRows = false;
            
            dataGridViewInsumos.Columns[0].HeaderText = "ID do insumo";
            dataGridViewInsumos.Columns[1].HeaderText = "Nome do insumo";
            dataGridViewInsumos.Columns[2].HeaderText = "Descrição";
            dataGridViewInsumos.Columns[3].HeaderText = "ID do fornecedor";
            dataGridViewInsumos.Columns[4].HeaderText = "Estoque";
            dataGridViewInsumos.Columns[5].HeaderText = "Unidade de medida";
            dataGridViewInsumos.Columns[6].HeaderText = "Data de entrada";
            dataGridViewInsumos.Columns[7].HeaderText = "Data de validade";
            dataGridViewInsumos.Columns[8].HeaderText = "Ativo";

            foreach (DataGridViewColumn col in dataGridViewInsumos.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //dataGridViewInsumosDisp - config

            dataGridViewInsumosDisp.BackgroundColor = Color.White;
            dataGridViewInsumosDisp.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 27, 27);
            dataGridViewInsumosDisp.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewInsumosDisp.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewInsumosDisp.RowTemplate.Height = 30;
            dataGridViewInsumosDisp.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewInsumosDisp.RowHeadersVisible = false;

            dataGridViewInsumosDisp.ReadOnly = true;
            dataGridViewInsumosDisp.AllowUserToResizeColumns = false;
            dataGridViewInsumosDisp.AllowUserToResizeRows = false;
            dataGridViewInsumosDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInsumosDisp.AllowUserToAddRows = false;
            dataGridViewInsumosDisp.AllowUserToDeleteRows = false;

            dataGridViewInsumosDisp.Columns[0].HeaderText = "Insumos";
            dataGridViewInsumosDisp.Columns[1].HeaderText = "Estoque";
            dataGridViewInsumosDisp.Columns[2].HeaderText = "Unidade de medida";
            dataGridViewInsumosDisp.Columns[3].HeaderText = "Data de entrada";
            dataGridViewInsumosDisp.Columns[4].HeaderText = "Data de validade";

            foreach (DataGridViewColumn col in dataGridViewInsumosDisp.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public KryptonButton BtnCadastrarInsumo
        {
            get { return btnCadastrarInsumo; }
            set { btnCadastrarInsumo = value; }
        }

        public KryptonButton BtnCadastrarFornecedor
        {
            get { return btnCadastrarFornecedor; }
            set { btnCadastrarFornecedor = value; }
        }

        public KryptonButton BtnEditarInsumo
        {
            get { return btnEditarInsumo; }
            set { btnEditarInsumo = value; }
        }

        public KryptonButton BtnEditarFornecedor
        {
            get { return btnEditarFornecedor; }
            set { btnEditarFornecedor = value; }
        }

        public KryptonButton BtnDesativarInsumo
        {
            get { return btnDesativarInsumo; }
            set { btnDesativarInsumo = value; }
        }

        public KryptonButton BtnDesativarFornecedor
        {
            get { return btnDesativarFornecedor; }
            set { btnDesativarFornecedor = value; }
        }

        public KryptonButton BtnCriarGrafico
        {
            get { return btnCriarGrafico; }
            set { btnCriarGrafico = value; }
        }

        public void CarregarDadosInsumos()
        {
            string query = "SELECT * FROM Insumos WHERE ativo = 1";

            DataTable dataTable = conexao.ExecutarConsulta(query);

            dataGridViewInsumos.DataSource = dataTable;
        }

        public void CarregarDadosAviso()
        {
            string query = "SELECT nome_insumo, estoque, unidade_medida, data_entrada, data_validade FROM Insumos WHERE ativo = 1 " +
                           "AND (DATEDIFF(day, GETDATE(), data_validade) <= 30 OR estoque < 500 OR (unidade_medida = 'gramas' AND estoque < 50000))";

            DataTable dataTable = conexao.ExecutarConsulta(query);

            dataGridViewInsumosDisp.DataSource = dataTable;
        }

        private void PreencherComboBoxFornecedores()
        {
            string query = "SELECT id_fornecedor, nome_fornecedor FROM Fornecedor WHERE ativo = 1";

            DataTable dataTable = conexao.ExecutarConsulta(query);

            kbcFiltroInsumos.DisplayMember = "nome_fornecedor";
            kbcFiltroInsumos.ValueMember = "id_fornecedor";

            DataTable comboData = new DataTable();
            comboData.Columns.Add("id_fornecedor", typeof(int));
            comboData.Columns.Add("nome_fornecedor", typeof(string));

            DataRow allRow = comboData.NewRow();
            allRow["id_fornecedor"] = 0;
            allRow["nome_fornecedor"] = "Todos";
            comboData.Rows.Add(allRow);

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = comboData.NewRow();
                newRow["id_fornecedor"] = row["id_fornecedor"];
                newRow["nome_fornecedor"] = row["nome_fornecedor"];
                comboData.Rows.Add(newRow);
            }

            kbcFiltroInsumos.DataSource = comboData;
        }

        private void PreencherMapeamentoFornecedores()
        {
            fornecedorIdMap.Clear();

            string query = "SELECT id_fornecedor, nome_fornecedor FROM Fornecedor WHERE ativo = 1";

            DataTable dataTable = conexao.ExecutarConsulta(query);

            foreach (DataRow row in dataTable.Rows)
            {
                int fornecedorId = Convert.ToInt32(row["id_fornecedor"]);
                string fornecedorNome = row["nome_fornecedor"].ToString();
                fornecedorIdMap.Add(fornecedorNome, fornecedorId);
            }
        }

        private bool DesativarInsumo(int insumoID)
        {
            try
            {
                SqlParameter parametroID = new SqlParameter("@InsumoID", SqlDbType.Int);
                parametroID.Value = insumoID;

                int linhasAfetadas = conexao.ExecutarComando("usp_DesativarInsumo", new SqlParameter[] { parametroID });

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Insumo desativado com sucesso!");

                    return true;
                }
                else
                {
                    MessageBox.Show("Falha ao desativar o insumo.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desativar insumo: " + ex.Message);
                MessageBox.Show("Erro ao desativar o insumo.");
                return false;
            }
        }

        private bool DesativarFornecedor(int fornecedorID)
        {
            try
            {
                SqlParameter parametroID = new SqlParameter("@FornecedorID", SqlDbType.Int);
                parametroID.Value = fornecedorID;

                int linhasAfetadas = conexao.ExecutarComando("usp_DesativarFornecedor", new SqlParameter[] { parametroID });

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Fornecedor desativado com sucesso!");

                    CarregarDadosInsumos();

                    return true;
                }
                else
                {
                    MessageBox.Show("Falha ao desativar o fornecedor.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desativar fornecedor: " + ex.Message);
                MessageBox.Show("Erro ao desativar o fornecedor.");
                return false;
            }
        }

        private void txtPesquisaInsumos_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtPesquisaInsumos.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = "SELECT * FROM Insumos WHERE nome_insumo LIKE @searchTerm"
                +" AND ativo = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@searchTerm", "%" + searchTerm + "%")
                };

                DataTable dataTable = conexao.ExecutarConsultaParametros(query, parameters);
                dataGridViewInsumos.DataSource = dataTable;
            }
            else
            {
                CarregarDadosInsumos();
            }
        }

        private void kbcFiltroInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedFornecedorId = (int)kbcFiltroInsumos.SelectedValue;

            if (selectedFornecedorId != 0)
            {
                string query = "SELECT * FROM Insumos WHERE id_fornecedor = @fornecedorId AND ativo = 1";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@fornecedorId", selectedFornecedorId)
                };

                DataTable dataTable = conexao.ExecutarConsultaParametros(query, parameters);
                dataGridViewInsumos.DataSource = dataTable;
            }
            else
            {
                CarregarDadosInsumos();
            }
        }

        private void btnCadastrarInsumo_Click(object sender, EventArgs e)
        {
            FrmCadastroInsumos frmCI = new FrmCadastroInsumos();
            frmCI.Show();
        }

        private void btnEditarInsumo_Click(object sender, EventArgs e)
        {
            if (dataGridViewInsumos.SelectedRows.Count > 0)
            {
                int insumoID = Convert.ToInt32(dataGridViewInsumos.SelectedRows[0].Cells["id_insumo"].Value);
                FrmCadastroInsumos frmCI = new FrmCadastroInsumos();
                frmCI.InsumoID = insumoID;
                frmCI.Show();
            }
            else
            {
                MessageBox.Show("Selecione um insumo para editar.");
            }
        }

        private void btnDesativarInsumo_Click(object sender, EventArgs e)
        {
            if (dataGridViewInsumos.SelectedRows.Count > 0)
            {
                int insumoID = Convert.ToInt32(dataGridViewInsumos.SelectedRows[0].Cells["id_insumo"].Value);

                bool sucesso = DesativarInsumo(insumoID);

                if (sucesso)
                {
                    CarregarDadosInsumos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um insumo para desativar.");
            }
        }

        private void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            FrmCadastroFornecedores frmCFornec = new FrmCadastroFornecedores();
            frmCFornec.Show();
        }

        private void btnEditarFornecedor_Click(object sender, EventArgs e)
        {
            if (dataGridViewInsumos.SelectedRows.Count > 0)
            {
                int insumoID = Convert.ToInt32(dataGridViewInsumos.SelectedRows[0].Cells["id_insumo"].Value);

                string query = "SELECT id_fornecedor FROM Insumos WHERE id_insumo = @insumoID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@insumoID", insumoID)
                };

                DataTable fornecedorTable = conexao.ExecutarConsultaParametros(query, parameters);

                if (fornecedorTable.Rows.Count > 0)
                {
                    int idFornecedor = Convert.ToInt32(fornecedorTable.Rows[0]["id_fornecedor"]);

                    FrmCadastroFornecedores frmCFornec = new FrmCadastroFornecedores();
                    frmCFornec.FornecedorID = idFornecedor;
                    frmCFornec.Show();
                }
                else
                {
                    MessageBox.Show("O insumo selecionado não tem um fornecedor associado.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para editar.");
            }

        }

        private void btnDesativarFornecedor_Click(object sender, EventArgs e)
        {

        }

        private void btnCriarGrafico_Click(object sender, EventArgs e)
        {
            PdfDocument pdfDocument = new PdfDocument();

            PdfPage page = pdfDocument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);

            int[] dataPoints1 = { 100, 50, 20 };
            int[] dataPoints2 = { 0, 30, 5 }; // Altura menor para Saídas

            XColor[] seriesColors = { XColors.Green, XColors.Blue, XColors.Red };

            int chartWidth = 400;
            int chartHeight = 300;

            int barWidth = 40;

            int spacing = 10;

            int chartX = 100;
            int chartY = 300;

            int legendX = 100;
            int legendY = 350;

            // Adicionei o título "Fluxo de Estoque"
            gfx.DrawString("Fluxo de Estoque", font, XBrushes.Black, new XRect(100, 50, chartWidth, chartHeight), XStringFormats.TopCenter);

            int totalHeight = 0;

            for (int i = 0; i < dataPoints1.Length; i++)
            {
                int barHeight1 = dataPoints1[i] * 2;

                int barHeight2 = i < dataPoints2.Length ? dataPoints2[i] * 2 : 0;

                totalHeight += barHeight1 + barHeight2;

                // Desenha a barra verde (Estoque Inicial)
                gfx.DrawRectangle(new XSolidBrush(seriesColors[0]), chartX, chartY - totalHeight, barWidth, barHeight1);

                // Desenha a barra azul (Entradas)
                gfx.DrawRectangle(new XSolidBrush(seriesColors[1]), chartX, chartY - totalHeight, barWidth, barHeight2);

                // Desenha a barra vermelha (Saídas)
                gfx.DrawRectangle(new XSolidBrush(seriesColors[2]), chartX, chartY - totalHeight, barWidth, barHeight2);

                chartX += barWidth + spacing;
            }

            string[] seriesNames = { "Estoque Inicial", "Entradas", "Saídas" };
            for (int i = 0; i < seriesNames.Length; i++)
            {
                gfx.DrawRectangle(new XSolidBrush(seriesColors[i]), legendX, legendY, 10, 10);
                gfx.DrawString(seriesNames[i], font, XBrushes.Black, legendX + 20, legendY);
                legendX += 120;
            }

            pdfDocument.Save("Grafico.pdf");

            System.Diagnostics.Process.Start("Grafico.pdf");
        }

    }
}
