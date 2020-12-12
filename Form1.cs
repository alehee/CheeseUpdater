using System;
using System.Windows.Forms;
using System.IO.Compression;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Cheese_Updater
{
    public partial class Cheese_Updater : Form
    {
        static string VERSION = "1.0.3";

        // POŁĄCZENIE Z BAZĄ DANYCH
        static string DATABASE_CONNECTION = "datasource=urlexample.com;port=3306;username=user;password=pass;database=database";
        string sql = "SELECT Ver, URL FROM Version WHERE Program='programName'";

        // ZMIEŃ NAZWĘ PROGRAMU
        static string PROGRAM_NAME = "programName";
        // ZMIEŃ ŚCIEŻKĘ DO ODPALENIA PROGRAMU PO ZAKOŃCZENIU
        static string PROGRAM_PATH = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        // ZMIEŃ NAZWĘ PLIKU WYKONYWALNEGO PROGRAMU
        static string PROGRAM_TO_RUN_EXE = PROGRAM_PATH + "\\bin\\" + "";
        // ZMIEŃ STRONĘ DO ŚCIĄGNIĘCIA PLIKU
        string PROGRAM_DOWNLOAD = "";
        // ZMIENNA DLA WERSJI PROGRAMU
        string PROGRAM_CURRENT_VERSION = Properties.Settings.Default["ProgramVersion"].ToString();
        string PROGRAM_DOWNLOAD_VERSION = "";

        /*
         * UPDATE NA STRONIE W ZIPIE MUSI BYĆ FOLDER BIN
         */

        // BĘDZIE TRZYMAŁA STATUS INSTALACJI:
        // 0 - POŁĄCZENIE Z BAZĄ I POBRANIE DANYCH O LINKU DO ŚCIĄGNIĘCIA
        // 1 - TWORZENIE KOPII ZAPASOWEJ PROGRAMU
        // 2 - POBIERANIE AKTUALIZACJI
        // 3 - USUWANIE STAREJ WERSJI
        // 4 - ROZPAKOWANIE AKTUALIZACJI
        // 5 - USUWANIE PLIKÓW TYMCZASOWYCH
        // 6 - URUCHOMIENIE NOWEJ WERSJI
        // 7 - ZAKOŃCZONO POMYŚLNIE
        short installState = 0;

        bool error = false;
        bool versionGood = false;

        public Cheese_Updater()
        {
            InitializeComponent();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            errorBackup();
        }

        private void B_Next_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cheese_Updater_Load(object sender, EventArgs e)
        {
            this.L_Title.Text = "Wait a second... We are updating " + PROGRAM_NAME;

            // STATUS 0 --- POŁĄCZENIE Z BAZĄ I POBRANIE DANYCH O LINKU DO ŚCIĄGNIĘCIA
            if (installState == 0)
            {
                MySqlConnection conn = new MySqlConnection(DATABASE_CONNECTION);
                MySqlCommand query = new MySqlCommand(sql, conn);
                query.CommandTimeout = 30;
                try
                {
                    conn.Open();
                    MySqlDataReader mySqlDataReader = query.ExecuteReader();

                    if (mySqlDataReader.HasRows)
                    {
                        while (mySqlDataReader.Read())
                        {
                            PROGRAM_DOWNLOAD_VERSION = mySqlDataReader.GetString(0);
                            PROGRAM_DOWNLOAD = mySqlDataReader.GetString(1);
                            installState = 1;
                            this.progressBar.Value = installState;
                        }
                    }
                    else
                    {
                        this.L_Progress.Visible = false;
                        this.L_Error.Text = "Error: download unavailable!";
                        this.L_Error.Visible = true;
                        error = true;
                    }
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Error.Text = "Error: database connection error!";
                    this.L_Error.Visible = true;
                    error = true;
                }

                if (PROGRAM_DOWNLOAD_VERSION == PROGRAM_CURRENT_VERSION)
                    versionGood = true;
            }
            // -----
            // STATUS 1 --- TWORZENIE KOPII ZAPASOWEJ PROGRAMU
            if (installState == 1 && error == false && versionGood == false)
            {
                try
                {
                    if(File.Exists(PROGRAM_PATH + "\\program_backup.zip"))
                    {
                        File.Delete(PROGRAM_PATH + "\\program_backup.zip");
                    }
                    if(Directory.Exists(PROGRAM_PATH + "\\bin"))
                    {
                        ZipFile.CreateFromDirectory(PROGRAM_PATH + "\\bin", PROGRAM_PATH + "\\program_backup.zip");
                    }
                    // W TYM ZIPIE BĘDĄ PLIKI Z FOLDERU BIN, A NIE SAM FOLDER
                    installState = 2;
                    this.progressBar.Value = installState;
                    this.B_Cancel.Visible = true;
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Error.Text = "Error: can not create backup file!";
                    this.L_Error.Visible = true;
                    error = true;
                }
            }
            // -----
            // STATUS 2 --- POBIERANIE AKTUALIZACJI
            if(installState == 2 && error == false && versionGood == false)
            {
                try
                {
                    if(File.Exists(PROGRAM_PATH + "\\update.zip"))
                    {
                        File.Delete(PROGRAM_PATH + "\\update.zip");
                    }

                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(PROGRAM_DOWNLOAD, PROGRAM_PATH + "\\update.zip");

                    // UPDATE JEST ŚCIĄGANY JUŻ W ZIPIE, A W ŚRODKU JEST FOLDER BIN
                    installState = 3;
                    this.progressBar.Value = installState;
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Error.Text = "Error: update download exception!";
                    this.L_Error.Visible = true;
                    error = true;
                }
            }
            // -----
            // STATUS 3 --- USUWANIE STAREJ WERSJI
            if (installState == 3 && error == false && versionGood == false)
            {
                try
                {
                    if (Directory.Exists(PROGRAM_PATH + "\\bin"))
                    {
                        DirectoryInfo di = new DirectoryInfo(PROGRAM_PATH + "\\bin");

                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                    installState = 4;
                    this.progressBar.Value = installState;
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Error.Text = "Error: can not delete old files!";
                    this.L_Error.Visible = true;
                    error = true;
                }
            }
            // -----
            // STATUS 4 --- ROZPAKOWANIE AKTUALIZACJI
            if (installState == 4 && error == false && versionGood == false)
            {
                try
                {
                    ZipFile.ExtractToDirectory(PROGRAM_PATH + "\\update.zip", PROGRAM_PATH);
                    installState = 5;
                    this.progressBar.Value = installState;
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Error.Text = "Error: update unzip failed!";
                    this.L_Error.Visible = true;
                    error = true;
                }
            }
            // -----
            // STATUS 5 --- USUWANIE PLIKÓW TYMCZASOWYCH
            if (installState == 5 && error == false && versionGood == false)
            {
                try
                {
                    if(File.Exists(PROGRAM_PATH + "\\program_backup.zip"))
                    {
                        File.Delete(PROGRAM_PATH + "\\program_backup.zip");
                    }
                    if(File.Exists(PROGRAM_PATH + "\\update.zip"))
                    {
                        File.Delete(PROGRAM_PATH + "\\update.zip");
                    }
                    installState = 6;
                    this.progressBar.Value = installState;
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Error.Text = "Error: temporary files error!";
                    this.L_Error.Visible = true;
                    error = true;
                }
            }
            // -----
            // STATUS 6 --- URUCHOMIENIE NOWEJ WERSJI
            if (installState == 6 && error == false && versionGood == false)
            {
                try
                {
                    installState = 7;
                    this.progressBar.Value = installState;
                    this.L_Title.Text = "Done! " + PROGRAM_NAME + " updated!";
                    this.B_Next.Visible = true;

                    Properties.Settings.Default["ProgramVersion"] = PROGRAM_DOWNLOAD_VERSION;
                    Properties.Settings.Default.Save();

                    Process.Start(PROGRAM_TO_RUN_EXE);
                    Application.Exit();
                }
                catch
                {
                    this.L_Progress.Visible = false;
                    this.L_Progress.Text = "Application is ready to launch!";
                    this.L_Progress.Visible = true;
                    error = true;
                }
            }
            // -----
            // GDY WERSJA JEST DOBRA
            if(versionGood == true)
            {
                this.progressBar.Value = 7;
                this.L_Title.Text = "Launching " + PROGRAM_NAME;
                this.B_Next.Visible = true;
                Process.Start(PROGRAM_TO_RUN_EXE);
                Application.Exit();
            }
            // -----
        }

        private void errorBackup()
        {
            error = true;
            this.L_Title.Text = "Something went wrong!";
            this.L_Progress.Text = "Restoring to the last version...";
            this.progressBar.Value = 0;
            if (Directory.Exists(PROGRAM_PATH + "\\bin"))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(PROGRAM_PATH + "\\bin");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            if (File.Exists(PROGRAM_PATH + "\\program_backup.zip"))
            {
                ZipFile.ExtractToDirectory(PROGRAM_PATH + "\\program_backup.zip", PROGRAM_PATH);
            }
            if (File.Exists(PROGRAM_PATH + "\\program_backup.zip"))
            {
                File.Delete(PROGRAM_PATH + "\\program_backup.zip");
            }
            if (File.Exists(PROGRAM_PATH + "\\update.zip"))
            {
                File.Delete(PROGRAM_PATH + "\\update.zip");
            }
            this.progressBar.Value = 7;
            Process.Start(PROGRAM_TO_RUN_EXE);
            Application.Exit();
        }
    }
}
