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

        }
    }
}
