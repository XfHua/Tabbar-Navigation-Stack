using System;
using System.Linq;
using Xamarin.Forms;

namespace TabbedPageWithNavigationPage
{
	public partial class UpcomingAppointmentsPage : ContentPage
	{
		public UpcomingAppointmentsPage ()
		{
			InitializeComponent ();
		}

		async void OnBackButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //Clear Navigation Stack, clicking on tab page should always 
            //go to corresponding page

            if (Device.RuntimePlatform == Device.Android)
            {
                try
                {
                    var existingPages = Navigation.NavigationStack.ToList();
                    foreach (var page in existingPages)
                    {
                        //existingPages count should be greater than 1, so that this will never be root page. Otherwise removing root page will throw exception
                        if (string.Compare(page.GetType().Name, "UpcomingAppointmentsPage", StringComparison.OrdinalIgnoreCase) == 0 && existingPages.Count > 1)
                        {
                            Navigation.RemovePage(page);
                        }

                    }                 
                }
                catch (Exception ex)
                {

                }
            }           
        }

    }
}

