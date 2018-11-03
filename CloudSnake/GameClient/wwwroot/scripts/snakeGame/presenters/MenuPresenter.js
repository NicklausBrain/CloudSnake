define(
    'snakeGame/presenters/MenuPresenter',
    ['snakeGame/common/Authentication'],
    function (Authentication) {

        function MenuPresenter(menuView, viewActivator) {

            menuView.playButtonClickHandler = function () {
                viewActivator.activateGameView();
            };

            menuView.settingsButtonClickHandler = function () {
                viewActivator.activateSettingsView();
            };

            menuView.scoresButtonClickHandler = function () {
                viewActivator.activateScoresView();
            };

            menuView.signInButtonClickHandler = function () {
                Authentication.loginPopup();
            };
        }

        return MenuPresenter;
    }
);