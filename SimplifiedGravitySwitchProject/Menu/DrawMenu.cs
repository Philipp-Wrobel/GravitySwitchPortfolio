using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GravitySwitch.Menus
{
    public class DrawMenu
    {
        private ContentManager content;
        private GraphicsDevice graphicsDevice;
        private SpriteFont spriteFont;
        private SpriteBatch spriteBatch;
        private Vector2 playerPosition;
        private GameState currentGameState = GameState.Playing;

        private Texture2D cameraBackground;
        private Texture2D mainBackground;
        private Texture2D pauseBackground;
        private Texture2D loseBackground;
        private Texture2D winBackground;

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
            this.content = content;

            this.cameraBackground = this.content.Load<Texture2D>("MainMapBG");
            this.mainBackground = this.content.Load<Texture2D>("TitelBild");
            this.pauseBackground = this.content.Load<Texture2D>("PauseMenuBackground");
            this.loseBackground = this.content.Load<Texture2D>("PersonInSpace");
            this.winBackground = this.content.Load<Texture2D>("PersonOnTheMoon");
        }
        public void HandleDraw(GameState gameState, GraphicsDevice graphicsDevice, SpriteFont spriteFont, SpriteBatch spriteBatch, Vector2 playerPosition)
        {
            this.graphicsDevice = graphicsDevice;
            this.spriteFont = spriteFont;
            this.spriteBatch = spriteBatch;
            this.currentGameState = gameState;
            this.playerPosition = playerPosition;

            switch (this.currentGameState)
            {
                case GameState.GameOver:
                    this.DrawGameOver();
                    break;
                case GameState.LevelFinished:
                    this.DrawLevelFinished();
                    break;
                case GameState.Menu:
                    this.DrawGameMenu();
                    break;
                case GameState.StartMenu:
                    this.DrawStartMenu();
                    break;
                case GameState.Playing:
                    this.DrawPlayMode();
                    break;
            }
        }
        public void DrawStartMenu()
        {
            this.graphicsDevice.Clear(Color.Black);
            this.spriteBatch.Draw(this.mainBackground, new Vector2(-1200, -700), Color.White);
            string startMenuMessage = "Press \nSPACE \nto \nbegin!";
            this.spriteBatch.DrawString(this.spriteFont, startMenuMessage, new Vector2(-650, -200), Color.Red, 0, Vector2.Zero, 2.0f, SpriteEffects.None, 0);
        }
        public void DrawPlayMode()
        {
            this.graphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Draw(this.cameraBackground, new Vector2(0, -1000), Color.White);
        }
        public void DrawGameMenu()
        {
            this.graphicsDevice.Clear(Color.White);
            this.spriteBatch.Draw(this.pauseBackground, new Vector2(this.playerPosition.X - 960, this.playerPosition.Y - 540), Color.White);
            string exit = "ESC for Exit";
            this.spriteBatch.DrawString(this.spriteFont, exit, new Vector2(this.playerPosition.X - 850, this.playerPosition.Y - 250), Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);

            string resume = "TAB for Resume";
            this.spriteBatch.DrawString(this.spriteFont, resume, new Vector2(this.playerPosition.X - 850, this.playerPosition.Y - 50), Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);

            string restart = "Enter for Restart";
            this.spriteBatch.DrawString(this.spriteFont, restart, new Vector2(this.playerPosition.X - 850, this.playerPosition.Y + 150), Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);
        }
        public void DrawGameOver()
        {
            this.graphicsDevice.Clear(Color.White);
            this.spriteBatch.Draw(this.loseBackground, new Vector2(this.playerPosition.X - 960, this.playerPosition.Y - 550), Color.White);
            string gameOverMessage = "Exit with Esc or restart with Enter";
            this.spriteBatch.DrawString(this.spriteFont, gameOverMessage, new Vector2(this.playerPosition.X - 470, this.playerPosition.Y + 375), Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
        public void DrawLevelFinished()
        {
            this.graphicsDevice.Clear(Color.Black);
            this.spriteBatch.Draw(this.winBackground, new Vector2(this.playerPosition.X - 970, this.playerPosition.Y - 550), Color.White);

            string levelFinishedMessage = "Gratulation Neil, du hast es geschafft!";
            this.spriteBatch.DrawString(this.spriteFont, levelFinishedMessage, new Vector2(this.playerPosition.X - 650, this.playerPosition.Y - 550), Color.White, 0, Vector2.Zero, 1.8f, SpriteEffects.None, 0);

            string levelFinish = "Exit with Esc or restart with Enter";
            this.spriteBatch.DrawString(this.spriteFont, levelFinish, new Vector2(this.playerPosition.X - 370, this.playerPosition.Y + 350), Color.Black, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
    }
}