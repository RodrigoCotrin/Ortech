using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        try
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao abrir conexão: " + ex.Message);
        }
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

    public DataTable ExecutarConsultaParametros(string query, SqlParameter[] parametros)
    {
        DataTable dataTable = new DataTable();

        try
        {
            AbrirConexao();

            // Criação do comando e execução da consulta
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;

            if (parametros != null)
            {
                command.Parameters.AddRange(parametros);
            }

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

    public string ExecutarComandoScalar(string procedureName, SqlParameter[] parameters)
    {
        string result = null;

        try
        {
            AbrirConexao();

            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            object scalarResult = command.ExecuteScalar();
            if (scalarResult != null)
            {
                result = scalarResult.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar comando: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return result;
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

    public T ExecutarConsultaScalarG<T>(string query, SqlParameter[] parametros)
    {
        T result = default(T);

        try
        {
            AbrirConexao();

            // Criação do comando e execução da consulta
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;

            if (parametros != null)
            {
                command.Parameters.AddRange(parametros);
            }

            object scalarResult = command.ExecuteScalar();
            if (scalarResult != null && scalarResult != DBNull.Value)
            {
                result = (T)Convert.ChangeType(scalarResult, typeof(T));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar consulta scalar: " + ex.Message);
            // Trate qualquer exceção aqui ou adicione um log
        }
        finally
        {
            FecharConexao();
        }

        return result;
    }


    public T ExecutarComandoScalarG<T>(string query, SqlParameter[] parametros = null)
    {
        T result = default(T);

        try
        {
            AbrirConexao();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parametros != null)
                {
                    command.Parameters.AddRange(parametros);
                }

                object scalarResult = command.ExecuteScalar();

                if (scalarResult != null && scalarResult != DBNull.Value)
                {
                    result = (T)Convert.ChangeType(scalarResult, typeof(T));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar comando: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return result;
    }

    public int ExecutarAtualizacao(string query, SqlParameter[] parametros)
    {
        int linhasAfetadas = 0;

        try
        {
            AbrirConexao();

            // Criação do comando e execução da consulta de atualização
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;

            if (parametros != null)
            {
                command.Parameters.AddRange(parametros);
            }

            linhasAfetadas = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {   
            Console.WriteLine("Erro ao executar consulta de atualização: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return linhasAfetadas;
    }

    public int ExecutarComandoComImagem(string query, SqlParameter[] parametros)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    // Adicione os parâmetros fornecidos à consulta SQL
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }

                    int linhasAfetadas = command.ExecuteNonQuery();
                    return linhasAfetadas;
                }
                catch (Exception ex)
                {
                    // Trate qualquer exceção aqui
                    throw ex;
                }
            }
        }
    }
    public int ExecutarComandoParametro(string comandoSQL)
    {
        int linhasAfetadas = 0;

        try
        {
            AbrirConexao();

            using (SqlCommand command = new SqlCommand(comandoSQL, connection))
            {
                linhasAfetadas = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar comando SQL: " + ex.Message);
        }
        finally
        {
            FecharConexao();
        }

        return linhasAfetadas;
    }

}