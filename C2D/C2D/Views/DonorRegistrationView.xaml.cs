using C2D.Model;
using C2D.ViewModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C2D.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DonorRegistrationView : ContentPage
	{
		public DonorRegistrationView ()
		{
			InitializeComponent ();
		}

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
           
            RegistrationViewModels donorViewModel = new RegistrationViewModels();
            Donors donor = new Donors();
            donor.FirstName = firstName.Text;
            donor.LastName = lastName.Text;
            donor.Email = email.Text;
            donor.Contact = Convert.ToInt64(contact.Text);
            donor.UserName = userName.Text;
            donor.Password = password.Text;
            if (password.Text.Equals(confirmPassword.Text))
            {
                donorViewModel.addinfo(donor);
                Navigation.PushAsync(new C2D.RequestsOfRecipientView());
            }
            else
            {
                lblConfirmPassword.Text = "Password does not Match";
                lblConfirmPassword.IsVisible = true;
            }

           
        }
     }
}