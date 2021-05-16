using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.ReviewKit.Web.Menus
{
    public class ReviewKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(ReviewKitMenus.Prefix, displayName: "ReviewKit", "~/ReviewKit", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}