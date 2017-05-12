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
    public partial class Form3 : Form
    {
        protected readonly int Id;
        protected Agenda agenda;

        public Form3(int id)
        {
            this.Id = id;
            InitializeComponent();
            CarregaDados();
        }

        private void CarregaDados()
        {
            using (var db = new LiteDatabase("Filename=ConhecendoUsandoLiteDb.db"))
            {
                agenda = db.GetCollection<Agenda>().FindById(this.Id);
            }

            textBox1.Text = agenda.Id.ToString();
            textBox2.Text = agenda.Nome;
            textBox3.Text = agenda.Email;
            textBox4.Text = agenda.Telefone;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            agenda.Nome = textBox2.Text;
            agenda.Email = textBox3.Text;
            agenda.Telefone = textBox4.Text;

            using (var db = new LiteDatabase("Filename=ConhecendoUsandoLiteDb.db"))
            {
                db.GetCollection<Agenda>().Update(agenda);
            }

            this.Close();
        }
    }
}
