using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cadastro.Model;

namespace Cadastro.DAL.SqlProvider
{
    public class FisicaDao : BaseDao<Fisica>
    {
        protected override string GetInsertCommand(Fisica entidade)
        {
            return String.Format("INSERT INTO FISICA (ID, NOME, IDADE, SEXO) VALUES ('{0}', '{1}', {2}, '{3}')",
                entidade.ID, entidade.Nome, entidade.Idade, entidade.Sexo);
        }

        protected override string GetSelectCommand()
        {
            return "SELECT * FROM Fisica";
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT * FROM Fisica WHERE ID = '" + id + "'";
        }

        protected override Fisica Hydrate(SqlDataReader reader)
        {
            Fisica fisica = new Fisica();
            
            fisica.ID = Guid.Parse(reader[0].ToString());
            fisica.Nome = reader[1].ToString();
            fisica.Idade = int.Parse(reader[2].ToString());
            fisica.Sexo = reader[3].ToString();
            //T.Telefones = ???

            return fisica;
        }
    }
}