using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class Page1 : ContentPage
    {
        /// <summary>
        /// 建構函式
        /// </summary>
        /// <param name="userInfo"></param>
        public Page1(UserInfoModel userInfo)
        {
            this.Title = "個人資料";
            this.Padding = 20;

            #region 頁面控制項
            var nameLabel = new Label() { Text = "中文姓名" };
            var nameEntry = new Entry() { Placeholder = "中文姓名" };
            var engNameLabel = new Label() { Text = "英文姓名" };
            var engNameEntry = new Entry() { Placeholder = "英文姓名" };
            var saveBtn = new Button() { Text = "存檔", IsEnabled = false };
            #endregion

            #region 控制項事件
            nameEntry.TextChanged += (s, e) => 
            {
                if (String.IsNullOrEmpty(nameEntry.Text) || String.IsNullOrEmpty(engNameEntry.Text))
                    saveBtn.IsEnabled = false;
                else
                    saveBtn.IsEnabled = true;
                
            };

            engNameEntry.TextChanged += (s, e) =>
            {
                if (String.IsNullOrEmpty(nameEntry.Text) || String.IsNullOrEmpty(engNameEntry.Text))
                    saveBtn.IsEnabled = false;
                else
                    saveBtn.IsEnabled = true;
            };

            saveBtn.Clicked += async (s, e) => 
            {
                userInfo.Name = nameEntry.Text;
                userInfo.EngName = engNameEntry.Text;
                await DisplayAlert("", "完成", "OK");
                await Navigation.PopAsync();
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
