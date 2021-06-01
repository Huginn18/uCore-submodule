namespace Scripts.Utils.Tests
{
    using HoodedCrow.uCore.Utils;
    using NUnit.Framework;
    using UnityEngine;

    public class ColorExtensionsTests
    {
        public class _SetRed_
        {
            [Test]
            public void _SetRedFrom0To1_()
            {
                Color color = Color.clear;
                color = color.SetRed(1);
                Assert.AreEqual(1, color.r);
            }

            [Test]
            public void _SetRedFrom1To025_()
            {
                Color color = Color.red;
                color = color.SetRed(0.25f);
                Assert.AreEqual(0.25f, color.r);
            }
        }

        public class _SetBlue_
        {
            [Test]
            public void _SetBlueFrom0To1_()
            {
                Color color = Color.clear;
                color = color.SetBlue(1);
                Assert.AreEqual(1, color.b);
            }

            [Test]
            public void _SetBlueFrom1To025_()
            {
                Color color = Color.blue;
                color = color.SetBlue(0.25f);
                Assert.AreEqual(0.25f, color.b);
            }
        }

        public class _SetGreen_
        {
            [Test]
            public void _SetGreenFrom0To1_()
            {
                Color color = Color.clear;
                color = color.SetGreen(1);
                Assert.AreEqual(1, color.g);
            }

            [Test]
            public void _SetGreenFrom1To025_()
            {
                Color color = Color.green;
                color = color.SetGreen(0.25f);
                Assert.AreEqual(0.25f, color.g);
            }
        }
    }
}
