﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74470C6A14FE165DA3C6B215867838293C617146"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InteractiveDataDisplay.WPF;
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
using WpfMath.Controls;
using chromaProcess;


namespace chromaProcess {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu file;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuInput;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuOutput;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuExit;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSample1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSample5;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuMetadata;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuTristimulus;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAdjCoef;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuPropCoef;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuChroma;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuLm;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuColorTemp;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label hints;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfMath.Controls.FormulaControl formula;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfMath.Controls.FormulaControl formulaY;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfMath.Controls.FormulaControl formulaZ;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTemp;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTempY;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTempZ;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnK;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXYZ;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_xyz;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNT;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrightness;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSetTriValues;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLm;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dispLabel;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView spectrumList;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn gcv1;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn gcv2;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnS_lambda;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIn_X;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIn_Y;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIn_Z;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIn_x;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIn_y;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPhi;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeltaLambda;
        
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
            System.Uri resourceLocater = new System.Uri("/chromaProcess;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            
            #line 9 "..\..\MainWindow.xaml"
            ((chromaProcess.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.file = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            this.menuInput = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.menuInput.Click += new System.Windows.RoutedEventHandler(this.MenuInput_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuOutput = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.menuOutput.Click += new System.Windows.RoutedEventHandler(this.MenuOutput_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menuExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.menuExit.Click += new System.Windows.RoutedEventHandler(this.MenuExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.menuSample1 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.menuSample1.Click += new System.Windows.RoutedEventHandler(this.menuSample1_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.menuSample5 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.menuSample5.Click += new System.Windows.RoutedEventHandler(this.menuSample5_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.menuMetadata = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.menuMetadata.Click += new System.Windows.RoutedEventHandler(this.menuMetadata_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.menuTristimulus = ((System.Windows.Controls.MenuItem)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.menuTristimulus.Click += new System.Windows.RoutedEventHandler(this.MenuTristimulus_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.menuAdjCoef = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.menuAdjCoef.Click += new System.Windows.RoutedEventHandler(this.menuAdjCoef_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.menuPropCoef = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\MainWindow.xaml"
            this.menuPropCoef.Click += new System.Windows.RoutedEventHandler(this.menuPropCoef_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.menuChroma = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\MainWindow.xaml"
            this.menuChroma.Click += new System.Windows.RoutedEventHandler(this.menuChroma_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.menuLm = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\MainWindow.xaml"
            this.menuLm.Click += new System.Windows.RoutedEventHandler(this.menuLm_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.menuColorTemp = ((System.Windows.Controls.MenuItem)(target));
            
            #line 31 "..\..\MainWindow.xaml"
            this.menuColorTemp.Click += new System.Windows.RoutedEventHandler(this.menuColorTemp_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 33 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuPlot_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.hints = ((System.Windows.Controls.Label)(target));
            return;
            case 17:
            this.formula = ((WpfMath.Controls.FormulaControl)(target));
            return;
            case 18:
            this.formulaY = ((WpfMath.Controls.FormulaControl)(target));
            return;
            case 19:
            this.formulaZ = ((WpfMath.Controls.FormulaControl)(target));
            return;
            case 20:
            this.txtTemp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 21:
            this.txtTempY = ((System.Windows.Controls.TextBox)(target));
            return;
            case 22:
            this.txtTempZ = ((System.Windows.Controls.TextBox)(target));
            return;
            case 23:
            this.btnK = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\MainWindow.xaml"
            this.btnK.Click += new System.Windows.RoutedEventHandler(this.btnK_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            this.btnXYZ = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\MainWindow.xaml"
            this.btnXYZ.Click += new System.Windows.RoutedEventHandler(this.btnXYZ_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.btn_xyz = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\MainWindow.xaml"
            this.btn_xyz.Click += new System.Windows.RoutedEventHandler(this.btn_xyz_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.btnNT = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\MainWindow.xaml"
            this.btnNT.Click += new System.Windows.RoutedEventHandler(this.btnNT_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            this.btnBrightness = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\MainWindow.xaml"
            this.btnBrightness.Click += new System.Windows.RoutedEventHandler(this.btnBrightness_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            this.btnSetTriValues = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\MainWindow.xaml"
            this.btnSetTriValues.Click += new System.Windows.RoutedEventHandler(this.btnSetTriValues_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            this.btnLm = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\MainWindow.xaml"
            this.btnLm.Click += new System.Windows.RoutedEventHandler(this.btnLm_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            this.dispLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 31:
            this.spectrumList = ((System.Windows.Controls.ListView)(target));
            return;
            case 32:
            this.gcv1 = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 33:
            this.gcv2 = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 34:
            this.btnS_lambda = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\MainWindow.xaml"
            this.btnS_lambda.Click += new System.Windows.RoutedEventHandler(this.btnS_lambda_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            this.btnIn_X = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\MainWindow.xaml"
            this.btnIn_X.Click += new System.Windows.RoutedEventHandler(this.btnIn_X_Click);
            
            #line default
            #line hidden
            return;
            case 36:
            this.btnIn_Y = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\MainWindow.xaml"
            this.btnIn_Y.Click += new System.Windows.RoutedEventHandler(this.btnIn_Y_Click);
            
            #line default
            #line hidden
            return;
            case 37:
            this.btnIn_Z = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\MainWindow.xaml"
            this.btnIn_Z.Click += new System.Windows.RoutedEventHandler(this.btnIn_Z_Click);
            
            #line default
            #line hidden
            return;
            case 38:
            this.btnIn_x = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\MainWindow.xaml"
            this.btnIn_x.Click += new System.Windows.RoutedEventHandler(this.btnIn_x_Click);
            
            #line default
            #line hidden
            return;
            case 39:
            this.btnIn_y = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\MainWindow.xaml"
            this.btnIn_y.Click += new System.Windows.RoutedEventHandler(this.btnIn_y_Click);
            
            #line default
            #line hidden
            return;
            case 40:
            this.btnPhi = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\MainWindow.xaml"
            this.btnPhi.Click += new System.Windows.RoutedEventHandler(this.btnPhi_Click);
            
            #line default
            #line hidden
            return;
            case 41:
            this.btnDeltaLambda = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\MainWindow.xaml"
            this.btnDeltaLambda.Click += new System.Windows.RoutedEventHandler(this.btnDeltaLambda_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

