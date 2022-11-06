using System.Collections.Generic;
using GravitySwitch.Players;

namespace GravitySwitch.Collisions
{
    public class CollisionRectangle
    {
        private float x;      // top left corner of rectangle
        private float y;      // top left corner of rectangle
        private float width;  // width from left to right
        private float height; // height from top to bottom

        private float mapXOffset = 0; // not accessible outside of this class
        private float mapYOffset = 0; // not accessible outside of this class

        private List<CollisionRectangle> collisionRectangleList = new List<CollisionRectangle>();
        private CollisionRectangle playerCollider;
        private CollisionRectangle zielCollider;

        private int playerHBXOffsetNG = 19;
        private int playerHBYOffsetNG = 24;
        private int playerHBXOffsetRG = 19;
        private int playerHBYOffsetRG = 48;

        public CollisionRectangle(float inputX, float inputY, float inputWidth, float inputHeight)
        {
            this.x = inputX - this.mapXOffset;
            this.y = inputY - this.mapYOffset;
            this.width = inputWidth;
            this.height = inputHeight;
        }

        public CollisionRectangle()
        {
        }

        public void InitializeAllCollisionRectangles(Player player)
        {
            // this is the collider for the player
            this.playerCollider = new CollisionRectangle(player.PlayerPosition.X - this.playerHBXOffsetNG, player.PlayerPosition.Y - this.playerHBYOffsetNG, 38, 72);
            // this is the collider for the Ziel
            this.zielCollider = new CollisionRectangle(14475, 1430, 128, 190);

            /* add all collision boxes for platforms here: */

            // Platform 1
            this.collisionRectangleList.Add(new CollisionRectangle(268, 984, 5440, 512));
            // Platform 2
            this.collisionRectangleList.Add(new CollisionRectangle(1612, 856, 128, 128));
            // Platform 3
            this.collisionRectangleList.Add(new CollisionRectangle(2316, 792, 192, 192));
            // Platform 4
            this.collisionRectangleList.Add(new CollisionRectangle(3340, 692, 256, 292));
            // Platform 5
            this.collisionRectangleList.Add(new CollisionRectangle(2828, -296, 1856, 512));
            // Platform 6
            this.collisionRectangleList.Add(new CollisionRectangle(4172, 152, 256, 356));
            // Platform 7
            this.collisionRectangleList.Add(new CollisionRectangle(5836, 88, 384, 128));
            // Platform 8
            this.collisionRectangleList.Add(new CollisionRectangle(6284, 216, 384, 128));
            // Platform 9
            this.collisionRectangleList.Add(new CollisionRectangle(7116, 216, 384, 128));
            // Platform 10
            this.collisionRectangleList.Add(new CollisionRectangle(7948, 24, 384, 128));
            // Platform 11
            this.collisionRectangleList.Add(new CollisionRectangle(6732, 792, 384, 128));
            // Platform 12
            this.collisionRectangleList.Add(new CollisionRectangle(8908, 984, 1920, 512));
            // Platform 13
            this.collisionRectangleList.Add(new CollisionRectangle(11084, 536, 384, 768));
            // Platform 14
            this.collisionRectangleList.Add(new CollisionRectangle(11660, 1240, 64, 128));
            // Platform 15 -> etwas abgeändert um Bug zu verhindern. Width - 128
            this.collisionRectangleList.Add(new CollisionRectangle(11404, 1624, 512, 128));
            // Platform 16
            this.collisionRectangleList.Add(new CollisionRectangle(11916, 1240, 128, 512));
            // Platform 17
            this.collisionRectangleList.Add(new CollisionRectangle(12236, 920, 384, 768));
            // Platform 18
            this.collisionRectangleList.Add(new CollisionRectangle(12364, 792, 128, 128));
            // Platform 19 -> etwas abgeändert um Bug zu verhindern. Width - 128; Height + 64; y - 64
            this.collisionRectangleList.Add(new CollisionRectangle(12492, 1624, 128, 320));
            // Platform 20 -> etwas abgeändert um Bug zu verhindern. Height +256
            this.collisionRectangleList.Add(new CollisionRectangle(12620, 1240, 128, 704));
            // Platform 21  -> etwas abgeändert um Bug zu verhindern. Width - 128
            this.collisionRectangleList.Add(new CollisionRectangle(12748, 984, 384, 128));
            // Platform 22
            this.collisionRectangleList.Add(new CollisionRectangle(13132, 984, 128, 384));
            // Platform 23
            this.collisionRectangleList.Add(new CollisionRectangle(13580, 1432, 256, 256));
            // Platform 24
            this.collisionRectangleList.Add(new CollisionRectangle(13580, 1176, 384, 128));
            // Platform 25
            this.collisionRectangleList.Add(new CollisionRectangle(14732, 1048, 256, 256));
            // Platform 26
            this.collisionRectangleList.Add(new CollisionRectangle(13452, 1304, 1536, 128));
        }

        public float X
        {
            get { return this.x; }
        }
        public float Y
        {
            get { return this.y; }
        }
        public float Width
        {
            get { return this.width; }
        }
        public float Height
        {
            get { return this.height; }
        }
        public void SetRecX(float newX) // should only have to change for the players rectangle (hit-box)
        {
            this.x = newX;
        }
        public void SetRecY(float newY) // should only have to change for the players rectangle (hit-box)
        {
            this.y = newY;
        }
        public int PlayerHBXOffsetNG
        {
            get { return this.playerHBXOffsetNG; }
        }
        public int PlayerHBYOffsetNG
        {
            get { return this.playerHBYOffsetNG; }
        }
        public int PlayerHBXOffsetRG
        {
            get { return this.playerHBXOffsetRG; }
        }
        public int PlayerHBYOffsetRG
        {
            get { return this.playerHBYOffsetRG; }
        }
        public List<CollisionRectangle> CollisionRectangleList
        {
            get { return this.collisionRectangleList; }
        }
        public CollisionRectangle PlayerCollider
        {
            get { return this.playerCollider; }
        }
        public CollisionRectangle ZielCollider
        {
            get { return this.zielCollider; }
        }
        public void SetPlayerCollider(CollisionRectangle collisionRectangle)
        {
            this.playerCollider = collisionRectangle;
        }
        public void SetZielCollider(CollisionRectangle collisionRectangle)
        {
            this.zielCollider = collisionRectangle;
        }
    }
}