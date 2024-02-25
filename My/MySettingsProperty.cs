using System.ComponentModel.Design;

namespace Pangya_Modern_Editor.My
{
    internal sealed class MySettingsProperty
    {
        [HelpKeyword("My.Settings")]
        internal static MySettings Settings => MySettings.Default;
    }

}