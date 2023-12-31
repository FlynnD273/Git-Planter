﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9416C8CF0E1F76003F19AC4F16E7E4E7B7773F31"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GitPlanter;
using GitPlanter.Converter;
using GitPlanter.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace GitPlanter {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid commitTree;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView unstagedChangesList;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView stagedChangesList;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox commitMessageText;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GitPlanter;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.commitTree = ((System.Windows.Controls.Grid)(target));
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.commitTree.Loaded += new System.Windows.RoutedEventHandler(this.commitTree_Loaded);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.commitTree.SizeChanged += new System.Windows.SizeChangedEventHandler(this.commitTree_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.unstagedChangesList = ((System.Windows.Controls.ListView)(target));
            
            #line 79 "..\..\..\MainWindow.xaml"
            this.unstagedChangesList.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChangesList_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\MainWindow.xaml"
            this.unstagedChangesList.MouseMove += new System.Windows.Input.MouseEventHandler(this.ChangesList_MouseMove);
            
            #line default
            #line hidden
            
            #line 81 "..\..\..\MainWindow.xaml"
            this.unstagedChangesList.Drop += new System.Windows.DragEventHandler(this.ChangesList_Drop);
            
            #line default
            #line hidden
            return;
            case 3:
            this.stagedChangesList = ((System.Windows.Controls.ListView)(target));
            
            #line 101 "..\..\..\MainWindow.xaml"
            this.stagedChangesList.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChangesList_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 102 "..\..\..\MainWindow.xaml"
            this.stagedChangesList.MouseMove += new System.Windows.Input.MouseEventHandler(this.ChangesList_MouseMove);
            
            #line default
            #line hidden
            
            #line 103 "..\..\..\MainWindow.xaml"
            this.stagedChangesList.Drop += new System.Windows.DragEventHandler(this.ChangesList_Drop);
            
            #line default
            #line hidden
            return;
            case 4:
            this.commitMessageText = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

