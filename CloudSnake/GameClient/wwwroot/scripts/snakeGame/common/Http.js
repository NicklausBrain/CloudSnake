define(
    'snakeGame/common/Http',
    ['snakeGame/common/Authentication'],
    function (Authentication) {

        var gameApiUrl = "https://cloud-snake-local:8505";

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
                        return fetch(gameApiUrl + url, request)
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
                        return fetch(gameApiUrl + url, request)
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