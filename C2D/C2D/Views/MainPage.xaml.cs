using System;

using Xamarin.Forms;
using C2D.ViewModel;
using MongoDB.Driver;
using MongoDB.Bson;
using C2D.Views;

namespace C2D
{
    public partial class RequestsOfRecipientView : ContentPage
    {
        private bool userTypeDonor=false;
        public RequestsOfRecipientView()
        {
            InitializeComponent();
            
            
        }

        public  void  btnLoginClicked (object sender, EventArgs e)
        {
            Login login = new Login();
            if (userName.Text != null || password.Text != null)
            {
                if (login.Authenticate(userName.Text, password.Text, userTypeDonor))
                {
                    lblLogin.Text = "Login Successful!";
                    if (userTypeDonor)
                    {
                        Application.Current.Properties["UserName"] = userName.Text;
                        Navigation.PushAsync(new ListDonationRequestsView());
                    }
                    else
                    { 
                        Application.Current.Properties["UserName"] = userName.Text;
                        Navigation.PushAsync(new AddDonationRequest());
                    }

                }
                else
                {
                    lblLogin.Text = "Either UserName or Password is wrong!";
                }
            }
            else
                lblLogin.Text = "UserName or Password should not be empty!";
                
        }
        public void BtnNvgtRegistration(object sender, EventArgs e)
        {   
            if(userTypeDonor)
                Navigation.PushAsync(new DonorRegistrationView());
            else
                Navigation.PushAsync(new RecipientRegistrationView());

        }

        private void switch_Toggled(object sender, ToggledEventArgs e)
        {
            userTypeDonor = e.Value;
        }
        private void switch_Toggled1(object sender, ToggledEventArgs e)
        {
            userTypeDonor = e.Value;
        }
    }
}
