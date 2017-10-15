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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Org.Json;

namespace OSOP
{
    [Activity(Label = "eReceipt")]
    public class eReceipt : Activity
    {
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId, receiptArray,
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate, receiptMessage;
        private bool receiptStatus = false;
        //public string[] receiptArray;

        RecyclerView receipt;
        private receipt_RecycleViewAdapter recycleAdapter1;
        private RecyclerView.LayoutManager layoutManager;
        private List<receipt_Data> listData = new List<receipt_Data>();

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.eReceipt_Screen);

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

            Toast.MakeText(this, "Downloading the list.", ToastLength.Short).Show();
            await Task.Run(() => ReceiptFetcher(wId, userId));
            Toast.MakeText(this, "Settings things up.", ToastLength.Short).Show();

            InitData();

            FindViews();

        }

        private void InitData()
        {
            if (receiptStatus)
            {
                dynamic dynJson = JsonConvert.DeserializeObject(receiptArray);
                foreach (var item in dynJson)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", item.rewardPointsGiven, item.billAmount, item.storeName, item.transactionTime);
                    listData.Add(new receipt_Data() { reciept_TotalAmount = item.billAmount, reciept_TxnID = item.transactionID, reciept_TxnTime = item.transactionTime, reciept_StoreName = item.storeName, reciept_RewardGained = item.rewardPointsGiven });
                }
                Toast.MakeText(this, "done.", ToastLength.Short).Show();
            }
            else
            {
                listData.Add(new receipt_Data() { reciept_TotalAmount = "N/A", reciept_TxnID = "N/A", reciept_TxnTime = "N/A", reciept_StoreName = "N/A", reciept_RewardGained = "N/A" });
            }
            //listData.Add(new receipt_Data() { reciept_TotalAmount = "9", reciept_TxnID = "1000000", reciept_TxnTime = "2017-09-23 08:50:00", reciept_StoreName = "Store 1", reciept_RewardGained = "50" });
            
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

        private async Task ReceiptFetcher(string wId, string userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("wId", wId),
                    new KeyValuePair<string, string>("userId", userId)
                });
                var result = await client.PostAsync("/uhack/api/transactions/receiptsDisplay.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                Console.WriteLine("resultContent : " + resultContent);
                //Console.WriteLine("User id: " + userId);
                //Console.WriteLine("amountToDeduct: " + amountToDeduct);
                //Console.WriteLine("wId: " + wId);
                //Console.WriteLine("storeName: " + storeName);
                //Console.WriteLine("itemList: " + itemList);
                //Console.WriteLine("customerId: " + customerId);
                //Console.WriteLine("receiverAccountNumber: " + receiverAccountNumber);

                try
                {
                    //string tempData = resultContent.Replace("[", "").Replace("]", "");
                    //Console.WriteLine("tempData : " + tempData);
                    receiptArray = resultContent;
                    this.receiptStatus = true;
                    //Toast.MakeText(this, "Downloaded the list.", ToastLength.Short).Show();

                    //dynamic obj2 = Newtonsoft.Json.Linq.JObject.Parse(tempData);

                    //try
                    //{
                    //    if (obj2.error_code == 1)
                    //    {
                    //        Console.WriteLine("Sign Up Failed : " + obj2.message);
                    //        this.receiptMessage = obj2.message;
                    //        this.receiptStatus = false;
                    //    }
                    //}
                    //catch (Exception lel)
                    //{
                    //    Console.WriteLine("Here : " + lel);
                    //    //throw;
                    //    this.receiptStatus = true;
                    //    receiptArray = resultContent;
                    //}
                    //else
                    //{
                    //    this.receiptStatus = true;
                    //    receiptArray = resultContent;
                    //}
                }
                catch (Exception SignInException)
                {
                    Console.WriteLine("SignInException : " + SignInException);
                    throw;
                }
            }

        }
    }
}