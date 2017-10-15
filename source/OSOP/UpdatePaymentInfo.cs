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
    public class UpdatePaymentInfo : Activity
    {
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId,
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate;

        private string cardAdditionMessage;
        private bool cardAdditionStatus = false;


        TextView creditCard_Tagline1, creditCard_Tagline2, creditCard_Tagline3, creditCard_Tagline4, creditCard_Required;
        EditText creditCard_Numberblock1, creditCard_Numberblock2, creditCard_Numberblock3, creditCard_Numberblock4;
        EditText creditCard_Name, creditCard_ValidYear, creditCardValidMonth, creditCard_ValidFromYear, creditCard_ValidFromMonth;
        Button paymentScreen_SubmitInfo;
        TextView paymentScreen_CancelInfo;
        //TextView debitCard_Tagline1, debitCard_Tagline2, debitCard_Tagline3, debitCard_Tagline4, debitCard_Required;
        //EditText debitCard_Numberblock1, debitCard_Numberblock2, debitCard_Numberblock3, debitCard_Numberblock4;
        //EditText debitCard_Name, debitCard_ValidYear, debitCardValidMonth, debitCard_ValidFromYear, debitCard_ValidFromMonth;
        ScrollView creditCard_Layout, debitCard_Layout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.paymentInfo_Screen);

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

            Console.WriteLine("userId : " + userId);
            Console.WriteLine("wId : " + wId);

            debitCardHolderName = Intent.GetStringExtra("debitCardHolderName") ?? "Data not available";
            debitCardNumber = Intent.GetStringExtra("debitCardNumber") ?? "Data not available";
            debitExpiryDate = Intent.GetStringExtra("debitExpiryDate") ?? "Data not available";
            debitStartDate = Intent.GetStringExtra("debitStartDate") ?? "Data not available";

            creditCardHolderName = Intent.GetStringExtra("creditCardHolderName") ?? "Data not available";
            creditCardNumber = Intent.GetStringExtra("creditCardNumber") ?? "Data not available";
            creditExpiryDate = Intent.GetStringExtra("creditExpiryDate") ?? "Data not available";
            creditStartDate = Intent.GetStringExtra("creditStartDate") ?? "Data not available";

            //All views declarations are inside this Method.
            FindViews();
            creditCard_Name.Text = debitCardHolderName;
            creditCard_Numberblock1.Text = debitCardNumber.Split('-')[0];
            creditCard_Numberblock2.Text = debitCardNumber.Split('-')[1];
            creditCard_Numberblock3.Text = debitCardNumber.Split('-')[2];
            creditCard_Numberblock4.Text = debitCardNumber.Split('-')[3];
            creditCard_ValidYear.Text = debitExpiryDate.Split('-')[0];
            creditCardValidMonth.Text = debitExpiryDate.Split('-')[1];

            creditCard_ValidFromYear.Text = "2015";
            creditCard_ValidFromMonth.Text = "03";

            //All click events registered are inside this Method.
            ClickEvnets();

        }

        private void ClickEvnets()
        {
            paymentScreen_SubmitInfo.Click += PaymentScreen_SubmitInfo_ClickAsync;
            paymentScreen_CancelInfo.Click += PaymentScreen_CancelInfo_Click;

        }


        private void PaymentScreen_CancelInfo_Click(object sender, EventArgs e)
        {
            OnBackPressed();
        }

        private async void PaymentScreen_SubmitInfo_ClickAsync(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Clicked.", ToastLength.Short).Show();
            //Toast.MakeText(this, "Card Information Updated", ToastLength.Short).Show();
            if (string.IsNullOrEmpty(creditCard_Numberblock1.Text) || string.IsNullOrEmpty(creditCard_Numberblock2.Text)
                || string.IsNullOrEmpty(creditCard_Numberblock3.Text) || string.IsNullOrEmpty(creditCard_Numberblock4.Text)
                || string.IsNullOrEmpty(creditCard_ValidYear.Text) || string.IsNullOrEmpty(creditCardValidMonth.Text) 
                || string.IsNullOrEmpty(creditCard_Name.Text))
                
            {
                Toast.MakeText(this, "Make sure all the mandatory fields are filled.", ToastLength.Short).Show();
            }
            else
            {
                if (string.IsNullOrEmpty(creditCard_ValidFromYear.Text) || string.IsNullOrEmpty(creditCard_ValidFromMonth.Text))
                {
                    creditCard_ValidFromYear.Text = "0000-00-0000";
                    creditCard_ValidFromMonth.Text = "0000-00-0000";
                }
                Toast.MakeText(this, "Clicked 2.", ToastLength.Short).Show();
                await Task.Run(() => PaymentProcessor(creditCard_Name.Text, creditCard_Numberblock1.Text + "-" + creditCard_Numberblock2.Text + "-"
                    + creditCard_Numberblock3.Text + "-" + creditCard_Numberblock4.Text, creditCard_ValidYear.Text + "-" + creditCardValidMonth.Text + "-01",
                    creditCard_ValidFromYear.Text + "-" + creditCard_ValidFromMonth.Text + "-01", userId, wId));

                Toast.MakeText(this, "Clicked 3.", ToastLength.Short).Show();
            }
        }

        private void FindViews()
        {
            //View Declaration of Credit Card Field
            creditCard_Tagline1 = FindViewById<TextView>(Resource.Id.paymentScreen_CreditCardTagline1);
            creditCard_Tagline2 = FindViewById<TextView>(Resource.Id.paymentScreen_CreditCardTagline2);
            creditCard_Tagline3 = FindViewById<TextView>(Resource.Id.paymentScreen_CreditCardTagline3);
            creditCard_Tagline4 = FindViewById<TextView>(Resource.Id.paymentScreen_CreditCardTagline4);
            creditCard_Required = FindViewById<TextView>(Resource.Id.paymentScreen_CreditCardTagline5);
            creditCard_Numberblock1 = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardNumber1);
            creditCard_Numberblock2 = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardNumber2);
            creditCard_Numberblock3 = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardNumber3);
            creditCard_Numberblock4 = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardNumber4);
            creditCard_Name = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardName);
            creditCard_ValidYear = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardValidYear);
            creditCardValidMonth = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardValidMonth);
            creditCard_ValidFromYear = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardValidFromYear);
            creditCard_ValidFromMonth = FindViewById<EditText>(Resource.Id.paymentScreen_CreditCardValidFromMonth);
            creditCard_Layout = FindViewById<ScrollView>(Resource.Id.paymentScreen_CreditCardInfo);


            //Submit Button and Cancel Button declaration
            paymentScreen_SubmitInfo= FindViewById<Button>(Resource.Id.paymentScreen_SubmitInfo);
            paymentScreen_CancelInfo = FindViewById<TextView>(Resource.Id.paymentScreen_CancelInfo);

            //View Declaration of Debit Card Field

            //Declaring Custom Fonts Typeface
            Typeface tf = Typeface.CreateFromAsset(Assets, "Raleway-SemiBold.ttf");
            Typeface tf1 = Typeface.CreateFromAsset(Assets, "Raleway-Regular.ttf");
            Typeface tf2 = Typeface.CreateFromAsset(Assets, "OpenSans-Regular.ttf");
            Typeface tf3 = Typeface.CreateFromAsset(Assets, "OpenSans-Light.ttf");

            //Applying Custom fonts
           
            creditCard_Tagline1.SetTypeface(tf1, TypefaceStyle.Normal);
            creditCard_Tagline2.SetTypeface(tf1, TypefaceStyle.Normal);
            creditCard_Tagline3.SetTypeface(tf1, TypefaceStyle.Normal);
            creditCard_Tagline4.SetTypeface(tf1, TypefaceStyle.Normal);
            creditCard_Required.SetTypeface(tf2, TypefaceStyle.Bold);
            creditCard_Numberblock1.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_Numberblock2.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_Numberblock3.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_Numberblock4.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_Name.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_ValidYear.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCardValidMonth.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_ValidFromYear.SetTypeface(tf2, TypefaceStyle.Normal);
            creditCard_ValidFromMonth.SetTypeface(tf2, TypefaceStyle.Normal);

            paymentScreen_SubmitInfo.SetTypeface(tf, TypefaceStyle.Normal);
            paymentScreen_CancelInfo.SetTypeface(tf3, TypefaceStyle.Normal);

           

        }

        private async Task PaymentProcessor(string debitCardHolderName, string debitCardNumber, string debitExpiryDate, 
            string debitStartDate, string userId, string walletId)
        {
            Console.WriteLine("debitCardNumber : " + debitCardNumber);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("debitCardHolderName", debitCardHolderName),
                    new KeyValuePair<string, string>("debitCardNumber", debitCardNumber),
                    new KeyValuePair<string, string>("debitExpiryDate", debitExpiryDate),
                    new KeyValuePair<string, string>("debitStartDate", debitStartDate),
                    new KeyValuePair<string, string>("userId", userId),
                    new KeyValuePair<string, string>("walletId", walletId)
                });
                var result = await client.PostAsync("/uhack/api/cardsInformation/debitCardInformationAddition.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                Console.WriteLine("resultContent Debit : " + resultContent);
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
                        Console.WriteLine("Addition Failed : " + obj2.message);
                        this.cardAdditionMessage = obj2.message;
                        this.cardAdditionStatus = false;
                    }
                    else
                    {
                        this.cardAdditionMessage = obj2.message;
                        this.cardAdditionStatus = true;
                    }
                }
                catch (Exception AdditionException)
                {
                    Console.WriteLine("AdditionException : " + AdditionException);
                    throw;
                }
            }

        }
    }
}