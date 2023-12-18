using System;
using System.Data;
using System.Data.SqlClient;

public class Conexao
{
    private string connectionString;
    private SqlConnection connection;

    public Conexao(string server, string database, string username, string password)
    {
        // Criação da string de conexão
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = server;
        builder.InitialCatalog = database;
        builder.UserID = username;
        builder.Password = password;

        connectionString = builder.ConnectionString;
    }

    public void AbrirConexao()
    {
        // Criação da conexão
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public void FecharConexao()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public DataTable ExecutarConsulta(string query)
    {
        DataTable dataTable = new DataTable();

        try
        {
            AbrirConexao();

            // Criação do comando e execução da consulta
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            // Preenchimento do DataTable com os resultados
            dataTable.Load(reader);

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar consulta: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return dataTable;
    }

    public int ExecutarComando(string procedureName, SqlParameter[] parameters)
    {
        int rowsAffected = 0;

        try
        {
            AbrirConexao();

            // Criação do comando e execução do comando
            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Adicionar os parâmetros ao comando
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            rowsAffected = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar comando: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return rowsAffected;
    }


    public T ExecutarConsultaScalar<T>(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
            {
                return default(T);
            }
            }
        }
    }

    public int AtualizarImagemDoProduto(string nomeProduto, byte[] imagemBytes)
    {
        int rowsAffected = 0;

        try
        {
            AbrirConexao();

            // Criação do comando e execução do comando
            string query = "UPDATE Produtos SET img_prato = @imagem WHERE nome_produto = @nome";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@imagem", imagemBytes);
            command.Parameters.AddWithValue("@nome", nomeProduto);

            rowsAffected = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar imagem do produto: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return rowsAffected;
    }
    public int AtualizarImagemDoFunc(string nomeProduto, byte[] imagemBytes)
    {
        int rowsAffected = 0;

        try
        {
            AbrirConexao();

            // Criação do comando e execução do comando
            string query = "UPDATE Funcionario SET img_func = @img_func WHERE cpf = @cpf";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@img_func", imagemBytes);
            command.Parameters.AddWithValue("@cpf", nomeProduto);

            rowsAffected = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar imagem do Funcionario: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return rowsAffected;
    }
}
