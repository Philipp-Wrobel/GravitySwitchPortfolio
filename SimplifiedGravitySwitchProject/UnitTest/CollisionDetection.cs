using System.Diagnostics.CodeAnalysis;
using GravitySwitch.Collisions;
using GravitySwitch.Menus;
using GravitySwitch.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CollisionDetection
    {
        private Player player;
        private Collision collision;
        private CollisionRectangle collisionRectangle = new CollisionRectangle();

        private int playerHBXOffsetNG = 19;
        private int playerHBYOffsetNG = 24;

        [TestInitialize]
        public void InitializeCollisionRectangles()
        {
            player = new Player();
            collision = new Collision();
            collisionRectangle = new CollisionRectangle(300, 1000, 800, 3000);
            collisionRectangle.CollisionRectangleList.Add(collisionRectangle);
            collisionRectangle.SetPlayerCollider(new CollisionRectangle(player.PlayerPosition.X - this.playerHBXOffsetNG, player.PlayerPosition.Y - this.playerHBYOffsetNG, 38, 72));
            collisionRectangle.SetZielCollider(new CollisionRectangle(14475, 1430, 128, 190));

        }

        //Reversed Gravity
        [TestMethod]
        public void TestPlayerCollisionRightReversedGravity()
        {
            player.NormalGravity = false;
            player.IsPlayerOnFloor = true;
            collision.SetLocalPlayerIsOnFloor(true);
            player.SetGravity(false);
            player.SetXPlayerPosition(collisionRectangle.X + collisionRectangle.Width);
            player.SetYPlayerPosition(collisionRectangle.Y + collisionRectangle.Height / 2);

            collision.UpdateCollision(player, collisionRectangle);


            Assert.IsFalse(player.IsPlayerOnFloor);
            Assert.IsTrue(collisionRectangle.X + collisionRectangle.Width < player.PlayerPosition.X);
        }
        [TestMethod]
        public void TestPlayerCollisionLeftReversedGravity()
        {
            player.NormalGravity = false;
            player.IsPlayerOnFloor = true;
            collision.SetLocalPlayerIsOnFloor(true);
            player.SetGravity(false);
            player.SetXPlayerPosition(collisionRectangle.X);
            player.SetYPlayerPosition(collisionRectangle.Y + collisionRectangle.Height / 2);

            collision.UpdateCollision(player, collisionRectangle);


            Assert.IsFalse(player.IsPlayerOnFloor);
            Assert.IsTrue(collisionRectangle.X > player.PlayerPosition.X);
        }
        [TestMethod]
        public void TestPlayerCollisionTopReversedGravity()
        {
            player.NormalGravity = false;
            player.IsPlayerOnFloor = true;
            player.PlayerJustJumped = true;
            collision.SetLocalPlayerIsOnFloor(true);
            player.SetGravity(false);
            player.SetXPlayerPosition(collisionRectangle.X + collisionRectangle.Width / 2);
            player.SetYPlayerPosition(collisionRectangle.Y);

            collision.UpdateCollision(player, collisionRectangle);


            Assert.IsFalse(player.PlayerJustJumped);
            Assert.IsFalse(player.IsPlayerOnFloor);
            Assert.IsTrue(collisionRectangle.Y > player.PlayerPosition.Y);
        }
        [TestMethod]
        public void TestPlayerCollisionBottomReversedGravity()
        {
            player.NormalGravity = false;
            player.PlayerJustJumped = true;
            player.IsPlayerOnFloor = false;
            player.SetGravity(false);
            player.SetXPlayerPosition(collisionRectangle.X + collisionRectangle.Width / 2);
            player.SetYPlayerPosition(collisionRectangle.Y + collisionRectangle.Height);

            collision.UpdateCollision(player, collisionRectangle);

            Assert.IsTrue(player.IsPlayerOnFloor);
            Assert.IsFalse(player.PlayerJustJumped);
            Assert.IsTrue(player.PlayerPosition.Y >= collisionRectangle.Y + collisionRectangle.Height + 48);
        }
        [TestMethod]
        public void TestPlayerNoCollisionReversedGravity()
        {
            player.NormalGravity = false;
            player.IsPlayerOnFloor = true;
            player.SetGravity(false);
            player.SetXPlayerPosition(200);
            player.SetYPlayerPosition(200);

            collision.UpdateCollision(player, collisionRectangle);

            Assert.IsFalse(player.IsPlayerOnFloor);
        }

        //Normal Gravity
        [TestMethod]
        public void TestPlayerCollisionRightNormalGravity()
        {
            player.NormalGravity = true;
            player.IsPlayerOnFloor = true;
            collision.SetLocalPlayerIsOnFloor(true);
            player.SetGravity(true);
            player.SetXPlayerPosition(collisionRectangle.X + collisionRectangle.Width);
            player.SetYPlayerPosition(collisionRectangle.Y + collisionRectangle.Height / 2);

            collision.UpdateCollision(player, collisionRectangle);


            Assert.IsFalse(player.IsPlayerOnFloor);
            Assert.IsTrue(collisionRectangle.X + collisionRectangle.Width < player.PlayerPosition.X);
        }
        [TestMethod]
        public void TestPlayerCollisionLeftNormalGravity()
        {
            player.NormalGravity = true;
            player.IsPlayerOnFloor = true;
            collision.SetLocalPlayerIsOnFloor(true);
            player.SetGravity(true);
            player.SetXPlayerPosition(collisionRectangle.X);
            player.SetYPlayerPosition(collisionRectangle.Y + collisionRectangle.Height / 2);

            collision.UpdateCollision(player, collisionRectangle);

            Assert.IsFalse(player.IsPlayerOnFloor);
            Assert.IsTrue(collisionRectangle.X > player.PlayerPosition.X);
        }
        [TestMethod]
        public void TestPlayerCollisionTopNormalGravity()
        {
            player.NormalGravity = true;
            player.IsPlayerOnFloor = false;
            player.PlayerJustJumped = true;
            collision.SetLocalPlayerIsOnFloor(true);
            player.SetGravity(true);
            player.SetXPlayerPosition(collisionRectangle.X + collisionRectangle.Width / 2);
            player.SetYPlayerPosition(collisionRectangle.Y);

            collision.UpdateCollision(player, collisionRectangle);

            Assert.IsFalse(player.PlayerJustJumped);
            Assert.IsTrue(player.IsPlayerOnFloor);
            Assert.IsTrue(collisionRectangle.Y > player.PlayerPosition.Y);
        }
        [TestMethod]
        public void TestPlayerCollisionBottomNormalGravity()
        {
            player.PlayerJustJumped = true;
            player.NormalGravity = true;
            player.IsPlayerOnFloor = true;
            player.SetGravity(true);
            player.SetXPlayerPosition(collisionRectangle.X + collisionRectangle.Width / 2);
            player.SetYPlayerPosition(collisionRectangle.Y + collisionRectangle.Height);

            collision.UpdateCollision(player, collisionRectangle);

            Assert.IsFalse(player.IsPlayerOnFloor);
            Assert.IsFalse(player.PlayerJustJumped);
            Assert.IsTrue(player.PlayerPosition.Y >= collisionRectangle.Y + collisionRectangle.Height + 48);
        }

        [TestMethod]
        public void TestPlayerNoCollisionNormalGravity()
        {
            player.NormalGravity = true;
            player.IsPlayerOnFloor = true;
            player.SetGravity(true);
            player.SetXPlayerPosition(200);
            player.SetYPlayerPosition(200);

            collision.UpdateCollision(player, collisionRectangle);

            Assert.IsFalse(player.IsPlayerOnFloor);
        }

        [TestMethod]
        public void TestPlayerOutOfBoundsTop()
        {
            player.SetXPlayerPosition(0);
            player.SetYPlayerPosition(-1301);
            GameState gameState = new GameState();
            gameState = GameState.Playing;

            Assert.AreNotEqual(gameState, collision.UpdateCollision(player, collisionRectangle));
        }
        [TestMethod]
        public void TestPlayerOutOfBoundsBottom()
        {
            player.SetXPlayerPosition(0);
            player.SetYPlayerPosition(3001);
            GameState gameState = new GameState();
            gameState = GameState.Playing;

            Assert.AreNotEqual(gameState, collision.UpdateCollision(player, collisionRectangle));
        }
        [TestMethod]
        public void TestCollisioWithFlag()
        {
            player.SetXPlayerPosition(14476);
            player.SetYPlayerPosition(1431);
            GameState gameState = new GameState();
            gameState = GameState.Playing;

            Assert.AreNotEqual(gameState, collision.UpdateCollision(player, collisionRectangle));
        }
        [TestMethod]
        public void TestInitializeOfRectangles()
        {
            int f = collisionRectangle.CollisionRectangleList.Count;
            collisionRectangle.InitializeAllCollisionRectangles(player);
            int l = collisionRectangle.CollisionRectangleList.Count;

            Assert.IsTrue(l != 0 && l > f);
        }

        [TestCleanup]
        public void CleanupTestObjects()
        {
            player = null;
            collision = null;
            collisionRectangle = null;
        }

    }
}
