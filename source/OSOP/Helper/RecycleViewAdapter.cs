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
    class RecycleViewHolder: RecyclerView.ViewHolder
    {
        public TextView itemName { get; set; }
        public TextView itemPrice { get; set; }
        public RecycleViewHolder(View itemView):base(itemView)
        {
            itemName = itemView.FindViewById<TextView>(Resource.Id.itemName);
            itemPrice = itemView.FindViewById<TextView>(Resource.Id.itemPrice);
        }
    }
    class RecycleViewAdapter : RecyclerView.Adapter
    {
        private List<Data> listData = new List<Data>();
        private List<Data> listData2 = new List<Data>();

        public RecycleViewAdapter(List<Data> listData)
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
            RecycleViewHolder viewHolder = holder as RecycleViewHolder;
            viewHolder.itemName.Text = listData[position].itemNameData;
            viewHolder.itemPrice.Text = listData[position].itemPriceData;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.row, parent, false);
            return new RecycleViewHolder(itemView);
        }
    }
}