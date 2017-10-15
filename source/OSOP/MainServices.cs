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

namespace OSOP
{
    [Activity]
    public class MainServices : Activity
    {
        Button Services_paymentInfo, Services_addAmount, Services_QRScan, Services_eReceipts, Services_ProfileInfo, Services_Rewards;
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId, 
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Services);

            // All the Intent Data for the logged in user's account.

            userName = Intent.GetStringExtra("userName") ?? "Data not available";
            userEmail = Intent.GetStringExtra("userEmail") ?? "Data not available";
            customerID = Intent.GetStringExtra("customerID") ?? "Data not available";
            userPhoto = Intent.GetStringExtra("userPhoto") ?? "Data not available";
            userPhoneNumber = Intent.GetStringExtra("userPhoneNumber") ?? "Data not available";
            accountEnabled = Intent.GetStringExtra("accountEnabled") ?? "Data not available";
            accountAmount = Intent.GetStringExtra("accountAmount") ?? "Data not available";
            wId = Intent.GetStringExtra("wId") ?? "Data not available";
            walletAmount = Intent.GetStringExtra("walletAmount") ?? "Data not available";
            userRewardPoints = Intent.GetStringExtra("userRewardPoints") ?? "Data not available";
            cId = Intent.GetStringExtra("cId") ?? "Data not available";
            userId = Intent.GetStringExtra("userId") ?? "Data not available";

            debitCardHolderName = Intent.GetStringExtra("debitCardHolderName") ?? "Data not available";
            debitCardNumber = Intent.GetStringExtra("debitCardNumber") ?? "Data not available";
            debitExpiryDate = Intent.GetStringExtra("debitExpiryDate") ?? "Data not available";
            debitStartDate = Intent.GetStringExtra("debitStartDate") ?? "Data not available";

            creditCardHolderName = Intent.GetStringExtra("creditCardHolderName") ?? "Data not available";
            creditCardNumber = Intent.GetStringExtra("creditCardNumber") ?? "Data not available";
            creditExpiryDate = Intent.GetStringExtra("creditExpiryDate") ?? "Data not available";
            creditStartDate = Intent.GetStringExtra("creditStartDate") ?? "Data not available";

            //All the View Declaration is contained in this method
            FindViews();

