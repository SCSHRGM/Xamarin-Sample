using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    public class Page3 : ContentPage
    {
        UserInfoViewModel UserInfo { set; get; }

        public Page3(UserInfoViewModel defaultUserInfo)
        {
            this.UserInfo = defaultUserInfo;

            this.Title = "個人資料";
            this.Padding = 20;
            this.BindingContext = UserInfo;

            #region 頁面控制項
            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, "NameLabel");

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.PlaceholderProperty, "NameLabel");
            nameEntry.SetBinding(Entry.TextProperty, "NameText");

            var engNameLabel = new Label();
            engNameLabel.SetBinding(Label.TextProperty, "EngNameLabel");

            var engNameEntry = new Entry();
            engNameEntry.SetBinding(Entry.PlaceholderProperty, "EngNameLabel");
            engNameEntry.SetBinding(Entry.TextProperty, "EngNameText");

            var saveBtn = new TButton() { IsEnabled = false };
            saveBtn.SetBinding(Button.TextProperty, "ButtonText");
            saveBtn.SetBinding(Button.IsEnabledProperty, "IsEnabled");
            saveBtn.SetBinding(Button.CommandProperty, "SaveCommand");
            saveBtn.SetBinding(TButton.FinishedProperty, "Finished");
            #endregion

            #region 控制項事件
            saveBtn.PropertyChanged += (s, e) => saveBtn_PropertyChanged(s, e);
            #endregion

            #region 頁面 Layout
            Content = new StackLayout
            {
                Children = {
					nameLabel,
                    nameEntry,
                    engNameLabel,
                    engNameEntry,
                    saveBtn
				}
            };
            #endregion
        }

        async void saveBtn_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Finished")
            {
                await DisplayAlert("", "完成", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
