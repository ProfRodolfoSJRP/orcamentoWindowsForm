using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace orcamentoWF.Adicionar
{
    public partial class frmClienteAdicionar : Form
    {
        // Capturar a conexão do Settings.Settings
        string _conexao = orcamentoWF.Properties.Settings.Default.conexao;
        public frmClienteAdicionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Configurar Botão Salvar
            // Chama Objeto Cliente

            Cliente cliente = new Cliente();

            ClienteCRUD clientecrud = new ClienteCRUD(_conexao);

            if(string.IsNullOrWhiteSpace(txbNome.Text) || string.IsNullOrEmpty(txbEndereco.Text))
            {
                MessageBox.Show("Hey, Digite todos os campos em !!", "Erro");
            }
            else
            {
                // Try = tente
                // Atribui os valores dos campos no objeto Cliente
                cliente.Nome = txbNome.Text;
                cliente.Endereco = txbEndereco.Text;
                cliente.Telefone = txbTelefone.Text;

                // Executa o comando de inclusão do cliente 
                clientecrud.IncluiCliente(cliente);

                // Exibe uma Mensagem se deu certo
                MessageBox.Show("Cadastrado com Sucesso");

                // Fecha a Tela
                this.Close();

            }
        }
    }
}
