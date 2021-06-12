using System.IO;
using HoodedCrow.uCore.Core;
using NUnit.Framework;
using UnityEngine;

public class TextFilesManagerTests
{
    [Test]
    public void _0_LoadTestFilesManagerFromResources_()
    {
        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        Assert.NotNull(filesManager);
    }

    [Test]
    public void _1_CreateFile_()
    {
        string fileName = "create.test";
        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        filesManager.Create(fileName);

        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [Test]
    public void _2_DeleteFile_()
    {
        string fileName = "delete.test";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);
        File.CreateText(path);

        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        filesManager.Delete(fileName);

        Assert.IsFalse(File.Exists(path));
    }

    [Test]
    public void _3_WriteToNewFile_()
    {
        string fileName = "write.test";
        string content = "2";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);

        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        filesManager.Write(fileName, content);

        string fileContent = File.ReadAllText(path);
        File.Delete(path);
        Assert.IsTrue(fileContent.Equals($"{content}\n"));
    }

    [Test]
    public void _4_WriteToExistingFile_()
    {
        string fileName = "write2.test";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);

        StreamWriter streamWriter = File.CreateText(path);
        streamWriter.WriteLine("1");
        streamWriter.Close();


        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        filesManager.Write(fileName, "2");

        string fileContent = File.ReadAllText(path);
        File.Delete(path);
        Assert.IsTrue(fileContent.Equals("1\n2\n"));
    }

    [Test]
    public void _5_OverwriteToNewFile_()
    {
        string fileName = "write3.test";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);

        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        filesManager.Overwrite(fileName, "foo");

        string fileContent = File.ReadAllText(path);
        File.Delete(path);
        Assert.IsTrue(fileContent.Equals("foo"));
    }

    [Test]
    public void _6_OverwriteExistingFile_()
    {
        string fileName = "write4.test";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);

        StreamWriter streamWriter = File.CreateText(path);
        streamWriter.WriteLine("1");
        streamWriter.Close();

        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        filesManager.Overwrite(fileName, "foo");

        string fileContent = File.ReadAllText(path);
        File.Delete(path);
        Assert.IsTrue(fileContent.Equals("foo"));
    }

    [Test]
    public void _7_ReadFile_()
    {
        string fileName = "read.test";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);

        StreamWriter streamWriter = File.CreateText(path);
        streamWriter.Write("foo");
        streamWriter.Close();

        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        string fileContent = filesManager.Read(fileName);
        File.Delete(path);
        Assert.IsTrue(fileContent.Equals("foo"));
    }

    [Test]
    public void _8_ReadLinesFromFile_()
    {

        string fileName = "read.test";
        string path = Application.persistentDataPath;
        path = Path.Combine(path, "test");
        path = Path.Combine(path, fileName);

        StreamWriter streamWriter = File.CreateText(path);
        streamWriter.WriteLine("foo");
        streamWriter.WriteLine("foo");
        streamWriter.Close();

        TextFilesManager filesManager = Resources.Load<TextFilesManager>("Test Text Files Manager");
        string[] lines = filesManager.ReadLines(fileName);
        File.Delete(path);
        if (lines.Length != 2)
        {
            Assert.Fail();
        }

        if (lines[0] != lines[1])
        {
            Assert.Fail();
        }

        Assert.IsTrue(lines[0] == "foo");
    }
}
