using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Authentication;

namespace iOSApp1;

[Register("MainViewController")]
public partial class MainViewController : UIViewController
{
    public MainViewController() : base()
    {
    }

    public override void ViewDidAppear(bool animated)
    {
        base.ViewDidAppear(animated);
        TryAuthenticateAsync();
    }

    private async Task TryAuthenticateAsync()
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                string host =
                    "https://www1-myapp.com/simplesaml/module.php/oidc/authorize.php?response_type=code&state=aaaa&code_challenge=aaaaa&code_challenge_method=S256&client_id=aaaa&scope=aaaa&redirect_uri=https://www1-myapp-dev.com";
                string returnUrl = "https://www1-myapp-dev.com";
                var result = await WebAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
                {
                    Url = new Uri(host), // your host
                    CallbackUrl = new Uri(returnUrl), // Anything with https scheme
                    PrefersEphemeralWebBrowserSession = false
                });
                // It crashes before getting here
                Debug.Print(result.AccessToken != null ? "Success" : "Fails");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }

}