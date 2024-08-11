using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Review_Project.MVVM.Model
{
    public class PostContent
    {
        public PostContent()
        {
            Title = "";
            Content = null;
        }

        public PostContent(string title, FlowDocument content)
        {
            Title = title;
            Content = content;
        }
        public string Title { get; set; }
        public FlowDocument Content { get; set; }
    }
}
