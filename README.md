[![N|Solid](https://raw.githubusercontent.com/PsychoticElites/Offline-Shopping-Online-Payment/master/OS-OP%20Logo.png)](https://github.com/PsychoticElites/Offline-Shopping-Online-Payment)
# Offline Shopping - Online Payment (OS-OP)

## Table of Content
* [Short Introduction](#1-short-introduction)
* [Detailed Introduction](#2-detailed-introduction)
* [PROBLEM STATEMENT](#3-problem-statement)
     * [Current Scenario](#current-scenario)
     * [Our Solution](#our-solution)
* [Objectives](#4-objectives)
* [Workflow](#5---extra-features)
* [Extra Features](#5-workflow)
    * [E-RECEIPTS](#e-receipts-)
    * [REWARD SYSTEM](#reward-system-)
* [Marketing plan](#7-marketing-plan)
* [Future Scope/ To Do](#8-future-scope)
* [Running The Project](#9----running-the-project)
    * [Permissions Required](#permissions-required-)
    * [Instructions For Direct APK Installation](#instructions-for-direct-apk-installation-)
    * [Instructions For Developers/Testers](#instructions-for-developerstesters-)
* [F.A.Q](#10-faq)
* [Technology Stack Used](#11---technology-stack-used)
    * [Front End Development](#front-end-development)
    * [Back End Development](#back-end-development)
    * [Frameworks](#frameworks)
    * [Packages](#packages)
* [Team’s Area of Expertise](#12--teams-area-of-expertise)
* [Team's Achievements and Experience](13--teams-achievements-and-experience)
* [Team](#14--team)

## 1. Short Introduction
We developed an innovative Offline Shopping-Online Payment (OS-OP) platform application to induce Cashless banking in Malls and Stores. This platform aims to reduce/remove the traditional queue systems in stores and promotes a more “Self-Checkout facility” easily-accessible to every and all personnel.
In addition to this cashless Innovation, we aim to promote a more accessible and user-friendly mechanism to scan/store/sort e-Receipts of all sorts available to all users which helps to reduce the paper-burden of physical receipts. 

Above mentioned innovations helps us to promote a more Environmental-friendly economy and contribute to the Global “Save Trees Campaign”.

>You need at least Android API level 21 (Lollipop) to run this application. And, we have used Mock GPS location for testing purposes.

> The libraries used in this project are mostly (if not all) Open Source and Free to use and distribute. This application was built for sole purpose of competing in [UHack Hackathon, 2017](https://uhack.hackerearth.com/). We do not claim any copyright on the external libraries or technologies used.

## 2. Detailed Introduction
With ongoing project like [Amazon Go](https://www.amazon.com/b?node=16008589011), which enhances user's experience while shopping and makes it easier for its customers to pay for the good/product(s). We were amazed by the whole idea of self-checkouts and awed by the working of Amzon Go. However, we had our concerns like too much processing power will be needed to track one person, but what if there are multiple people? It'll take even more power. While this is an amazing technology, we believe that it may not work effeciently in crowded places and India being one of the countries where there are many people in a shop simultaneously shopping for the same product(s) more or less. The current technology may have a hard time tracking all the things in real time.

With this mindset, we wanted to make a "lighter" version of Amazon Go, which will not need that much processing power, is easier for the machines to handle and even easier for the customers to use. At the end of the day, we came up with the idea which will involve one of the most powerful product we all have with us almost 24x7, i.e., our smartphones. Why not utilize the current technology that we have and build something around it which will be feasible. So, after researching for the basic idea we had, we came up with a combination of Smartphones, QR Codes and e-Wallets.

##### Why Smartphones?
Because, everyone (almost) have smartphones with them almost 24x7. They're easy to carry and most of all, they're powerful. They're powerful and fast enough to scan QR Codes and get your shopping done easily.

##### Why QR Codes?
We wanted to use barcode at first because they're everywhere. It can hold any type of text information you encode but with product labels the price in not usually encoded. The barcode will denote what product it is and your POS software or database will have pricing information associated to this. 
> Source - https://www.barcodesinc.com/faq/?nav=ftr

But, there are various advantages of using QR Codes to that of Barcodes.
> A QR code can carry up to some hundred times the amount of information a conventional barcode is capable of. When comparing the display of both: a conventional barcode can take up to ten times the amount of printing space as a QR code carrying the same amount of information. A QR code is capable of being read in 360 degrees, from any direction, thus eliminating any interference and negative effects from backgrounds.
> Source - http://www.mobile-qr-codes.org/qr-codes-vs-barcodes.html

##### What are the Benefits of this solution?
Benefits of using our application is that:
1. Firstly, we don’t have any need to carry cash with us, as our prime minister Mr. Narendra Modi is
motivating India to become cashless to finish corruption.
2. Secondly, we don’t have to stand in long queues for the payment as user can directly pay through
their E-Wallet.
3. Thirdly, one doesn’t need to maintain all the paper receipts as they receive E-receipts which is
stored at the database and can be accessed by the user and also supports the cause of save paper.

## 3. PROBLEM STATEMENT

#### Current Scenario
In the current Marketing system, A User has to use a third-party payment gateway or physical cash just to
make transactions and also has to pay extra-fee for using that Payment Gateways. Various Applications
are built upon these modular “Third-Party Gateways” which essentially contains homogeneous
functionality. This creates an unnecessarily complicated Architecture consisting of Modules or Silos.
Furthermore, they have to wait in line to do the job which can be easily achieved by a much more efficient
solution. All the receipts generated by Transactions are paper-based as well which is literally a waste of
paper, thus a much more environment-friendly method is needed.

#### Our Solution
Instead of creating another Silo of this complex hierarchy, we aim to unify and simplify Payment methods
by introducing a e-Wallet right into our application for Offline shopping where user don’t have to carry
any Credit/Debit Card or any sort of physical currency.
Our developed application can be incorporated into existing frameworks of the banks, thus enabling us to
use dedicated e-Wallets or Aadhar-based UPI systems which essentially combines all the major Payment
Gateways, thus reducing Silos from Hierarchy and can be utilized effectively for more crowd engagement.
An Internet Enabled-Device along with Our Application is all user need to do their Shopping.

## 4. Objectives
- QR-based Shopping.
- Crowd-less Solution.
- Self-Checkout Facility
- Cashless System
- E-Receipt
- On-The-Go Payment
- Unified Payment Interface

## 5. Workflow
Based on our analysis and Workflow Model, Our Scenario will be:
 - User goes to a shop
 - Picks out the item(s)
 - Scans the QR code on the item(s) via our application.
 - Bill will be generated accordingly

Upon clicking on the ”CHECKOUT” button in Application, User will have the choice to either directly pay from the application’s personalised Gateway or can choose another Physical card Payment Options and get out of the shop. This way, it’ll also reduce the un-necessary queues in the shops

## 6. Extra Features
As mentioned in the "Our Solution" section above, we have our own e-Wallets, e-Receipts and e-Rewards. While e-Wallets makes it easier to limit your expenditure and e-Receipts make it easier for the user to track their previous shopping bills, e-Rewards gives users a reason to come back to using our application. They can use these reward points in the form of "Discounts" upto 25% on their next purchases.

- ### E-RECEIPTS :
    User will also receive an “e-Receipt” for the same after successful payment. These e-receipts are stored on our encrypted Database and can be only accessed by user anywhere, anytime, without them having to organize the receipts manually.

    They can sort the receipts to find a specific receipts using various included filters such as:
    - Item Name
    - Date
    - Amount
    - Shop

- ### REWARD SYSTEM :
    We also wish to incorporate “Reward” system for the users who use this application. Reward points can be later utilized to get discounts on purchases or be sent as a gift card for other services like Amazon etc. This will increase the crowd engagement for the application and this will get more people to use our application and will help move people away from cash-based economy and paperbased receipts.

## 7. Marketing plan
As our idea is about Offline Shopping online payment to induce cashless payment, we have offered our own wallet because of which user don’t need to carry their debit cards and credit card. We target to incorporate our application to most stores in India where the crowd level is too high. Amazon go had also given a solution and made a store which uses deep learning and machine learning with various cameras that focuses on every person in the store and then just have to scan their phone during checkout but in India due to high population the crowds in stores is way too much and there is high chance of server crash due to high data transfer rate. So we incorporated our application to overcome this problem in India. We can increase our idea implementation by giving some gift points which can be redeemed after some time and offers can be availed by customers. All the monitoring of data is done at the server side.

## 8. Future Scope
Since we have receipts of user, we can use that data to incorporate Deep Learning to enhance user's experience in many ways, such as:
 - Making a list of groceries to buy every month, based on the past purchases.
 - Plan the total (approx.) monthly expense on user's shopping.

##### SECURITY FEATURES
 - Encrypt the traffic through and to the application/web-server.
 - Usage of CSRF Tokens to make the connection even more secure.
 - Usage of SSL based connections.
 - Usage of Google's Firebase for safer and faster user authentication.

##### PAYMENT GATEWAY(S)
 - Implementation of VISA Payment services.
 - Enabling Worldwide Purchases.
 - Enabling In-App Purchases.

# 9.    Running The Project
Let  us remind you again that the minimum Android OS that you need to run this project is Lollipop (API Level 21). So, make sure you're satisfying the minimum requirements first. Otherwise, your handset won't be able to parse the apk file.

- ### Permissions Required :
    This application requires you to provide few permissions to it, in order to work properly. Here's the list of permissions that the application needs :
    - Internet Access
    - View WiFi Connections
    - Storage (Read/Write Perms For Cache)
    - Read Google Service Configuration
    - Flashlight (QR Scanning Library perms)
    - Prevent Phone From Sleeping (For QR Scanning)
    
- #### Instructions For Direct APK Installation :
    If you want to run this application on your android phone, please move over to the "[`Release`](https://github.com/PsychoticElites/Offline-Shopping-Online-Payment/releases)" section and download the latest stable APK build for your android phone. You do not need any external libraries or application.

- #### Instructions For Developers/Testers :
     If you're a developer or any user who wishes to test this application and run this android project, it's recommended to install Visual Studio with Xamarin Support and Android SDKs on your system. Remember that Android SDKs should be in your local path for you to be able to compile the project properly. You can find the source code in the "[SOURCE](https://github.com/PsychoticElites/Offline-Shopping-Online-Payment/tree/master/source)" directory.

    If you do not happen to have Visual Studio, it is recommended to get it because it'll download all the required packages on its own, if they're not present. You can use Visual Studio's Free Community Edition. It'll work, as we've developed this application on it.
But, if for some reason, you don't want to or can't install Visual Studio, you will need to have .NET, Xamarin, Android SDK and required Packages in your system's local path for you to be able to compile and execute this application project.


You can check the Demonstration Video On YouTube :

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/S82XQPmhBbc/0.jpg)](https://www.youtube.com/watch?v=S82XQPmhBbc)

## 10. F.A.Q
**Q. What if this project decreases human employment?**
**A.** By recent data given by researches done for many years, Scientists have proved that the human employment have been increased recently due to advancement of technologies.

**Q. What is the use of creating this application?**
**A.** This application deals with the problem faced by customers ie. carrying cash, standing in long queues and taking care of various receipts.

**Q. Are there any reward points?**
**A.** Yes, rewards points have been provided which can be used to avail discounts upto 25% on the total bill.

**Q. Is our card information secured?**
**A. Yes, the transfer of information is encrypted by AES 256bit which is decrypted at the server and therefore is completely secured.

## 11.   Technology Stack Used
- ### Front End Development

    - ##### User Interface design:
       - Android XML (.axml)

    - ##### Other Softwares: 
       - GIMP

- ### Back End Development

    - ##### Main programming language:
       - C# - to develop base functionalities of proposed application.

    - ##### Basic scripting languages:
       - PHP – for creating Back-end APIs.
       - JSON - Server replies in JSON format.

-    ### Frameworks

       - Xamarin Framework– to develop native portable Android Application in C#
       - .NET Framework– to use Microsoft’s Visual Studio and C# basic packages.

-    ### Packages

       - C# Basic Packages– provided by Microsoft.
       - Newtonsoft – To parse JSON data.
       - ZXing.Mobile - To Scan and Parse QR Codes.

## 12.  Team’s Area of Expertise
- ### Front End Developer
    - **Ankit Passi** **(** UI/UX Designer **)**
        - Photoshop
        - GIMP
        - Illustrator
        - C#
        - C++
        - Xamarin Framework
        - VR Developer
        - Well-versed with Unreal Engine Visual Scripting.


- ### Back End Developers
    - **Dhruv Kanojia** **(** Lead Developer **)**
        - Python
        - C#
        - Core Java
        - JSON
        - PHP
        - .NET Framework
        - Xamarin Framework
        - Web Development
        - Google Accessibility Packages
 
    - **Devesh Shyngle** **(** Programmer & Security Professional **)**
        - C#
        - C++
        - PHP
        - .NET Framework
        - Xamarin Framework
        - Google Play Services
        - Web Development
        - Security Optimizer
        - Bug Tester

    - **Shubham Dwivedi** **(** Assistant Programmer **)**
        - C#
        - C++
        - .NET Framework
        - Xamarin Framework
        - Google Play Services

## 13.  Team's Achievements and Experience
- ### Rajasthan Hackathon, 2017 ([Project Link](https://github.com/PsychoticElites/Rajasthan-Sign-On-GOR-Hackathon-Project-))
    - Developed a Stand-Alone Windows application which incorporated 2 leading User Services, “Bhamashah” and “e-Mitra” to create a User Friendly and Efficient application which focuses on performing major tasks with little-or-no Extra Inputs from User ensuring minimal interaction from User side, yet performing crucial tasks.
    
    - Stood among TOP 50 participants in the Hackathon. 

- ### ICICI Hackathon, 2017
    - Developed an Android application which introduces a new Method for Visually-Challenged People to interact and use Bank Services such as performing Fund Transfers, Bill Payment and checking Account Details.

- ### #UnitedByHCL Hackathon, 2017 ([Project Link](https://github.com/PsychoticElites/FExBarclays))
    - Developed an Android application to complete challenges 1, 2 and 4 of the UI/UX Theme of #UNITEDBYHCL Hackathon, 2017. This application users can Sign Up, Log In, view upcoming races, Driver’s information, watch Live streams of the ongoing events and find any nearby places to explore by using the integrated Google Maps. Furthermore, the users can also locate the nearest Barclays Bank ATM or Branch using voice enabled commands specially designed for visually impaired people.
    
    - Finalists for #UnitedByHCL Hackathon and were invited to Old Trafford, UK on a sponsired trip for the 24 Hours offline Hackathon final phase.

## 14.  Team
### Team Name : Psychotic Elites
- #### [Dhruv Kanojia](https://github.com/Xonshiz) (Lead Developer)
- #### [Ankit Pass](https://github.com/ankitpassi141) (UI/UX Designer)
- #### [Devesh Shyngle](https://github.com/deveshyngle) (Programmer & Security Tester)
- #### [Shubham Dwivedi](https://github.com/shubham1706) (Assistant Programmer)
