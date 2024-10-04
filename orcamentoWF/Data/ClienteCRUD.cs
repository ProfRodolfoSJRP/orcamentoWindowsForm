using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClienteCRUD
    {
        // Receber Conexão da Tela que enviar
        private readonly string _conexao;

        // Receber a variavel Conexão e colocar o valor
        public ClienteCRUD(string conexao)
        {
            _conexao = conexao;
        }

        // Método Incluir Cliente, recebe o objeto Cliente da tela Cliente
        // Inclui no banco de dados
        public void IncluiCliente(Cliente cliente)
        {
            // Query para inserir algo com SQL no Banco de dados
            const string query = @"INSERT INTO Clientes(Nome,Endereco,telefone)
                               Values(@Nome, @Endereco, @Telefone)";


            // Bloco para tratar possiveis erros ao inserir e exibir mensagens
            try
            {
                //Criação de uma conexão com o banco de dados 
                using (var conexaoBd = new SqlConnection(_conexao))
                // Transformo a Query em comando SQL
                using (var comandoSql = new SqlCommand(query, conexaoBd))
                {
                    comandoSql.Parameters.AddWithValue("@Nome", cliente.Nome);
                    comandoSql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    comandoSql.Parameters.AddWithValue("@Telefone", cliente.Telefone);

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
        // Buscar Cliente - Fazer buscar no banco de dados.
        public DataSet BuscarCliente(string pesquisa = "") 
        {
            // Query SQL que realiza uma busca filtrando o nome
            const string query = "Select * from Clientes Where Nome Like @Pesquisa";

            // Tente
            try
            {
                // Cria uma nova conexão com o banco de dados.
                using (var conexaoBd = new SqlConnection(_conexao))
                // Criação do comando SQL associado á query e á conexão
                using (var comando = new SqlCommand(query, conexaoBd))
                // Criação de um adaptador para preencher o DataSet
                using(var adaptador = new SqlDataAdapter(comando))
                {
                    // Prepara o Valor do parâmetro de pesquisa by Pedro
                    string parametroPesquisa = $"%{pesquisa}%";
                    comando.Parameters.AddWithValue("@Pesquisa", parametroPesquisa);
                    // Abre a conexão com o banco de dados
                    conexaoBd.Open();
                    // Cria o formatado de dados que o DGV aceita (Dataset) 
                    var dsClientes = new DataSet();
                    adaptador.Fill(dsClientes, "Clientes"); // Preenche o Dataset
                    return dsClientes; // Retorna Dataset
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao Buscar Clientes {ex.Message}",ex);
            }
        }
        // Excluir Cliente
        // Lógica :  Enviar o Código do cliente para o SQL e o SQL executar o Delete
        public void ExcluirCliente(int codigoCliente)
        {
            // Query SQL para Excluir Cliente
            const string query = "DELETE from clientes where Id_Cliente = @codigoCli";

            try
            {
                // Criando uma conexão com o BD
                using(var conexaoBd = new SqlConnection(_conexao))
                // Criaçao comando Sql Associado à query e à conexão
                using(var comando = new SqlCommand(query,conexaoBd))
                {
                    comando.Parameters.AddWithValue("@codigoCli", codigoCliente);
                    conexaoBd.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch(Exception ex )
            {
                throw new Exception($"Erro ao Deletar:{ex.Message}", ex);
            }
        }
        // Alterar Cliente 
        public void AlterarCliente(Cliente cliente)
        {
            // Query SQL para atualizar os campos da tela
            const string query = @"update clientes set
                                  nome = @Nome,
                                  telefone = @Telefone,
                                  endereco = @Endereco
                                  where Id_Cliente = @codigoCli";
            try
            {
                //Criação de uma conexão com o banco de dados 
                using (var conexaoBd = new SqlConnection(_conexao))
                // Transformo a Query em comando SQL
                using (var comandoSql = new SqlCommand(query, conexaoBd))
                {
                    comandoSql.Parameters.AddWithValue("@Nome", cliente.Nome);
                    comandoSql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    comandoSql.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    comandoSql.Parameters.AddWithValue("@codigoCli", cliente.Id_Cliente);

                    // Abre a conexão com o Banco de dados
                    conexaoBd.Open();

                    // Executa toda a operação que fizemos 
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar o cliente: {ex.Message}", ex);
            }

        }
        // Obtem Cliente, Trazer apenas um cliente 
        public Cliente ObtemCliente(int codigoCliente)
        {
            const string query = "Select * from clientes where id_cliente = @cod";
            Cliente cliente = null; // Variavel para armazenar o cliente 

            try
            {
                using(var conexaoBd = new SqlConnection(_conexao))
                using(var comando = new SqlCommand(query, conexaoBd))
                {
                    // Adicionar o parametro 
                    comando.Parameters.AddWithValue("@cod", codigoCliente);
                    conexaoBd.Open();
                    // Executa a query e obtém os dados do cliente 
                    using(var reader = comando.ExecuteReader())
                    {
                       if(reader.Read())
                        {
                            cliente = new Cliente
                            {
                                Id_Cliente = Convert.ToInt32(reader["id_Cliente"]),
                                Nome = reader["nome"].ToString(),
                                Endereco = reader["endereco"].ToString(),
                                Telefone = reader["telefone"].ToString()
                            };
                        }
                        
                    }
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return cliente;
        }
    }
}