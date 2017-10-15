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
using System.Threading.Tasks;
using System.Net.Http;

namespace OSOP
{
    [Activity(MainLauncher =false)]
    public class AmountAddition : Activity
    {
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId,
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate;
        private string transferMessage;
        private bool TransferStatus = false;

        TextView amountAddition_Tagline1, amountAddition_Tagline2, amountAddition_Tagline3, amountAddition_Tagline4, amountAddition_Tagline5;
        TextView amountAddition_RupeeSymbol, amountAddition_WalletBalance;
        EditText amountAddition_AddAmount;
        TextView amountAddition_CardBlock1, amountAddition_CardBlock2, amountAddition_CardBlock3, amountAddition_CardBlock4;
        TextView amountAddition_ValidYear, amountAddition_ValidMonth;
        EditText amountAddition_CVV;
        Button amountAddition_SubmitAmount;
        TextView amountAddition_Cancel;
        //RadioButton amountAddition_debitRadio, amountAddition_creditRadio;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.amountAddition);

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

            amountAddition_WalletBalance.Text = walletAmount;
            amountAddition_CardBlock1.Text = debitCardNumber.Split('-')[0];
            amountAddition_CardBlock2.Text = debitCardNumber.Split('-')[1];
            amountAddition_CardBlock3.Text = debitCardNumber.Split('-')[2];
            amountAddition_CardBlock4.Text = debitCardNumber.Split('-')[3];
            amountAddition_ValidYear.Text = debitExpiryDate.Split('-')[0];
            amountAddition_ValidMonth.Text = debitExpiryDate.Split('-')[1];

            //All the Click events registered are contained in this method
            ClickEvents();
        }

        private void ClickEvents()
        {
            
            amountAddition_SubmitAmount.Click += AmountAddition_SubmitAmount_ClickAsync;
            amountAddition_Cancel.Click += AmountAddition_Cancel_Click;
        }

        private void AmountAddition_Cancel_Click(object sender, EventArgs e)
        {
            OnBackPressed();
        }

        private async void AmountAddition_SubmitAmount_ClickAsync(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "Amount Added", ToastLength.Short).Show();
            if (string.IsNullOrEmpty(amountAddition_CVV.Text) || string.IsNullOrEmpty(amountAddition_AddAmount.Text))
            {
                Toast.MakeText(this, "Make sure all the fields are filled.", ToastLength.Short).Show();
            }
            else
            {
                await Task.Run(() => MoneyAdder(amountAddition_AddAmount.Text, wId, userId));
                if (TransferStatus)
                {
                    Toast.MakeText(this, "Money Added Successfully.", ToastLength.Short).Show();
                    amountAddition_WalletBalance.Text = Convert.ToString(Convert.ToDouble(amountAddition_AddAmount.Text) + Convert.ToDouble(amountAddition_WalletBalance.Text));
                    walletAmount = amountAddition_WalletBalance.Text;
                    amountAddition_AddAmount.Text = "";
                }
                else
                {
                    Toast.MakeText(this, transferMessage, ToastLength.Short).Show();
                }
            }
        }


        private void FindViews()
        {
            amountAddition_Tagline1 = FindViewById<TextView>(Resource.Id.updateWallet_Tagline1);
            amountAddition_Tagline2 = FindViewById<TextView>(Resource.Id.updateWallet_Tagline2);
            amountAddition_Tagline3 = FindViewById<TextView>(Resource.Id.updateWallet_Tagline3);
            amountAddition_Tagline4 = FindViewById<TextView>(Resource.Id.updateWallet_Tagline4);
            amountAddition_Tagline5 = FindViewById<TextView>(Resource.Id.updateWallet_Tagline5);
            amountAddition_RupeeSymbol = FindViewById<TextView>(Resource.Id.updateWallet_RupeeSymbol);
            amountAddition_WalletBalance = FindViewById<TextView>(Resource.Id.updateWallet_Balance);
            amountAddition_AddAmount = FindViewById<EditText>(Resource.Id.updateWallet_AddAmount);
            amountAddition_CardBlock1 = FindViewById<TextView>(Resource.Id.updateWallet_CardNumber1);
            amountAddition_CardBlock2 = FindViewById<TextView>(Resource.Id.updateWallet_CardNumber2);
            amountAddition_CardBlock3 = FindViewById<TextView>(Resource.Id.updateWallet_CardNumber3);
            amountAddition_CardBlock4 = FindViewById<TextView>(Resource.Id.updateWallet_CardNumber4);
            amountAddition_ValidYear = FindViewById<TextView>(Resource.Id.updateWallet_ValidYear);
            amountAddition_ValidMonth = FindViewById<TextView>(Resource.Id.updateWallet_ValidMonth);
            amountAddition_CVV = FindViewById<EditText>(Resource.Id.updateWallet_CVV);
            amountAddition_SubmitAmount = FindViewById<Button>(Resource.Id.updateWallet_SubmitInfo);
            amountAddition_Cancel = FindViewById<TextView>(Resource.Id.updateWallet_Cancel);
            

            //Declaring Custom Fonts Typeface
            Typeface tf = Typeface.CreateFromAsset(Assets, "Raleway-SemiBold.ttf");
            Typeface tf1 = Typeface.CreateFromAsset(Assets, "Raleway-Regular.ttf");
            Typeface tf2 = Typeface.CreateFromAsset(Assets, "OpenSans-Regular.ttf");
            Typeface tf3 = Typeface.CreateFromAsset(Assets, "OpenSans-SemiBold.ttf");


            //Applying Custom Fonts
            amountAddition_Tagline1.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_Tagline2.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_Tagline3.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_Tagline4.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_Tagline5.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_RupeeSymbol.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_WalletBalance.SetTypeface(tf3, TypefaceStyle.Normal);
            amountAddition_AddAmount.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_CardBlock1.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_CardBlock2.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_CardBlock3.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_CardBlock4.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_ValidYear.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_ValidMonth.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_CVV.SetTypeface(tf2, TypefaceStyle.Normal);
            amountAddition_SubmitAmount.SetTypeface(tf, TypefaceStyle.Normal);
            amountAddition_Cancel.SetTypeface(tf, TypefaceStyle.Normal);
            

        }

        private async Task MoneyAdder(string amountToAdd, string wId, string userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("amountToAdd", amountToAdd),
                    new KeyValuePair<string, string>("wId", wId),
                    new KeyValuePair<string, string>("userId", userId)
                });
                var result = await client.PostAsync("/uhack/api/transactions/cardToWalletMoney.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                //Console.WriteLine("resultContent : " + resultContent);
                //Console.WriteLine("User id: " + userId);
                //Console.WriteLine("amountToDeduct: " + amountToDeduct);
                //Console.WriteLine("wId: " + wId);
                //Console.WriteLine("storeName: " + storeName);
                //Console.WriteLine("itemList: " + itemList);
                //Console.WriteLine("customerId: " + customerId);
                //Console.WriteLine("receiverAccountNumber: " + receiverAccountNumber);

                try
                {
                    dynamic obj2 = Newtonsoft.Json.Linq.JObject.Parse(resultContent);

                    if (obj2.error_code == 1)
                    {
                        Console.WriteLine("Sign Up Failed : " + obj2.message);
                        this.transferMessage = obj2.message;
                        this.TransferStatus = false;
                    }
                    else
                    {
                        this.transferMessage = obj2.message;
                        this.TransferStatus = true;
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