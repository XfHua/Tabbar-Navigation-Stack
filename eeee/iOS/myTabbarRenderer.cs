using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TabbedPageWithNavigationPage;
using TabbedPageWithNavigationPage.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(MainPage), typeof(myTabbarRenderer))]
namespace TabbedPageWithNavigationPage.iOS
{
    class myTabbarRenderer : TabbedRenderer
    {
        private MainPage _page;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _page = (MainPage)e.NewElement;
            }
            else
            {
                _page = (MainPage)e.OldElement;
            }

            try
            {
                var tabbarController = (UITabBarController)this.ViewController;
                if (null != tabbarController)
                {
                    tabbarController.ViewControllerSelected += OnTabbarControllerItemSelected;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private async void OnTabbarControllerItemSelected(object sender, UITabBarSelectionEventArgs eventArgs)
        {
            if (_page?.CurrentPage?.Navigation != null && _page.CurrentPage.Navigation.NavigationStack.Count > 0)
            {
                await _page.CurrentPage.Navigation.PopToRootAsync();
            }

        }
    }
}