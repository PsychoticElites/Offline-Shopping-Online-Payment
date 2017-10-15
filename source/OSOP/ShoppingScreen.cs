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
using ZXing.Mobile;
using System.Threading.Tasks;
using Android.Graphics;
using System.Net.Http;

/*
 * QR Code Content : Store Name :~ Product Name :~ Product Price
 * Test Store:~Apple:~2
 */
namespace OSOP
{
    [Activity(Label = "MainScreen")]
    public class ShoppingServices : Activity
    {
        public string userName, userEmail, customerID, userPhoto, userPhoneNumber, accountEnabled, accountAmount, wId, userId, walletAmount, userRewardPoints, cId,
            debitCardHolderName, debitCardNumber, debitExpiryDate, debitStartDate, creditCardHolderName, creditCardNumber, creditExpiryDate, creditStartDate;

        public static string storeName;

        Button addContent, checkOut;
        TextView cartEmpty, cartEmptyDescription, itemName, itemPrice, itemShopName;
        ImageView cartImage;
        LinearLayout layoutEmptyCart;
        public static List<double> itemPriceList = new List<double>();
        public static List<string> itemNameList = new List<string>();

        public static string receivedAccountNumber, receivedEmailId, totalAmount, message;
        public bool paymentStatus = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShoppingCart);

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

            FindViews();
            ClickEvent();
            receivedAccountNumber = Intent.GetStringExtra("userAccountNumber") ?? "Data not available";
            receivedEmailId = Intent.GetStringExtra("userEmailId") ?? "Data not available";

            Console.WriteLine("Main Screen Account Number : " + receivedAccountNumber);
            Console.WriteLine("Main Screen Email ID : " + receivedEmailId);
            // Create your application here

            // Somewhere in your app, call the initialization code:
            // Calling this in the OnCreate method because It'll be a wastage of resource to instantiate a new  instance everytime for scanning QR.
            // I think we might need to move the initialization in the QRReader() method itself. This might initialize the QR  Scanner as soon as View Loads.
            //MobileBarcodeScanner.Initialize(Application);

            //Remove this line after you're done making the UI and attaching the button click event.
            //await Task.Run(() => QRReader());

            //foreach (var itemsName in itemNameList)
            //{
            //    Console.WriteLine("Name of Item : " + itemsName);
            //    itemName.Text = itemsName;
            //}

