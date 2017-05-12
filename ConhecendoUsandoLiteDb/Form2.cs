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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var agenda = new Agenda();
            agenda.Nome = textBox1.Text;
            agenda.Email = textBox2.Text;
            agenda.Telefone = textBox3.Text;

            using (var db = new LiteDatabase("Filename=ConhecendoUsandoLiteDb.db"))
            {
                db.GetCollection<Agenda>().Insert(agenda);
            }

            this.Close();
        }
    }
}
