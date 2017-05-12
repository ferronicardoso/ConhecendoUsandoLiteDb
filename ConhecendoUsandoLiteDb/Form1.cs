using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConhecendoUsandoLiteDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("Filename=ConhecendoUsandoLiteDb.db"))
            {
                var agendas = db.GetCollection<Agenda>().FindAll().ToList();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = agendas;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out id);

            var form3 = new Form3(id);
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out id);

            if (id > 0)
            {
                var dialogResult = MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new LiteDatabase("Filename=ConhecendoUsandoLiteDb.db"))
                    {
                        db.GetCollection<Agenda>().Delete(id);
                    }
                }
            }
        }
    }
}
