using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSample.Consts;
using XamarinSample.Models;
using XamarinSample.ViewModels;

namespace XamarinSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ViewModels.LoginViewModel ViewModel { get; private set; } = new ViewModels.LoginViewModel();

        public Login()
        {
            InitializeComponent();
            ViewModel.Initialize(this);
            this.BindingContext = ViewModel;
        }

        private void Login_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<LoginViewModel, AlertParameter>(this, "DisplayAlert", DisplayAlert);
            MessagingCenter.Subscribe<LoginViewModel, UserType>(this, "GoNextPage", GoNextPage);
        }

        private void Login_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<LoginViewModel, AlertParameter>(this, "DisplayAlert");
            MessagingCenter.Unsubscribe<LoginViewModel, UserType>(this, "GoNextPage");
        }

        private async void DisplayAlert<T>(T sender, AlertParameter arg)
        {
            bool isAccept = false;
            if (arg.Cancel == null)
            {
                await DisplayAlert(arg.Title, arg.Message, arg.Accept);
            }
            else
            {
                isAccept = await DisplayAlert(arg.Title, arg.Message, arg.Accept, arg.Cancel);
            }
            arg.Action?.Invoke(isAccept);
        }

        private async void GoNextPage<T>(T sender, UserType arg)
        {
            if (arg.userStatus == CommonEnums.UserStatusType.Temporary)
            {
                if (arg.userCategory == CommonEnums.UserCategoryType.UserRollA)
                {
                    await Navigation.PushAsync(new InputCreditInfoRollA());
                    return;
                }
                else if (arg.userCategory == CommonEnums.UserCategoryType.UserRollB)
                {

                }
            }
            else if (arg.userStatus == CommonEnums.UserStatusType.Examination || arg.userStatus == CommonEnums.UserStatusType.Member)
            {
                if (arg.userCategory == CommonEnums.UserCategoryType.UserRollA)
                {

                }
                else if (arg.userCategory == CommonEnums.UserCategoryType.UserRollB)
                {

                }
            }

            await DisplayAlert("Error", $"ログイン権限がありません。Status:{arg.userStatus} Category:{arg.userCategory}", "OK");
        }

        private void RePasswordButton_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SecondPage());
        }

        private void RollA_Clicked(object sender, EventArgs e)
        {
            this.ButtonSelectedRollB.BorderColor = Color.Gray;
            this.ButtonSelectedRollA.BorderColor = Color.FromHex("94C565");
        }

        private void RollB_Clicked(object sender, EventArgs e)
        {
            this.ButtonSelectedRollA.BorderColor = Color.Gray;
            this.ButtonSelectedRollB.BorderColor = Color.FromHex("94C565");
        }
    }

}