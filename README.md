MegaracSP-QuickConnect
=========

This is an application that is currently only verified to work with the ASRock C2550D4I/C2750D4I motherboards

### What does it do?
Currently a big feature of these motherboards are MegaracSP powered IPMI. Additionally it allows remote desktop connection through a Java based KVM. Unfortunately most modern browsers block Java execution totally now. The process for manually downloading the .jlnp file required to remote into the unit was cumbersome. This program attempts to alleviate it. 

### How does it do it?
The application is a simple dialog asking IP, Username and Password for the IPMI box. It will then go and fetch the jnlp file and execute it automatically. Saving you a ton of hassle. Additionally, opening the program via command line arguments allows an even quicker execution of pre-saved profiles.

### Warning
Passwords currently stored in C# Settings. They are stored plaintext. Hopefully work can be done on this.

### Coded by
[@prashker](http://prashker.net)

### How-to Code:
* Coded in VS2015 with C#

### Pull Requests
* Welcome! Some much needed work is necessary.

### Pet Project
This is a small pet project that will not be actively maintained, unless people would like to contribute :).