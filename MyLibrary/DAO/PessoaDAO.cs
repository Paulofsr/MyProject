using MyLibrary.Entinty;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAO
{
    public class PessoaDAO
    {
        //Insert (objeto) R: ObjetoNovo
        public Pessoa Insert(Pessoa obj)
        {
            obj.Id = Guid.NewGuid();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ToString()))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format(@"

INSERT INTO [dbo].[PessoaTB]
           ([Id]
           ,[Nome]
           ,[Idade]
           ,[CPF])
     VALUES
           (N'{0}'
           ,N'{1}'
           ,{2}
           ,N'{4}')",
           obj.Id,
           obj.Nome,
           obj.Idade,
           obj.DataNascimento,
           obj.CPF);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return GetById(obj.Id);
        }


        //Select (id) R: Objeto
        public Pessoa GetById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ToString()))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format(@"
SELECT [Id]
      ,[Nome]
      ,[Idade]
      ,[DataNascimento]
      ,[CPF]
  FROM [dbo].[PessoaTB]
WHERE Id = N'{0}'", id);

                    connection.Open();

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            Pessoa objectResult = new Pessoa();
                            objectResult.Id = new Guid(dr["Id"].ToString());
                            objectResult.Nome = dr["Nome"].ToString();
                            objectResult.Idade = Convert.ToInt32(dr["Idade"].ToString());
                            objectResult.CPF = dr["CPF"].ToString();
                            return objectResult;
                        }
                    }
                }
            }
            return new Pessoa();
        }

        //Update (Objeto) R
        public void Update(Pessoa obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ToString()))
            {
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format(@"

UPDATE [dbo].[PessoaTB]
   SET [Nome] = N'{1}'
      ,[Idade] = {2}
      ,[CPF] = N'{4}'
 WHERE Id = N'{0}'",
           obj.Id,
           obj.Nome,
           obj.Idade,
           obj.DataNascimento,
           obj.CPF);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Delete (Id) 
        public void Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ToString()))
            {
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format(@"
DELETE
  FROM [dbo].[PessoaTB]
WHERE Id = N'{0}'", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Select ALL () R: Lista Objeto
        public List<Pessoa> GetAll()
        {
            List<Pessoa> lista = new List<Pessoa>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ToString()))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format(@"
SELECT [Id]
      ,[Nome]
      ,[Idade]
      ,[DataNascimento]
      ,[CPF]
  FROM [dbo].[PessoaTB]");

                    connection.Open();

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Pessoa objectResult = new Pessoa();
                            objectResult.Id = new Guid(dr["Id"].ToString());
                            objectResult.Nome = dr["Nome"].ToString();
                            objectResult.Idade = Convert.ToInt32(dr["Idade"].ToString());
                            objectResult.CPF = dr["CPF"].ToString();
                            lista.Add(objectResult);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
