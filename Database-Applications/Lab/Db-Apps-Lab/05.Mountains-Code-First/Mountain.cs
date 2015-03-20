namespace _05.Mountains_Code_First
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Mountain
    {
        private ICollection<Peak> peaks; 

        public Mountain()
        {
            this.Peaks = new HashSet<Peak>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Peak> Peaks
        {
            get
            {
                return this.peaks;
            }

            set
            {
                this.peaks = value;
            }
        }

        public virtual Country Country { get; set; }
    }
}
