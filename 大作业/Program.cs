using 大作业.myForms;
using 窗体实验;
using static System.Net.Http.HttpClient;
using static System.Net.HttpWebRequest;

namespace 大作业
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new 用户登录());
   
        }
    }
}