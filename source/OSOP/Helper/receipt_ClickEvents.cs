using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OSOP.Helper
{
    public interface receipt_ClickEvents
    {
        void onClick(View itemView, int Position);
    }
}