using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste
{
    public partial class FromFornecedores : Form
    {
        public FromFornecedores()
        {
            InitializeComponent();
        }


        private void FromFornecedores_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns.Add("coluna Nome", "Nome");
            dataGridView1.Columns.Add("coluna Email", "email");

            DataClasses1DataContext dc = new DataClasses1DataContext();

            var lista = from Utilizador in dc.Utilizadors select Utilizador;
            int idxLinha = 0;
            foreach (Utilizador a in lista)
            {

                dataGridView1.Rows.Add();
                dataGridView1.Rows[idxLinha].Cells[0].Value = a.Nome;
                dataGridView1.Rows[idxLinha].Cells[1].Value = a.Email;
                idxLinha++;


            }
        }
    }
}
