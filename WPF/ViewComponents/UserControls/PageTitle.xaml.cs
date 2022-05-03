using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.ViewComponents.UserControls
{
    public partial class PageTitle : UserControl
    {
        public PageTitle()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PageTitle), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(PageTitle), new PropertyMetadata());
    }
}
