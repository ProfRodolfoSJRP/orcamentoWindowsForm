﻿using System;
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
    }
}
