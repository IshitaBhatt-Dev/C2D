using C2D.Model;
using C2D.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C2D.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResponseDonationRequests : ContentPage
    {
        string[] arrayData;
        string id;
        string userName;

        public ResponseDonationRequests()
        {
            InitializeComponent();
            getDetails();
        }
        public ResponseDonationRequests(string data)
        {
            InitializeComponent();
           
            arrayData = data.Split(',');
            id = arrayData[0];
           userName = arrayData[1];
            getDetails();


        }
        public async void getDetails()
        {
            ListDonationRequestsViewModel list = new ListDonationRequestsViewModel();
            var requestDetails = await list.SearchById(id);

            RegistrationViewModels recipient = new RegistrationViewModels();
          

            title.Text = requestDetails.title;
            description.Text = requestDetails.description;

            fullName.Text = userName;
                
        }

        public void btnSubmitResponse()
        {
            ResponseRequestViewModel responseRequestViewModel = new ResponseRequestViewModel();
            Response response = new Response();

            response.ResponseDescription = description.Text;
            response.RequestId = description.Text;
            response.DonorUserName = Application.Current.Properties["UserName"].ToString();
            response.RequestId = id;
            
            responseRequestViewModel.AddNewRequestResponse(response);
            

        }
    }
}