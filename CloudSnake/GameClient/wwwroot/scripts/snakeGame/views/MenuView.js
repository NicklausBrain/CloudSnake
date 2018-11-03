define(
    'snakeGame/views/MenuView',
    [],
    function () {

        function MenuView(
            playButton,
            settingsButton,
            scoresButton,
            signInButton) {
            var self = this;

            this.playButtonClickHandler = null;
            this.settingsButtonClickHandler = null;
            this.scoresButtonClickHandler = null;
            this.signInButtonClickHandler = null;

            playButton.addEventListener('click', function () {
                self.playButtonClickHandler();
            });
            settingsButton.addEventListener('click', function () {
                self.settingsButtonClickHandler();
            });
            scoresButton.addEventListener('click', function () {
                self.scoresButtonClickHandler();
            });
            signInButton.addEventListener('click', function() {
                self.signInButtonClickHandler();
            });

            //Object.defineProperties(this, {
            //	playButtonClickHandler: {
            //		set: function () {
            //			scoreLabel.textContent = 'Score: ' + (score += 10);// add string format
            //		}
            //	}
            //});

            this.activate = function () {

            };
        }

        return MenuView;
    }
);