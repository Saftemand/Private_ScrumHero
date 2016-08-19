using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public abstract class BaseConverter<TV, TM> : IModelConverter<TV, TM>
        where TV : IViewModel 
        where TM: IModel
    {
        protected TV _viewModel;

        public TV ToViewModel(TM model, params object[] viewModelProperties)
        {
            InstantiateViewModel(model);

            FindRelevantProperties(viewModelProperties);

            AssignRelevantPropertiesToViewModel(model);

            return _viewModel;
        }

        protected abstract void AssignRelevantPropertiesToViewModel(TM model);

        protected abstract void InstantiateViewModel(TM model);

        protected abstract void FindRelevantProperties(params object[] viewModelProperties);

        public virtual List<TV> ToViewModels(List<TM> models, params object[] viewModelProperties)
        {
            List<TV> viewModels = new List<TV>();

            foreach (TM model in models)
            {
                viewModels.Add(ToViewModel(model, viewModelProperties));
            }

            return viewModels;
        }
    }
}