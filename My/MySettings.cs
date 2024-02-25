namespace Pangya_Modern_Editor.My
{
    using Microsoft.VisualBasic.ApplicationServices;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, EditorBrowsable(EditorBrowsableState.Advanced), GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed class MySettings : ApplicationSettingsBase
    {
        private static MySettings defaultInstance = ((MySettings) Synchronized(new MySettings()));
        private static bool addedHandler;
        private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        private static void AutoSaveSettings(object sender, EventArgs e)
        {
            if (MyProject.Application.SaveMySettingsOnExit)
            {
                MySettingsProperty.Settings.Save();
            }
        }

        public static MySettings Default
        {
            get
            {
                if (!addedHandler)
                {
                    object addedHandlerLockObject = MySettings.addedHandlerLockObject;
                    ObjectFlowControl.CheckForSyncLockOnValueType(addedHandlerLockObject);
                    lock (addedHandlerLockObject)
                    {
                        if (!addedHandler)
                        {
                            MyProject.Application.Shutdown += new ShutdownEventHandler(MySettings.AutoSaveSettings);
                            addedHandler = true;
                        }
                    }
                }
                return defaultInstance;
            }
        }

        [UserScopedSetting, DefaultSettingValue("")]
        public string ArquivoIff
        {
            get
            {
                return Conversions.ToString(this["ArquivoIff"]);
            }
            set
            {
                this["ArquivoIff"] = value;
            }
        }

        [DefaultSettingValue(""), UserScopedSetting]
        public string DiretorioIff
        {
            get
            {
                return Conversions.ToString(this["DiretorioIff"]);
            }
            set
            {
                this["DiretorioIff"] = value;
            }
        }

        [DefaultSettingValue(""), UserScopedSetting]
        public string iffFavorito
        {
            get
            {
                return Conversions.ToString(this["iffFavorito"]);
            }
            set
            {
                this["iffFavorito"] = value;
            }
        }

        [DefaultSettingValue(""), UserScopedSetting]
        public string DiretorioDividir
        {
            get
            {
                return Conversions.ToString(this["DiretorioDividir"]);
            }
            set
            {
                this["DiretorioDividir"] = value;
            }
        }

        [DefaultSettingValue("True"), UserScopedSetting]
        public bool BuscarImagensGit
        {
            get
            {
                return Conversions.ToBoolean(this["BuscarImagensGit"]);
            }
            set
            {
                this["BuscarImagensGit"] = value;
            }
        }

        [UserScopedSetting, DefaultSettingValue("False")]
        public bool TrabalharOffline
        {
            get
            {
                return Conversions.ToBoolean(this["TrabalharOffline"]);
            }
            set
            {
                this["TrabalharOffline"] = value;
            }
        }

        [UserScopedSetting, DefaultSettingValue("False")]
        public bool ImagensWeb
        {
            get
            {
                return Conversions.ToBoolean(this["ImagensWeb"]);
            }
            set
            {
                this["ImagensWeb"] = value;
            }
        }
    }
}

