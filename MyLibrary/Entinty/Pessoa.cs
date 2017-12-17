using System;

namespace MyLibrary.Entinty
{
    public class Pessoa
    {
        #region Comentários
        //Id Nome Idade DataNascimento CPF

        //private string nome;
        //public string GetNome()
        //{
        //    return nome;
        //}
        //public void SetNome(string val)
        //{
        //    nome = val;
        //}
        #endregion


        #region Atributos
        public Guid Id
        {
            get;
            set;
        }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }

        public string CPF { get; set; }
        #endregion 
    }
}