            //foreach (var itemsPrice in itemPriceList)
            //{
            //    Console.WriteLine("Price of Item : " + itemsPrice);
            //    itemPrice.Text = itemsPrice.ToString();
            //}
            /*
             * You need to call the ScanTheQR_ButtonClickAsync() method on another thread for that "Scan The Code" Button.
             * I've written the code, to it'll open that QRReader() method asyncly to scan the QR.
             * Generate QR Here : http://www.qr-code-generator.com/
             * Generate the "Text" based QR.
             */

        }

        public void FindViews()
        {
            addContent = FindViewById<Button>(Resource.Id.buttonScanQR);
            checkOut = FindViewById<Button>(Resource.Id.buttonCheckout);
            cartEmpty = FindViewById<TextView>(Resource.Id.textCartEmpty);
            cartEmptyDescription = FindViewById<TextView>(Resource.Id.textCartDescription);
            layoutEmptyCart = FindViewById<LinearLayout>(Resource.Id.layoutEmptyCart);
            //linearlayoutCartItem = FindViewById<LinearLayout>(Resource.Id.linearLayoutCartItem);
            itemName = FindViewById<TextView>(Resource.Id.itemName);
            itemPrice = FindViewById<TextView>(Resource.Id.itemPrice);
            itemShopName = FindViewById<TextView>(Resource.Id.shopName);
            cartImage = FindViewById<ImageView>(Resource.Id.imageView1);


            Typeface tf = Typeface.CreateFromAsset(Assets, "Khula-Light.ttf");
            Typeface tf1 = Typeface.CreateFromAsset(Assets, "Poppins-Medium.ttf");
            Typeface tf2 = Typeface.CreateFromAsset(Assets, "Raleway-Regular.ttf");
            cartEmpty.SetTypeface(tf1, TypefaceStyle.Normal);
            cartEmptyDescription.SetTypeface(tf, TypefaceStyle.Normal);
            itemName.SetTypeface(tf1, TypefaceStyle.Normal);
            itemPrice.SetTypeface(tf2, TypefaceStyle.Normal);
            itemShopName.SetTypeface(tf, TypefaceStyle.Normal);

        }

        public void ClickEvent()
        {
            addContent.Click += ScanTheQR_ButtonClickAsync;
            checkOut.Click += CheckOut_Click;
        }

        private async void CheckOut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(storeName))
            {
                if (itemNameList.Count > 0)
                {
                    totalAmount = Convert.ToString(itemPriceList.Sum());

                    var checkOut = new Intent(this, typeof(checkOutService));
                    checkOut.PutExtra("userName", this.userName);
                    checkOut.PutExtra("userEmail", this.userEmail);
                    checkOut.PutExtra("customerID", this.customerID);
                    checkOut.PutExtra("userPhoto", this.userPhoto);
                    checkOut.PutExtra("userPhoneNumber", this.userPhoneNumber);
                    checkOut.PutExtra("accountEnabled", this.accountEnabled);
                    checkOut.PutExtra("accountAmount", this.accountAmount);
                    checkOut.PutExtra("wId", this.wId);
                    checkOut.PutExtra("userId", this.userId);
                    checkOut.PutExtra("walletAmount", this.walletAmount);
                    checkOut.PutExtra("userRewardPoints", this.userRewardPoints);
                    checkOut.PutExtra("cId", this.cId);
                    checkOut.PutExtra("debitCardHolderName", this.debitCardHolderName);
                    checkOut.PutExtra("debitCardNumber", this.debitCardNumber);
                    checkOut.PutExtra("debitExpiryDate", this.debitExpiryDate);
                    checkOut.PutExtra("debitStartDate", this.debitStartDate);
                    checkOut.PutExtra("creditCardHolderName", this.creditCardHolderName);
                    checkOut.PutExtra("creditCardNumber", this.creditCardNumber);
                    checkOut.PutExtra("creditExpiryDate", this.creditExpiryDate);
                    checkOut.PutExtra("creditStartDate", this.creditStartDate);
                    checkOut.PutExtra("totalAmount", Convert.ToString(totalAmount));
                    checkOut.PutExtra("storeName", storeName);
                    checkOut.PutExtra("itemPriceList", Convert.ToString(string.Join(",", itemPriceList.ToArray())));
                    checkOut.PutExtra("itemNameList", Convert.ToString(string.Join(",", itemNameList.ToArray())));
                    StartActivity(checkOut);
                }
                else
                {
                    Toast.MakeText(this, "Your Cart Seems Empty", ToastLength.Long).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Your Cart Seems Empty", ToastLength.Long).Show();
            }
        }

        private async void ScanTheQR_ButtonClickAsync(object sender, System.EventArgs e)
        {
            await Task.Run(() => QRReader());
            //Sets changes to the Interface when a QR scan is successful.
            cartImage.Visibility = ViewStates.Gone;
            cartEmpty.Visibility = ViewStates.Gone;
            cartEmptyDescription.Visibility = ViewStates.Gone;
            itemName.Visibility = ViewStates.Visible;
            itemPrice.Visibility = ViewStates.Visible;
            itemShopName.Visibility = ViewStates.Visible;
            // Sets the Label Text. Last Element of the list.
            string itemPrice1 = "₹" + Convert.ToString(itemPriceList.Last());
            itemName.Text = Convert.ToString(itemNameList.Last());
            itemPrice.Text = Convert.ToString(itemPrice1);
            itemShopName.Text = Convert.ToString(storeName);
        }

        private async Task QRReader()
        {
            try
            {
                MobileBarcodeScanner.Initialize(Application);
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result != null)
                {
                    /* This piece of code controls the visiblity of the View materials
                        of the main screen, cartImage,cartEmpty and cartEmptyDescription
                        are the items visible when the view launched and there is nothing
                        in the cart.
                        itemName, itemPrice and itemShopName are visible when the QR Scanner
                        detects some item and add it in list. This replaces the cartItem layout
                        with Item Description.*/
                    //cartImage.Visibility = ViewStates.Gone;
                    //cartEmpty.Visibility = ViewStates.Gone;
                    //cartEmptyDescription.Visibility = ViewStates.Gone;
                    //itemName.Visibility = ViewStates.Visible;
                    //itemPrice.Visibility = ViewStates.Visible;
                    //itemShopName.Visibility = ViewStates.Visible;


                    Console.WriteLine("Scanned Barcode: " + result.Text);
                    string QR_Text = result.Text;
                    string[] QrTextSplit = QR_Text.Split(':');
                    //QR Code Content : Store Name : Product Name : Product Price
                    storeName = QrTextSplit[0];
                    itemNameList.Add(Convert.ToString(QrTextSplit[1]));
                    itemPriceList.Add(Convert.ToDouble(QrTextSplit[2]));

                    foreach (var itemsName in itemNameList)
                    {
                        Console.WriteLine("Name of Item : " + itemsName);
                        //itemName.Text = itemsName;
                    }

                    foreach (var itemsPrice in itemPriceList)
                    {
                        Console.WriteLine("Price of Item : " + itemsPrice);
                        //itemPrice.Text = Convert.ToString(itemsPrice);
                    }

                    //foreach(var nameStore in storeName)
                    //{
                    //    itemShopName.Text = Convert.ToString(nameStore);
                    //}
                }
            }
            catch (Exception ExCam)
            {
                Console.WriteLine("ExCam : " + ExCam);
                throw;
            }
        }

        private async Task PaymentPoster()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://xonshiz.heliohost.org");
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("userAccountNumber", receivedAccountNumber),
                new KeyValuePair<string, string>("amountToDeduct", totalAmount),
                new KeyValuePair<string, string>("userEmail", receivedEmailId)
            });
                var result = await client.PostAsync("/humaniq/moneyDeduction.php", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                try
                {
                    dynamic obj2 = Newtonsoft.Json.Linq.JObject.Parse(resultContent);

                    if (obj2.error_code == 1)
                    {
                        Console.WriteLine(obj2.message);
                        message = obj2.message;
                        this.paymentStatus = false;
                    }
                    else
                    {
                        message = obj2.userName;
                        this.paymentStatus = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}