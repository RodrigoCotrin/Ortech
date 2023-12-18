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
    public partial class FrmPedidos : KryptonForm
    {
        string query = "SELECT MAX(id_pedido) FROM Pedido";
        Conexao myconexao;
        Timer tmr = new Timer();
        public int codigoCount;
        public int ultimoIDpedido;

        public FrmPedidos()
        {
            InitializeComponent();
            myconexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
            tmr.Interval = 10000; //0,1 segundos
            tmr.Tick += controleChegadaPedido_Tick;
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            CriarComandasEmAberto();
            tmr.Start();
            ultimoIDpedido = myconexao.ExecutarConsultaScalar<int>(query);
        }

        private void controleChegadaPedido_Tick(object sender, EventArgs e)
        {
            // Consulte o banco de dados para verificar se há um novo registro
            int maxId = myconexao.ExecutarConsultaScalar<int>(query);

            if (maxId > ultimoIDpedido)
            {
                CriarComanda();
                //Incrementa 
                codigoCount++;
                // Atualize o último ID já processado para o novo ID
                ultimoIDpedido = maxId;
            }
        }

        private void Botao_Excluir_Click(Object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir o pedido?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Obtém o botão que foi clicado
                Button botao = (Button)sender;

                // Obtém o Panel pai do botão
                Panel panel = (Panel)botao.Parent;

                // Acesse o Panel interno dentro do Panel externo
                Panel panelInterno = panel.Controls.OfType<Panel>().FirstOrDefault();

                // Acesse o Label lblPedido dentro do Panel interno
                Label lblPedido = panelInterno.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("lblPedido"));


                // Verifique se o Label lblPedido foi encontrado
                if (lblPedido != null)
                {
                    // Acesse o texto do Label lblPedido
                    string textoPedido = lblPedido.Text;

                    // Use o texto do Label para remover os dados do banco de dados correspondentes ao ID do pedido
                    string deleteQuery = "DELETE FROM Pedido WHERE id_pedido = " + textoPedido;
                    myconexao.ExecutarConsulta(deleteQuery);
                }

                // Remove o Panel do seu controle pai
                panel.Parent.Controls.Remove(panel);
            }
        }

        private void Botao_Sinalizar_Pronto(Object sender, EventArgs e)
        {
            // Obtém botão clicado
            Button botao = (Button)sender;

            // Obtém o Panel pai do botão
            Panel panel = (Panel)botao.Parent;

            // Acesse o Panel interno dentro do Panel externo
            Panel panelInterno = panel.Controls.OfType<Panel>().FirstOrDefault();

            // Acesse o Label lblPedido dentro do Panel interno
            Label lblPedido = panelInterno.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("lblPedido"));

            // Verifique se o Label lblPedido foi encontrado
            if (lblPedido != null)
            {
                // Acesse o texto do Label lblPedido
                string textoPedido = lblPedido.Text;

                // Use o texto do Label para remover os dados do banco de dados correspondentes ao ID do pedido
                string deleteQuery = "UPDATE StatusPedido SET status_pedido = 'Pronto' WHERE id_pedido = " + textoPedido;
                myconexao.ExecutarConsulta(deleteQuery);
            }

            // Obtém o TableLayoutPanel atual
            TableLayoutPanel tabelaAtual = (TableLayoutPanel)panel.Parent;

            // Remove o Panel do TableLayoutPanel atual
            tabelaAtual.Controls.Remove(panel);
        }

        public void CriarComanda()
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            // painelPrincipal
            // 
            Panel painelPrincipal = new Panel();
            painelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            painelPrincipal.Location = new System.Drawing.Point(473, 46);
            painelPrincipal.Name = "painelPrincipal" + codigoCount;
            painelPrincipal.Size = new System.Drawing.Size(176, 274);
            painelPrincipal.TabIndex = 6;
            // 
            // btnExcluir
            // 
            Button btnExcluir = new Button();
            btnExcluir.BackColor = System.Drawing.Color.Red;
            btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnExcluir.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnExcluir.ForeColor = System.Drawing.Color.White;
            btnExcluir.Location = new System.Drawing.Point(91, 232);
            btnExcluir.Name = codigoCount.ToString();
            btnExcluir.Size = new System.Drawing.Size(80, 37);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += new System.EventHandler(this.Botao_Excluir_Click);
            painelPrincipal.Controls.Add(btnExcluir);
            // 
            // btnPronto
            // 
            Button btnPronto = new Button();
            btnPronto.BackColor = System.Drawing.Color.LimeGreen;
            btnPronto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnPronto.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnPronto.ForeColor = System.Drawing.Color.White;
            btnPronto.Location = new System.Drawing.Point(3, 232);
            btnPronto.Name = "btnPronto" + codigoCount;
            btnPronto.Size = new System.Drawing.Size(80, 37);
            btnPronto.TabIndex = 2;
            btnPronto.Text = "Pronto";
            btnPronto.UseVisualStyleBackColor = false;
            btnPronto.Click += new System.EventHandler(this.Botao_Sinalizar_Pronto);
            painelPrincipal.Controls.Add(btnPronto);
            // 
            // lstProdutos
            // 
            ListView lstProdutos = new ListView();
            lstProdutos.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lstProdutos.HideSelection = false;
            lstProdutos.Location = new System.Drawing.Point(0, 42);
            lstProdutos.Name = "lstProdutos" + codigoCount;
            lstProdutos.Size = new System.Drawing.Size(174, 186);
            lstProdutos.TabIndex = 1;
            lstProdutos.Enabled = false;
            lstProdutos.AutoArrange = true;
            lstProdutos.UseCompatibleStateImageBehavior = false;
            lstProdutos.View = System.Windows.Forms.View.Details;
            // Adicionar colunas ao ListView
            lstProdutos.Columns.Add("", 30); // Adicionar coluna "" 
            lstProdutos.Columns.Add("Nome", 140); // Adicionar coluna "Nome" 
                                                  //CONSULTA (SOMENTE NOME E QUANTIDADE)
            string produtos = "SELECT p.nome_produto, dp.quantidade_produto\r\nFROM Pedido pe" +
               "\r\nINNER JOIN DetalhesPedido dp ON pe.id_pedido = dp.id_pedido" +
               "\r\nINNER JOIN Produtos p ON p.id_produto = dp.id_produto" +
               "\r\nWHERE pe.id_pedido = (SELECT MAX(id_pedido) FROM Pedido)" +
               "\r\nORDER BY dp.id_pedido DESC;";
            //ARMAZENA CONSULTA
            dt = myconexao.ExecutarConsulta(produtos);
            //
            foreach (DataRow row in dt.Rows)
            {
                string quantidadeProduto = row["quantidade_produto"].ToString();
                string nomeProduto = row["nome_produto"].ToString();

                ListViewItem item = new ListViewItem(quantidadeProduto);
                item.SubItems.Add(nomeProduto);

                lstProdutos.Items.Add(item);
            }
            painelPrincipal.Controls.Add(lstProdutos);

            // 
            // paineldecima
            // 
            Panel paineldecima = new Panel();
            paineldecima.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            paineldecima.BackColor = System.Drawing.SystemColors.HotTrack;
            paineldecima.Location = new System.Drawing.Point(0, 0);
            paineldecima.Name = "paineldecima" + codigoCount;
            paineldecima.Size = new System.Drawing.Size(174, 44);
            paineldecima.TabIndex = 0;
            painelPrincipal.Controls.Add(paineldecima);
            // 
            // label4
            // 
            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Yu Gothic UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(82, 2);
            label4.Name = "label4" + codigoCount;
            label4.Size = new System.Drawing.Size(17, 28);
            label4.TabIndex = 3;
            label4.ForeColor = Color.White;
            label4.Text = "|";
            // 
            // lblPedido
            // 
            Label lblPedido = new Label();
            lblPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lblPedido.AutoSize = true;
            lblPedido.BackColor = System.Drawing.SystemColors.HotTrack;
            lblPedido.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPedido.Location = new System.Drawing.Point(115, 17);
            lblPedido.Name = "lblPedido";
            lblPedido.ForeColor = Color.White;
            lblPedido.Size = new System.Drawing.Size(27, 20);
            lblPedido.TabIndex = 2;
            //
            string consulta_pedido = "Select id_pedido from Pedido where id_pedido = (SELECT MAX(id_pedido) FROM Pedido)";
            dt1 = myconexao.ExecutarConsulta(consulta_pedido);
            string pedido = dt1.Rows[0][0].ToString();
            //
            lblPedido.Text = pedido;
            paineldecima.Controls.Add(lblPedido);
            // 
            // label2
            // 
            Label label2 = new Label();
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.HotTrack;
            label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(105, 0);
            label2.Name = "label2" + codigoCount;
            label2.Size = new System.Drawing.Size(54, 17);
            label2.TabIndex = 1;
            label2.ForeColor = Color.White;
            label2.Text = "Pedido ";
            paineldecima.Controls.Add(label2);
            // 
            // lblMesa
            // 
            Label lblMesa = new Label();
            lblMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lblMesa.AutoSize = true;
            lblMesa.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblMesa.Location = new System.Drawing.Point(3, 9);
            lblMesa.Name = "lblMesa" + codigoCount;
            lblMesa.ForeColor = Color.White;
            lblMesa.Size = new System.Drawing.Size(63, 20);
            lblMesa.TabIndex = 0;
            //
            string consulta_mesa = "Select numero_mesa from Pedido where id_pedido = (SELECT MAX(id_pedido) FROM Pedido)";
            dt1 = myconexao.ExecutarConsulta(consulta_mesa);
            string mesa = dt1.Rows[0][0].ToString();
            //
            lblMesa.Text = "Mesa " + mesa;
            paineldecima.Controls.Add(lblMesa);

            chegadaPedido.Controls.Add(painelPrincipal);
        }
        public void CriarComandasEmAberto()
        {
            chegadaPedido.Controls.Clear();

            // Consulta os dados do banco de dados
            string produtosQuery = "SELECT pe.id_pedido, pe.numero_mesa, p.nome_produto, dp.quantidade_produto " +
                       "FROM Pedido pe " +
                       "INNER JOIN DetalhesPedido dp ON pe.id_pedido = dp.id_pedido " +
                       "INNER JOIN Produtos p ON p.id_produto = dp.id_produto " +
                       "INNER JOIN StatusPedido sp ON pe.id_pedido = sp.id_pedido " +
                       "WHERE sp.status_pedido = 'Em Preparo' " +
                       "ORDER BY pe.id_pedido ASC";

            DataTable produtosData = myconexao.ExecutarConsulta(produtosQuery);

            // Cria um dicionário para armazenar os grupos de produtos por ID do pedido
            Dictionary<int, List<(string, int)>> gruposProdutos = new Dictionary<int, List<(string, int)>>();

            // Agrupa os produtos por ID do pedido
            foreach (DataRow row in produtosData.Rows)
            {
                // Extrai os dados da linha atual
                int idPedido = Convert.ToInt32(row["id_pedido"]);
                string nomeProduto = row["nome_produto"].ToString();
                int quantidadeProduto = Convert.ToInt32(row["quantidade_produto"]);

                // Verifica se o ID do pedido já existe no dicionário
                if (gruposProdutos.ContainsKey(idPedido))
                {
                    // Adiciona o produto e a quantidade ao grupo existente
                    gruposProdutos[idPedido].Add((nomeProduto, quantidadeProduto));
                }
                else
                {
                    // Cria um novo grupo para o ID do pedido e adiciona o produto e a quantidade
                    gruposProdutos[idPedido] = new List<(string, int)> { (nomeProduto, quantidadeProduto) };
                }
            }

            // Cria os painéis com os grupos de produtos
            foreach (var grupo in gruposProdutos)
            {
                int idPedido = grupo.Key;
                List<(string, int)> produtos = grupo.Value;

                Panel painelPrincipal = new Panel();
                // Configurar as propriedades do painel
                painelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                painelPrincipal.Size = new System.Drawing.Size(176, 274);
                painelPrincipal.Name = "painelPrincipal" + idPedido;

                // Criação do listview
                ListView lstProdutos = new ListView();
                lstProdutos.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lstProdutos.HideSelection = false;
                lstProdutos.Location = new System.Drawing.Point(0, 42);
                lstProdutos.Name = "lstProdutos" + idPedido;
                lstProdutos.Size = new System.Drawing.Size(174, 186);
                lstProdutos.TabIndex = 1;
                lstProdutos.UseCompatibleStateImageBehavior = false;
                lstProdutos.View = System.Windows.Forms.View.Details;
                lstProdutos.Enabled = false;
                lstProdutos.AutoArrange = true;
                // Adicionar colunas ao ListView
                lstProdutos.Columns.Add("", 30); // Adicionar coluna "" 
                lstProdutos.Columns.Add("Nome", 140); // Adicionar coluna "Nome" 
                // Adicionar os produtos ao ListView
                foreach ((string produto, int quantidade) in produtos)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = quantidade.ToString(); // Coluna "Quantidade"
                    item.SubItems.Add(produto); // Coluna "Nome"

                    lstProdutos.Items.Add(item);
                }
                painelPrincipal.Controls.Add(lstProdutos);

                // paineldecima
                Panel paineldecima = new Panel();
                paineldecima.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                paineldecima.BackColor = System.Drawing.SystemColors.HotTrack;
                paineldecima.Location = new System.Drawing.Point(0, 0);
                paineldecima.Name = "paineldecima" + idPedido;
                paineldecima.Size = new System.Drawing.Size(174, 44);
                paineldecima.TabIndex = 0;
                //adição ao painel
                painelPrincipal.Controls.Add(paineldecima);

                // lblPedido
                Label lblPedido = new Label();
                lblPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                lblPedido.AutoSize = true;
                lblPedido.ForeColor = Color.White;
                lblPedido.BackColor = System.Drawing.SystemColors.HotTrack;
                lblPedido.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblPedido.Location = new System.Drawing.Point(115, 17);
                lblPedido.Name = "lblPedido";
                lblPedido.Size = new System.Drawing.Size(27, 20);
                lblPedido.TabIndex = 2;
                lblPedido.Text = idPedido.ToString();//busca com a lista acima
                //adição ao painel
                paineldecima.Controls.Add(lblPedido);

                // lblMesa
                Label lblMesa = new Label();
                lblMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                lblMesa.AutoSize = true;
                lblMesa.ForeColor = Color.White;
                lblMesa.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblMesa.Location = new System.Drawing.Point(3, 9);
                lblMesa.Name = "lblMesa" + idPedido;
                //consulta do numero da mesa
                string consulta_mesa = "SELECT numero_mesa FROM Pedido WHERE id_pedido = " + idPedido;
                DataTable dtMesa = myconexao.ExecutarConsulta(consulta_mesa);
                string mesa = dtMesa.Rows[0]["numero_mesa"].ToString();
                //
                lblMesa.Text = "Mesa " + mesa;
                lblMesa.Size = new System.Drawing.Size(63, 20);
                lblMesa.TabIndex = 0;
                //adição ao painel
                paineldecima.Controls.Add(lblMesa);

                // Pedido
                Label label2 = new Label();
                label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                label2.AutoSize = true;
                label2.ForeColor = Color.White;
                label2.BackColor = System.Drawing.SystemColors.HotTrack;
                label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
                label2.Location = new System.Drawing.Point(105, 0);
                label2.Name = "label2" + codigoCount;
                label2.Size = new System.Drawing.Size(54, 17);
                label2.TabIndex = 1;
                label2.Text = "Pedido ";
                //adição ao painel
                paineldecima.Controls.Add(label2);

                // Divisão
                // 
                Label label4 = new Label();
                label4.AutoSize = true;
                label4.ForeColor = Color.White;
                label4.Font = new System.Drawing.Font("Yu Gothic UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label4.Location = new System.Drawing.Point(82, 2);
                label4.Name = "label4" + codigoCount;
                label4.Size = new System.Drawing.Size(17, 28);
                label4.TabIndex = 3;
                label4.Text = "|";

                // btnExcluir
                // 
                Button btnExcluir = new Button();
                btnExcluir.BackColor = System.Drawing.Color.Red;
                btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                btnExcluir.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnExcluir.ForeColor = System.Drawing.Color.White;
                btnExcluir.Location = new System.Drawing.Point(91, 232);
                btnExcluir.Name = codigoCount.ToString();
                btnExcluir.Size = new System.Drawing.Size(80, 37);
                btnExcluir.TabIndex = 3;
                btnExcluir.Text = "Excluir";
                btnExcluir.UseVisualStyleBackColor = false;
                btnExcluir.Click += new System.EventHandler(this.Botao_Excluir_Click);
                painelPrincipal.Controls.Add(btnExcluir);
                // 
                // btnPronto
                // 
                Button btnPronto = new Button();
                btnPronto.BackColor = System.Drawing.Color.LimeGreen;
                btnPronto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                btnPronto.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPronto.ForeColor = System.Drawing.Color.White;
                btnPronto.Location = new System.Drawing.Point(3, 232);
                btnPronto.Name = "btnPronto" + codigoCount;
                btnPronto.Size = new System.Drawing.Size(80, 37);
                btnPronto.TabIndex = 2;
                btnPronto.Text = "Pronto";
                btnPronto.UseVisualStyleBackColor = false;
                btnPronto.Click += new System.EventHandler(this.Botao_Sinalizar_Pronto);
                painelPrincipal.Controls.Add(btnPronto);
                //adição ao painel
                painelPrincipal.Controls.Add(btnExcluir);

                //adicionar ao table
                chegadaPedido.Controls.Add(painelPrincipal);
            }
        }
    }
}
