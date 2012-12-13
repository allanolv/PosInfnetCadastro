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
            return String.Format("INSERT INTO FISICA (ID, IDADE, SEXO) VALUES ('{0}', '{1}', {2})",
                entidade.ID, entidade.Idade, entidade.Sexo);
        }

        protected override string GetSelectCommand()
        {
            return "SELECT * FROM Fisica";
        }

        protected override string GetSelectCommand(string id)
        {
            return string.Format("SELECT * FROM Fisica WHERE ID = '{0}'", id);
        }

        protected override string GetUpdateCommand(Fisica entidade)
        {
            return string.Format("UPDATE Fisica SET IDADE = {1}, SEXO = '{2}' WHERE ID = '{0}'", entidade.ID, entidade.Idade, entidade.Sexo);
        }

        protected override string GetDeleteCommand(string id)
        {
            return string.Format("DELETE FROM Fisica WHERE ID = '{0}'", id);
        }

        protected override Fisica Hydrate(SqlDataReader reader)
        {
            Fisica fisica = new Fisica();
            
            fisica.ID = Guid.Parse(reader[0].ToString());
            fisica.Nome = reader[1].ToString();
            fisica.Idade = int.Parse(reader[2].ToString());
            fisica.Sexo = reader[3].ToString();

            return fisica;
        }
    }
}