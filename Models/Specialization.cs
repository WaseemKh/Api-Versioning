namespace Versioning.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Doctor> Doctors { get; set; }
    }
}
