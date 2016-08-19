using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ViewModels
{
    public interface IModelConverter<V, M> 
        where V : IViewModel 
        where M : IModel
    {
        V ToViewModel(M model, params object[] viewModelProperties);
        List<V> ToViewModels(List<M> models, params object[] viewModelProperties);
    }
}
