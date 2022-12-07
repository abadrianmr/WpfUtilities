using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfUtilities.Selectors
{
    public class TypeDataTemplateSelector : DataTemplateSelector
    {
        public Collection<TypeDataTemplate> Templates { get; } = new Collection<TypeDataTemplate>();

        public override DataTemplate? SelectTemplate( object item, DependencyObject container )
            => item != null
            ? Templates.Where( templatePair => IsDerivedOfType( item.GetType(), templatePair.Type ) ).Select( templatePair => templatePair.Template ).FirstOrDefault()
            : null;

        private static bool IsDerivedOfType( Type itemType, Type baseType )
        {
            while( true )
            {
                if( itemType == baseType )
                    return true;
                if( itemType.BaseType == null )
                    return false;
                itemType = itemType.BaseType;
            }
        }
    }

    public class TypeDataTemplate
    {
        public Type Type { get; set; }
        public DataTemplate Template { get; set; }
    }
}
