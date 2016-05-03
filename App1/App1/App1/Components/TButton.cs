using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class TButton : Button
    {
        public static readonly BindableProperty FinishedProperty = BindableProperty.Create("Finished", typeof(bool), typeof(bool), false);
    }
}
