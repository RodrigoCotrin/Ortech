using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmProdutos : KryptonForm
    {
        private Conexao conexao;
        private int indiceProdutoAtual;
        private int totalProdutos;
        private string caminhoImagem;
        private List<Produto> produtos = new List<Produto>();

        private List<Categoria> categorias = new List<Categoria>
        {
            new Categoria(1, "Sushi"),
            new Categoria(2, "Sashimi"),
            new Categoria(3, "Tempurá"),
            new Categoria(4, "Yakissoba"),
            new Categoria(5, "Temaki"),
            new Categoria(6, "Nigiri"),
            new Categoria(7, "Robata"),
            new Categoria(8, "Bebidas"),
            new Categoria(9, "Sobremesas")
        };

        public FrmProdutos()
        {
            InitializeComponent();
            conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
            listBoxProdutos.Visible = false;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            totalProdutos = ObterTotalProdutos();

            if (totalProdutos > 0)
            {
                indiceProdutoAtual = 0;
                MostrarProduto(indiceProdutoAtual + 1);
            }
            else
            {
                MessageBox.Show("Não há produtos disponíveis.");
            }

            btnConfirmarAdicao.Enabled = false;
        }

        public class Categoria
        {
            public int ID { get; set; }
            public string Nome { get; set; }

            public Categoria(int id, string nome)
            {
                ID = id;
                Nome = nome;
            }
        }

        public class Produto
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public decimal Preco { get; set; }
            public int CategoriaID { get; set; }
        }

        private void CarregarProdutosDoBanco()
        {
            produtos.Clear();

            string connectionString = "sua_string_de_conexão"; // Substitua pela sua string de conexão

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Produtos WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto produto = new Produto
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("id_produto")),
                            Nome = reader.GetString(reader.GetOrdinal("nome_produto")),
                            Descricao = reader.GetString(reader.GetOrdinal("descricao")),
                            Preco = reader.GetDecimal(reader.GetOrdinal("preco")),
                            CategoriaID = reader.GetInt32(reader.GetOrdinal("id_categoriaprod"))
                            // Preencha outras propriedades do produto, se necessário
                        };

                        produtos.Add(produto);
                    }
                }
            }
        }

        private List<Produto> BuscarProdutosNoBanco(string termoPesquisa)
        {
            string connectionString = "sua_string_de_conexão"; // Substitua pela sua string de conexão

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Produtos WHERE nome_produto LIKE @termoPesquisa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@termoPesquisa", "%" + termoPesquisa + "%");

                List<Produto> resultados = new List<Produto>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto produto = new Produto
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("id_produto")),
                            Nome = reader.GetString(reader.GetOrdinal("nome_produto")),
                            Descricao = reader.GetString(reader.GetOrdinal("descricao")),
                            Preco = reader.GetDecimal(reader.GetOrdinal("preco")),
                            CategoriaID = reader.GetInt32(reader.GetOrdinal("id_categoriaprod"))
                            // Preencha outras propriedades do produto, se necessário
                        };

                        resultados.Add(produto);
                    }
                }

                return resultados;
            }
        }

        private bool CamposObrigatoriosPreenchidos()
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtDescricaoProduto.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtPrecoProduto.Text))
            {
                return false;
            }

            if (kbcCategoriaProduto.SelectedItem == null)
            {
                return false;
            }

            if (kbcUM.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private void MostrarProduto(int produtoID)
        {
            if (produtoID >= 1 && produtoID <= totalProdutos)
            {
                DataTable produtoData = BuscarProdutoPorID(produtoID);

                if (produtoData.Rows.Count > 0)
                {
                    DataRow row = produtoData.Rows[0];
                    PreencherControlesComDadosDoProduto(row);
                    indiceProdutoAtual = produtoID - 1; // Atualize o índice do produto atual
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                }
            }
        }

        private void PreencherCamposComDadosDoProduto(DataRow produto)
        {
            // Preencha os campos de inserção/atualização com os dados do produto
            txtNomeProduto.Text = produto["nome_produto"].ToString();
            txtDescricaoProduto.Text = produto["descricao"].ToString();
            txtPrecoProduto.Text = produto["preco"].ToString();
            kbcUM.Text = produto["unidade_medida"].ToString();

            int categoriaId = Convert.ToInt32(produto["id_categoriaprod"]);
            PreencherKbcCategoria(categoriaId);

            // Tratar a imagem
            if (produto["img_prato"] != DBNull.Value)
            {
                byte[] imagemBytes = (byte[])produto["img_prato"];
                pictureBoxImgProd.Image = ByteToImage(imagemBytes);
            }
            else
            {
                // Se não houver imagem, defina a imagem para null ou uma imagem padrão
                pictureBoxImgProd.Image = null; // ou pictureBoxImgProd.Image = Properties.Resources.ImagemEmBranco;
            }

            // Atualize o texto da lblIDProduto com o ID do produto
            int produtoId = Convert.ToInt32(produto["id_produto"]);
            lblIDProduto.Text = "ID do produto: " + produtoId;
        }

        private void PreencherControlesComDadosDoProduto(DataRow row)
        {
            int produtoId = Convert.ToInt32(row["id_produto"]);
            string idProdutoTexto = "ID do produto: " + produtoId;
            txtNomeProduto.Text = row["nome_produto"].ToString();
            lblIDProduto.Text = idProdutoTexto;
            txtDescricaoProduto.Text = row["descricao"].ToString();

            // Formatando o campo "preco" para exibir no formato "R$ 05,99"
            decimal preco = Convert.ToDecimal(row["preco"]);
            string precoFormatado = preco.ToString("0.00");

            // Adicionando um "0" à esquerda se necessário
            if (precoFormatado.Length == 4) // Verifica se há apenas um dígito à esquerda
            {
                precoFormatado = "0" + precoFormatado;
            }

            precoFormatado = "R$ " + precoFormatado;
            txtPrecoProduto.Text = precoFormatado;

            kbcUM.Text = row["unidade_medida"].ToString();
            int categoriaId = Convert.ToInt32(row["id_categoriaprod"]);
            if (!string.IsNullOrEmpty(ObterNomeCategoria(categoriaId)))
            {
                PreencherKbcCategoria(categoriaId);
            }

            if (row["img_prato"] != DBNull.Value)
            {
                byte[] imagemBytes = (byte[])row["img_prato"];
                pictureBoxImgProd.Image = Image.FromStream(new MemoryStream(imagemBytes));
            }
            else
            {
                // Se não houver imagem válida, defina a imagem para null ou uma imagem em branco
                pictureBoxImgProd.Image = null; // ou pictureBoxImgProd.Image = Properties.Resources.ImagemEmBranco;
            }

            AdicionarItensKbcUM();
            DefinirKbcUM(row);
        }

        // Método para converter bytes em uma imagem
        private Image ByteToImage(byte[] imagemBytes)
        {
            if (imagemBytes == null || imagemBytes.Length == 0)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream(imagemBytes))
            {
                return Image.FromStream(stream);
            }
        }

        private void LimparCamposDeInsercaoAtualizacao()
        {
            // Limpe os campos de inserção/atualização, isso pode variar dependendo da lógica da sua aplicação
            txtNomeProduto.Clear();
            txtDescricaoProduto.Clear();
            txtPrecoProduto.Clear();
            kbcUM.Text = string.Empty;
            kbcCategoriaProduto.SelectedIndex = -1; // Se você deseja desmarcar a seleção da categoria
            pictureBoxImgProd.Image = null; // Limpe a imagem, se aplicável
        }

        private int ObterCategoriaSelecionada()
        {
            if (kbcCategoriaProduto.SelectedItem != null)
            {
                return ((Categoria)kbcCategoriaProduto.SelectedItem).ID;
            }
            return -1;
        }
        private int ObterProdutoIdPeloIndice(int indice)
        {
            // Verifica se o índice está dentro dos limites válidos
            if (indice >= 0 && indice < totalProdutos)
            {
                // Supondo que os IDs de produtos começam em 1
                return indice + 1;
            }

            // Se o índice estiver fora dos limites, retorne um valor que indique que não há ID correspondente
            return -1;
        }

        private int ObterTotalProdutos()
        {
            string query = "SELECT COUNT(*) FROM Produtos";
            return conexao.ExecutarConsultaScalar<int>(query);
        }

        private void AtualizarTotalProdutos()
        {
            totalProdutos = ObterTotalProdutos();
        }

        private DataTable PesquisarProdutosNoBanco(string termoPesquisa)
        {
            string query = "SELECT * FROM Produtos WHERE nome_produto LIKE @termoPesquisa";
            SqlParameter[] parametros = { new SqlParameter("@termoPesquisa", "%" + termoPesquisa + "%") };
            return conexao.ExecutarConsultaParametros(query, parametros);
        }

        private DataTable BuscarProdutoPorID(int produtoID)
        {
            string query = "SELECT * FROM Produtos WHERE id_produto = @produtoID AND ativo = 1";
            SqlParameter[] parameters = { new SqlParameter("@produtoID", produtoID) };
            return conexao.ExecutarConsultaParametros(query, parameters);
        }

        private string ObterNomeCategoria(int categoriaId)
        {
            string query = "SELECT nome_categoria FROM CategoriaProduto WHERE id_categoriaprod = @categoriaId";
            SqlParameter[] parameters = { new SqlParameter("@categoriaId", categoriaId) };
            DataTable categoriaData = conexao.ExecutarConsultaParametros(query, parameters);
            return categoriaData.Rows.Count > 0 ? categoriaData.Rows[0]["nome_categoria"].ToString() : string.Empty;
        }

        private void PreencherKbcCategoria(int categoriaId)
        {
            kbcCategoriaProduto.DataSource = categorias;
            kbcCategoriaProduto.DisplayMember = "Nome";
            kbcCategoriaProduto.ValueMember = "ID";
            kbcCategoriaProduto.SelectedValue = categoriaId;
        }

        private void AdicionarItensKbcUM()
        {
            if (kbcUM.Items.Count == 0) // Verifica se a lista suspensa já possui itens
            {
                kbcUM.Items.Add("Unidade");
                kbcUM.Items.Add("Porção");
                kbcUM.Items.Add("8 Unidades");
            }
        }

        private void DefinirKbcUM(DataRow row)
        {
            kbcUM.Text = row["unidade_medida"].ToString();
        }

        private byte[] ObterBytesDaImagem(Image imagem)
        {
            if (imagem == null)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                imagem.Save(stream, imagem.RawFormat);
                return stream.ToArray();
            }
        }

        private void LimparControlesFormulario()
        {
            txtNomeProduto.Clear();
            txtDescricaoProduto.Clear();
            txtPrecoProduto.Clear();
            kbcUM.Text = "";
            kbcCategoriaProduto.Text = "";
            pictureBoxImgProd.Image = null;
            caminhoImagem = null;
        }

        private string ConverterPrecoParaBanco(string salario)
        {
            try
            {
                string salarioLimpo = new string(salario.Where(char.IsDigit).ToArray());

                if (salarioLimpo.Length >= 2)
                {
                    string reaisPart = salarioLimpo.Substring(0, salarioLimpo.Length - 2);
                    string centavosPart = salarioLimpo.Substring(salarioLimpo.Length - 2);

                    string valorFormatado = reaisPart + "." + centavosPart;

                    if (decimal.TryParse(valorFormatado, out decimal salarioConvertido))
                    {
                        return salarioConvertido.ToString("0.00");
                    }
                }

                // Se a conversão falhar, retorne uma string vazia (ou outra indicação de erro)
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção, registre o erro para depuração.
                Console.WriteLine("Erro ao converter preço: " + ex.Message);
                return string.Empty;
            }
        }

        private int ObterUltimoProdutoAtivo()
        {
            string query = "SELECT TOP 1 id_produto FROM Produtos WHERE ativo = 1 ORDER BY id_produto DESC";
            return conexao.ExecutarConsultaScalar<int>(query);
        }

        private int InserirProduto(string nome, string descricao, string preco, int categoriaId, string unidadeMedida, byte[] imagem)
        {
            string query = "INSERT INTO Produtos (nome_produto, descricao, preco, id_categoriaprod, unidade_medida, img_prato) " +
                           "VALUES (@Nome, @Descricao, @Preco, @CategoriaId, @UnidadeMedida, @Imagem); " +
                           "SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nome", nome),
                new SqlParameter("@Descricao", descricao),
                new SqlParameter("@Preco", preco),
                new SqlParameter("@CategoriaId", categoriaId),
                new SqlParameter("@UnidadeMedida", unidadeMedida),
                new SqlParameter("@Imagem", (object)imagem ?? DBNull.Value) // Para permitir valores nulos
            };

            int novoProdutoID = conexao.ExecutarComandoScalarG<int>(query, parametros);

            if (novoProdutoID > 0)
            {
                totalProdutos = ObterTotalProdutos();
                MostrarProduto(novoProdutoID);
            }
            else
            {
                MessageBox.Show("Falha ao inserir o novo produto.");
            }

            return novoProdutoID;
        }

        public int AtualizarProduto(int produtoId, string nome, string descricao, string preco, int categoriaId, string unidadeMedida, byte[] imagem)
        {
            // Crie um array de parâmetros para a sua consulta de atualização
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ProdutoId", produtoId),
                new SqlParameter("@Nome", nome),
                new SqlParameter("@Descricao", descricao),
                new SqlParameter("@Preco", preco),
                new SqlParameter("@CategoriaId", categoriaId),
                new SqlParameter("@UnidadeMedida", unidadeMedida),
                new SqlParameter("@Imagem", (object)imagem ?? DBNull.Value)
            };

            int linhasAfetadas = conexao.ExecutarComando("usp_AtualizarProduto", parametros);

            if (linhasAfetadas >= 0)
            {
                if (linhasAfetadas == 0)
                {
                    // Nenhuma linha afetada, o produto não foi atualizado
                    return 0;
                }
                else
                {
                    // Produto atualizado com sucesso
                    return 1;
                }
            }
            else
            {
                // Falha ao atualizar o produto
                return -1;
            }
        }

        private void AtualizarListaDeProdutos()
        {
            listBoxProdutos.Items.Clear(); // Limpe a lista atual

            foreach (Produto produto in produtos)
            {
                listBoxProdutos.Items.Add(produto.Nome); // Adicione o nome do produto à lista.
            }
        }

        public void DesativarProduto(int produtoID)
        {
            string query = "EXEC usp_DesativarProduto @produtoID";
            SqlParameter[] parameters = { new SqlParameter("@produtoID", produtoID) };

            try
            {
                string mensagem = conexao.ExecutarConsultaScalarG<string>(query, parameters);
                if (!string.IsNullOrEmpty(mensagem))
                {
                    MessageBox.Show(mensagem);
                    AtualizarListaDeProdutos(); // Atualize a lista de produtos após a desativação
                    if (indiceProdutoAtual >= 0)
                    {
                        // Apenas se a operação foi bem-sucedida, atualize o índice do produto atual
                        indiceProdutoAtual--;
                        if (indiceProdutoAtual < 0)
                        {
                            // Certifique-se de que o índice não seja negativo
                            indiceProdutoAtual = 0;
                        }
                        // Mostrar o produto no novo índice atual
                        MostrarProduto(ObterProdutoIdPeloIndice(indiceProdutoAtual));
                    }
                }
                else
                {
                    // A procedure não retornou uma mensagem válida
                    MessageBox.Show("Falha ao desativar o produto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desativar o produto: " + ex.Message);
            }
        }


        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = openFileDialog.FileName;
                pictureBoxImgProd.Image = Image.FromFile(caminhoImagem);
            }
        }

        private void btnPrimeiroProduto_Click(object sender, EventArgs e)
        {
            if (totalProdutos > 0)
            {
                MostrarProduto(1); // Mostra o primeiro produto
            }
            else
            {
                MessageBox.Show("Não há produtos disponíveis.");
            }
        }

        private void btnAnteriorProduto_Click(object sender, EventArgs e)
        {
            if (indiceProdutoAtual > 0)
            {
                MostrarProduto(indiceProdutoAtual); // Mostra o produto anterior
            }
            else
            {
                MessageBox.Show("Você já está no primeiro produto.");
            }
        }

        private void btnProximoProduto_Click(object sender, EventArgs e)
        {
            if (indiceProdutoAtual < totalProdutos - 1)
            {
                indiceProdutoAtual++;
                MostrarProduto(indiceProdutoAtual + 1);
            }
            else
            {
                MessageBox.Show("Você já está no último produto.");
            }
        }

        private void btnUltimoProduto_Click(object sender, EventArgs e)
        {
            if (totalProdutos > 0)
            {
                int ultimoProdutoAtivo = ObterUltimoProdutoAtivo();
                if (ultimoProdutoAtivo > 0)
                {
                    MostrarProduto(ultimoProdutoAtivo); // Mostra o último produto ativo
                }
                else
                {
                    MessageBox.Show("Não há produtos ativos disponíveis.");
                }
            }
            else
            {
                MessageBox.Show("Não há produtos disponíveis.");
            }
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            LimparControlesFormulario();

            int proximoID = totalProdutos + 1;
            lblIDProduto.Text = "ID do produto: " + proximoID;

            kbcCategoriaProduto.SelectedIndex = 0;
            kbcUM.SelectedIndex = 0;
            pictureBoxImgProd.Image = null;

            btnConfirmarAdicao.Enabled = true;
            btnAtualizarProduto.Enabled = false;

            txtNomeProduto.Text = "Taiyaki";
            kbcCategoriaProduto.Text = "Sobremesas";
            txtPrecoProduto.Text = "0499";
            kbcUM.Text = "Unidade";
            txtDescricaoProduto.Text = "Waffle em forma de peixe recheado";
        }

        private void btnConfirmarAdicao_Click(object sender, EventArgs e)
        {
            btnAtualizarProduto.Enabled = true;
            btnConfirmarAdicao.Enabled = false;


            if (!CamposObrigatoriosPreenchidos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                string precoFormatado = ConverterPrecoParaBanco(txtPrecoProduto.Text);
                if (string.IsNullOrEmpty(precoFormatado))
                {
                    MessageBox.Show("Formato de preço inválido. Use o formato: R$ 10.99");
                    return;
                }

                int categoriaId = ObterCategoriaSelecionada();
                if (categoriaId < 0)
                {
                    MessageBox.Show("Selecione uma categoria válida.");
                    return;
                }

                byte[] imagemBytes = ObterBytesDaImagem(pictureBoxImgProd.Image);

                int linhasAfetadas = InserirProduto(
                    txtNomeProduto.Text,
                    txtDescricaoProduto.Text,
                    precoFormatado,
                    categoriaId,
                    kbcUM.Text,
                    imagemBytes
                );

                if (linhasAfetadas > 0)
                {
                    btnAdicionarProduto.Enabled = true;
                    btnConfirmarAdicao.Enabled = false;
                    MessageBox.Show("Novo produto inserido com sucesso.");
                    AtualizarTotalProdutos();
                    indiceProdutoAtual = 0; // Volte para o primeiro produto na lista
                    MostrarProduto(indiceProdutoAtual + 1);
                }
                else
                {
                    MessageBox.Show("Falha ao inserir o novo produto. Nenhuma linha afetada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir o produto: " + ex.Message);
            }
        }

        private void btnAtualizarProduto_Click(object sender, EventArgs e)
        {
            if (!CamposObrigatoriosPreenchidos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                string precoFormatado = ConverterPrecoParaBanco(txtPrecoProduto.Text);
                if (string.IsNullOrEmpty(precoFormatado))
                {
                    MessageBox.Show("Formato de preço inválido. Use o formato: R$ 00.00");
                    return;
                }

                int categoriaId = ObterCategoriaSelecionada();
                if (categoriaId < 0)
                {
                    MessageBox.Show("Selecione uma categoria válida.");
                    return;
                }

                byte[] imagemBytes = ObterBytesDaImagem(pictureBoxImgProd.Image);

                if (indiceProdutoAtual >= 0)
                {
                    int produtoId = ObterProdutoIdPeloIndice(indiceProdutoAtual);

                    int linhasAfetadas = AtualizarProduto(
                        produtoId,
                        txtNomeProduto.Text,
                        txtDescricaoProduto.Text,
                        precoFormatado,
                        categoriaId,
                        kbcUM.Text,
                        imagemBytes
                    );

                    if (linhasAfetadas == 1)
                    {
                        MessageBox.Show("Produto atualizado com sucesso.");
                        AtualizarTotalProdutos();
                        MostrarProduto(produtoId); // Atualize para mostrar o produto atualizado
                    }
                    else if (linhasAfetadas == 0)
                    {
                        MessageBox.Show("Nenhum produto atualizado. Verifique os valores fornecidos.");
                    }
                    else
                    {
                        MessageBox.Show("Falha ao atualizar o produto.");
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum produto selecionado para atualizar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o produto: " + ex.Message);
            }
        }

        private void txtPesquisaProduto_TextChanged(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisaProduto.Text;

            // Realize uma consulta no banco de dados para encontrar produtos que correspondam ao termoPesquisa
            DataTable resultadosPesquisa = PesquisarProdutosNoBanco(termoPesquisa);

            // Verifique se há resultados na pesquisa
            if (resultadosPesquisa.Rows.Count > 0)
            {
                // Se houver resultados, atualize os campos de inserção/atualização com os dados do primeiro resultado
                DataRow primeiroResultado = resultadosPesquisa.Rows[0];

                // Preencha os campos apropriados com os dados do primeiro resultado
                PreencherCamposComDadosDoProduto(primeiroResultado);
            }
            else
            {
                // Se não houver resultados, você pode limpar os campos de inserção/atualização ou fazer outra ação apropriada
                LimparCamposDeInsercaoAtualizacao();
            }

        }

        private void btnDesabilitarProduto_Click(object sender, EventArgs e)
        {
            if (indiceProdutoAtual >= 0)
            {
                int produtoId = ObterProdutoIdPeloIndice(indiceProdutoAtual);

                try
                {
                    DesativarProduto(produtoId);
                    // Atualize a lista de produtos após a desativação, se necessário
                    AtualizarListaDeProdutos();
                    // Atualize a exibição com o próximo produto após a desativação
                    if (indiceProdutoAtual < totalProdutos - 1)
                    {
                        MostrarProduto(indiceProdutoAtual + 1);
                    }
                    else
                    {
                        // Não há mais produtos disponíveis após a desativação
                        MessageBox.Show("Não há mais produtos disponíveis.");
                        LimparCamposDeInsercaoAtualizacao();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao desativar o produto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado para desativar.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
