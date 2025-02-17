using System.Diagnostics;

namespace PassSentinel
{
    internal static class Program
    {
        public static int ExitCode = 0;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Read Config
            Config.ReadConfig();

            // Initialize DB Connection
            Globals.DB = new PassSentinelDatabase();

            // Initial Login
            Login loginForm = new Login();
            Application.Run(loginForm);
            char[] passwordArray = loginForm.MasterPassword;

            if (loginForm.loginSuccess)
            {
                bool UnlockSuccess = false;

                do // Vault-Lock Loop
                {
                    UnlockSuccess = false;

                    VaultViewForm vaultForm = new VaultViewForm(loginForm.userID, passwordArray);
                    Array.Clear(passwordArray, 0, passwordArray.Length);
                    Application.Run(vaultForm);
                    vaultForm.ClearSentinel();

                    if (vaultForm.Lock)
                    {
                        LockScreenForm lockScreen = new LockScreenForm();
                        Application.Run(lockScreen);
                        UnlockSuccess = lockScreen.loginSuccess;
                        if (UnlockSuccess)
                            passwordArray = lockScreen.password;
                    }
                } while (UnlockSuccess);

            } // end loginForm.loginSuccess

        } // end Main
    } // end Program class
}