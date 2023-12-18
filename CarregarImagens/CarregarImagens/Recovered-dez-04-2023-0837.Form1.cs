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

namespace CarregarImagens
{
    public partial class Form1 : Form
    {
        Conexao conexao;
        string diretorio = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
            /*conexao = new Conexao("", "", "", "");
            string caminho = "C:\\Users\\Pichau\\source\\repos\\CarregarImagens\\CarregarImagens\\imgs\\agua.jpg";


            byte[] imagemBytes = File.ReadAllBytes(caminho);
            conexao.AtualizarImagemDoProduto("Agua", imagemBytes);*/

        }

        private void button1_Click(object sender, EventArgs e)
        {

            conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "etesp");

            string caminhoDaagua = Path.Combine(diretorio, "..\\..\\imgs", "agua.jpg");

            byte[] imagemAgua = File.ReadAllBytes(caminhoDaagua);
            conexao.AtualizarImagemDoProduto("Água Mineral", imagemAgua);
            /////////////////////////////////////////////////////////////////////////////
            string caminhoDacerveja = Path.Combine(diretorio, "..\\..\\imgs", "cerveja.jpg");

            byte[] imagemCerveja = File.ReadAllBytes(caminhoDacerveja);
            conexao.AtualizarImagemDoProduto("Cerveja", imagemCerveja);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaChaVerde = Path.Combine(diretorio, "..\\..\\imgs", "chaverde.jpg");

            byte[] imagemDaChaVerde = File.ReadAllBytes(caminhoDaChaVerde);
            conexao.AtualizarImagemDoProduto("Chá Verde", imagemDaChaVerde);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaCoqueteldeFrutas = Path.Combine(diretorio, "..\\..\\imgs", "coqueteldefrutas.jpg");

            byte[] imagemDaCoqueteldeFrutas = File.ReadAllBytes(caminhoDaCoqueteldeFrutas);
            conexao.AtualizarImagemDoProduto("Coquetel de Frutas", imagemDaCoqueteldeFrutas);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaDoburri = Path.Combine(diretorio, "..\\..\\imgs", "doburridesalmao.jpg");

            byte[] imagemDaDoburri = File.ReadAllBytes(caminhoDaDoburri);
            conexao.AtualizarImagemDoProduto("Donburi de Salmão", imagemDaDoburri);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaGyoza = Path.Combine(diretorio, "..\\..\\imgs", "gyoza.jpg");

            byte[] imagemDaGyoza = File.ReadAllBytes(caminhoDaGyoza);
            conexao.AtualizarImagemDoProduto("Gyoza", imagemDaGyoza);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaGyudon = Path.Combine(diretorio, "..\\..\\imgs", "gyudon.jpg");

            byte[] imagemDaGyudon = File.ReadAllBytes(caminhoDaGyudon);
            conexao.AtualizarImagemDoProduto("Gyudon", imagemDaGyudon);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaHotRoll = Path.Combine(diretorio, "..\\..\\imgs", "hotRoll.jpg");

            byte[] imagemDaHotRoll = File.ReadAllBytes(caminhoDaHotRoll);
            conexao.AtualizarImagemDoProduto("Hot Roll", imagemDaHotRoll);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDarefrigerante = Path.Combine(diretorio, "..\\..\\imgs", "refrigerante.jpg");

            byte[] imagemDarefrigerante = File.ReadAllBytes(caminhoDarefrigerante);
            conexao.AtualizarImagemDoProduto("Refrigerante", imagemDarefrigerante);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaRobata = Path.Combine(diretorio, "..\\..\\imgs", "robata.jpg");

            byte[] imagemDaRobata = File.ReadAllBytes(caminhoDaRobata);
            conexao.AtualizarImagemDoProduto("Robata", imagemDaRobata);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaRobatadeFrango = Path.Combine(diretorio, "..\\..\\imgs", "robatadefrango.jpg");

            byte[] imagemDaRobatadeFrango = File.ReadAllBytes(caminhoDaRobatadeFrango);
            conexao.AtualizarImagemDoProduto("Robata de Frango", imagemDaRobatadeFrango);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaSaque = Path.Combine(diretorio, "..\\..\\imgs", "saque.jpg");

            byte[] imagemDaSaque = File.ReadAllBytes(caminhoDaSaque);
            conexao.AtualizarImagemDoProduto("Saquê", imagemDaSaque);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaSashimi = Path.Combine(diretorio, "..\\..\\imgs", "sashimi.jpg");

            byte[] imagemDaSashimi = File.ReadAllBytes(caminhoDaSashimi);
            conexao.AtualizarImagemDoProduto("Sashimi de Salmão", imagemDaSashimi);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaSushi = Path.Combine(diretorio, "..\\..\\imgs", "sushi.jpg");

            byte[] imagemDaSushi = File.ReadAllBytes(caminhoDaSushi);
            conexao.AtualizarImagemDoProduto("Sushi Misto", imagemDaSushi);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDaTataki = Path.Combine(diretorio, "..\\..\\imgs", "tatakidesalmao.jpg");

