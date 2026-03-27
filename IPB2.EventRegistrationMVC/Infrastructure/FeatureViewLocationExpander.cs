using Microsoft.AspNetCore.Mvc.Razor;

namespace IPB2.EventRegistrationMVC.Infrastructure
{
    public class FeatureViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            // The {0} is the action name, {1} is the controller name, {2} is the area name (not used here)
            // {3} is the feature name (same as controller name in this simple case)

            var featureName = context.ControllerName;

            var featureLocations = new[]
            {
                "/Features/{1}/Views/{0}.cshtml",
                "/Features/Shared/Views/{0}.cshtml",
            };

            return featureLocations.Union(viewLocations);
        }
    }
}
