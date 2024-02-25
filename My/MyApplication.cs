namespace Pangya_Modern_Editor.My
{
    using Microsoft.VisualBasic.ApplicationServices;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal class MyApplication : WindowsFormsApplicationBase
    {
       
        public MyApplication() : base(AuthenticationMode.Windows)
        {
            this.IsSingleInstance = true;
            this.EnableVisualStyles = true;
            this.SaveMySettingsOnExit = true;
            this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

        [MethodImpl(MethodImplOptions.NoOptimization), DebuggerHidden, STAThread, EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static void Main(string[] args)
        {
            try
            {
                Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
            }
            finally
            {
            }
            MyProject.Application.Run(args);
        }

       
        protected override void OnCreateMainForm()
        {
            this.MainForm = MyProject.Forms.frmPrincipal;
        }
    }
}

