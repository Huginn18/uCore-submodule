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
    }
}
