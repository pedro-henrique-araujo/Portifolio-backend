namespace Portifolio.Data
{
    public class Contact
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? SolutionType { get; set; }

        public string? Message { get; set; }
        public DateTime? Created { get; set; }
    }
}
