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
	public partial class RecipientRegistrationView : ContentPage
	{
		public RecipientRegistrationView ()
		{
			InitializeComponent ();
		}
        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            RegistrationViewModels donorViewModel = new RegistrationViewModels();
            Recipients recipient = new Recipients();
            recipient.FullName = fullName.Text;
            recipient.GovtId = govtId.Text;
            recipient.Email = email.Text;
            recipient.Contact = Convert.ToInt64(contact.Text);
            recipient.userName = userName.Text;
            recipient.Password = password.Text;
            if (password.Text.Equals(confirmPassword.Text))
            {
                donorViewModel.addinfo(recipient);
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