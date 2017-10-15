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
using Android.Support.V7.Widget;
using OSOP.Helper;

namespace OSOP
{
    [Activity(Label = "eReceipt")]
    public class eReceipt : Activity
    {
        RecyclerView receipt;
        private receipt_RecycleViewAdapter recycleAdapter1;
        private RecyclerView.LayoutManager layoutManager;
        private List<receipt_Data> listData = new List<receipt_Data>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.eReceipt_Screen);

            InitData();
            FindViews();

        }

        private void InitData()
        {
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });

        }

        private void FindViews()
        {
            receipt = FindViewById<RecyclerView>(Resource.Id.reciept_RecycleView);
            receipt.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(this);
            receipt.SetLayoutManager(layoutManager);
            //recycleAdapter1 = new RecycleViewAdapter(listData);
            recycleAdapter1 = new receipt_RecycleViewAdapter(listData);
            receipt.SetAdapter(recycleAdapter1);
        }
    }
}