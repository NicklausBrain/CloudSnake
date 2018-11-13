define(
    'snakeGame/common/Http',
    ['snakeGame/common/Authentication'],
    function (Authentication) {

        var config = {};

        fetch('/api/Config')
            .then(function (response) {
                return response.json();
            })
            .then(function (cfg) {
                config = cfg;
                config.authority = cfg.instance + cfg.tenantId;
            });

        function initPostRequest(token, data) {
            return {
                method: 'POST',
                headers: {
                    'Authorization': 'Bearer ' + token,
                    'Content-Type': 'application/json'
                },
                mode: 'cors',
                cache: 'no-cache',
                redirect: 'follow',
                referrer: 'no-referrer',
                body: JSON.stringify(data)
            };
        }

        function initGetRequest(token) {
            return {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + token,
                    'Content-Type': 'application/json'
                },
                mode: 'cors',
                cache: 'no-cache'
            };
        }

        var Http = {
            get: function (url) {
                return Authentication.getToken()
                    .then(function (token) {
                        var request = initGetRequest(token);
                        return fetch(config.apiUrl + url, request)
                            .then(function (response) {
                                return response.json();
                            })
                            .catch(function (error) {
                                console.error(error);
                            });
                    });
            },
            post: function (url, data) {
                return Authentication.getToken()
                    .then(function (token) {
                        var request = initPostRequest(token, data);
                        return fetch(config.apiUrl + url, request)
                            .then(function (response) {
                                return response.json();
                            })
                            .catch(function (error) {
                                console.error(error);
                            });
                    });
            }
        };

        return Http;
    }
);