namespace GameClient.Authentication
{
    public class AzureAdOptions
    {
        public AzureAdOptions()
        {
            /* TODO: make it configurable */
            this.Instance = "https://login.microsoftonline.com/";
            this.ClientId = "352a9497-51a7-4712-8512-4b0a3454e38e";
            /*
              The Domain and TenantId are only needed if you want to accept access tokens
              from a sigle tenant (line of business app)
              Otherwise you can leave them blank
            */
            this.Domain = "NicklausBrainhotmail.onmicrosoft.com"; // for instance contoso.onmicrosoft.com
            this.TenantId = "common";
            // 'common' or 'organizations' or 'consumers'
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Instance { get; set; }

        public string Domain { get; set; }

        public string TenantId { get; set; }
    }
}
