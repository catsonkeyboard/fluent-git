using FluentGit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FluentGit.Pages.RepositoryContent
{
    public class DecoratorsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DateTimeTemplate { get; set; }

        public DataTemplate DecoratorsTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return DateTimeTemplate;
            if(item is CommitInfo commitInfo && commitInfo.Decorators?.Count > 0)
            {
                return DecoratorsTemplate;
            }
            else
            {
                return DateTimeTemplate;
            }
        }
    }
}
