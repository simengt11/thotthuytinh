﻿#pragma checksum "..\..\..\UserControlOMS\UC_Setting.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FA68A4E9B24F959E2070404AD82B418A34E81EA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OMS.UserControlOMS {
    
    
    /// <summary>
    /// UC_Setting
    /// </summary>
    public partial class UC_Setting : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\UserControlOMS\UC_Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDatabasePath;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UserControlOMS\UC_Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCheckConnect;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UserControlOMS\UC_Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListaViewOrder;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OMS;component/usercontroloms/uc_setting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlOMS\UC_Setting.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBoxDatabasePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ButtonCheckConnect = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\UserControlOMS\UC_Setting.xaml"
            this.ButtonCheckConnect.Click += new System.Windows.RoutedEventHandler(this.ButtonCheckConnect_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListaViewOrder = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

