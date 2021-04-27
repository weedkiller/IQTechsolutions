namespace Troubleshooting.Base.Models.ApiModels
{
    public class ProblemResultModel
    {
        public string Id { get; set; }

        public string Heading { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        public int CausesCount { get; set; }
    }
}
