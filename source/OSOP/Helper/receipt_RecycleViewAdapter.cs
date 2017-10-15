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
using Android.Graphics;

namespace OSOP.Helper
{
    class receipt_RecycleViewHolder : RecyclerView.ViewHolder
    {
        public View mMainView { get; set; }
        public TextView reciept_TotalAmount { get; set; }
        public TextView reciept_TxnID { get; set; }
        public TextView reciept_TxnTime { get; set; }
        public TextView reciept_StoreName { get; set; }
        public TextView reciept_RewardGained { get; set; }

        public receipt_RecycleViewHolder(View itemView) : base(itemView)
        {
            reciept_TotalAmount = itemView.FindViewById<TextView>(Resource.Id.receipt_Amount);
            reciept_TxnID = itemView.FindViewById<TextView>(Resource.Id.receipt_TxnId);
            reciept_TxnTime = itemView.FindViewById<TextView>(Resource.Id.receipt_TxnTime);
            reciept_StoreName = itemView.FindViewById<TextView>(Resource.Id.receipt_StoreName);
            reciept_RewardGained = itemView.FindViewById<TextView>(Resource.Id.receipt_RewardGained);
        }
    }
    class receipt_RecycleViewAdapter : RecyclerView.Adapter
    {
        private List<receipt_Data> listData = new List<receipt_Data>();
        

        public receipt_RecycleViewAdapter(List<receipt_Data> listData)
        {
            this.listData = listData;
        }

        public override int ItemCount
        {
            get
            {
                return listData.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            receipt_RecycleViewHolder viewHolder = holder as receipt_RecycleViewHolder;
            viewHolder.reciept_TotalAmount.Text = listData[position].reciept_TotalAmount;
            viewHolder.reciept_TxnID.Text = listData[position].reciept_TxnID;
            viewHolder.reciept_TxnTime.Text = listData[position].reciept_TxnTime;
            viewHolder.reciept_StoreName.Text = listData[position].reciept_StoreName;
            viewHolder.reciept_RewardGained.Text = listData[position].reciept_RewardGained;
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.row_Reciept, parent, false);
            return new receipt_RecycleViewHolder(itemView);
        }
    }
}