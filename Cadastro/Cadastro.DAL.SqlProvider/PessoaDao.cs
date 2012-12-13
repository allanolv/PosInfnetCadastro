using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cadastro.Model;

namespace Cadastro.DAL.SqlProvider
{
    public class PessoaDao : BaseDao<Pessoa>
    {
        protected override string GetInsertCommand(Pessoa entidade)
        {
            return String.Format("INSERT INTO Pessoa (ID, NOME) VALUES ('{0}', '{1}')",
                entidade.ID, entidade.Nome);
        }

        protected override string GetSelectCommand()
        {
            return "SELECT * FROM Pessoa";
        }

        protected override string GetSelectCommand(string id)
        {
            return string.Format("SELECT * FROM Pessoa WHERE ID = '{0}'", id);
        }

        protected override string GetUpdateCommand(Pessoa entidade)
        {
            return string.Format("UPDATE Pessoa SET NOME ='{0}' WHERE ID = '{1}'", entidade.Nome, entidade.ID);
        }

        protected override string GetDeleteCommand(string id)
        {
            return string.Format("DELETE FROM Pessoa WHERE ID = '{0}'", id);
        }

        protected override Pessoa Hydrate(SqlDataReader reader)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.ID = Guid.Parse(reader[0].ToString());
            pessoa.Nome = reader[1].ToString();
            
            return null;
        }

    }
}
