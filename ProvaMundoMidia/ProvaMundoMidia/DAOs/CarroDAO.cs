using MySql.Data.MySqlClient;
using ProvaMundoMidia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProvaMundoMidia.DAOs
{
    public class CarroDAO : BaseDAO<Carro>
    {
        public override void Alterar(Carro obj)
        {
            string sql = "update carro set descricao = @descricao, modelo = @modelo, ano = @ano where id_carro = @idCarro";

            Executar(sql, obj, "Alterar");
        }

        public override void Excluir(Carro obj)
        {
            string sql = "delete from carro where id_carro = @idCarro";

            Executar(sql, obj, "Excluir");
        }

        public override void Inserir(Carro obj)
        {
            string sql = "insert into carro (id_carro, descricao, modelo, ano) values (@idCarro, @descricao, @modelo, @ano)";

            Executar(sql, obj, "Inserir");
        }

        public override List<Carro> RetornarTodos()
        {
            string sql = "select * from carro order by descricao";

            MySqlCommand comando = new MySqlCommand(sql);

            var carrosEncontrados = RetornarDataTable(comando);
            List<Carro> listaCarros = new List<Carro>();

            foreach (DataRow row in carrosEncontrados.Rows)
            {
                Carro carro = new Carro
                {
                    IdCarro = Convert.ToInt32(row["id_carro"]),
                    Descricao = row["descricao"].ToString(),
                    Modelo = row["modelo"].ToString(),
                    Ano = Convert.ToInt32(row["ano"])
                };

                listaCarros.Add(carro);
            }

            return listaCarros;
        }

        public Carro BuscarCarroPorId(int id)
        {
            string sql = "select * from carro where id_carro = @idCarro";
            MySqlCommand comando = new MySqlCommand(sql);
            comando.Parameters.Add(new MySqlParameter("idCarro", id));

            DataRow carroEncontrado = RetornarDataTable(comando).Rows[0];

            if (carroEncontrado != null)
            {
                Carro carro = new Carro
                {
                    IdCarro = Convert.ToInt32(carroEncontrado["id_carro"]),
                    Descricao = carroEncontrado["descricao"].ToString(),
                    Modelo = carroEncontrado["modelo"].ToString(),
                    Ano = Convert.ToInt32(carroEncontrado["ano"])
                };

                return carro;
            }
            return null;
            
        }

        public List<Carro> BuscarCarrosPorDescricaoEModelo(string descricaoBusca, string modeloBusca, int anoBusca)
        {
            string sql = "select * from carro";

            if (!string.IsNullOrEmpty(descricaoBusca) && !string.IsNullOrEmpty(modeloBusca) && anoBusca != -1)
            {
                sql += " where descricao like @descricao and modelo like @modelo and ano = @ano";
            }
            else if (!string.IsNullOrEmpty(descricaoBusca))
            {
                sql += " where descricao like @descricao";
            }
            else if (!string.IsNullOrEmpty(modeloBusca))
            {
                sql += " where modelo like @modelo";
            }
            else if (anoBusca != -1)
            {
                sql += " where ano = @ano";
            }

            sql += " order by descricao";

            MySqlCommand comando = new MySqlCommand(sql);
            comando.Parameters.Add(new MySqlParameter("descricao", "%" + descricaoBusca + "%"));
            comando.Parameters.Add(new MySqlParameter("modelo", "%" + modeloBusca + "%"));
            comando.Parameters.Add(new MySqlParameter("ano", anoBusca));

            var carrosEncontrados = RetornarDataTable(comando);
            List<Carro> listaCarros = new List<Carro>();

            foreach (DataRow row in carrosEncontrados.Rows)
            {
                Carro carro = new Carro
                {
                    IdCarro = Convert.ToInt32(row["id_carro"]),
                    Descricao = row["descricao"].ToString(),
                    Modelo = row["modelo"].ToString(),
                    Ano = Convert.ToInt32(row["ano"])
                };

                listaCarros.Add(carro);
            }

            return listaCarros;
        }

        private void Executar(string sql, Carro obj, string funcao)
        {
            MySqlCommand comando = new MySqlCommand(sql);
            comando.Parameters.Add(new MySqlParameter("idCarro", obj.IdCarro));
            if (funcao == "Inserir" || funcao == "Alterar")
            {
                comando.Parameters.Add(new MySqlParameter("descricao", obj.Descricao));
                comando.Parameters.Add(new MySqlParameter("modelo", obj.Modelo));
                comando.Parameters.Add(new MySqlParameter("ano", obj.Ano));
            }

            ExecutarComando(comando);
        }        
    }
}