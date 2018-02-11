using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboRally.Core.Tests
{
    [TestClass]
    public class DirectionHelperTest
    {
        [TestMethod]
        public void GetRotatedDirectionTest()
        {
			Assert.AreEqual(Direction.Right, DirectionHelper.GetRotatedDirection(Direction.Down, RotateDirection.Left));
			Assert.AreEqual(Direction.Up, DirectionHelper.GetRotatedDirection(Direction.Right, RotateDirection.Left));
			Assert.AreEqual(Direction.Left, DirectionHelper.GetRotatedDirection(Direction.Up, RotateDirection.Left));
			Assert.AreEqual(Direction.Down, DirectionHelper.GetRotatedDirection(Direction.Left, RotateDirection.Left));

			Assert.AreEqual(Direction.Left, DirectionHelper.GetRotatedDirection(Direction.Down, RotateDirection.Right));
			Assert.AreEqual(Direction.Down, DirectionHelper.GetRotatedDirection(Direction.Right, RotateDirection.Right));
			Assert.AreEqual(Direction.Right, DirectionHelper.GetRotatedDirection(Direction.Up, RotateDirection.Right));
			Assert.AreEqual(Direction.Up, DirectionHelper.GetRotatedDirection(Direction.Left, RotateDirection.Right));
		}

		[TestMethod]
		public void GetRotationDirectionTest() {
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(Direction.Up, Direction.Right));
			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(Direction.Up, Direction.Left));
			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(Direction.Up, Direction.Down));
			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(Direction.Up, Direction.Up));

			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(Direction.Right, Direction.Right));
			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(Direction.Right, Direction.Left));
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(Direction.Right, Direction.Down));
			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(Direction.Right, Direction.Up));

			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(Direction.Down, Direction.Right));
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(Direction.Down, Direction.Left));
			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(Direction.Down, Direction.Down));
			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(Direction.Down, Direction.Up));

			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(Direction.Left, Direction.Right));
			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(Direction.Left, Direction.Left));
			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(Direction.Left, Direction.Down));
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(Direction.Left, Direction.Up));
		}
    }
}
