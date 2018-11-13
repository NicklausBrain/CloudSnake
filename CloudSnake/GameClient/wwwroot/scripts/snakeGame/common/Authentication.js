define(
    'snakeGame/common/Authentication',
    [],
    function () {

        var config = {};
        var clientApplication = {};

        fetch('/api/Config')
            .then(function (response) {
                return response.json();
            })
            .then(function (cfg) {
                config = cfg;
                config.authority = cfg.instance + cfg.tenantId;

                clientApplication = new Msal.UserAgentApplication(
                    config.clientId,
                    config.authority,
                    authCallback);
            });

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
            getToken: function () {
                var scope = [config.clientId];
                return clientApplication.acquireTokenSilent(scope);
            }
        };

        return Authentication;
    }
);