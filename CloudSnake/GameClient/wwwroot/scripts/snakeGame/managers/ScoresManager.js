define(
    'snakeGame/managers/ScoresManager',
    ['snakeGame/common/LocalStorage'],
    function (localStorage) {
        var maxRecordsCount = 12; // mb to settings
        var recordsKey = 'playerRecords';
        var records = localStorage.getItem(recordsKey) || [];

        var scoresManager = {
            trySaveNewRecord: function (score) {
                var scope = [window.config.clientID];
                window.clientApplication.acquireTokenSilent(scope)
                    .then(function(token) {
                        var myHeaders = new Headers();
                        myHeaders.append('Authorization', 'Bearer ' + token);
                        myHeaders.append("Content-Type", "application/json");

                        var myInit = {
                            method: 'POST',
                            headers: myHeaders,
                            mode: 'cors',
                            cache: 'default'
                        };

                        postData('/api/Score', { Value: score, Date: new Date() },

                            {
                                "Content-Type": "application/json; charset=utf-8",
                                'Authorization': 'Bearer ' + token
                                //    // "Content-Type": "application/x-www-form-urlencoded",
                                })
                            .then(data => console.log(JSON.stringify(data))) // JSON-string from `response.json()` call
                            .catch(error => console.error(error));
                    });

                

                //if (records.length < maxRecordsCount || records.last().score < score) {
                //	var record = {
                //		score: score,
                //		date: new Date().toLocaleString()
                //	};

                //	records.push(record);
                //	records.sort(function (a, b) { return b.score - a.score; });

                //	if (records.length > maxRecordsCount) {
                //		records.pop();
                //	}

                //	localStorage.setItem(recordsKey, records);

                //	return true;
                //}

                //return false;
            },
            getRecords: function () {
                var scope = [window.config.clientID];
                return window.clientApplication.acquireTokenSilent(scope)
                    .then(function(token) {
                            //saveTodoItem(token, todoId, $description);

                        var myHeaders = new Headers();
                        myHeaders.append('Authorization', 'Bearer ' + token);
                        myHeaders.append("Content-Type", "application/json");
                            
                            var myInit = {
                                method: 'GET',
                                headers: myHeaders,
                                mode: 'cors',
                                cache: 'default'
                            };

                        return fetch('/api/Score', myInit)
                                .then(function (response) {
                                    return response.json();
                                });
                        },
                    function (error) {
                        console.log(error);
                            //clientApplication.acquireTokenPopup(scope).then(function(token) {
                            //        deleteTodoItem(token, todoId, $description);
                            //    },
                            //    function(error) {
                            //        printErrorMessage(error);
                            //    });
                        });

                
                //return localStorage.getItem(recordsKey);
            }
        };

        return scoresManager;
    }
);