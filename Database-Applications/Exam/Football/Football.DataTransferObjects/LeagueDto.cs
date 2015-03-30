namespace Football.DataTransferObjects
{
    using System.Collections.Generic;

    using Football.Data;

    public class LeagueDto
    {
        private IEnumerable<TeamsDto> teams;

        public LeagueDto()
        {
            this.teams = new HashSet<TeamsDto>();
        }

        public string LeagueName { get; set; }

        public virtual IEnumerable<TeamsDto> Teams
        {
            get
            {
                return this.teams;
            }

            set
            {
                this.teams = value;
            }
        }
    }
}
