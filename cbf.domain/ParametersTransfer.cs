namespace cbf.domain
{
    public class ParametersTransfer
    {
        public int idTeamOrigin { get; set; }
        public int idTeamDestiny { get; set; }
        public DateTime datetransfer { get; set; }
        public Decimal valueTransfer { get; set; }
        public int idPlayer { get; set; }

    }
}