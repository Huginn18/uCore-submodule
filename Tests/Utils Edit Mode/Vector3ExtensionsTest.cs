namespace Scripts.Utils.Tests
{
    using HoodedCrow.uCore.Utils;
    using NUnit.Framework;
    using UnityEngine;

    public class Vector3ExtensionsTest
    {
        public class _SetX_
        {
            [Test]
            public void _0_SetXFrom0To1_()
            {
                Vector3 vector3 = Vector3.zero;
                vector3 = vector3.SetX(1);

                Assert.AreEqual(new Vector3(1, 0), vector3);
            }

            [Test]
            public void _1_SetXFrom1To075_()
            {
                Vector3 vector3 = Vector3.right;
                vector3 = vector3.SetX(0.75f);

                Assert.AreEqual(new Vector3(0.75f, 0), vector3);
            }
        }

        public class _SetY_
        {
            [Test]
            public void _0_SetYFrom0To1_()
            {
                Vector3 vector3 = Vector3.zero;
                vector3 = vector3.SetY(1);

                Assert.AreEqual(new Vector3(0, 1), vector3);
            }

            [Test]
            public void _1_SetYFrom1To075_()
            {
                Vector3 vector3 = Vector3.up;
                vector3 = vector3.SetY(0.75f);

                Assert.AreEqual(new Vector3(0, 0.75f), vector3);
            }
        }

        public class _SetZ_
        {
            [Test]
            public void _0_SetZFrom0To1_()
            {
                Vector3 vector3 = Vector3.zero;
                vector3 = vector3.SetZ(1);

                Assert.AreEqual(new Vector3(0, 0, 1), vector3);
            }

            [Test]
            public void _1_SetZFrom1To075_()
            {
                Vector3 vector3 = Vector3.forward;
                vector3 = vector3.SetZ(0.75f);

                Assert.AreEqual(new Vector3(0, 0, 0.75f), vector3);
            }
        }

        public class _SetXYZ_
        {
            [Test]
            public void _0_SetXYZFrom0To1()
            {
                Vector3 vector3 = Vector3.zero;
                vector3 = vector3.SetX(1);
                vector3 = vector3.SetY(1);
                vector3 = vector3.SetZ(1);

                Assert.AreEqual(Vector3.one, vector3);
            }


            [Test]
            public void _1_SetXYZTo07505025()
            {
                Vector3 vector3 = Vector3.zero;
                vector3 = vector3.SetX(0.75f);
                vector3 = vector3.SetY(0.50f);
                vector3 = vector3.SetZ(0.25f);

                Assert.AreEqual(new Vector3(0.75f, 0.50f, 0.25f), vector3);
            }
        }
    }
}
