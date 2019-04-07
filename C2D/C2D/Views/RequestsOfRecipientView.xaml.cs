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
    public partial class RequestsOfRecipientView : ContentPage
    {
   
        public RequestsOfRecipientView()
        {
            InitializeComponent();
            Get_All();
        }



        protected async void Get_All()
        {
            ListDonationRequestsViewModel listDonationRequestsViewModel = new ListDonationRequestsViewModel();
            var allItems = await listDonationRequestsViewModel.SearchByUserName(Application.Current.Properties["UserName"].ToString());

            var lbl = new Label
            {

                Text = "TITLE",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl, 0, 0);
            var lbl1 = new Label
            {
                Text = "DESCRIPTION",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl1, 1, 0);
            var lbl2 = new Label
            {
                Text = "KEY1",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl2, 2, 0);
            var lbl3 = new Label
            {
                Text = "KEY2",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl3, 3, 0);
            var lbl4 = new Label
            {
                Text = "USERNAME",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl4, 4, 0);
            var lbl5 = new Label
            {
                Text = "STATUS",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl5, 5, 0);
            var lbl6 = new Label
            {
                Text = "",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl6, 6, 0);

            int rowIndex = 1;
            foreach (var item in allItems)
            {
                var label = new Label
                {

                    Text = item.title,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayout.Children.Add(label, 0, rowIndex);
                var label1 = new Label
                {
                    Text = item.description,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayout.Children.Add(label1, 1, rowIndex);
                var label2 = new Label
                {
                    Text = item.keyword1,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayout.Children.Add(label2, 2, rowIndex);
                var label3 = new Label
                {
                    Text = item.keyword2,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayout.Children.Add(label3, 3, rowIndex);
                var label4 = new Label
                {
                    Text = item.username,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayout.Children.Add(label4, 4, rowIndex);
                var label5 = new Label
                {
                    Text = item.status.ToString(),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayout.Children.Add(label5, 5, rowIndex);
                var label6 = new Button
                {
                    Text = "Edit",
                    BindingContext = item.Id.ToString(),
                    // CommandParameter = item.Id,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                label6.Clicked += new EventHandler(btn_Clicked);
                gridLayout.Children.Add(label6, 6, rowIndex);
                rowIndex++;
            }

        }

        public async void btn_Clicked(object sender, EventArgs e)
        {
            string data = ((Button)sender).BindingContext as string;
            // var newToDo = new DonationRequests { Title = "ark", UserName = "abc" };

            // await DbManager.InsertItem(newToDo);

            await Navigation.PushAsync(new UpdateDonationRequest(data));



        }
    }
}