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
    public class MainActivity_Signup : Activity
    {
        private string message;
        private bool signUpStatus;
        private bool SignInStatus = false;
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount;
        public string wId, userId, walletAmount, userRewardPoints, cId, debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, 
            creditCardNumber, creditExpiryDate, creditStartDate;

        ImageView signupScreen_CloseLayout, signupScreen_GoogleIcon;
        TextView signupScreen_Tagline1, signupScreen_Tagline2, sigupScreen_GoogleText, signupScreen_Terms;
        Button signupScreen_SignupButton;
        EditText signupScreen_Name, signupScreen_Phone, signupScreen_EmailID, signupScreen_Password;
        LinearLayout mainlayout_SignupScreen;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainScreen_Signup);

            //All the View Declaration is contained in this method
            FindViews();

            //All the Click events registered are contained in this method
            ClickEvents();
        }

        private void ClickEvents()
        {
            signupScreen_CloseLayout.Click += SignupScreen_CloseLayout_Click;
            signupScreen_GoogleIcon.Click += SignupScreen_GoogleIcon_Click;
            sigupScreen_GoogleText.Click += SigupScreen_GoogleText_Click;
            signupScreen_SignupButton.Click += SignupScreen_SignupButton_ClickAsync;
        }

        private async void SignupScreen_SignupButton_ClickAsync(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Trying To Sign You Up!", ToastLength.Long).Show();

            if (string.IsNullOrEmpty(signupScreen_Name.Text) || string.IsNullOrEmpty(signupScreen_EmailID.Text) || string.IsNullOrEmpty(signupScreen_Phone.Text) || string.IsNullOrEmpty(signupScreen_Password.Text))
            {
                Toast.MakeText(this, "Please make sure that all the fields are filled.", ToastLength.Long).Show();
            }
            else
            {
                if (Android.Util.Patterns.EmailAddress.Matcher(signupScreen_EmailID.Text.Trim()).Matches())
                {
                    await Task.Run(() => SignUpPoster(signupScreen_Name.Text, signupScreen_EmailID.Text, "+91-" + signupScreen_Phone.Text, signupScreen_Password.Text));
                    Toast.MakeText(this, "Creating Your Account.", ToastLength.Long).Show();

                    if (this.signUpStatus)
                    {
                        await Task.Run(() => SignInPoster(signupScreen_EmailID.Text, signupScreen_Password.Text));
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
                        Toast.MakeText(this, this.message, ToastLength.Long).Show();
                    }
                    
                }
                else
                {
                    Toast.MakeText(this, "Please Enter A Proper Email ID.", ToastLength.Long).Show();
                }
            }
        }

        private void SigupScreen_GoogleText_Click(object sender, EventArgs e)
        {
            GoogleSignup();
        }

        private void SignupScreen_GoogleIcon_Click(object sender, EventArgs e)
        {
            GoogleSignup();
        }

        private void SignupScreen_CloseLayout_Click(object sender, EventArgs e)
        {
            OnBackPressed();
        }

        private void GoogleSignup()
        {
            Toast.MakeText(this, "Google Signup Clicked", ToastLength.Short).Show();
        }

        private void FindViews()
        {
            // View Declaration of Signup Layout
            signupScreen_CloseLayout = FindViewById<ImageView>(Resource.Id.Signup_CloseLayout);
            signupScreen_Tagline1 = FindViewById<TextView>(Resource.Id.SignupScreen_TagLine1);
            signupScreen_Tagline2 = FindViewById<TextView>(Resource.Id.SignupScreen_TagLine2);
            signupScreen_Name = FindViewById<EditText>(Resource.Id.SignupScreen_FullName);
            signupScreen_Phone = FindViewById<EditText>(Resource.Id.SignupScreen_PhoneNumber);
            signupScreen_EmailID = FindViewById<EditText>(Resource.Id.SignupScreen_EmailID);
            signupScreen_Password = FindViewById<EditText>(Resource.Id.SignupScreen_Password);
            signupScreen_Terms = FindViewById<TextView>(Resource.Id.SignupScreen_Terms);
            signupScreen_GoogleIcon = FindViewById<ImageView>(Resource.Id.SignupScreen_GoogleSignup);
            sigupScreen_GoogleText = FindViewById<TextView>(Resource.Id.SignupScreen_GoogleSignup1);
            signupScreen_SignupButton = FindViewById<Button>(Resource.Id.SignupScreen_SignupButton);
            mainlayout_SignupScreen = FindViewById<LinearLayout>(Resource.Id.mainLayout_SignupScreen);

            //Declaring Custom Fonts Typeface
            Typeface tf = Typeface.CreateFromAsset(Assets, "Raleway-SemiBold.ttf");
            Typeface tf1 = Typeface.CreateFromAsset(Assets, "Raleway-Regular.ttf");
            Typeface tf2 = Typeface.CreateFromAsset(Assets, "OpenSans-Regular.ttf");


            //Applying Custom fonts
            signupScreen_Tagline1.SetTypeface(tf, TypefaceStyle.Normal);
            signupScreen_Tagline2.SetTypeface(tf, TypefaceStyle.Normal);
            signupScreen_Name.SetTypeface(tf2, TypefaceStyle.Normal);
            signupScreen_Phone.SetTypeface(tf2, TypefaceStyle.Normal);
            signupScreen_EmailID.SetTypeface(tf2, TypefaceStyle.Normal);
            signupScreen_Password.SetTypeface(tf2, TypefaceStyle.Normal);
            signupScreen_Terms.SetTypeface(tf2, TypefaceStyle.Bold);
            sigupScreen_GoogleText.SetTypeface(tf2, TypefaceStyle.Normal);
            signupScreen_SignupButton.SetTypeface(tf, TypefaceStyle.Normal);
        }

        private async Task SignUpPoster(string name, string email, string phoneNumber, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("userName", name),
                new KeyValuePair<string, string>("userEmail", email),
                new KeyValuePair<string, string>("userPhoto", "http://xonshiz.heliohost.org/uhack/api/userImages/NoUserPic.png"),
                new KeyValuePair<string, string>("userPhoneNumber", phoneNumber),
                new KeyValuePair<string, string>("userPassword", password)
            });
                var result = await client.PostAsync("/uhack/api/userRegistration/signUp.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                try
                {
                    dynamic obj2 = Newtonsoft.Json.Linq.JObject.Parse(resultContent);

                    if (obj2.error_code == 1)
                    {
                        Console.WriteLine("Sign Up Failed : " + obj2.message);
                        this.message = obj2.message;
                        this.signUpStatus = false;
                    }
                    else
                    {
                        this.message = obj2.message;
                        this.signUpStatus = true;
                    }
                }
                catch (Exception SignUpException)
                {
                    Console.WriteLine("SignUpException : " + SignUpException);
                    throw;
                }
            }

        }

        private async Task SignInPoster(string email, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("userEmail", email),
                    new KeyValuePair<string, string>("userPassword", password)
                });
                var result = await client.PostAsync("/uhack/api/userRegistration/signIn.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                try
                {
                    dynamic obj2 = Newtonsoft.Json.Linq.JObject.Parse(resultContent);

                    if (obj2.error_code == 1)
                    {
                        Console.WriteLine("Sign Up Failed : " + obj2.message);
                        this.message = obj2.message;
                        this.SignInStatus = false;
                    }
                    else
                    {
                        this.message = obj2.message;
                        this.SignInStatus = true;
                        this.userName = obj2.userName;
                        this.userEmail = obj2.userEmail;
                        this.customerID = obj2.customerID;
                        this.userPhoto = obj2.userPhoto;
                        this.userPhoneNumber = obj2.userPhoneNumber;
                        this.accountEnabled = obj2.accountEnabled;
                        this.accountAmount = obj2.accountAmount;
                        this.wId = obj2.wId;
                        this.userId = obj2.userId;
                        this.walletAmount = obj2.walletAmount;
                        this.userRewardPoints = obj2.userRewardPoints;
                        this.cId = obj2.cId;
                        this.debitCardHolderName = obj2.cards.debitCard.debitCardHolderName;
                        this.debitCardNumber = obj2.cards.debitCard.debitCardNumber;
                        this.debitExpiryDate = obj2.cards.debitCard.debitExpiryDate;
                        this.debitStartDate = obj2.cards.debitCard.debitStartDate;
                        this.creditCardHolderName = obj2.cards.creditCard.creditCardHolderName;
                        this.creditCardNumber = obj2.cards.creditCard.creditCardNumber;
                        this.creditExpiryDate = obj2.cards.creditCard.creditExpiryDate;
                        this.creditStartDate = obj2.cards.creditCard.creditStartDate;
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