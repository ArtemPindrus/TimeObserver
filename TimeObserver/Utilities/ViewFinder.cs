using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TimeObserver.ViewModels;

namespace TimeObserver.Utilities
{
    public static class ViewFinder {
        public static ContentControl? FindView(ViewModel dataContext) {
            Type viewModelType = dataContext.GetType();

            string viewTypeName = viewModelType.Name.Replace("Model", "");
            Type? viewType = viewModelType.Assembly.GetTypes().First(x => x.Name == viewTypeName);

            if (viewType != null) {
                var view = Activator.CreateInstance(viewType) as ContentControl;
                
                if (view != null) view.DataContext = dataContext;

                return view;
            }

            return null;
        } 
    }
}
