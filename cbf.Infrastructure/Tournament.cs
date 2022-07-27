using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using cbf.domain;
using cbf.Infrastructure.Db;

namespace cbf.Infrastructure
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }                
        public List<Tournament> GetTournament()
        {
            
            return (List<Tournament>)DbConnection.GetConnection().Query<Tournament>("SELECT * FROM tournament");
        }

        public Tournament GetTournamentPerID(int id)
        {
            var strComando = "SELECT * FROM tournament WHERE id = " + id.ToString();                        
            return (Tournament)DbConnection.GetConnection().Query<Tournament>(strComando).FirstOrDefault();
        }
        public void DeleteTournamentPerID(int id)
        {
            var strComando = "DELETE FROM tournament WHERE id = " + id.ToString();
            DbConnection.GetConnection().Execute(strComando);
        }

        public void UpdateTournamentPerID(int id, ParametersTournament tournament)
        {
            var strComando = "UPDATE tournament SET name='{0}', dateStart='{1}', dateEnd='{2}'" +
                "   WHERE id = {3} ";
            strComando = strComando.Replace("{0}", tournament.Name);
            strComando = strComando.Replace("{1}", tournament.dateStart.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{2}", tournament.dateEnd.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{3}", id.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }
        public void InsertTournament(ParametersTournament tournament)
        {
            var id = DbConnection.GetConnection().ExecuteScalar("SELECT max(id) + 1 FROM tournament;");

            if (id == null)
                id = 1;

            var strComando = "INSERT INTO tournament (id, name, dateStart, dateEnd) VALUES({0}, '{1}', '{2}', '{3}')";

            strComando = strComando.Replace("{0}", id.ToString());
            strComando = strComando.Replace("{1}", tournament.Name);
            strComando = strComando.Replace("{2}", tournament.dateStart.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{3}", tournament.dateEnd.ToString("yyyyMMdd"));


            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}