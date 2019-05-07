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

            var CarrosEncontrados = RetornarDataTable(comando);
            List<Carro> listaCarros = new List<Carro>();

            foreach (DataRow row in CarrosEncontrados.Rows)
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

        public List<Carro> ConsultarCarrosPorNome(string busca)
        {
            string sql = "select * from carro where descricao like @nome";

            MySqlCommand comando = new MySqlCommand(sql);
            comando.Parameters.Add(new MySqlParameter("nome", "%" + busca + "%"));

            var CarrosEncontrados = RetornarDataTable(comando);
            List<Carro> listaCarros = new List<Carro>();

            foreach (DataRow row in CarrosEncontrados.Rows)
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