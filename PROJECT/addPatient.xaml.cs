using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for addPatient.xaml
    /// </summary>
    public partial class addPatient : UserControl
    {
        public addPatient()
        {
            InitializeComponent();
        }

       
            public static readonly RoutedEvent AddedSavedEvent = EventManager.RegisterRoutedEvent(
            "AddedSaved", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(addPatient));

        public event RoutedEventHandler AddedSaved
        {
            add { AddHandler(AddedSavedEvent, value); }
            remove { RemoveHandler(AddedSavedEvent, value); }
        }


        void RaiseEvent()
        {
            RoutedEventArgs myArgs = new RoutedEventArgs(AddedSavedEvent);
            RaiseEvent(myArgs);
        }

         private void add_save_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent();
        }
        
        }

        
    }

