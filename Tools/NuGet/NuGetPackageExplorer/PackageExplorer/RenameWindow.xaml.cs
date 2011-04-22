﻿using System.Windows;

namespace PackageExplorer {
    /// <summary>
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : StandardDialog {
        public RenameWindow() {
            InitializeComponent();
        }

        public string NewName {
            get {
                return NameBox.Text;
            }
            set {
                NameBox.Text = value;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }

        private void DialogWithNoMinimizeAndMaximize_Loaded(object sender, RoutedEventArgs e) {
            NameBox.Focus();
            NameBox.SelectAll();
        }
    }
}
