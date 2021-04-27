using System.Collections.Generic;

namespace Troubleshooting.Base.ApiModels
{
    public class QuestionModel
    {
        public string Id { get; set; }
        public string Question { get; set; }

        public ICollection<string> Answers { get; set; } = new List<string>();
    }
}
