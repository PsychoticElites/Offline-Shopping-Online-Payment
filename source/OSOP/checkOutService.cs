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
using Android.Graphics;
using Android.Support.V7.Widget;
using OSOP.Helper;
using System.Threading.Tasks;
using System.Net.Http;

namespace OSOP
{
    [Activity(Label = "Checkout Counter")]
    public class checkOutService : Activity
    {
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId,
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate;
        public string totalAmount, storeName, itemPriceListString, itemNameListString, itemListJSONRep = "{", message, paymentMessage;
        private List<string> itemNameListConverted;
        private List<string> itemPriceListConverted;
        private bool PaymentStatus = false;
        Button checkout_PaymentInit;

        public Dictionary<string, string> itemList = new Dictionary<string, string>(); //itemList is the parameter for the payment API.

        TextView totalPrice;
        string finalAmount1;
        private RecyclerView recycleView;
        private RecycleViewAdapter recycleAdapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<Data> listData = new List<Data>();
        private List<double> itemPriceList_Final;
        private List<string> itemNameList_Final;
        private string storeName_Final;
        private string finalAmount;

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
            Toast.MakeText(this, "Action Not Allowed!", ToastLength.Long).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.checkOutScreen);

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

            totalAmount = Intent.GetStringExtra("totalAmount") ?? "Data not available";
            storeName = Intent.GetStringExtra("storeName") ?? "Data not available";
            itemPriceListString = Intent.GetStringExtra("itemPriceList") ?? "Data not available";
            itemNameListString = Intent.GetStringExtra("itemNameList") ?? "Data not available";

            //Console.WriteLine("itemNameListString : " + itemNameListString);
            //Console.WriteLine("itemPriceListString : " + itemPriceListString);

            // Convert the string to the list to later make a dictionary.
            itemNameListConverted = itemNameListString.Split(',').ToList();
            itemPriceListConverted = itemPriceListString.Split(',').ToList();


            for (int i = 0; i < itemNameListConverted.Count; i++)
            {
                itemListJSONRep = itemListJSONRep + "\"" + itemNameListConverted[i] + "\"" + ":" + "\"" + itemPriceListConverted[i] + "\",";

            }
            // Final cleaning the last , and adding } to make a perfect json!
            itemListJSONRep = itemListJSONRep.TrimEnd(',');
            itemListJSONRep = itemListJSONRep + "}";

            FindViews();
            ClickEvents();
            valueSetter();

            InitData();

            recycleView = FindViewById<RecyclerView>(Resource.Id.recyclerScreen);
            recycleView.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(this);
            recycleView.SetLayoutManager(layoutManager);
            recycleAdapter = new RecycleViewAdapter(listData);
            recycleView.SetAdapter(recycleAdapter);
            // Empty the cart, because the transaction has been made!
            ValueCleaner();

