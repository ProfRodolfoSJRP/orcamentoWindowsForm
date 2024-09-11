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
    public partial class frmTecnicoAdicionar : Form
    {
        string _conexao = orcamentoWF.Properties.Settings.Default.conexao;
        public frmTecnicoAdicionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Configurar Botão Salvar
            // Chama Objeto Cliente

            Tecnico tecnico = new Tecnico();

            TecnicoCRUD tecnicocrud = new TecnicoCRUD(_conexao);

            if (string.IsNullOrWhiteSpace(txbNome.Text) || string.IsNullOrEmpty(txbTelefone.Text))
            {
                MessageBox.Show("Hey, Digite todos os campos em !!", "Erro");
            }
            else
            {
                // Try = tente
                // Atribui os valores dos campos no objeto Cliente
                tecnico.nome = txbNome.Text;
                tecnico.especializacao = txbExpecializa.Text;
                tecnico.telefone = txbTelefone.Text;

                // Executa o comando de inclusão do cliente 
                tecnicocrud.IncluiTecnico(tecnico);

                // Exibe uma Mensagem se deu certo
                MessageBox.Show("Cadastrado com Sucesso");

                // Fecha a Tela
                this.Close();

            }
        }
    }
}
