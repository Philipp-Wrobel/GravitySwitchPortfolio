using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GravitySwitch.Players
{
    public class Player
     {
        private Vector2 playerPosition = new Vector2(500, -250);
        private int speed = 600;
        private PlayerMovementNormalG playerMovementNG = PlayerMovementNormalG.Idle;
        private PlayerMovementReversedG playerMovementRG = PlayerMovementReversedG.Idle;

        public SpriteAnimation playerAnimation;
        public SpriteAnimation[] playerAnimationsNormalG = new SpriteAnimation[5];   // animations for normal Gravity
        public SpriteAnimation[] playerAnimationsReversedG = new SpriteAnimation[5]; // animations for reversed Gravity

        private bool isPlayerOnFloor = false; // added here since player is passed to all functions anyways

        private int jumpPower = 2219; // jump power 2219 is genau die Grenze das man zwei gestapelte 128 blocks (insgesamt 256 pixel) nicht drüber springen kann
        private bool playerJustJumped = false;
        private bool spaceBarReleased = true;
        private float previousPlayerYPosition = 2000; // needed to determine if player is falling

        private bool normalGravity = true;

        public void UpdatePlayerPosition(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.normalGravity == true)
            {
                this.UpdatePlayerNormalGravity(gameTime, keyboardState, deltaTime);
            }
            else
            {
                this.UpdatePlayerReversedGravity(gameTime, keyboardState, deltaTime);
            }
        }

        private void UpdatePlayerNormalGravity(GameTime gameTime, KeyboardState keyboardState, float deltaTime)
        {
            this.playerMovementNG = PlayerMovementNormalG.Idle;
            bool nG = true; // used to tell Update Jump function if gravity is normal or not

            if (keyboardState.IsKeyUp(Keys.Space))
            {
                this.spaceBarReleased = true;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                this.playerMovementNG = PlayerMovementNormalG.Right;
                this.playerPosition.X += (float)Math.Floor(this.speed * deltaTime);
            }

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                this.playerMovementNG = PlayerMovementNormalG.Left;
                this.playerPosition.X -= (float)Math.Floor(this.speed * deltaTime);
            }

            if ((keyboardState.IsKeyDown(Keys.Space) && this.isPlayerOnFloor == true && this.spaceBarReleased == true) || this.playerJustJumped == true)
            {
                this.UpdateJump(deltaTime, nG);
            }

            this.playerAnimation = this.playerAnimationsNormalG[(int)this.playerMovementNG];
            this.playerAnimation.Position = new Vector2(this.playerPosition.X - 48, this.playerPosition.Y - 48);
            this.playerAnimation.Update(gameTime);
        }

        private void UpdatePlayerReversedGravity(GameTime gameTime, KeyboardState keyboardState, float deltaTime)
        {
            this.playerMovementRG = PlayerMovementReversedG.Idle;
            bool nG = false; // used to tell Update Jump function if gravity is normal or not
            if (keyboardState.IsKeyUp(Keys.Space))
            {
                this.spaceBarReleased = true;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                this.playerMovementRG = PlayerMovementReversedG.Right;
                this.playerPosition.X += (float)Math.Floor(this.speed * deltaTime);
            }

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                this.playerMovementRG = PlayerMovementReversedG.Left;
                this.playerPosition.X -= (float)Math.Floor(this.speed * deltaTime);
            }

            if ((keyboardState.IsKeyDown(Keys.Space) && this.isPlayerOnFloor == true && this.spaceBarReleased == true) || this.playerJustJumped == true)
            {
                this.UpdateJump(deltaTime, nG);
            }

            this.playerAnimation = this.playerAnimationsReversedG[(int)this.playerMovementRG];
            this.playerAnimation.Position = new Vector2(this.playerPosition.X - 48, this.playerPosition.Y - 48);
            this.playerAnimation.Update(gameTime);
        }

        private void UpdateJump(float deltaTime, bool nG)
        {
            this.spaceBarReleased = false;
            this.playerJustJumped = true;

            if (nG == true)
            {
                this.playerPosition.Y -= (float)Math.Floor(this.jumpPower * deltaTime);

                // This detects if the player is falling
                if (this.previousPlayerYPosition > this.playerPosition.Y)
                {
                    this.playerMovementNG = PlayerMovementNormalG.JumpRight;
                }
                else
                {
                    this.playerMovementNG = PlayerMovementNormalG.FallRight;
                }

                this.previousPlayerYPosition = this.playerPosition.Y;
            }
            else
            {
                this.playerPosition.Y += (float)Math.Floor(this.jumpPower * deltaTime);

                // This detects if the player is falling
                if (this.previousPlayerYPosition < this.playerPosition.Y)
                {
                    this.playerMovementRG = PlayerMovementReversedG.JumpRight;
                }
                else
                {
                    this.playerMovementRG = PlayerMovementReversedG.FallRight;
                }

                this.previousPlayerYPosition = this.playerPosition.Y;
            }
        }
        // Getters and Setters
        public Vector2 PlayerPosition
        {
            get { return this.playerPosition; }
        }
        public void SetXPlayerPosition(float newX)
        {
            this.playerPosition.X = newX;
        }
        public void SetYPlayerPosition(float newY)
        {
            this.playerPosition.Y = newY;
        }
        public void SetGravity(bool newBool)
        {
            this.normalGravity = newBool;
        }
        public bool IsPlayerOnFloor
        {
            get { return this.isPlayerOnFloor; }
            set { this.isPlayerOnFloor = value; }
        }
        public bool PlayerJustJumped
        {
            get { return this.playerJustJumped; }
            set { this.playerJustJumped = value; }
        }
        public bool NormalGravity
        {
            get { return this.normalGravity; }
            set { this.normalGravity = value; }
        }
    }
}