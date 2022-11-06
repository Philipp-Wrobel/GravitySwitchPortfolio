using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GravitySwitch.Players
{
    public class LoadTexture
    {
        // Sprites for Normal Gravity (NG)
        private Texture2D playerFallRightNGSprite;
        private Texture2D playerIdleRightNGAnimation;
        private Texture2D playerJumpRightNGSprite;
        private Texture2D playerRunRightNGAnimation;
        private Texture2D playerRunLeftNGAnimation;

        // Sprites for Reversed Gravity (RG)
        private Texture2D playerFallRightRGSprite;
        private Texture2D playerIdleRightRGAnimation;
        private Texture2D playerJumpRightRGSprite;
        private Texture2D playerRunRightRGAnimation;
        private Texture2D playerRunLeftRGAnimation;

        public void LoadContent(ContentManager content, Player player)
        {
            this.playerFallRightNGSprite = content.Load<Texture2D>("Player/NormalGravity/FallRightScaled300");
            this.playerIdleRightNGAnimation = content.Load<Texture2D>("Player/NormalGravity/IdleRightScaled300");
            this.playerJumpRightNGSprite = content.Load<Texture2D>("Player/NormalGravity/JumpRightScaled300");
            this.playerRunRightNGAnimation = content.Load<Texture2D>("Player/NormalGravity/RunRightScaled300");
            this.playerRunLeftNGAnimation = content.Load<Texture2D>("Player/NormalGravity/RunLeftScaled300");

            player.playerAnimationsNormalG[0] = new SpriteAnimation(this.playerIdleRightNGAnimation, 11, 11);
            player.playerAnimationsNormalG[1] = new SpriteAnimation(this.playerRunRightNGAnimation, 12, 20);
            player.playerAnimationsNormalG[2] = new SpriteAnimation(this.playerRunLeftNGAnimation, 12, 20);
            player.playerAnimationsNormalG[3] = new SpriteAnimation(this.playerJumpRightNGSprite, 1, 1);
            player.playerAnimationsNormalG[4] = new SpriteAnimation(this.playerFallRightNGSprite, 1, 1);

            player.playerAnimation = player.playerAnimationsNormalG[0];

            this.playerFallRightRGSprite = content.Load<Texture2D>("Player/ReversedGravity/FlippedFallRightScaled300");
            this.playerIdleRightRGAnimation = content.Load<Texture2D>("Player/ReversedGravity/FlippedIdleRightScaled300");
            this.playerJumpRightRGSprite = content.Load<Texture2D>("Player/ReversedGravity/FlippedJumpRightScaled300");
            this.playerRunRightRGAnimation = content.Load<Texture2D>("Player/ReversedGravity/FlippedRunRightScaled300");
            this.playerRunLeftRGAnimation = content.Load<Texture2D>("Player/ReversedGravity/FlippedRunLeftScaled300");

            player.playerAnimationsReversedG[0] = new SpriteAnimation(this.playerIdleRightRGAnimation, 11, 11);
            player.playerAnimationsReversedG[1] = new SpriteAnimation(this.playerRunRightRGAnimation, 12, 20);
            player.playerAnimationsReversedG[2] = new SpriteAnimation(this.playerRunLeftRGAnimation, 12, 20);
            player.playerAnimationsReversedG[3] = new SpriteAnimation(this.playerJumpRightRGSprite, 1, 1);
            player.playerAnimationsReversedG[4] = new SpriteAnimation(this.playerFallRightRGSprite, 1, 1);
        }
    }
}
