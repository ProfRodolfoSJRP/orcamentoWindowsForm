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

namespace orcamentoWF
{
    public partial class frmAlterarCliente : Form
    {
        // Conexão com BD
        string _conexao = orcamentoWF.Properties.Settings.Default.conexao;

        public frmAlterarCliente(int codigo)
        {
            InitializeComponent();
            // Verifica se o código é maior que zero para realizar a busca
            if(codigo > 0)
            {
                Cliente cliente = new Cliente();
                ClienteCRUD clienteCrud = new ClienteCRUD(_conexao);
                // Obtém o Cliente a partir do código Fornecido
                cliente = clienteCrud.ObtemCliente(codigo);

                // Verifica se o Cliente foi encontrado
                if(cliente == null)
                {
                    MessageBox.Show("Cade o Cliente ??? Não temos");
                    // Fecha o Form
                    this.Close();
                }
                // Preenche os campos do formulário com os dados do clientes
                txbCodigo.Text = cliente.Id_Cliente.ToString();
                txbEndereco.Text = cliente.Endereco;
                txbNome.Text = cliente.Nome;
                txbTelefone.Text = cliente.Telefone.ToString();
               
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Atualiza os dados no banco de dados
            Cliente cliente = new Cliente();
            ClienteCRUD clientecrud = new ClienteCRUD(_conexao);

            try
            {
                // Atribui os valores dos campos de texto aos atributos do objeto clientes
                cliente.Id_Cliente = int.Parse(txbCodigo.Text);
                cliente.Nome = txbNome.Text;
                cliente.Telefone = txbTelefone.Text;
                cliente.Endereco = txbEndereco.Text;

                clientecrud.AlterarCliente(cliente);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Occoreu um erro" + ex);
            }
        }
    }
}
