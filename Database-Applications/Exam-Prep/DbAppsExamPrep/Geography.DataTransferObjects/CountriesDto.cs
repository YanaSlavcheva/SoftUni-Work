namespace Geography.DataTransferObjects
{
    using System.Collections.Generic;
    using Geography.Data;

    public class CountriesDto
    {
        private IEnumerable<string> monasteries;

        public CountriesDto()
        {
            this.monasteries = new HashSet<string>();
        }


        public string CountryName { get; set; }

        public virtual IEnumerable<string> Monasteries
        {
            get
            {
                return this.monasteries;
            }

            set
            {
                this.monasteries = value;
            }
        }
    }
}
