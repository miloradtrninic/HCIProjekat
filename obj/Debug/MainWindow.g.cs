﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0678D49AD68B366E92BBB7BC4014C9BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCIProjekat;
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


namespace HCIProjekat {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 131 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SpomenikLista;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TipLista;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView EtiketaLista;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl MapCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/HCIProjekat;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 23 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_NoviSpomenik);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 28 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_NoviTip);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_NovaEtiketa);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 39 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItemOpen_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 44 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItemSave_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 89 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_NoviSpomenik);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 95 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_NoviTip);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 102 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_NovaEtiketa);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 109 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonTabele_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SpomenikLista = ((System.Windows.Controls.ListView)(target));
            
            #line 131 "..\..\MainWindow.xaml"
            this.SpomenikLista.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ListView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 131 "..\..\MainWindow.xaml"
            this.SpomenikLista.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.ListView_MouseMove);
            
            #line default
            #line hidden
            
            #line 131 "..\..\MainWindow.xaml"
            this.SpomenikLista.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SpomeniciLista_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.TipLista = ((System.Windows.Controls.ListView)(target));
            
            #line 153 "..\..\MainWindow.xaml"
            this.TipLista.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TipLista_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.EtiketaLista = ((System.Windows.Controls.ListView)(target));
            
            #line 175 "..\..\MainWindow.xaml"
            this.EtiketaLista.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.EtiketaLista_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 13:
            this.MapCanvas = ((System.Windows.Controls.ItemsControl)(target));
            
            #line 188 "..\..\MainWindow.xaml"
            this.MapCanvas.Drop += new System.Windows.DragEventHandler(this.DropMapa_Drop);
            
            #line default
            #line hidden
            
            #line 188 "..\..\MainWindow.xaml"
            this.MapCanvas.DragEnter += new System.Windows.DragEventHandler(this.DropMapa_DragEnter);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

