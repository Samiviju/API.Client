namespace ClientsAPI.Model
{
    public class Client
    {
        public int? Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}