using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LSystem;

namespace LSystemTesting
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void TestForward()
        {
            var p = new Point(10, 10);
            var r1 = Helper.Forward(p, 90, 10);
            Debug.WriteLine("X: {0}, Y: {1}", r1.X, r1.Y);
            Assert.AreEqual(new Point(10, 20), r1);

            var r2 = Helper.Forward(p, 180, 10);
            Debug.WriteLine("X: {0}, Y: {1}", r2.X, r2.Y);

            Assert.AreEqual(new Point(0,10),r2);

            var r3 = Helper.Forward(p, 45, 10);
            Debug.WriteLine("X: {0}, Y: {1}", r3.X, r3.Y);

            Assert.AreEqual(new Point(17,17),r3);
        }

        [TestMethod]
        public void TestGenerator()
        {
            var s = new LSystem.LSystem { Axiom = "A", Iterations = 1, Theta = 60.0 };
            s.GeneratePattern();

            Assert.AreEqual("B-A-B", s.Pattern);


            s.Iterations = 2;
            s.GeneratePattern();

            Assert.AreEqual("A+B+A-B-A-B-A+B+A",s.Pattern);
        }
    }
}
