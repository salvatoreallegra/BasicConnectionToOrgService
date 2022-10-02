using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;


public class Program
{
    static void Main(string[] args)
    {
        // e.g. https://yourorg.crm.dynamics.com
        //string url = "*****************";
        // e.g. you@yourorg.onmicrosoft.com
        //string userName = "************";
        // e.g. y0urp455w0rd 
        //string password = "***************";

        // e.g. https://yourorg.crm.dynamics.com
        string url = "https://org7ba21b0e.crm.dynamics.com/";
        // e.g. you@yourorg.onmicrosoft.com
        string userName = "SalvatoreAllegra@NoCo7775.onmicrosoft.com";
        // e.g. y0urp455w0rd 
        string password = "JediKnight1@7775";

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

            
        }

        string fetch2 = @"  
           <fetch mapping='logical'>  
             <entity name='account'>   
                <attribute name='accountid'/>   
                <attribute name='name'/>   
                <link-entity name='systemuser' to='owninguser'>   
                   <filter type='and'>   
                      <condition attribute='lastname' operator='ne' value='Cannon' />   
                   </filter>   
                </link-entity>   
             </entity>   
           </fetch> "
                ;
        using (var svc = new CrmServiceClient(conn))
        {
            EntityCollection result = svc.RetrieveMultiple(new FetchExpression(fetch2));
            
            foreach (var c in result.Entities)
            {
                System.Console.WriteLine(c.Attributes["name"]);
            }
        }
        Console.ReadLine();
    }

}

