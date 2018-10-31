define(
    'snakeGame/presenters/ScoresPresenter',
    ['snakeGame/managers/ScoresManager'],
    function (scoresManager) {

        function ScoresPresenter(scoresView, viewActivator) {

            scoresView.quitButtonClickHandler = function () {
                viewActivator.activateMenuView();
            };

            scoresManager
                .getRecords()
                .then(function (records) {
                    records.forEach(scoresView.renderRecord);
                });
        }

        return ScoresPresenter;
    }
);