            //Add this here
            // await Task.Run(() => PaymentProcessor(userId, totalAmount, wId, storeName, itemListJSONRep, customerID, "000000000000"));
        }

        private void ClickEvents()
        {
            checkout_PaymentInit.Click += Checkout_PaymentInit_ClickAsync;
        }

        private async void Checkout_PaymentInit_ClickAsync(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Paying The Money", ToastLength.Long).Show();
            await Task.Run(() => PaymentProcessor(userId, totalAmount, wId, storeName, itemListJSONRep, customerID, "000000000000"));
            if (PaymentStatus)
            {
                Toast.MakeText(this, "Payment Successful.", ToastLength.Long).Show();
                // Open the MainServices screen after the successfull payment.
                var MainServices = new Intent(this, typeof(MainServices));
                MainServices.PutExtra("userName", this.userName);
                MainServices.PutExtra("userEmail", this.userEmail);
                MainServices.PutExtra("customerID", this.customerID);
                MainServices.PutExtra("userPhoto", this.userPhoto);
                MainServices.PutExtra("userPhoneNumber", this.userPhoneNumber);
                MainServices.PutExtra("accountEnabled", this.accountEnabled);
                MainServices.PutExtra("accountAmount", this.accountAmount);
                MainServices.PutExtra("wId", this.wId);
                MainServices.PutExtra("userId", this.userId);
                MainServices.PutExtra("walletAmount", this.walletAmount);
                MainServices.PutExtra("userRewardPoints", this.userRewardPoints);
                MainServices.PutExtra("cId", this.cId);
                MainServices.PutExtra("debitCardHolderName", this.debitCardHolderName);
                MainServices.PutExtra("debitCardNumber", this.debitCardNumber);
                MainServices.PutExtra("debitExpiryDate", this.debitExpiryDate);
                MainServices.PutExtra("debitStartDate", this.debitStartDate);
                MainServices.PutExtra("creditCardHolderName", this.creditCardHolderName);
                MainServices.PutExtra("creditCardNumber", this.creditCardNumber);
                MainServices.PutExtra("creditExpiryDate", this.creditExpiryDate);
                MainServices.PutExtra("creditStartDate", this.creditStartDate);
                StartActivity(MainServices);
            }
            else
            {
                Toast.MakeText(this, "Payment Failed. Try Again", ToastLength.Long).Show();
                Toast.MakeText(this, paymentMessage, ToastLength.Long).Show();
            }
        }

        private void InitData()
        {
            {
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
                //listData.Add(new Data() { itemNameData = "Dairy Milk - Silk", itemPriceData = "10" });
            }
            for (int i = 0; i != itemNameListConverted.Count; i++)
            {
                listData.Add(new Data() { itemNameData = itemNameListConverted[i], itemPriceData = Convert.ToString(itemPriceListConverted[i]) });
            }

        }

        private void FindViews()
        {
            totalPrice = FindViewById<TextView>(Resource.Id.buttonScanQR);
            Typeface tf1 = Typeface.CreateFromAsset(Assets, "Poppins-Medium.ttf");
            totalPrice.SetTypeface(tf1, TypefaceStyle.Normal);
            checkout_PaymentInit = FindViewById<Button>(Resource.Id.checkout_PaymentInit);
        }

        private void valueSetter()
        {
            totalPrice.Text = Convert.ToString(totalAmount);
        }

        public void ValueCleaner()
        {
            ShoppingServices.storeName = null;
            ShoppingServices.totalAmount = null;
            ShoppingServices.itemNameList.Clear();
            ShoppingServices.itemPriceList.Clear();
        }

        private async Task PaymentProcessor(string userId, string amountToDeduct, string wId, string storeName, string itemList, string customerId, string receiverAccountNumber)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("userId", userId),
                    new KeyValuePair<string, string>("wId", wId),
                    new KeyValuePair<string, string>("storeName", storeName),
                    new KeyValuePair<string, string>("itemList", itemList),
                    new KeyValuePair<string, string>("customerId", customerId),
                    new KeyValuePair<string, string>("receiverAccountNumber", receiverAccountNumber),
                    new KeyValuePair<string, string>("amountToDeduct", amountToDeduct)
                });
                var result = await client.PostAsync("/uhack/api/transactions/finalTransaction.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                Console.WriteLine("resultContent : " + resultContent);
                Console.WriteLine("User id: " + userId);
                Console.WriteLine("amountToDeduct: " + amountToDeduct);
                Console.WriteLine("wId: " + wId);
                Console.WriteLine("storeName: " + storeName);
                Console.WriteLine("itemList: " + itemList);
                Console.WriteLine("customerId: " + customerId);
                Console.WriteLine("receiverAccountNumber: " + receiverAccountNumber);

                try
                {
                    dynamic obj2 = Newtonsoft.Json.Linq.JObject.Parse(resultContent);

                    if (obj2.error_code == 1)
                    {
                        Console.WriteLine("Sign Up Failed : " + obj2.message);
                        this.paymentMessage = obj2.message;
                        this.PaymentStatus = false;
                    }
                    else
                    {
                        this.paymentMessage = obj2.message;
                        this.PaymentStatus = true;
                    }
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