﻿#pragma checksum "..\..\..\UserControlOMS\UC_PostAutomation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B1B051F62A7C60DD72F4395FEEB7B086824D2F19"
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
using System.Windows.Interactivity;
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
    /// UC_SchedulePost
    /// </summary>
    public partial class UC_SchedulePost : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxCaption;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxDestination;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxProduct;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateTimePickerDate;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker DateTimePickerTime;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBoxFbPassword;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListSchedulePost;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonLoad;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCreate;
        
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
            System.Uri resourceLocater = new System.Uri("/OMS;component/usercontroloms/uc_postautomation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlOMS\UC_PostAutomation.xaml"
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
            this.TextBoxCaption = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ComboBoxDestination = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ComboBoxProduct = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.DateTimePickerDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.DateTimePickerTime = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 6:
            this.PasswordBoxFbPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.ListSchedulePost = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.ButtonLoad = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.ButtonCreate = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

