using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System;


public class Program
{
    static void Main(string[] args)
    {
        // e.g. https://yourorg.crm.dynamics.com
        string url = "*****************";
        // e.g. you@yourorg.onmicrosoft.com
        string userName = "************";
        // e.g. y0urp455w0rd 
        string password = "***************";

        string conn = $@"
        Url = {url};
        AuthType = OAuth;
        UserName = {userName};
        Password = {password};
        AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
        RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
        LoginPrompt=Auto;
        RequireNewInstance = True";

        using (var svc = new CrmServiceClient(conn))
        {

            WhoAmIRequest request = new WhoAmIRequest();

            WhoAmIResponse response = (WhoAmIResponse)svc.Execute(request);

            Console.WriteLine("Your UserId is {0}", response.UserId);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }

}

