﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class FileReadAllTextActivityTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }

        [TestCleanup]
        public void Cleanup()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        [TestMethod]
        public async Task Test___Method_Start___Encoding_null()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            
            File.WriteAllText(path, "bar");

            var contents = new AnyVariable<string>();

            var testee = new FileReadAllTextActivity()
            {
                Path = new AnyVariable<string>() { Value = path },
                Contents = contents
            };

            await testee.Start();

            Assert.AreEqual("bar", contents.GetValue());
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Encoding_UTF8()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            File.WriteAllText(path, "bar");

            var contents = new AnyVariable<string>();

            var testee = new FileReadAllTextActivity()
            {
                Path = new AnyVariable<string>() { Value = path },
                Contents = contents,
                Encoding = new AnyVariable<Encoding>() { Value = Encoding.UTF8 }
            };

            await testee.Start();

            Assert.AreEqual("bar", contents.GetValue());
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
