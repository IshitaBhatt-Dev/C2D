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
  
        string reqId;
        string recipientUserName;

        public ResponseDonationRequests()
        {
            InitializeComponent();
            getDetails();
        }
        public ResponseDonationRequests(string title1,string description1,string recipientUsername1,string reqId1)
        {

            InitializeComponent();
            title.Text = title1;
            description.Text = description1;
            recipientUserName = recipientUsername1;
            reqId = reqId1;
            getDetails();
           

        }

        public  void getDetails()
        {
            ListDonationRequestsViewModel list = new ListDonationRequestsViewModel();
           // var requestDetails = await list.SearchById(id);

            RegistrationViewModels recipient = new RegistrationViewModels();
          

            //title.Text = requestDetails.title;
            //description.Text = requestDetails.description;

            fullName.Text = Application.Current.Properties["UserName"].ToString(); ;
                
        }

        public void btnSubmitResponse()
        {
            ResponseRequestViewModel responseRequestViewModel = new ResponseRequestViewModel();
            Response response = new Response();

            response.RequestId = reqId;
            response.description = resDescription.Text;
            
            response.DonorUserName = Application.Current.Properties["UserName"].ToString();
            response.RecipientUserName = recipientUserName;
            response.status = 0;
            responseRequestViewModel.AddNewRequestResponse(response);
            

        }
    }
}