using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using cbf.domain;
using cbf.Infrastructure.Db;

namespace cbf.Infrastructure
{
    public class Participant
    {
        public int idTournament { get; set; }
        public int idTeam { get; set; }
        
        public List<Participant> GetParticipant()
        {            
            return (List<Participant>)DbConnection.GetConnection().Query<Participant>("SELECT * FROM participant");
        }

        public List<Participant> GetParticipantPerIdTournament(int idTournament)
        {
            var strComando = "SELECT * FROM participant WHERE idTournament = {0}";
            strComando = strComando.Replace("{0}", idTournament.ToString());
            return (List<Participant>)DbConnection.GetConnection().Query<Participant>(strComando);
        }
        public void DeleteParticipantPerID(int idTournament, int idTeam)
        {
            var strComando = "DELETE FROM participant WHERE idTournament = {0} and idTeam = {1}";
            strComando = strComando.Replace("{0}", idTournament.ToString());
            strComando = strComando.Replace("{1}", idTeam.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }
        
        public void InsertParticipant(ParametersParticipant participant)
        {                     
            var strComando = "INSERT INTO participant (idTournament, idTeam) VALUES({0}, {1})";

            strComando = strComando.Replace("{0}", participant.idTournament.ToString());
            strComando = strComando.Replace("{1}", participant.idTeam.ToString());

            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}