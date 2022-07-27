using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using cbf.domain;
using cbf.Infrastructure.Db;

namespace cbf.Infrastructure
{
    public class Team
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Localidade { get; set; }

        public List<Team> GetTeam()
        {
            return (List<Team>)DbConnection.GetConnection().Query<Team>("SELECT * FROM team");
        }

        public Team GetTeamPerID(int id)
        {
            var strComando = "SELECT * FROM team WHERE id = " + id.ToString();                        
            return (Team)DbConnection.GetConnection().Query<Team>(strComando).FirstOrDefault();
        }
        public void DeleteTeamPerID(int id)
        {            
            var strComando = "DELETE FROM team WHERE id = " + id.ToString();
            DbConnection.GetConnection().Execute(strComando);
        }

        public void UpdateTeamPerID(int id, ParametersTeam team)
        {            
            var strComando = "UPDATE team SET name = '{0}', Localidade = '{1}' " +
                "   WHERE id = {2} ";
            strComando = strComando.Replace("{0}", team.Name);
            strComando = strComando.Replace("{1}", team.Localidade);
            strComando = strComando.Replace("{2}", id.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }
        public void InsertTeam(ParametersTeam team)
        {         
            var id = DbConnection.GetConnection().ExecuteScalar("SELECT max(id) + 1 FROM teste.team;");

            var strComando = "INSERT INTO team (id, name, localidade) VALUES({0}, '{1}', '{2}')";
            
            strComando = strComando.Replace("{0}", id.ToString());
            strComando = strComando.Replace("{1}", team.Name);
            strComando = strComando.Replace("{2}", team.Localidade);

            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}