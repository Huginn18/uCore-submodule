using System.Collections;
using System.Collections.Generic;
using HoodedCrow.uCore.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TransformExtensionsTests
{
    public class _0_Get_Children_
    {
        [UnityTest]
        public IEnumerator _0_GetChildrenFromGoWithNoChildren_()
        {
            GameObject gameObject = new GameObject();
            List<Transform> children = gameObject.transform.GetChildren();
            yield return null;

            Assert.AreEqual(0, children.Count);
        }


        [UnityTest]
        public IEnumerator _1_GetChildrenFromGoWith1Children_()
        {
            GameObject gameObject = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(gameObject.transform);

            List<Transform> children = gameObject.transform.GetChildren();
            yield return null;

            Assert.AreEqual(1, children.Count);
        }
    }

    public class _1_FindParentWithComponent_
    {
        [UnityTest]
        public IEnumerator _0_GetComponentFromParentWithoutIt_()
        {
            GameObject gameObject = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(gameObject.transform);

            Assert.Throws<NoParentsWithComponentException>(() => child.transform.FindParentWithComponent<Image>());
            yield return null;
        }

        [UnityTest]
        public IEnumerator _1_GetComponentFromParent_()
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<Image>();
            GameObject child = new GameObject();
            child.transform.SetParent(gameObject.transform);

            yield return null;
            var component = child.transform.FindParentWithComponent<Image>();

            Assert.AreSame(gameObject, component.gameObject);
        }

        [UnityTest]
        public IEnumerator _2_GetComponentFromNestedParent_()
        {
            GameObject root = new GameObject();
            GameObject nested = new GameObject();
            nested.transform.SetParent(root.transform);
            nested.AddComponent<Image>();
            GameObject child = new GameObject();
            child.transform.SetParent(nested.transform);

            yield return null;
            var component = child.transform.FindParentWithComponent<Image>();
            Assert.AreSame(nested, component.gameObject);
        }

        [UnityTest]
        public IEnumerator _3_GetComponentFromNestedRootParent_()
        {
            GameObject root = new GameObject();
            root.AddComponent<Image>();
            GameObject nested = new GameObject();
            nested.transform.SetParent(root.transform);
            GameObject child = new GameObject();
            child.transform.SetParent(nested.transform);

            yield return null;
            var component = child.transform.FindParentWithComponent<Image>();
            Assert.AreSame(root, component.gameObject);
        }
    }

    public class _2_FindChildWithComponent_
    {
        [UnityTest]
        public IEnumerator _0_FindChildWithComponentOnObjectWithNoChildren_()
        {
            GameObject parent = new GameObject();

            yield return null;
            Assert.Throws<NoChildrenWithComponentException>(() => parent.transform.FindChildWithComponent<Image>());
        }

        [UnityTest]
        public IEnumerator _1_FindChildWithComponentOnObjectWithOneChild_()
        {
            GameObject parent = new GameObject();
            GameObject child = new GameObject();
            child.AddComponent<Image>();
            child.transform.SetParent(parent.transform);

            yield return null;
            var component = parent.transform.FindChildWithComponent<Image>();
            Assert.AreSame(child, component.gameObject);
        }

        [UnityTest]
        public IEnumerator _2_FindChildWithComponentOnObjectWithTwoChildren_()
        {
            GameObject parent = new GameObject();
            GameObject child1 = new GameObject();
            GameObject child2 = new GameObject();

            child1.transform.SetParent(parent.transform);
            child2.transform.SetParent(parent.transform);
            child2.AddComponent<Image>();

            yield return null;
            var component = parent.transform.FindChildWithComponent<Image>();
            Assert.AreSame(child2, component.gameObject);
        }
    }

    public class _3_FindChildrenWithComponent_
    {
        [UnityTest]
        public IEnumerator _0_FindChildrenWithComponentOnObjectWithNoChildren_()
        {
            GameObject gameObject = new GameObject();
            yield return null;
            Assert.Throws<NoChildrenWithComponentException>(() => gameObject.transform.FindChildrenWithComponent<Image>());
        }

        [UnityTest]
        public IEnumerator _1_FindChildrenWithComponentOnObjectWithNoCorrectChildren_()
        {
            GameObject parent = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(parent.transform);

            yield return null;
            Assert.Throws<NoChildrenWithComponentException>(() => parent.transform.FindChildrenWithComponent<Image>());
        }

        [UnityTest]
        public IEnumerator _2_FindChildrenWithComponentOnObjectWithOneCorrectChild_()
        {
            GameObject parent = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(parent.transform);
            child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Image>();

            yield return null;
            List<Image> children = parent.transform.FindChildrenWithComponent<Image>();
            Assert.AreEqual(1, children.Count);
        }

        [UnityTest]
        public IEnumerator _3_FindChildrenWithComponentOnObjectWithTwoCorrectChildren_()
        {
            GameObject parent = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Image>();
            child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Image>();

            yield return null;
            List<Image> children = parent.transform.FindChildrenWithComponent<Image>();
            Assert.AreEqual(2, children.Count);
        }

        [UnityTest]
        public IEnumerator _4_FindChildrenWithComponentOnObjectWithTwoCorrectChildrenAndOneWrong_()
        {
            GameObject parent = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Image>();
            child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Image>();
            child = new GameObject();
            child.transform.SetParent(parent.transform);

            yield return null;
            List<Image> children = parent.transform.FindChildrenWithComponent<Image>();
            Assert.AreEqual(2, children.Count);
        }
    }

    public class _4_DestroyChildren_
    {
        [UnityTest]
        public IEnumerator _0_DestroyChildrenOffObjectWithoutChildren_()
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.DestroyChildren();

            yield return null;
            Assert.AreEqual(0, gameObject.transform.childCount);
        }

        [UnityTest]
        public IEnumerator _1_DestroyChildrenOffObjectWithOneChild_()
        {
            GameObject parent = new GameObject();
            GameObject child = new GameObject();
            child.transform.SetParent(parent.transform);
            Assert.AreEqual(1, parent.transform.childCount);

            yield return null;
            parent.transform.DestroyChildren();
            Assert.AreEqual(0, parent.transform.childCount);
        }

        [UnityTest]
        public IEnumerator _2_DestroyChildrenOffObjectWithThreeChild_()
        {
            GameObject parent = new GameObject();
            for(int i = 0; i <3; i++)
            {
                GameObject child = new GameObject();
                child.transform.SetParent(parent.transform);
            }
            Assert.AreEqual(3, parent.transform.childCount);

            yield return null;
            parent.transform.DestroyChildren();
            Assert.AreEqual(0, parent.transform.childCount);
        }
    }
}
