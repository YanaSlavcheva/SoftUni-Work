namespace Football.DataTransferObjects
{
    using System;

    using Football.Data;

    public class InternationalMatchesDto
    {
        public string HomeCountryCode { get; set; }

        public string AwayCountryCode { get; set; }

        public string Score { get; set; } 

        //public int? HomeGoals { get; set; }

        //public int? AwayGoals { get; set; }

        public string MatchDate { get; set; }

        // country1
        public virtual string HomeCountry { get; set; }

        // country
        public virtual string AwayCountry { get; set; }

        public virtual string League { get; set; }
    }
}
