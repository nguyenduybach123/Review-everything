using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using Review_Project.MVVM.Model;

namespace Review_Project.MVVM.View.UserControlView
{
    /// <summary>
    /// Interaction logic for ProductCommentUC.xaml
    /// </summary>
    public partial class ProductCommentUC : UserControl
    {
        public ProductCommentUC()
        {
            InitializeComponent();
        }

        public Comment Comment
        {
            get { return (Comment)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(Comment), typeof(ProductCommentUC));

        public string CommentType
        {
            get { return (string)GetValue(CommentTypeProperty); }
            set { SetValue(CommentTypeProperty, value); }
        }

        public static readonly DependencyProperty CommentTypeProperty = DependencyProperty.Register("CommentType", typeof(string), typeof(ProductCommentUC));

        public bool IsCurrentUser
        {
            get { return (bool)GetValue(IsCurrentUserProperty); }
            set { SetValue(IsCurrentUserProperty, value); }
        }

        public static readonly DependencyProperty IsCurrentUserProperty = DependencyProperty.Register("IsCurrentUser", typeof(bool), typeof(ProductCommentUC));

        public StackPanel CommentContainer
        {
            get { return (StackPanel)GetValue(CommentContainerProperty); }
            set { SetValue(CommentContainerProperty, value); }
        }

        public static readonly DependencyProperty CommentContainerProperty = DependencyProperty.Register("CommentContainer", typeof(StackPanel), typeof(ProductCommentUC));

    }
}
