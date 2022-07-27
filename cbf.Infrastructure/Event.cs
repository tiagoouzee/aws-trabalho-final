using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using cbf.domain;
using cbf.Infrastructure.Db;

namespace cbf.Infrastructure
{
    public class Event
    {
        public int Id { get; set; }
        public string typeEvents { get; set; }
        public int idMatch { get; set; }
        public string description { get; set; }
        public int idTeamGeneratorEvents { get; set; }
        public DateTime dateEvent { get; set; }

        public List<Event> GetEvent()
        {
            //var connection = new MySqlConnection("Server=localhost;Database=teste;Uid=root;Pwd=root;");
            return (List<Event>)DbConnection.GetConnection().Query<Event>("SELECT * FROM event");
        }

        public Event GetEventPerID(int id)
        {            
            var strComando = "SELECT * FROM event WHERE id = " + id.ToString();                        
            return (Event)DbConnection.GetConnection().Query<Event>(strComando).FirstOrDefault();
        }
        public void DeleteEventPerID(int id)
        {
            var strComando = "DELETE FROM event WHERE id = " + id.ToString();
            DbConnection.GetConnection().Execute(strComando);
        }

        public void UpdateEventPerID(int id, ParametersEvent pEvent)
        {
            var strComando = "UPDATE event SET typeEvents='{0}', idMatch={1}, description='{2}', idTeamGeneratorEvents={3}, dateEvent='{4}'" +
                "   WHERE id = {5} ";
            strComando = strComando.Replace("{0}", pEvent.typeEvents);
            strComando = strComando.Replace("{1}", pEvent.idMatch.ToString());
            strComando = strComando.Replace("{2}", pEvent.description);
            strComando = strComando.Replace("{3}", pEvent.idTeamGeneratorEvents.ToString());
            strComando = strComando.Replace("{4}", pEvent.dateEvent.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{5}", id.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }
        public void InsertEvent(ParametersEvent pEvent)
        {
            var id = DbConnection.GetConnection().ExecuteScalar("SELECT max(id) + 1 FROM event");

            if (id == null)
                id = 1;

            var strComando = "INSERT INTO event (id, typeEvents, idMatch, description, idTeamGeneratorEvents, dateEvent) VALUES({0}, '{1}', {2}, '{3}', {4}, '{5}')";

            strComando = strComando.Replace("{0}", id.ToString());
            strComando = strComando.Replace("{1}", pEvent.typeEvents);
            strComando = strComando.Replace("{2}", pEvent.idMatch.ToString());
            strComando = strComando.Replace("{3}", pEvent.description);
            strComando = strComando.Replace("{4}", pEvent.idTeamGeneratorEvents.ToString());
            strComando = strComando.Replace("{5}", pEvent.dateEvent.ToString("yyyyMMdd"));

            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}