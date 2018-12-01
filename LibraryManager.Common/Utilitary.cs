namespace LibraryManager.Common
{
    using Microsoft.Win32;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Utilitary
    {
        public static string CleanFileName(string filename)
        {
            return Regex.Replace(filename, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        public static string CleanInput(string strIn)
        {
            try
            {
                return strIn.Replace("'", "").Replace(";", "").Replace("\"", "");
            }
            catch (RegexMatchTimeoutException)
            {
                return string.Empty;
            }
        }

        public static int ConvertToInt(string number)
        {
            int num = 0;
            try
            {
                num = int.Parse(number);
            }
            catch (FormatException)
            {
            }
            return num;
        }

        public static string Decrypt(string cipher)
        {
            if (cipher == null)
            {
                throw new ArgumentNullException("cipher");
            }
            byte[] bytes = Convert.FromBase64String(cipher);
            char[] array = Encoding.Unicode.GetString(bytes).ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static string ReadValueFromRegistry(string regKey, string subKey)
        {
            RegistryKey key = null;
            if (Environment.UserInteractive)
            {
                key = Registry.CurrentUser.OpenSubKey(regKey);
            }
            else
            {
                RegistryKey key3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                regKey = @"SOFTWARE\CorsPro";
                key = key3.OpenSubKey(regKey);
                if (key == null)
                {
                    regKey = @"SOFTWARE\WOW6432Node\CorsPro";
                    key = key3.OpenSubKey(regKey);
                }
            }
            if (key == null)
            {
                return null;
            }
            try
            {
                object obj2 = key.GetValue(subKey);
                return ((obj2 != null) ? ((string) obj2) : null);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

