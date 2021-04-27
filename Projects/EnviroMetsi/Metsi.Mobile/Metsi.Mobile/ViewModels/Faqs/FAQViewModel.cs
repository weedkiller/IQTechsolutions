using System.Collections.Generic;
using Metsi.Mobile.Models.Faqs;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Newtonsoft.Json;
using Troubleshooting.Api.Models;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.ViewModels.Faqs
{
    /// <summary>
    /// ViewModel for FAQ page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class FAQViewModel : BaseViewModel
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly HttpClient _client;
        private ObservableCollection<FAQ> questions;

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="FAQViewModel"/> class.
        /// </summary>
        public FAQViewModel(IHttpClientFactory httpClientFactory,  IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = httpClientFactory.CreateClient();
            SetupQuestions();

            //Questions = new ObservableCollection<FAQ>()
            //{
            //    new FAQ()
            //    {
            //        Question = "asdfasdfasdf",
            //        Answer = new List<string>()
            //        {
            //            "asdfasdfasdf",
            //            "2sdafasdfasdf"
            //        }
            //    },
            //    new FAQ()
            //    {
            //        Question = "123412341234",
            //        Answer = new List<string>()
            //        {
            //            "123412341234",
            //            "2123412341234"
            //        }
            //    }
            //};
        }

        private async void SetupQuestions()
        {
            var response = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/faqs");

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }

            string serialized = await response.Content.ReadAsStringAsync();

            PagedResult<QuestionResultModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<QuestionResultModel>>(serialized));

            List<FAQ> list = new List<FAQ>();
            foreach (var item in result.Results)
            {
                var faq = new FAQ()
                {
                    Question = item.Question,
                    Answer = item.Answers.ToList()
                };
                list.Add(faq);
            }

            Questions = new ObservableCollection<FAQ>(list);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the FAQ page.
        /// </summary>
        [DataMember(Name = "questions")]
        public ObservableCollection<FAQ> Questions
        {
            get
            {
                return questions;

            }
            set
            {
                questions = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}
