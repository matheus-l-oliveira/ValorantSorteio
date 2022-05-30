using Microsoft.Win32;

namespace ValorantSorteio.Utils
{
    internal class Regedit
    {
        static readonly string PathRegedit = @"SOFTWARE\ValorantSorteio";
        static readonly string NaoMostrarMensagemCopy = "NaoMostrarMensagemCopy";

        public static void SetaNaoMostrarMensagemCopy(bool arg)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(PathRegedit);

            key.SetValue(NaoMostrarMensagemCopy, arg.ToString());
            key.Close();
        }

        public static bool RetornaNaoMostrarMensagemCopy()
        { 
            RegistryKey key = Registry.CurrentUser.OpenSubKey(PathRegedit);

            if (key != null)
            {
                return key.GetValue(NaoMostrarMensagemCopy).ToString().Equals("true", StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
    }
}
