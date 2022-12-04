
namespace VCProryv.API.Contracts
{
    public class NewActivity
    {
        public string Name { get; set; }
        public string Degree { get; set; }
        public DateTime Date { get; set; }
        public Volunteer[] Volunteers { get; set; }
    }
}
