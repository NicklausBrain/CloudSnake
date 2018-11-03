define(
    'snakeGame/common/Authentication',
    [],
    function () {

        var config = {
            // The clientID of your application, you should get this from the application registration portal.
            clientID: '352a9497-51a7-4712-8512-4b0a3454e38e',
            // authority - A URL indicating a directory that MSAL can use to obtain tokens.
            // In Azure AD, it is of the form https://<instance>/<tenant>,
            // where<instance> is the directory host(e.g.https://login.microsoftonline.com)
            // and<tenant> is a identifier within the directory itself
            // (e.g.a domain associated to the tenant, such as contoso.onmicrosoft.com, or the GUID representing the TenantID property of the directory)
            authority: 'https://login.microsoftonline.com/27e4fcee-63ff-47c2-9d92-fa40d44e8ba5'
        };

        var clientApplication = new Msal.UserAgentApplication(
            config.clientID,
            config.authority,
            authCallback);

        function onSignin(idToken) {
            // Check Login Status, Update UI
            var user = clientApplication.getUser();
            if (user) {
                console.log(user);
            } else {
                console.log('no user');
            }
        }

        function authCallback(errorDesc, token, error, tokenType) {
            //This function is called after loginRedirect and acquireTokenRedirect. Not called with loginPopup
            // msal object is bound to the window object after the constructor is called.
            if (token) {
                console.log("token:" + token);
            }
            else {
                console.log(error + ":" + errorDesc);
            }
        }

        var Authentication = {
            loginPopup: function () {
                return clientApplication
                    .loginPopup()
                    .then(onSignin);
            },
            getToken: function() {
                var scope = [config.clientID];
                return clientApplication.acquireTokenSilent(scope);
            }
        };

        return Authentication;
    }
);