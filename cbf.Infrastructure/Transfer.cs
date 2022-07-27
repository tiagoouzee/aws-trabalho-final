using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using cbf.domain;
using cbf.Infrastructure.Db;

namespace cbf.Infrastructure
{
    public class Transfer 
    {
        public int Id { get; set; }
        public int idTeamOrigin { get; set; }
        public int idTeamDestiny { get; set; }
        public DateTime datetransfer { get; set; }
        public Decimal valueTransfer { get; set; }
        public int idPlayer { get; set; }
        public List<Transfer> GetTransfer()
        {
            return (List<Transfer>)DbConnection.GetConnection().Query<Transfer>("SELECT * FROM transfer");
        }

        public Transfer GetTransferPerID(int id)
        {
            var strComando = "SELECT * FROM transfer WHERE id = " + id.ToString();                        
            return (Transfer)DbConnection.GetConnection().Query<Transfer>(strComando).FirstOrDefault();
        }
        public void DeleteTransferPerID(int id)
        {
            var strComando = "DELETE FROM transfer WHERE id = " + id.ToString();
            DbConnection.GetConnection().Execute(strComando);
        }

        public void UpdateTransferPerID(int id, ParametersTransfer transfer)
        {
            var strComando = "UPDATE transfer SET idTeamOrigin={0}, idTeamDestiny={1}, datetransfer='{2}', valueTransfer={3}, idPlayer = {4}" +
                "   WHERE id = {5} ";
            strComando = strComando.Replace("{0}", transfer.idTeamOrigin.ToString());
            strComando = strComando.Replace("{1}", transfer.idTeamDestiny.ToString());
            strComando = strComando.Replace("{2}", transfer.datetransfer.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{3}", transfer.valueTransfer.ToString().Replace(",", "."));
            strComando = strComando.Replace("{4}", transfer.idPlayer.ToString());
            strComando = strComando.Replace("{5}", id.ToString());
            DbConnection.GetConnection().Execute(strComando);
        }
        public void InsertTransfer(ParametersTransfer transfer)
        {
            var id = DbConnection.GetConnection().ExecuteScalar("SELECT max(id) + 1 FROM transfer;");

            if (id == null)
                id = 1;

            var strComando = "INSERT INTO transfer (idTeamOrigin, idTeamDestiny, datetransfer, id, valueTransfer, idPlayer) VALUES({0}, {1}, '{2}', {3}, {4}, {5})";

            strComando = strComando.Replace("{0}", transfer.idTeamOrigin.ToString());
            strComando = strComando.Replace("{1}", transfer.idTeamDestiny.ToString());
            strComando = strComando.Replace("{2}", transfer.datetransfer.ToString("yyyyMMdd"));
            strComando = strComando.Replace("{3}", id.ToString());
            strComando = strComando.Replace("{4}", transfer.valueTransfer.ToString().Replace(",", "."));
            strComando = strComando.Replace("{5}", transfer.idPlayer.ToString());

            DbConnection.GetConnection().Execute(strComando);
        }


    }
  
}