            //All the Click events registered are contained in this method
            ClickEvents();
        }

        private void ClickEvents()
        {
            Services_paymentInfo.Click += Services_paymentInfo_Click;
            Services_addAmount.Click += Services_addAmount_Click;
            Services_QRScan.Click += Services_QRScan_Click;
            Services_eReceipts.Click += Services_eReceipts_Click;
            Services_Rewards.Click += Services_Rewards_Click;
            Services_ProfileInfo.Click += Services_ProfileInfo_Click;
        }

        private void Services_ProfileInfo_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "This Section is under Development", ToastLength.Short).Show();
        }

        private void Services_Rewards_Click(object sender, EventArgs e)
        {
            var IntentmyRewards = new Intent(this, typeof(myRewardsService));
            IntentmyRewards.PutExtra("userName", this.userName);
            IntentmyRewards.PutExtra("userEmail", this.userEmail);
            IntentmyRewards.PutExtra("customerID", this.customerID);
            IntentmyRewards.PutExtra("userPhoto", this.userPhoto);
            IntentmyRewards.PutExtra("userPhoneNumber", this.userPhoneNumber);
            IntentmyRewards.PutExtra("accountEnabled", this.accountEnabled);
            IntentmyRewards.PutExtra("accountAmount", this.accountAmount);
            IntentmyRewards.PutExtra("wId", this.wId);
            IntentmyRewards.PutExtra("userId", this.userId);
            IntentmyRewards.PutExtra("walletAmount", this.walletAmount);
            IntentmyRewards.PutExtra("userRewardPoints", this.userRewardPoints);
            IntentmyRewards.PutExtra("cId", this.cId);
            IntentmyRewards.PutExtra("debitCardHolderName", this.debitCardHolderName);
            IntentmyRewards.PutExtra("debitCardNumber", this.debitCardNumber);
            IntentmyRewards.PutExtra("debitExpiryDate", this.debitExpiryDate);
            IntentmyRewards.PutExtra("debitStartDate", this.debitStartDate);
            IntentmyRewards.PutExtra("creditCardHolderName", this.creditCardHolderName);
            IntentmyRewards.PutExtra("creditCardNumber", this.creditCardNumber);
            IntentmyRewards.PutExtra("creditExpiryDate", this.creditExpiryDate);
            IntentmyRewards.PutExtra("creditStartDate", this.creditStartDate);
            StartActivity(IntentmyRewards);
        }

        private void Services_eReceipts_Click(object sender, EventArgs e)
        {
            var IntentEReceipts = new Intent(this, typeof(eReceipt));
            StartActivity(IntentEReceipts);
        }  

        private void Services_QRScan_Click(object sender, EventArgs e)
        {
            var IntentQRScan = new Intent(this, typeof(ShoppingServices));
            IntentQRScan.PutExtra("userName", this.userName);
            IntentQRScan.PutExtra("userEmail", this.userEmail);
            IntentQRScan.PutExtra("customerID", this.customerID);
            IntentQRScan.PutExtra("userPhoto", this.userPhoto);
            IntentQRScan.PutExtra("userPhoneNumber", this.userPhoneNumber);
            IntentQRScan.PutExtra("accountEnabled", this.accountEnabled);
            IntentQRScan.PutExtra("accountAmount", this.accountAmount);
            IntentQRScan.PutExtra("wId", this.wId);
            IntentQRScan.PutExtra("userId", this.userId);
            IntentQRScan.PutExtra("walletAmount", this.walletAmount);
            IntentQRScan.PutExtra("userRewardPoints", this.userRewardPoints);
            IntentQRScan.PutExtra("cId", this.cId);
            IntentQRScan.PutExtra("debitCardHolderName", this.debitCardHolderName);
            IntentQRScan.PutExtra("debitCardNumber", this.debitCardNumber);
            IntentQRScan.PutExtra("debitExpiryDate", this.debitExpiryDate);
            IntentQRScan.PutExtra("debitStartDate", this.debitStartDate);
            IntentQRScan.PutExtra("creditCardHolderName", this.creditCardHolderName);
            IntentQRScan.PutExtra("creditCardNumber", this.creditCardNumber);
            IntentQRScan.PutExtra("creditExpiryDate", this.creditExpiryDate);
            IntentQRScan.PutExtra("creditStartDate", this.creditStartDate);
            StartActivity(IntentQRScan);
        }

        private void Services_addAmount_Click(object sender, EventArgs e)
        {
            var IntentAddAmount = new Intent(this, typeof(AmountAddition));
            IntentAddAmount.PutExtra("userName", this.userName);
            IntentAddAmount.PutExtra("userEmail", this.userEmail);
            IntentAddAmount.PutExtra("customerID", this.customerID);
            IntentAddAmount.PutExtra("userPhoto", this.userPhoto);
            IntentAddAmount.PutExtra("userPhoneNumber", this.userPhoneNumber);
            IntentAddAmount.PutExtra("accountEnabled", this.accountEnabled);
            IntentAddAmount.PutExtra("accountAmount", this.accountAmount);
            IntentAddAmount.PutExtra("wId", this.wId);
            IntentAddAmount.PutExtra("userId", this.userId);
            IntentAddAmount.PutExtra("walletAmount", this.walletAmount);
            IntentAddAmount.PutExtra("userRewardPoints", this.userRewardPoints);
            IntentAddAmount.PutExtra("cId", this.cId);
            IntentAddAmount.PutExtra("debitCardHolderName", this.debitCardHolderName);
            IntentAddAmount.PutExtra("debitCardNumber", this.debitCardNumber);
            IntentAddAmount.PutExtra("debitExpiryDate", this.debitExpiryDate);
            IntentAddAmount.PutExtra("debitStartDate", this.debitStartDate);
            IntentAddAmount.PutExtra("creditCardHolderName", this.creditCardHolderName);
            IntentAddAmount.PutExtra("creditCardNumber", this.creditCardNumber);
            IntentAddAmount.PutExtra("creditExpiryDate", this.creditExpiryDate);
            IntentAddAmount.PutExtra("creditStartDate", this.creditStartDate);
            StartActivity(IntentAddAmount);
        }

        private void Services_paymentInfo_Click(object sender, EventArgs e)
        {
            var IntentPaymentInfo = new Intent(this, typeof(UpdatePaymentInfo));
            IntentPaymentInfo.PutExtra("userName", this.userName);
            IntentPaymentInfo.PutExtra("userEmail", this.userEmail);
            IntentPaymentInfo.PutExtra("customerID", this.customerID);
            IntentPaymentInfo.PutExtra("userPhoto", this.userPhoto);
            IntentPaymentInfo.PutExtra("userPhoneNumber", this.userPhoneNumber);
            IntentPaymentInfo.PutExtra("accountEnabled", this.accountEnabled);
            IntentPaymentInfo.PutExtra("accountAmount", this.accountAmount);
            IntentPaymentInfo.PutExtra("wId", this.wId);
            IntentPaymentInfo.PutExtra("userId", this.userId);
            IntentPaymentInfo.PutExtra("walletAmount", this.walletAmount);
            IntentPaymentInfo.PutExtra("userRewardPoints", this.userRewardPoints);
            IntentPaymentInfo.PutExtra("cId", this.cId);
            IntentPaymentInfo.PutExtra("debitCardHolderName", this.debitCardHolderName);
            IntentPaymentInfo.PutExtra("debitCardNumber", this.debitCardNumber);
            IntentPaymentInfo.PutExtra("debitExpiryDate", this.debitExpiryDate);
            IntentPaymentInfo.PutExtra("debitStartDate", this.debitStartDate);
            IntentPaymentInfo.PutExtra("creditCardHolderName", this.creditCardHolderName);
            IntentPaymentInfo.PutExtra("creditCardNumber", this.creditCardNumber);
            IntentPaymentInfo.PutExtra("creditExpiryDate", this.creditExpiryDate);
            IntentPaymentInfo.PutExtra("creditStartDate", this.creditStartDate);
            StartActivity(IntentPaymentInfo);
        }

        private void FindViews()
        {
            Services_paymentInfo = FindViewById<Button>(Resource.Id.services_PaymentInfo);
            Services_addAmount = FindViewById<Button>(Resource.Id.services_AddAmount);
            Services_QRScan = FindViewById<Button>(Resource.Id.services_QRShopping);
            Services_eReceipts = FindViewById<Button>(Resource.Id.services_eReciepts);
            Services_Rewards = FindViewById<Button>(Resource.Id.services_MyRewards);
            Services_ProfileInfo = FindViewById<Button>(Resource.Id.services_ProfileInfo);
        }

        public override void OnBackPressed()
        {
            Toast.MakeText(this, "Back Button Pressed", ToastLength.Short).Show();
        }
    }
}