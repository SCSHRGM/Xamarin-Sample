using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class Page2 : ContentPage
    {
        UserInfoViewModel UserInfo { set; get; }

        /// <summary>
        /// 建構函式
        /// </summary>
        /// <param name="userInfo"></param>
        public Page2(UserInfoViewModel userInfo)
        {
            this.UserInfo = userInfo;

            this.Title = "個人資料";
            this.Padding = 20;

            //設定Binding物件
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

            var saveBtn = new Button() { IsEnabled = false };
            saveBtn.SetBinding(Button.TextProperty, "ButtonText");
            saveBtn.SetBinding(Button.IsEnabledProperty, "IsEnabled");
            #endregion

            #region 控制項事件
            saveBtn.Clicked += async (s, e) => 
            {
                if (this.UserInfo.Save())
                {
                    await DisplayAlert("", "完成", "OK");
                    await Navigation.PopAsync();
                }
            };
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
    }
}
