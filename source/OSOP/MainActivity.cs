using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using Android.Graphics;
using Android.Content;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace OSOP
{
    [Activity(MainLauncher = true)]
    public class MainActivity : Activity
    {
        private string message;
        private bool SignInStatus = false;
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId, 
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate;

        //This class here the Rijndael is what will have most all of the methods we need to do aes encryption.
        //When this is called it will create both a key and Initialization Vector to use.
        //RijndaelManaged Crypto = new RijndaelManaged();

        ////This is just here to convert the Encrypted byte array to a string for viewing purposes.
        //System.Text.UTF8Encoding UTF = new System.Text.UTF8Encoding();

        TextView mainLayoutTagline1, mainLayoutTagline2;
        Button mainLayoutLogin, mainLayoutSignup;
        LinearLayout mainLayout_MainScreen, mainLayout_LoginScreen;

        TextView loginScreen_TagLine1, loginScreen_GoogleSignupText, loginScreen_ForgotPassword;
        EditText loginScreen_EmailID, loginScreen_Password;
        ImageView loginScreen_GoogleIcon, loginScreen_LoginCloseLayout;
        Button loginScreen_LoginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainScreen);

            //All the View Declaration is contained in this method
            FindViews();

            //All the Click events registered are contained in this method
            ClickEvents();

            loginScreen_EmailID.Text = "kanojia24.10@gmail.com";
            loginScreen_Password.Text = "lol";
        }

        private void ClickEvents()
        {
            mainLayoutLogin.Click += MainLayoutLogin_Click;
            mainLayoutSignup.Click += MainLayoutSignup_Click;
            loginScreen_LoginCloseLayout.Click += LoginScreen_LoginCloseLayout_Click;
            loginScreen_GoogleIcon.Click += LoginScreen_GoogleIcon_Click;
            loginScreen_GoogleSignupText.Click += LoginScreen_GoogleSignupText_Click;
            loginScreen_LoginButton.Click += LoginScreen_LoginButton_ClickAsync;
        }


        private async void LoginScreen_LoginButton_ClickAsync(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Trying To Sign You In!", ToastLength.Long).Show();

            if (string.IsNullOrEmpty(loginScreen_EmailID.Text) || string.IsNullOrEmpty(loginScreen_Password.Text))
            {
                Toast.MakeText(this, "Please make sure that all the fields are filled.", ToastLength.Long).Show();
            }
            else
            {
                if (Android.Util.Patterns.EmailAddress.Matcher(loginScreen_EmailID.Text.Trim()).Matches())
                {
                    await Task.Run(() => SignInPoster(loginScreen_EmailID.Text, loginScreen_Password.Text));

                    if (this.SignInStatus)
                    {
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
            }
        }

        private void LoginScreen_GoogleSignupText_Click(object sender, EventArgs e)
        {
            GoogleLogin();
        }

        private void LoginScreen_GoogleIcon_Click(object sender, EventArgs e)
        {
            GoogleLogin();
        }

        private void LoginScreen_LoginCloseLayout_Click(object sender, EventArgs e)
        {
            mainLayout_MainScreen.Visibility = ViewStates.Visible;
            mainLayout_LoginScreen.Visibility = ViewStates.Gone;
        }

        private void MainLayoutSignup_Click(object sender, EventArgs e)
        {
            var IntentSignup = new Intent(this, typeof(MainActivity_Signup));
            StartActivity(IntentSignup);
        }

        private void MainLayoutLogin_Click(object sender, EventArgs e)
        {
            mainLayout_MainScreen.Visibility = ViewStates.Gone;
            mainLayout_LoginScreen.Visibility = ViewStates.Visible;
        }

        private void GoogleLogin()
        {
            Toast.MakeText(this, "Google Signup Clicked", ToastLength.Short).Show();
        }

        private void FindViews()
        {
            //View Declaration of MainLayout (First Screen)
            mainLayoutTagline1 = FindViewById<TextView>(Resource.Id.mainLayoutTagline1);
            mainLayoutTagline2 = FindViewById<TextView>(Resource.Id.mainLayoutTagline2);
            mainLayoutLogin = FindViewById<Button>(Resource.Id.mainLayout_loginButton);
            mainLayoutSignup = FindViewById<Button>(Resource.Id.mainLayout_SignupButton);
            mainLayout_MainScreen = FindViewById<LinearLayout>(Resource.Id.MainLayout_MainScreen);
            mainLayout_LoginScreen = FindViewById<LinearLayout>(Resource.Id.MainLayout_LoginScreen);


            //View Declaration of Login Screen
            loginScreen_TagLine1 = FindViewById<TextView>(Resource.Id.LoginScreen_Tagline1);
            loginScreen_EmailID = FindViewById<EditText>(Resource.Id.LoginScreen_EmailID);
            loginScreen_Password = FindViewById<EditText>(Resource.Id.LoginScreen_Password);
            loginScreen_ForgotPassword = FindViewById<TextView>(Resource.Id.LoginScreen_ForgotPassword);
            loginScreen_GoogleIcon = FindViewById<ImageView>(Resource.Id.LoginScreen_GoogleSignup);
            loginScreen_GoogleSignupText = FindViewById<TextView>(Resource.Id.LoginScreen_GoogleSignup1);
            loginScreen_LoginButton = FindViewById<Button>(Resource.Id.LoginScreen_LoginButton);
            loginScreen_LoginCloseLayout = FindViewById<ImageView>(Resource.Id.loginScreen_LoginCloseLayout);


            //Declaring Custom Fonts Typeface
            Typeface tf = Typeface.CreateFromAsset(Assets, "Raleway-SemiBold.ttf");
            Typeface tf1 = Typeface.CreateFromAsset(Assets, "Raleway-Regular.ttf");
            Typeface tf2 = Typeface.CreateFromAsset(Assets, "OpenSans-Regular.ttf");


            //Applying Custom fonts
            mainLayoutTagline1.SetTypeface(tf, TypefaceStyle.Normal);
            mainLayoutTagline2.SetTypeface(tf1, TypefaceStyle.Normal);
            mainLayoutLogin.SetTypeface(tf2, TypefaceStyle.Bold);
            mainLayoutSignup.SetTypeface(tf2, TypefaceStyle.Bold);
            loginScreen_TagLine1.SetTypeface(tf, TypefaceStyle.Normal);
            loginScreen_EmailID.SetTypeface(tf2, TypefaceStyle.Normal);
            loginScreen_Password.SetTypeface(tf2, TypefaceStyle.Normal);
            loginScreen_ForgotPassword.SetTypeface(tf2, TypefaceStyle.Bold);
            loginScreen_GoogleSignupText.SetTypeface(tf2, TypefaceStyle.Normal);
            loginScreen_LoginButton.SetTypeface(tf, TypefaceStyle.Normal);
        }

        public override void OnBackPressed()
        {
            if (mainLayout_LoginScreen.Visibility == ViewStates.Visible)
            {
                mainLayout_LoginScreen.Visibility = ViewStates.Gone;
                mainLayout_MainScreen.Visibility = ViewStates.Visible;
            }
            else if (mainLayout_MainScreen.Visibility == ViewStates.Visible)
            {
                Toast.MakeText(this, "Back Button Clicked", ToastLength.Short).Show();

            }
        }

        //private static string decrypt_function(byte[] Cipher_Text)
        //{
        //    RijndaelManaged Crypto = new RijndaelManaged();
        //    byte[] key = Encoding.UTF8.GetBytes("UsITuLtRaHaCkAtHoN2k17PsychoTeam");
        //    byte[] iv = Encoding.UTF8.GetBytes("ultrahackathon17");
        //    Console.WriteLine("1 lel");

        //    Crypto = null;
        //    MemoryStream MemStream = null;
        //    ICryptoTransform Decryptor = null;
        //    CryptoStream Crypto_Stream = null;
        //    StreamReader Stream_Read = null;
        //    string Plain_Text;
        //    Console.WriteLine("2 lel");

        //    try
        //    {
        //        Crypto = new RijndaelManaged();
        //        Crypto.Key = key;
        //        Crypto.IV = iv;
        //        Crypto.Padding = PaddingMode.Zeros;

        //        MemStream = new MemoryStream(Cipher_Text);
        //        Console.WriteLine("3 lel");

        //        //Create Decryptor make sure if you are decrypting that this is here and you did not copy paste encryptor.
        //        Decryptor = Crypto.CreateDecryptor(Crypto.Key, Crypto.IV);
        //        Console.WriteLine("4 lel");

        //        //This is different from the encryption look at the mode make sure you are reading from the stream.
        //        Crypto_Stream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read);

        //        //I used the stream reader here because the ReadToEnd method is easy and because it return a string, also easy.
        //        Stream_Read = new StreamReader(Crypto_Stream);
        //        Console.WriteLine("Stream_Read : " + Stream_Read);
        //        Console.WriteLine("5 lel");
        //        Plain_Text = Stream_Read.ReadToEnd();
        //        Console.WriteLine("6 lel");
        //    }
        //    finally
        //    {
        //        if (Crypto != null)
        //            Crypto.Clear();

        //        MemStream.Flush();
        //        MemStream.Close();

        //    }
        //    return Plain_Text;
        //}

        //private static byte[] encrypt_function(string Plain_Text)
        //{
        //    byte[] key = Encoding.UTF8.GetBytes("UsITuLtRaHaCkAtHoN2k17PsychoTeam");
        //    byte[] iv = Encoding.UTF8.GetBytes("ultrahackathonAF");

        //    RijndaelManaged Crypto = null;
        //    MemoryStream MemStream = null;
        //    //I crypto transform is used to perform the actual decryption vs encryption, hash function are a version of crypto transforms.
        //    ICryptoTransform Encryptor = null;
        //    //Crypto streams allow for encryption in memory.
        //    CryptoStream Crypto_Stream = null;

        //    System.Text.UTF8Encoding Byte_Transform = new System.Text.UTF8Encoding();

        //    //Just grabbing the bytes since most crypto functions need bytes.
        //    byte[] PlainBytes = Byte_Transform.GetBytes(Plain_Text);

        //    try
        //    {

        //        Crypto = new RijndaelManaged();

        //        Crypto.Key = key;
        //        Crypto.IV = iv;

        //        MemStream = new MemoryStream();

        //        //Calling the method create encryptor method Needs both the Key and IV these have to be from the original Rijndael call
        //        //If these are changed nothing will work right.
        //        Encryptor = Crypto.CreateEncryptor(Crypto.Key, Crypto.IV);

        //        //The big parameter here is the cryptomode.write, you are writing the data to memory to perform the transformation
        //        Crypto_Stream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write);

        //        //The method write takes three params the data to be written (in bytes) the offset value (int) and the length of the stream (int)
        //        Crypto_Stream.Write(PlainBytes, 0, PlainBytes.Length);

        //    }
        //    finally
        //    {
        //        //if the crypto blocks are not clear lets make sure the data is gone
        //        if (Crypto != null)
        //            Crypto.Clear();
        //        //Close because of my need to close things then done.
        //        Crypto_Stream.Close();
        //    }
        //    //Return the memory byte array
        //    return MemStream.ToArray();
        //}

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

                Console.WriteLine("resultContent Decrypt : " + resultContent);

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

