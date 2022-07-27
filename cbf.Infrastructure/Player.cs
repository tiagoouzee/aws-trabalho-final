using cbf.domain;
using cbf.Infrastructure.Db;
using Dapper;
using MySql.Data.MySqlClient;

namespace cbf.Infrastructure
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pais { get; set; }        
        public DateTime DataNascimento { get; set; }
        public int IdTeam { get; set; }

        public List<Player> GetPlayer()
        {
            
            return (List<Player>)DbConnection.GetConnection().Query<Player>("SELECT * FROM player");
        }

        public Player GetPlayerPerID(int id)
        {
           var strComando = "SELECT * FROM player WHERE id = " + id.ToString();
            return (Player)DbConnection.GetConnection().Query<Player>(strComando).FirstOrDefault();
        }

        public void DeletePlayerPerID(int id)
        {
            var strComando = "DELETE FROM player WHERE id = " + id.ToString();
            DbConnection.GetConnection().Execute(strComando);                    }

        public void UpdatePlayerPerID(int id, ParametersPlayer player)
        {            
            var strComando = "UPDATE player SET name = '{0}', pais = '{1}', datanascimento = '{2}', idteam = {3} " +
                "   WHERE id = {4} ";           

            strComando = strComando.Replace("{0}", player.Name);
            strComando = strComando.Replace("{1}", player.Pais);
            strComando = strComando.Replace("{2}", player.DataNascimento.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{3}", player.IdTeam.ToString());
            strComando = strComando.Replace("{4}", id.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }


        public void InsertPlayer(ParametersPlayer player)
        {           
            var id = DbConnection.GetConnection().ExecuteScalar("SELECT max(id) + 1 FROM player;");

            if (id == null)
                id = 1; 

            var strComando = "INSERT INTO player (id, name, datanascimento, pais, idteam) VALUES({0}, '{1}', '{2}', '{3}', {4})";

            strComando = strComando.Replace("{0}", id.ToString());
            strComando = strComando.Replace("{1}", player.Name);
            strComando = strComando.Replace("{2}", player.DataNascimento.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{3}", player.Pais);            
            strComando = strComando.Replace("{4}", player.IdTeam.ToString());

            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}