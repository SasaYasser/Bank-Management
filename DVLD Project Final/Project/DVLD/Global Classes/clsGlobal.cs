using DVLD_Buisness;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;
        private static string key = "1234567890123456";

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName = "CredentialUserData";
            try
            {
                Registry.SetValue(keyPath, valueName, Username + "#//#" + clsValidatoin.Encrypt(Password, key), RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName = "CredentialUserData";
            try
            {
                string value = Registry.GetValue(keyPath, valueName, null) as string;
                if (value != null)
                {
                    string[] parts = value.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    Username = parts[0];
                    Password = clsValidatoin.Decrypt(parts[1], key);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}