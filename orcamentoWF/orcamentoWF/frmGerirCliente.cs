using Data;
using orcamentoWF.Adicionar;
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
    public partial class frmGerirCliente : Form
    {
        // Capturar a conexão do Settings.Settings
        string _conexao = orcamentoWF.Properties.Settings.Default.conexao;
        public frmGerirCliente()
        {
            InitializeComponent();
            ListarCliente();
            ConfigurarDataGrid();
        }
        // Listar Cliente - Responsável por listar os clientes no DGV
        private void ListarCliente()
        {
            // Cria uma instância do ClienteCrud passando a String de Conexão
            ClienteCRUD clientecrud = new ClienteCRUD(_conexao);

            // Obtém o valor da caixa de texto de buscar
            string busca = txbPesquisa.Text.ToString();
            // Cria o Dataset para armazenar os dados do SQL 
            DataSet dsCliente = new DataSet();
            dsCliente = clientecrud.BuscarCliente(busca);
            // Associa os dados do DataSet ao DGV 
            dgvClientes.DataSource = dsCliente;
            dgvClientes.DataMember = "Clientes";
        }
        // Configurar o DataGrid Views 
        private void ConfigurarDataGrid()
        {
            // Definir a fonte padrão 
            dgvClientes.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            // Defini largura do cabeçalho
            dgvClientes.RowHeadersWidth = 25;
            // Ocultar o código
            dgvClientes.Columns["id_cliente"].Visible = false;
            dgvClientes.Columns["endereco"].HeaderText = "Endereço";
            dgvClientes.Columns["telefone"].HeaderText = "Tel";
            dgvClientes.Columns["nome"].HeaderText = "Nome Completo";

            // Alterar a ordem das colunas
            dgvClientes.Columns["nome"].DisplayIndex = 0;
            dgvClientes.Columns["endereco"].DisplayIndex = 1;
            dgvClientes.Columns["telefone"].DisplayIndex = 2;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            // Instancia
            var frmclienteadicionar = new frmClienteAdicionar();
            // Abre como Janela de Dialogo
            frmclienteadicionar.ShowDialog();
            // Listar os Cliente 
            ListarCliente();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // Verificar se a caixa de Busca está vazio 
            if(txbPesquisa.Text == "")
            {
                // Exibe uma Mensagem de aviso indicando que está vazio
                MessageBox.Show("Digite um Nome !!");
                // Defini o Foco no campo de busca
                txbPesquisa.Focus();
                // retorna sem Executar a busca
                return;
            }
            // Se a caixa de busca tiver algum valor chama ListarCliente
            ListarCliente();
        }
    }
}
