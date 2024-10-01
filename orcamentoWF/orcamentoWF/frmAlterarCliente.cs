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
               
            }
        }
    }
}
