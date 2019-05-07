using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ProvaMundoMidia.DAOs
{
    public abstract class BaseDAO<T>
    {
        public abstract void Inserir(T obj);
        public abstract void Alterar(T obj);
        public abstract void Excluir(T obj);
        public abstract List<T> RetornarTodos();

        public void ExecutarComando(MySqlCommand cmd)
        {
            using (MySqlConnection conexao = RetornarConexao())
            {
                conexao.Open();

                try
                {
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        public void ExecutarComandos(List<MySqlCommand> comandos)
        {
            using (MySqlConnection conexao = RetornarConexao())
            {
                conexao.Open();

                MySqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    foreach (var cmd in comandos)
                    {
                        cmd.Connection = conexao;
                        cmd.Transaction = transacao;
                        cmd.ExecuteNonQuery();
                    }

                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        public DataTable RetornarDataTable(MySqlCommand cmd)
        {
            using (MySqlConnection conexao = RetornarConexao())
            {

                conexao.Open();

                try
                {
                    cmd.Connection = conexao;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    var dt = new DataTable();

                    da.Fill(dt);

                    return dt;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        public MySqlConnection RetornarConexao()
        {
            var conexaoString = ConfigurationManager.ConnectionStrings["ProvaMundoMidiaBD"].ConnectionString;
            return new MySqlConnection(conexaoString);
        }

        //private string RetornarStringConexao()
        //{
        //    return "SERVER=localhost;" +
        //            "DATABASE=prova_mundo_midia_db;" +
        //            "UID=root;" +
        //            "PASSWORD=root;";
        //}
    }
}