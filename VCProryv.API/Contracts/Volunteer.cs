namespace VCProryv.API.Contracts
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string Institute { get; set; }
    }
}
