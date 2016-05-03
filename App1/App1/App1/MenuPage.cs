using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class MenuPage : ContentPage
    {
        UserInfoModel defaultUser = new UserInfoModel();
        //UserInfoList custUsers = new UserInfoList();

        public MenuPage()
        {
            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 5,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
					new Button 
                    { 
                        Text = "Page1", 
                        Command = new Command(() => Navigation.PushAsync(new Page1(defaultUser))) 
                    },
                    new Button 
                    { 
                        Text = "Page2", 
                        Command = new Command(() => Navigation.PushAsync(new Page2(new UserInfoViewModel(defaultUser)))) 
                    },
                    new Button 
                    { 
                        Text = "Page3", 
                        Command = new Command(() => Navigation.PushAsync(new Page3(new UserInfoViewModel(defaultUser)))) 
                    }
				}
            };
        }
    }
}
