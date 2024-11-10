using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_Produtos
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Produto> produtos = new Dictionary<string, Produto>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                double preco = double.Parse(txtPreco.Text);
                int quantidade = int.Parse(txtQuantidade.Text);
                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new ArgumentException("O nome do produto não pode ser vazio");
                }
                if (preco <= 0)
                {
                    throw new ArgumentException("O preço do produto deve ser maior que zero");
                }
                if (quantidade <= 0)
                {
                    throw new ArgumentException("A quantidade do produto deve ser maior que zero");
                }
                Produto produto = new Produto(nome, preco, quantidade);
                produtos[nome] = produto;

                AtualizarListaProdutos();
                LimparCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Digite valores válidos para preo e quantidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new ArgumentException("Selecione um produto para ser removido");
                }
                if (!produtos.ContainsKey(nome))
                {
                    throw new ArgumentException("Produto não encontrado");
                }

                produtos.Remove(nome);
                AtualizarListaProdutos();
                LimparCampos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnListarProdutos_Click(object sender, EventArgs e)
        {
            AtualizarListaProdutos();
        }

        
        

        private void AtualizarListaProdutos()
        {
            //Forma 1
           //dgvProdutos.DataSource = null;
           //dgvProdutos.DataSource = produtos.Values.ToList();
            
            //Forma 2
            dgvProdutos.Columns.Clear();
            dgvProdutos.Columns.Add("Nome", "Nome");
            dgvProdutos.Columns.Add("Preco", "Preço");
            dgvProdutos.Columns.Add("Quantidade", "Quantidade");

            foreach (Produto produto in produtos.Values)
            {
                dgvProdutos.Rows.Add(produto.Nome, produto.Preco, produto.Quantidade);
            }

        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
