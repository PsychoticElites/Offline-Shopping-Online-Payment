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
    class receipt_Data
    {
        public string reciept_TotalAmount { get; set; }
        public string reciept_TxnID { get; set; }
        public string reciept_TxnTime { get; set; }
        public string reciept_StoreName { get; set; }
        public string reciept_RewardGained { get; set; }
    }
}