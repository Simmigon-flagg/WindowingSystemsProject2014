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
		////////////////////////
		//Simmigon Flagg begin//
        ///////////////////////
    public partial class viewPatientInfo : UserControl
    {
        public viewPatientInfo()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent NewSearchEvent = EventManager.RegisterRoutedEvent(
            "NewSearch", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(viewPatientInfo));

        public event RoutedEventHandler NewSearch
        {
            add { AddHandler(NewSearchEvent, value); }
            remove { RemoveHandler(NewSearchEvent, value); }
        }


        void RaiseSearchEvent()
        {
            RoutedEventArgs myArgs = new RoutedEventArgs(NewSearchEvent);
            RaiseEvent(myArgs);
        }

        private void btnNewSearch_Click(object sender, RoutedEventArgs e)
        {
            RaiseSearchEvent();
        }
		////////////////////////
		//Simmigon Flagg end//
        ///////////////////////

    }
}
