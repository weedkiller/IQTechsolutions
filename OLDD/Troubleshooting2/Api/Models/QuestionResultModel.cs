using System;
using System.Collections.Generic;
using System.Text;

namespace Troubleshooting.Api.Models
{
    public class QuestionResultModel
    {
        public string Question { get; set; }
        public ICollection<string> Answers { get; set; }
    }
}
