using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TecnicoCRUD
    {
        // Receber Conexão da Tela que enviar
        private readonly string _conexao;

        // Receber a variavel Conexão e colocar o valor
        public TecnicoCRUD(string conexao)
        {
            _conexao = conexao;
        }

        // Inclui no banco de dados
        public void IncluiTecnico(Tecnico tecnico)
        {
            // Query para inserir algo com SQL no Banco de dados
            const string query = @"INSERT INTO Tecnicos(Nome,Especializacao,telefone)
                               Values(@Nome, @Especializacao, @Telefone)";


            // Bloco para tratar possiveis erros ao inserir e exibir mensagens
            try
            {
                //Criação de uma conexão com o banco de dados 
                using (var conexaoBd = new SqlConnection(_conexao))
                // Transformo a Query em comando SQL
                using (var comandoSql = new SqlCommand(query, conexaoBd))
                {
                    comandoSql.Parameters.AddWithValue("@Nome", tecnico.nome);
                    comandoSql.Parameters.AddWithValue("@Especializacao", tecnico.especializacao);
                    comandoSql.Parameters.AddWithValue("@Telefone", tecnico.telefone);

                    // Abre a conexão com o Banco de dados
                    conexaoBd.Open();

                    // Executa toda a operação que fizemos 
                    comandoSql.ExecuteNonQuery();
                }

            }
            // Caso ocorra erro no Sql Capturamos e mostramos na tela
            catch (Exception ex)
            {
                throw new Exception("EROOOO !!!", ex);
            }
        }

    }
}
