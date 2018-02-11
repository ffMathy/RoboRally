using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboRally.Core.Tests
{
    [TestClass]
    public class DirectionHelperTest
    {
        [TestMethod]
        public void GetRotatedDirectionTest()
        {
			Assert.AreEqual(OrientationDirection.Right, DirectionHelper.GetRotatedDirection(OrientationDirection.Down, RotateDirection.Left));
			Assert.AreEqual(OrientationDirection.Up, DirectionHelper.GetRotatedDirection(OrientationDirection.Right, RotateDirection.Left));
			Assert.AreEqual(OrientationDirection.Left, DirectionHelper.GetRotatedDirection(OrientationDirection.Up, RotateDirection.Left));
			Assert.AreEqual(OrientationDirection.Down, DirectionHelper.GetRotatedDirection(OrientationDirection.Left, RotateDirection.Left));

			Assert.AreEqual(OrientationDirection.Left, DirectionHelper.GetRotatedDirection(OrientationDirection.Down, RotateDirection.Right));
			Assert.AreEqual(OrientationDirection.Down, DirectionHelper.GetRotatedDirection(OrientationDirection.Right, RotateDirection.Right));
			Assert.AreEqual(OrientationDirection.Right, DirectionHelper.GetRotatedDirection(OrientationDirection.Up, RotateDirection.Right));
			Assert.AreEqual(OrientationDirection.Up, DirectionHelper.GetRotatedDirection(OrientationDirection.Left, RotateDirection.Right));
		}

		[TestMethod]
		public void GetRotationDirectionTest() {
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(OrientationDirection.Up, OrientationDirection.Right));
			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(OrientationDirection.Up, OrientationDirection.Left));
			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(OrientationDirection.Up, OrientationDirection.Down));
			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(OrientationDirection.Up, OrientationDirection.Up));

			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(OrientationDirection.Right, OrientationDirection.Right));
			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(OrientationDirection.Right, OrientationDirection.Left));
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(OrientationDirection.Right, OrientationDirection.Down));
			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(OrientationDirection.Right, OrientationDirection.Up));

			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(OrientationDirection.Down, OrientationDirection.Right));
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(OrientationDirection.Down, OrientationDirection.Left));
			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(OrientationDirection.Down, OrientationDirection.Down));
			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(OrientationDirection.Down, OrientationDirection.Up));

			Assert.AreEqual(RotateDirection.Uturn, DirectionHelper.GetRotationDirection(OrientationDirection.Left, OrientationDirection.Right));
			Assert.AreEqual(RotateDirection.None, DirectionHelper.GetRotationDirection(OrientationDirection.Left, OrientationDirection.Left));
			Assert.AreEqual(RotateDirection.Left, DirectionHelper.GetRotationDirection(OrientationDirection.Left, OrientationDirection.Down));
			Assert.AreEqual(RotateDirection.Right, DirectionHelper.GetRotationDirection(OrientationDirection.Left, OrientationDirection.Up));
		}
    }
}
