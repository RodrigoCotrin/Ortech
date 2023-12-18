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
using ComponentFactory.Krypton.Toolkit;


namespace TCC_appDesktopHRC.Telas
{
    public partial class FrmLogin : KryptonForm
    {
        Conexao conexao = new Conexao(Environment.MachineName, "hot_rolls_club", "sa", "120612");
        public static Image ImagemFuncionario { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
        }

        private void pictureBoxOlhoN_Click(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
            pictureBoxOlhoN.Visible = false;
            pictureBoxOlhoE.Visible = true;
        }

        private void pictureBoxOlhoE_Click(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
            pictureBoxOlhoE.Visible = false;
            pictureBoxOlhoN.Visible = true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nomeProcedure = "usp_loginFunc";
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            string dt;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@email", email),
                new SqlParameter("@senha", senha)
            };

            dt = conexao.ExecutarComandoScalar(nomeProcedure, parametros);

            if (dt.Equals("Login aceito"))
            {
                string queryInfosFunc = "SELECT nome, img_func FROM Funcionario WHERE email = @email";
                SqlParameter[] parametrosConsulta = new SqlParameter[]
                {
                    new SqlParameter("@email", email)
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
                            ImagemFuncionario = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        ImagemFuncionario = Properties.Resources.ImagemAusente;
                    }

                    string nomeFuncionario = dtInfosFunc.Rows[0]["nome"].ToString();
                    this.Hide();
                    FrmInicial frmInicial = new FrmInicial();
                    frmInicial.SetInfosFunc(nomeFuncionario);
                    frmInicial.Show();
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o nome do funcionário.");
                }
            }
            else
            {
                MessageBox.Show("Email ou senha inválidos.", "ERRO!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "admin@gmail.com";
            txtSenha.Text = "111111111";
        }
    }
}
