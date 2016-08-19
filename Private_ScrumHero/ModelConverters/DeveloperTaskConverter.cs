using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.ModelConverters;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class DeveloperTaskConverter : BaseConverter<DeveloperTaskViewModel, DeveloperTask>
    {

        protected override void AssignRelevantPropertiesToViewModel(DeveloperTask model)
        {
            //Do nothing ...
        }

        protected override void InstantiateViewModel(DeveloperTask model)
        {
            _viewModel = new DeveloperTaskViewModel()
            {
                DeveloperTaskId = model.DeveloperTaskId,
                LocalId = model.LocalId,
                DeveloperTaskName = model.DeveloperTaskName,
                UserStoryId = model.UserStory.UserStoryId
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            //Do nothing ...
        }
    }
}