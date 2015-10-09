using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
    typeof(ACM.App_Start.ACMConfig), "PreStart")]
 
namespace ACM.App_Start
{
    public class ACMConfig
    {
        public static void PreStart()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
 
}