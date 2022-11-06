using System;
using GravitySwitch.Menus;
using GravitySwitch.Players;

namespace GravitySwitch.Collisions
{
    public class Collision
    {
        private bool localPlayerIsOnFloor = false;

        public GameState UpdateCollision(Player player, CollisionRectangle collisionRectangle)
        {
            // This updates the position of the players hit-box
            this.UpdatePlayerHitbox(player, collisionRectangle);

            // This is used to determine where the player hit any floor in this run through
            this.localPlayerIsOnFloor = false;

            if (player.NormalGravity == true)
            {
                this.CheckForNormalGravityCollision(player, collisionRectangle);
            }
            else
            {
                this.CheckForReversedGravityCollision(player, collisionRectangle);
            }

            return this.CheckForOutOfBounds(player, collisionRectangle);
        }

        private void CheckForNormalGravityCollision(Player player, CollisionRectangle collisionRectangle)
        {
            foreach (CollisionRectangle platformCollider in collisionRectangle.CollisionRectangleList)
            {
                // If the player did not collide with the platform then skip iteration
                if (this.PlayerCollided(player, platformCollider, collisionRectangle) == false)
                {
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }

                    continue;
                }

                /* Here [all following if conditions] we check which side was collided with and respond accordingly */

                // collided with top side of platform (floor)
                if (platformCollider.Y >= collisionRectangle.PlayerCollider.Y)
                {
                    this.localPlayerIsOnFloor = true;
                    player.IsPlayerOnFloor = true;
                    player.PlayerJustJumped = false; // Sprung Function deaktivieren
                    player.SetYPlayerPosition(platformCollider.Y - 47);
                    continue; // completely exit loop
                }

                // collided with right side of platform
                if (platformCollider.X + platformCollider.Width <= collisionRectangle.PlayerCollider.X + collisionRectangle.PlayerCollider.Width)
                {
                    player.SetXPlayerPosition(platformCollider.X + platformCollider.Width + 19);
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                    continue; // completely exit loop
                }

                // collided with left side of platform
                if (platformCollider.X >= collisionRectangle.PlayerCollider.X)
                {
                    player.SetXPlayerPosition(platformCollider.X - 19);
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                    continue; // completely exit loop
                }

                // collided with bottom side of platform
                if (platformCollider.Y + platformCollider.Height <= collisionRectangle.PlayerCollider.Y + collisionRectangle.PlayerCollider.Height)
                {
                    player.SetYPlayerPosition(platformCollider.Y + platformCollider.Height + 48);
                    player.PlayerJustJumped = false; // Sprung Function deaktivieren
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                }
            }
        }

        private void CheckForReversedGravityCollision(Player player, CollisionRectangle collisionRectangle)
        {
            foreach (CollisionRectangle platformCollider in collisionRectangle.CollisionRectangleList)
            {
                // If the player did not collide with the platform then skip iteration
                if (this.PlayerCollided(player, platformCollider, collisionRectangle) == false)
                {
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                    continue;
                }

                /* Here [all following if conditions] we check which side was collided with and respond accordingly */

                // collided with bottom side of platform (floor -> gravity now reversed)
                if (platformCollider.Y + platformCollider.Height <= collisionRectangle.PlayerCollider.Y + collisionRectangle.PlayerCollider.Height)
                {
                    player.SetYPlayerPosition(platformCollider.Y + platformCollider.Height + 48);
                    this.localPlayerIsOnFloor = true;
                    player.IsPlayerOnFloor = true;
                    player.PlayerJustJumped = false; // Sprung Function deaktivieren
                    continue; // completely exit loop
                }

                // collided with right side of platform
                if (platformCollider.X + platformCollider.Width <= collisionRectangle.PlayerCollider.X + collisionRectangle.PlayerCollider.Width)
                {
                    player.SetXPlayerPosition(platformCollider.X + platformCollider.Width + 19);
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                    continue;
                }

                // collided with left side of platform
                if (platformCollider.X >= collisionRectangle.PlayerCollider.X)
                {
                    player.SetXPlayerPosition(platformCollider.X - 19);
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                }

                // collided with top side of platform
                if (platformCollider.Y >= collisionRectangle.PlayerCollider.Y)
                {
                    player.SetYPlayerPosition(platformCollider.Y - 48);
                    player.PlayerJustJumped = false; // Sprung Function deaktivieren
                    if (this.localPlayerIsOnFloor != true)
                    {
                        player.IsPlayerOnFloor = false;
                    }
                }
            }
        }

        private bool PlayerCollided(Player player, CollisionRectangle platformCollider, CollisionRectangle collisionRectangle)
        {
            this.UpdatePlayerHitbox(player, collisionRectangle);

            if (platformCollider.X + platformCollider.Width >= collisionRectangle.PlayerCollider.X &&
                platformCollider.X <= collisionRectangle.PlayerCollider.X + collisionRectangle.PlayerCollider.Width &&
                platformCollider.Y + platformCollider.Height >= collisionRectangle.PlayerCollider.Y &&
                platformCollider.Y <= collisionRectangle.PlayerCollider.Y + collisionRectangle.PlayerCollider.Height)
            {
                return true; // a collision occured
            }
            else
            {
                return false; // there was no collision
            }
        }

        private void UpdatePlayerHitbox(Player player, CollisionRectangle collisionRectangle)
        {
            if (player.NormalGravity == true)
            {
                collisionRectangle.PlayerCollider.SetRecX(player.PlayerPosition.X - collisionRectangle.PlayerHBXOffsetNG);
                collisionRectangle.PlayerCollider.SetRecY(player.PlayerPosition.Y - collisionRectangle.PlayerHBYOffsetNG);
            }
            else
            {
                collisionRectangle.PlayerCollider.SetRecX(player.PlayerPosition.X - collisionRectangle.PlayerHBXOffsetRG);
                collisionRectangle.PlayerCollider.SetRecY(player.PlayerPosition.Y - collisionRectangle.PlayerHBYOffsetRG);
            }
        }

        private GameState CheckForOutOfBounds(Player player, CollisionRectangle collisionRectangle)
        {
            if (player.PlayerPosition.Y < -1300)
            {
                Console.Error.WriteLine("\nPLAYER OUT OF BOUNDS!!!");
                return GameState.GameOver;
            }

            if (player.PlayerPosition.Y > 3000)
            {
                Console.Error.WriteLine("\nPLAYER OUT OF BOUNDS!!!");
                return GameState.GameOver;
            }

            if (this.PlayerCollided(player, collisionRectangle.ZielCollider, collisionRectangle))
            {
                return GameState.LevelFinished;
            }

            return GameState.Playing;
        }
        public void SetLocalPlayerIsOnFloor(bool onfloor)
        {
            this.localPlayerIsOnFloor = onfloor;
        }
    }
}