define(
    'snakeGame/managers/ScoresManager',
    ['snakeGame/common/LocalStorage', 'snakeGame/common/Http'],
    function (localStorage, http) {
        var maxRecordsCount = 12; // mb to settings
        var recordsKey = 'playerRecords';
        var records = localStorage.getItem(recordsKey) || [];

        var scoresManager = {
            trySaveNewRecord: function (score) {
                return http.post('/api/Score', {
                    Value: score,
                    Date: new Date()
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
                return http.get('/api/Score');
                //return localStorage.getItem(recordsKey);
            }
        };

        return scoresManager;
    }
);