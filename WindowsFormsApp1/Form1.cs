using MyLibrary.Entinty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Pessoa a = Pessoa();
            Pessoa a1 = new Pessoa();

            a.Nome = "Antnonio";

            string v = a.Nome;
        }

        private Pessoa Pessoa()
        {
            return new Pessoa();
        }
    }
}
