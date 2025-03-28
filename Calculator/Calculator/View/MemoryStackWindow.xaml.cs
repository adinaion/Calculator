﻿using Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculator.View
{
    /// <summary>
    /// Interaction logic for MemoryStackWindow.xaml
    /// </summary>
    public partial class MemoryStackWindow : Window
    {
        public MemoryStackWindow()
        {
            InitializeComponent();
            this.DataContext = (Application.Current.MainWindow as MainWindow)?.DataContext;
        }

        public void SetMemoryStack(IEnumerable<double> memoryStack)
        {
            MemoryStackListBox.ItemsSource = memoryStack;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
