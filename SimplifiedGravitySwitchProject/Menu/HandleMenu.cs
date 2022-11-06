using Microsoft.Xna.Framework.Input;

namespace GravitySwitch.Menus
{
    public class HandleMenu
    {
        public GameState currentGameState;
        public KeyboardState keyboardState;

        public GameState HandleGameState(GameState gameState, KeyboardState keyboardstate)
        {
            this.currentGameState = gameState;
            this.keyboardState = keyboardstate;
            // springt je nach GameState in die dazugehörige Funktion
            switch (this.currentGameState)
            {
                case GameState.Menu:
                    this.currentGameState = this.UpdateMenu();
                    return this.currentGameState;
                case GameState.StartMenu:
                    this.currentGameState = this.UpdateStartMenu();
                    return this.currentGameState;
                case GameState.Playing:
                    this.currentGameState = this.UpdatePlaying();
                    return this.currentGameState;
            }
            return this.currentGameState;
        }
        // Überprüft ob P für Pause gedrückt wird
        public GameState UpdatePlaying()
        {
            if (this.keyboardState.IsKeyDown(Keys.P))
            {
                this.currentGameState = GameState.Menu;
                return this.currentGameState;
            }
            return GameState.Playing;
        }
        // Startet das Spiel sobald die Space-Taste gedrückt wird
        public GameState UpdateStartMenu()
        {
            if (this.keyboardState.IsKeyDown(Keys.Space))
            {
                this.currentGameState = GameState.Playing;
                return this.currentGameState;
            }
            return GameState.StartMenu;
        }
        // Setzt laufendes Spiel fort (Tab-Taste)
        public GameState UpdateMenu()
        {
            if (this.keyboardState.IsKeyDown(Keys.Tab))
            {
                this.currentGameState = GameState.Playing;
                return this.currentGameState;
            }
            return GameState.Menu;
        }
    }
}
