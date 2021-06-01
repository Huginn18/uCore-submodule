namespace Scripts.Utils.Tests
{
    using HoodedCrow.uCore.Utils;
    using NUnit.Framework;
    using UnityEngine;

    public class Vector2ExtensionsTest
    {
        public class _SetX_
        {
            [Test]
            public void _0_SetXFrom0To1_()
            {
                Vector2 vector2 = Vector2.zero;
                vector2 = vector2.SetX(1);

                Assert.AreEqual(new Vector2(1, 0), vector2);
            }

            [Test]
            public void _1_SetXFrom1To075_()
            {
                Vector2 vector2 = Vector2.right;
                vector2 = vector2.SetX(0.75f);

                Assert.AreEqual(new Vector2(0.75f, 0), vector2);
            }
        }

        public class _SetY_
        {
            [Test]
            public void _0_SetYFrom0To1_()
            {
                Vector2 vector2 = Vector2.zero;
                vector2 = vector2.SetY(1);

                Assert.AreEqual(new Vector2(0, 1), vector2);
            }

            [Test]
            public void _1_SetYFrom1To075_()
            {
                Vector2 vector2 = Vector2.up;
                vector2 = vector2.SetY(0.75f);

                Assert.AreEqual(new Vector2(0, 0.75f), vector2);
            }
        }

        public class _SetXAndY_
        {
            [Test]
            public void _0_SetXAndYFrom0To1()
            {
                Vector2 vector2 = Vector2.zero;
                vector2 = vector2.SetX(1);
                vector2 = vector2.SetY(1);

                Assert.AreEqual(Vector2.one, vector2);
            }


            [Test]
            public void _0_SetXAndTo075And025()
            {
                Vector2 vector2 = Vector2.zero;
                vector2 = vector2.SetX(0.75f);
                vector2 = vector2.SetY(0.25f);

                Assert.AreEqual(new Vector2(0.75f, 0.25f), vector2);
            }
        }
    }
}
