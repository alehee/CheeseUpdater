# Cheese Updater
![It's a front pic!](https://github.com/alehee/CheeseUpdater/blob/master/github_resources/github_front.png?raw=true)

## Description
Cheese Updater is a low budget launcher for windows programs. Everytime application will be launching version check with MySQL database. If version will be different launcher will update the app safely with backup!

### Launch cycle:
* Version comparison
* Local version backup
* Download
* Local version replacing
* Clearing temporary files

## Used technology
Technology I used in this project:
* C#
* C# WinForms
* MySQL with C# connector

## How to use
Short description how to set launcher to your own purpose. First of all you need **MySQL server**. I use web hosted MySQL server, but you can test it on XAMPP as well.

When you have your environment here's what you need to do next:

  1. Download latest master branch files and unzip it
  2. Import the *table_example.sql* to your MySQL system, check how tables are build and clear it
  3. Insert row to MySQL table with data
  ```sql
  ID = NULL
  Ver = '1.0.0' // Current program version
  Program = 'programName' // Current program name
  URL = 'urlexample.com/updates/programName/update.zip' // Link newest version (I will write about it later)
  ```
  4. Open project file in **Visual Studio 2019** and set present data in *Form1.cs*
  ```c#
  static string DATABASE_CONNECTION = "datasource=urlexample.com;port=3306;username=user;password=pass;database=database"; // Replace 'urlexample.com', 'user', 'pass', 'database' to your server connection options
  
  string sql = "SELECT Ver, URL FROM Version WHERE Program='programName'"; // Replace 'programName' with name you used in MySQL row
  
  static string PROGRAM_NAME = "programName"; // Replace 'programName' with your program name
  
  static string PROGRAM_TO_RUN_EXE = PROGRAM_PATH + "\\bin\\" + "app.exe"; // Replace 'app.exe' for your application executable main file
  ```
  5. Compile code and go to *bin\Debug*, this folder will be your application default location. Program data will be downloaded to **bin** folder in this location
  6. To complete the preparation you need to do the **How to upload new version** steps for the first time
  
  ### How to upload new version
  * Put your 'new version' files to folder named *bin*. Application executable file should be directly in the *bin* folder
  * Zip the *bin* folder to *update.zip* and put it on some web hosting. We need direct download url. You can test it -> when you open the link in web browser it should automatically download the zip
  * Put the url to the MySQL program row in URL column, set also new program Version in Ver column
  
That's how you completed the preparation! On launcher open everything should work fine, and your program will always updated!
  
## Thank you!
Thank you for peeking at my project!

If you're interested check out my other stuff [here](https://github.com/alehee)
