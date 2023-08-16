using Microsoft.Maui.ApplicationModel;

namespace iOSApp1;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new MainViewController();
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        Platform.Init(() => this.Window.RootViewController);
        return true;
    }

    public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity,
        UIApplicationRestorationHandler completionHandler)
    {
        if (Platform.ContinueUserActivity(application, userActivity, completionHandler))
        {
            return true;
        }

        return false;
    }

    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        return Platform.OpenUrl(app, url, options);
    }
}