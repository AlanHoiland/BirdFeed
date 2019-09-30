using BirdFeed.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BirdFeed.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ObservationViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ObservationViewModel class.
        /// </summary>
        public ObservationViewModel()
        {
            if (IsInDesignMode)
            {
                TheObservations = new List<Observations>();
            }
            else
            {
                GetLatestObservations();
            }
        }

        //
        // Bound data starts here
        //
        #region Bound data

        private List<Observations> theObservations;
        public List<Observations> TheObservations
        {
            get
            {
                return theObservations;
            }

            set
            {
                if (theObservations != value)
                {
                    theObservations = value;
                    RaisePropertyChanged("TheObservations");
                }
            }
        }

        private int searchRadius = 2;
        public int SearchRadius
        {
            get
            {
                return searchRadius;
            }

            set
            {
                if (searchRadius != value)
                {
                    searchRadius = value;
                    RaisePropertyChanged("SearchRadius");

                    GetLatestObservations();
                }
            }
        }

        private int daysBack = 30;
        public int DaysBack
        {
            get
            {
                return daysBack;
            }

            set
            {
                if (daysBack != value)
                {
                    daysBack = value;
                    RaisePropertyChanged("DaysBack");

                    GetLatestObservations();
                }
            }
        }

        #endregion

        //
        // Functions start here
        //
        #region Functions

        public void GetLatestObservations()
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://api.ebird.org/v2/data/obs/geo/recent?lat={{51.0453}}&lng={{-114.0581}}&sort=species");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-eBirdApiToken", "vnu5fgrprfs3");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Observations obs = null;
            string url = string.Format("https://api.ebird.org/v2/data/obs/geo/recent?lat=51.0453&lng=-114.0581&sort=species&dist={0}&back={1}", SearchRadius, DaysBack);
            Task<HttpResponseMessage> t = client.GetAsync(url);
            t.Wait();

            HttpResponseMessage response = t.Result;

            response.EnsureSuccessStatusCode();

            Task<List<Observations>> tl = response.Content.ReadAsAsync<List<Observations>>();
            tl.Wait();

            TheObservations = new List<Observations>(tl.Result);
            //if (response.IsSuccessStatusCode)
            //{
            //    product = await response.Content.ReadAsAsync<Product>();
            //}
            //return product;

        }

        #endregion

    }
}
