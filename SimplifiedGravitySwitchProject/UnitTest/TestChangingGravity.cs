using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using GravitySwitch;
using GravitySwitch.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class TestChangingGravity
    {
        private Gravity gravity = new Gravity();
        private Player player = new Player();
        private float deltaTime = 1;

        [TestMethod]
        public void TestApplyNormalGravityPlayerOnAir()
        {
            player.NormalGravity = true;
            float before = gravity.GetCurrentGravityNG();
            
            gravity.ApplyNormalGravity(player, deltaTime, player.PlayerPosition, false);
            
            Assert.IsTrue(before < gravity.GetCurrentGravityNG());
        }
        [TestMethod]
        public void TestApplyNormalGravityPlayerOnFloor()
        {
            player.NormalGravity = true;
            float before = gravity.GetCurrentGravityNG();
            
            gravity.ApplyNormalGravity(player, deltaTime, player.PlayerPosition, true);
            
            Assert.IsTrue(before == gravity.GetCurrentGravityNG());
        }
        [TestMethod]
        public void TestApplyReversedGravityPlayerOnAir()
        {
            player.NormalGravity = false;
            float before = gravity.GetCurrentGravityRG(); //-1100
            
            gravity.ApplyReversedGravity(player, deltaTime, player.PlayerPosition, false);
            
            Assert.IsTrue(before > gravity.GetCurrentGravityRG());
        }
        [TestMethod]
        public void TestApplyReversedGravityPlayerOnFloor()
        {
            player.NormalGravity = false;
            float before = gravity.GetCurrentGravityRG();
            
            gravity.ApplyReversedGravity(player, deltaTime, player.PlayerPosition, true);
            
            Assert.IsTrue(before == gravity.GetCurrentGravityRG());
        }

    }
}