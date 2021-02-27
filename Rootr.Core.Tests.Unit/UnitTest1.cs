using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Rootr.Core.Cleaner;
using Rootr.Core.Extensions;

namespace Rootr.Core.Tests.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var dirCrud = new DirectoryCrudBase();
        }

        [Test]
        public void CleanBinFoldersFromDir()
        {
            var dirCrud = new DirectoryCrudBase();
            var basePath = @"E:\All Files\Programs\VB.NET";

            var directories = basePath
                .AsDirectoryInfo()
                .GetDirectories()
                .ToList();

            var badFolders = new List<DirectoryInfo>();
            directories.ForEach((d) =>
            {
                badFolders.AddRange(d.GetDirectories("", SearchOption.AllDirectories));
            });

            badFolders = badFolders.Where(e =>
                e.FullName.EndsWith("bin", StringComparison.OrdinalIgnoreCase) ||
                e.FullName.EndsWith("obj", StringComparison.OrdinalIgnoreCase) ||
                e.FullName.EndsWith(".vs", StringComparison.OrdinalIgnoreCase))
            .ToList();

            var contents = string.Join(Environment.NewLine, badFolders.Select(e => e.FullName));
            var outputPath = Path.Combine(basePath, "output.txt");
            File.WriteAllText(outputPath, string.Join(Environment.NewLine, badFolders.Select(e => e.FullName)));
            badFolders.ForEach((d) => 
            {
                try
                {
                    d.Delete(true);
                }
                catch (Exception e)
                {
                    File.AppendAllText(outputPath, $"Dir: {d.FullName}\r\n\r\n{e.Message}\r\n\r\n{e}");
                }
            });
        }
    }
}