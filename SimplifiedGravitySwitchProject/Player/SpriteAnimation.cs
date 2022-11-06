using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravitySwitch.Players
{
    public class SpriteManager
    {
        protected Texture2D texture;
        public Vector2 Position = Vector2.Zero;
        public Color Color = Color.White;
        public Vector2 Origin;
        public float Rotation = 0f;
        public float Scale = 1f;
        public SpriteEffects SpriteEffect;
        protected Rectangle[] rectangles;
        protected int frameIndex = 0;

        public SpriteManager(Texture2D Texture, int frames)
        {
            this.texture = Texture;
            int width = Texture.Width / frames;
            this.rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                this.rectangles[i] = new Rectangle(i * width, 0, width, Texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Position, this.rectangles[this.frameIndex], this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffect, 0f);
        }
    }

    public class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        public bool IsLooping = true;
        private float timeToUpdate; // default, you may have to change it
        public int FramesPerSecond
        {
            set { this.timeToUpdate = 1f / value; }
        }

        public SpriteAnimation(Texture2D Texture, int frames, int fps)
            : base(Texture, frames)
        {
            this.FramesPerSecond = fps;
        }

        public void Update(GameTime gameTime)
        {
            this.timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timeElapsed > this.timeToUpdate)
            {
                this.timeElapsed -= this.timeToUpdate;

                if (this.frameIndex < this.rectangles.Length - 1)
                {
                    this.frameIndex++;
                }
                else if (this.IsLooping)
                {
                    this.frameIndex = 0;
                }
            }
        }

        public void SetFrame(int frame)
        {
            this.frameIndex = frame;
        }
    }
}