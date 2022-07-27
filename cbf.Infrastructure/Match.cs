using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using cbf.domain;
using cbf.Infrastructure.Db;

namespace cbf.Infrastructure
{
    public class Match
    {
        public int id { get; set; }
        public int idTournament { get; set; }
        public int idTeamPrincipal { get; set; }
        public int idTeamVisitor { get; set; }
        public DateTime dateMatch { get; set; }

        public List<Match> GetMatch()
        {
            
            return (List<Match>)DbConnection.GetConnection().Query<Match>("SELECT * FROM `match`");
        }

        public Match GetMatchPerId(int id)
        {
            var strComando = "SELECT * FROM `match` WHERE id = " +id.ToString();            
            return (Match)DbConnection.GetConnection().Query<Match>(strComando).FirstOrDefault();
        }
        public void DeleteMatchPerID(int id)
        {            
            var strComando = "DELETE FROM `match` WHERE id = {0}";
            strComando = strComando.Replace("{0}", id.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }
        
        public void InsertMatch(ParametersMatch match)
        {
            var id = DbConnection.GetConnection().ExecuteScalar("SELECT max(id) + 1 FROM `match`");

            if (id == null)
                id = 1;

            var strComando = "INSERT INTO `match` (id, idTournament, idTeamPrincipal, idTeamVisitor, dateMatch) VALUES({0}, {1}, {2}, {3}, '{4}')";

            strComando = strComando.Replace("{0}", id.ToString()) ;
            strComando = strComando.Replace("{1}", match.idTournament.ToString());
            strComando = strComando.Replace("{2}", match.idTeamPrincipal.ToString());
            strComando = strComando.Replace("{3}", match.idTeamVisitor.ToString());
            strComando = strComando.Replace("{4}", match.dateMatch.ToString("yyyyMMdd"));

            DbConnection.GetConnection().Execute(strComando);
        }

        public void UpdateMatchPerID(int id, ParametersMatch match)
        {
            var strComando = "UPDATE `match` SET idTournament={0}, idTeamPrincipal={1}, idTeamVisitor={2}, dateMatch='{3}'" +
                "   WHERE id = {4} ";

            
            strComando = strComando.Replace("{0}", match.idTournament.ToString());
            strComando = strComando.Replace("{1}", match.idTeamPrincipal.ToString());
            strComando = strComando.Replace("{2}", match.idTeamVisitor.ToString());
            strComando = strComando.Replace("{3}", match.dateMatch.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{4}", id.ToString());

            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}