            byte[] imagemDaTataki = File.ReadAllBytes(caminhoDaTataki);
            conexao.AtualizarImagemDoProduto("Tataki de Salmão", imagemDaTataki);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDatemaki = Path.Combine(diretorio, "..\\..\\imgs", "temaki.jpg");

            byte[] imagemDatemaki = File.ReadAllBytes(caminhoDatemaki);
            conexao.AtualizarImagemDoProduto("Temaki", imagemDatemaki);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDatemakidesalmao = Path.Combine(diretorio, "..\\..\\imgs", "temakidesalmao.jpg");

            byte[] imagemDatemakidesalmao = File.ReadAllBytes(caminhoDatemakidesalmao);
            conexao.AtualizarImagemDoProduto("Temaki de Atum", imagemDatemakidesalmao);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDatofufrito = Path.Combine(diretorio, "..\\..\\imgs", "tofufrito.jpg");

            byte[] imagemDatofufrito = File.ReadAllBytes(caminhoDatofufrito);
            conexao.AtualizarImagemDoProduto("Tofu Frito", imagemDatofufrito);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDayakissobadefrango = Path.Combine(diretorio, "..\\..\\imgs", "yakissobadefrango.jpg");

            byte[] imagemDayakissobadefrango = File.ReadAllBytes(caminhoDayakissobadefrango);
            conexao.AtualizarImagemDoProduto("Yakisoba de Frango", imagemDayakissobadefrango);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDayakissobatradicional = Path.Combine(diretorio, "..\\..\\imgs", "yakissobatradicional.jpg");

            byte[] imagemDayakissobatradicional = File.ReadAllBytes(caminhoDayakissobatradicional);
            conexao.AtualizarImagemDoProduto("Yakisoba Tradicional", imagemDayakissobatradicional);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDayakitori = Path.Combine(diretorio, "..\\..\\imgs", "yakissobatradicional.jpg");

            byte[] imagemDayakitori = File.ReadAllBytes(caminhoDayakitori);
            conexao.AtualizarImagemDoProduto("Yakitori", imagemDayakitori);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDayakissobadelegumes = Path.Combine(diretorio, "..\\..\\imgs", "yakissobadelegumes.jpg");

            byte[] imagemDayakissobadelegumes = File.ReadAllBytes(caminhoDayakissobadelegumes);
            conexao.AtualizarImagemDoProduto("Yakisoba de Legumes", imagemDayakissobadelegumes);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDatempuradecamarao = Path.Combine(diretorio, "..\\..\\imgs", "tempuradesalmao.jpg");

            byte[] imagemDatempuradecamarao = File.ReadAllBytes(caminhoDatempuradecamarao);
            conexao.AtualizarImagemDoProduto("Tempurá de Camarão", imagemDatempuradecamarao);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDafrangoteryaki = Path.Combine(diretorio, "..\\..\\imgs", "frangoteryaki.jpg");

            byte[] imagemDafrangoteryaki = File.ReadAllBytes(caminhoDafrangoteryaki);
            conexao.AtualizarImagemDoProduto("Frango Teriyaki", imagemDafrangoteryaki);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDanigirisushisalmao = Path.Combine(diretorio, "..\\..\\imgs", "nigirisushisalmao.jpg");

            byte[] imagemDanigirisushisalmao = File.ReadAllBytes(caminhoDanigirisushisalmao);
            conexao.AtualizarImagemDoProduto("Nigiri Sushi de Salmão", imagemDanigirisushisalmao);

            /////////////////////////////////////////////////////////////////////////////
            string caminhoDasunomono = Path.Combine(diretorio, "..\\..\\imgs", "sunomono.jpg");

            byte[] imagemDasunomono = File.ReadAllBytes(caminhoDasunomono);
            conexao.AtualizarImagemDoProduto("Sunomono", imagemDasunomono);
            /////////////////////////////////////////////////////////////////////////////
            string caminhoMochi = Path.Combine(diretorio, "..\\..\\imgs", "mochi.jpg");

            byte[] imagemMochi = File.ReadAllBytes(caminhoMochi);
            conexao.AtualizarImagemDoProduto("Mochi", imagemMochi);
            /////////////////////////////////////////////////////////////////////////////
            string caminhoDorayaki = Path.Combine(diretorio, "..\\..\\imgs", "dorayaki.jpg");

            byte[] imagemDorayaki = File.ReadAllBytes(caminhoDorayaki);
            conexao.AtualizarImagemDoProduto("Dorayaki", imagemDorayaki);
            /////////////////////////////////////////////////////////////////////////////
            string caminhoTaiyaki = Path.Combine(diretorio, "..\\..\\imgs", "taiyaki.jpg");

            byte[] imagemTaiyaki = File.ReadAllBytes(caminhoTaiyaki);
            conexao.AtualizarImagemDoProduto("Taiyaki", imagemTaiyaki);

        }
        
    }
}

