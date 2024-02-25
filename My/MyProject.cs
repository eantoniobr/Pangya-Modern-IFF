namespace Pangya_Modern_Editor.My
{
    using Pangya_Modern_Editor.Forms;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.ApplicationServices;
    using Microsoft.VisualBasic.CompilerServices;
    using Pangya_Modern_Editor.My;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Pangya_Modern_Editor.Forms.Editors;

    [HideModuleName, GeneratedCode("MyTemplate", "8.0.0.0"), StandardModule]
    internal sealed class MyProject
    {
        private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();
        private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();
        private static readonly ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User> m_UserObjectProvider = new ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User>();
        private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();
        private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer =>
            m_ComputerObjectProvider.GetInstance;

        [HelpKeyword("My.Application")]
        internal static MyApplication Application =>
            m_AppObjectProvider.GetInstance;

        [HelpKeyword("My.User")]
        internal static Microsoft.VisualBasic.ApplicationServices.User User =>
            m_UserObjectProvider.GetInstance;

        [HelpKeyword("My.Forms")]
        internal static MyForms Forms =>
            m_MyFormsObjectProvider.GetInstance;

        [HelpKeyword("My.WebServices")]
        internal static MyWebServices WebServices =>
            m_MyWebServicesObjectProvider.GetInstance;

        [EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
        internal sealed class MyForms
        {
            //public FrmBallEditor m_frmBall;
            //public FrmCacheEditor m_frmCache;
            public FrmCaddieEditor m_frmCaddie;
            //public FrmCaddieItemEditor m_frmCaddieItem;
            //public FrmCadieMagicBoxEditor m_frmCadieMagicBox;
            //public FrmCadieMagicBoxRandonEditor m_frmCadieMagicBoxRandon;
            //public FrmClubEditor m_frmClub;
            //public FrmClubSetEditor m_frmClubSet;
            public FrmItemEditor m_frmItem;
            //public FrmItemMassaDescontoEditor m_frmItemMassaDesconto;
            //public FrmLoginEditor m_frmLogin;
            //public FrmMascotEditor m_frmMascot;
            public FrmPartEditor m_frmPart;
            //public FrmPartMassaPrecoEditor m_frmPartMassaPreco;
            //public FrmPartTypeidEditor m_frmPartTypeid;
            public FrmPrincipal m_frmPrincipal;
            //public FrmSetItemEditor m_frmSetItem;
            //public FrmSkinEditor m_frmSkin;
            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;

           
            private static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                if ((Instance == null) || Instance.IsDisposed)
                {
                    if (m_FormBeingCreated != null)
                    {
                        if (m_FormBeingCreated.ContainsKey(typeof(T)))
                        {
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                        }
                    }
                    else
                    {
                        m_FormBeingCreated = new Hashtable();
                    }
                    m_FormBeingCreated.Add(typeof(T), null);
                    try
                    {
                        return Activator.CreateInstance<T>();
                    }
                    catch (TargetInvocationException exception) when ((exception.InnerException != null))
                    {
                        ProjectData.SetProjectError(exception);
                        throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { exception.InnerException.Message }), exception.InnerException);
                    }
                    finally
                    {
                        m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                return Instance;
            }

           
            private void Dispose__Instance__<T>(ref T instance) where T : Form
            {
                instance.Dispose();
                T local = default(T);
                instance = local;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o) =>
                base.Equals(o);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() =>
                base.GetHashCode();

            [EditorBrowsable(EditorBrowsableState.Never)]
            internal new Type GetType() =>
                typeof(MyProject.MyForms);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString() =>
                base.ToString();

            //public FrmBallEditor frmBall
            //{

            //    get
            //    {
            //        this.m_frmBall = Create__Instance__<FrmBall>(this.m_frmBall);
            //        return this.m_frmBall;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmBall))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmBall>(ref this.m_frmBall);
            //        }
            //    }
            //}

            //public FrmCacheEditor frmCache
            //{

            //    get
            //    {
            //        this.m_frmCache = Create__Instance__<FrmCache>(this.m_frmCache);
            //        return this.m_frmCache;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmCache))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmCache>(ref this.m_frmCache);
            //        }
            //    }
            //}

            public FrmCaddieEditor frmCaddie
            {

                get
                {
                    this.m_frmCaddie = Create__Instance__<FrmCaddieEditor>(this.m_frmCaddie);
                    return this.m_frmCaddie;
                }

                set
                {
                    if (!ReferenceEquals(value, this.m_frmCaddie))
                    {
                        if (!ReferenceEquals(value, null))
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmCaddieEditor>(ref this.m_frmCaddie);
                    }
                }
            }

            //public FrmCaddieItemEditor frmCaddieItem
            //{

            //    get
            //    {
            //        this.m_frmCaddieItem = Create__Instance__<FrmCaddieItem>(this.m_frmCaddieItem);
            //        return this.m_frmCaddieItem;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmCaddieItem))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmCaddieItem>(ref this.m_frmCaddieItem);
            //        }
            //    }
            //}

            //public FrmCadieMagicBoxEditor frmCadieMagicBox
            //{

            //    get
            //    {
            //        this.m_frmCadieMagicBox = Create__Instance__<FrmCadieMagicBox>(this.m_frmCadieMagicBox);
            //        return this.m_frmCadieMagicBox;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmCadieMagicBox))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmCadieMagicBox>(ref this.m_frmCadieMagicBox);
            //        }
            //    }
            //}

            //public FrmCadieMagicBoxRandonEditor frmCadieMagicBoxRandon
            //{

            //    get
            //    {
            //        this.m_frmCadieMagicBoxRandon = Create__Instance__<FrmCadieMagicBoxRandon>(this.m_frmCadieMagicBoxRandon);
            //        return this.m_frmCadieMagicBoxRandon;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmCadieMagicBoxRandon))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmCadieMagicBoxRandon>(ref this.m_frmCadieMagicBoxRandon);
            //        }
            //    }
            //}

            //public FrmClubEditor frmClub
            //{

            //    get
            //    {
            //        this.m_frmClub = Create__Instance__<FrmClub>(this.m_frmClub);
            //        return this.m_frmClub;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmClub))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmClub>(ref this.m_frmClub);
            //        }
            //    }
            //}

            //public FrmClubSetEditor frmClubSet
            //{

            //    get
            //    {
            //        this.m_frmClubSet = Create__Instance__<FrmClubSet>(this.m_frmClubSet);
            //        return this.m_frmClubSet;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmClubSet))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmClubSet>(ref this.m_frmClubSet);
            //        }
            //    }
            //}

            public FrmItemEditor frmItem
            {

                get
                {
                    this.m_frmItem = Create__Instance__<FrmItemEditor>(this.m_frmItem);
                    return this.m_frmItem;
                }

                set
                {
                    if (!ReferenceEquals(value, this.m_frmItem))
                    {
                        if (!ReferenceEquals(value, null))
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmItemEditor>(ref this.m_frmItem);
                    }
                }
            }

            //public FrmItemMassaDescontoEditor frmItemMassaDesconto
            //{

            //    get
            //    {
            //        this.m_frmItemMassaDesconto = Create__Instance__<FrmItemMassaDesconto>(this.m_frmItemMassaDesconto);
            //        return this.m_frmItemMassaDesconto;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmItemMassaDesconto))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmItemMassaDesconto>(ref this.m_frmItemMassaDesconto);
            //        }
            //    }
            //}

            //public FrmLoginEditor frmLogin
            //{

            //    get
            //    {
            //        this.m_frmLogin = Create__Instance__<FrmLogin>(this.m_frmLogin);
            //        return this.m_frmLogin;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmLogin))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmLogin>(ref this.m_frmLogin);
            //        }
            //    }
            //}

            //public FrmMascotEditor frmMascot
            //{

            //    get
            //    {
            //        this.m_frmMascot = Create__Instance__<FrmMascot>(this.m_frmMascot);
            //        return this.m_frmMascot;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmMascot))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmMascot>(ref this.m_frmMascot);
            //        }
            //    }
            //}

            public FrmPartEditor frmPart
            {

                get
                {
                    this.m_frmPart = Create__Instance__<FrmPartEditor>(this.m_frmPart);
                    return this.m_frmPart;
                }

                set
                {
                    if (!ReferenceEquals(value, this.m_frmPart))
                    {
                        if (!ReferenceEquals(value, null))
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmPartEditor>(ref this.m_frmPart);
                    }
                }
            }

            //public FrmPartMassaPrecoEditor frmPartMassaPreco
            //{

            //    get
            //    {
            //        this.m_frmPartMassaPreco = Create__Instance__<FrmPartMassaPreco>(this.m_frmPartMassaPreco);
            //        return this.m_frmPartMassaPreco;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmPartMassaPreco))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmPartMassaPreco>(ref this.m_frmPartMassaPreco);
            //        }
            //    }
            //}

            //public FrmPartTypeidEditor frmPartTypeid
            //{

            //    get
            //    {
            //        this.m_frmPartTypeid = Create__Instance__<FrmPartTypeid>(this.m_frmPartTypeid);
            //        return this.m_frmPartTypeid;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmPartTypeid))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmPartTypeid>(ref this.m_frmPartTypeid);
            //        }
            //    }
            //}

            public FrmPrincipal frmPrincipal
            {

                get
                {
                    this.m_frmPrincipal = Create__Instance__<FrmPrincipal>(this.m_frmPrincipal);
                    return this.m_frmPrincipal;
                }

                set
                {
                    if (!ReferenceEquals(value, this.m_frmPrincipal))
                    {
                        if (!ReferenceEquals(value, null))
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmPrincipal>(ref this.m_frmPrincipal);
                    }
                }
            }

            //public FrmSetItemEditor frmSetItem
            //{

            //    get
            //    {
            //        this.m_frmSetItem = Create__Instance__<FrmSetItem>(this.m_frmSetItem);
            //        return this.m_frmSetItem;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmSetItem))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmSetItem>(ref this.m_frmSetItem);
            //        }
            //    }
            //}

            //public FrmSkinEditor frmSkin
            //{

            //    get
            //    {
            //        this.m_frmSkin = Create__Instance__<FrmSkin>(this.m_frmSkin);
            //        return this.m_frmSkin;
            //    }

            //    set
            //    {
            //        if (!ReferenceEquals(value, this.m_frmSkin))
            //        {
            //            if (!ReferenceEquals(value, null))
            //            {
            //                throw new ArgumentException("Property can only be set to Nothing");
            //            }
            //            this.Dispose__Instance__<FrmSkin>(ref this.m_frmSkin);
            //        }
            //    }
            //}
        }

        [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", ""), EditorBrowsable(EditorBrowsableState.Never)]
        internal sealed class MyWebServices
        {
           
            private static T Create__Instance__<T>(T instance) where T : new() =>
                (instance != null) ? instance : Activator.CreateInstance<T>();

           
            private void Dispose__Instance__<T>(ref T instance)
            {
                T local = default(T);
                instance = local;
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o) =>
                base.Equals(o);

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public override int GetHashCode() =>
                base.GetHashCode();

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            internal new Type GetType() =>
                typeof(MyProject.MyWebServices);

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString() =>
                base.ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never), ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            [CompilerGenerated, ThreadStatic]
            private static T m_ThreadStaticValue;

            internal T GetInstance
            {
               
                get
                {
                    if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
                    {
                        MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
                    }
                    return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
                }
            }
        }
    }
}

