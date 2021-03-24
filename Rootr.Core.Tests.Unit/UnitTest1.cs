using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Rootr.Core.Directory;
using Rootr.Core.Extensions;

namespace Rootr.Core.Tests.Unit
{
    public class Tests
    {
        private bool DeleteFiles = false;

        [SetUp]
        public void Setup()
        {
            var dirCrud = new DirectoryCrudBase();
        }

        [Test]
        public void CleanBinFoldersFromDir()
        {
            var dirCrud = new DirectoryCrudBase();
            var basePath = @"C:\Users\ireap\source\repos";

            var directories = basePath
                .AsDirectoryInfo()
                .GetDirectories()
                .ToList();

            var badFolders = new List<DirectoryInfo>();
            directories.ForEach((d) =>
            {
                badFolders.AddRange(d.GetDirectories("", SearchOption.AllDirectories));
            });
            var alldirs = Path.Combine(basePath, "output_alldirs.txt");

            File.WriteAllText(alldirs, string.Join(Environment.NewLine, badFolders.Select(e => e.FullName)));
            File.AppendAllText(alldirs, $"\r\n{badFolders.Count}");

            badFolders = badFolders.Where(e =>
                e.FullName.EndsWith("bin", StringComparison.OrdinalIgnoreCase) ||
                e.FullName.EndsWith("obj", StringComparison.OrdinalIgnoreCase) ||
                e.FullName.EndsWith(".vs", StringComparison.OrdinalIgnoreCase))
            .ToList();

            var contents = string.Join(Environment.NewLine, badFolders.Select(e => e.FullName));
            var outputPath = Path.Combine(basePath, "output_targetdirs.txt");
            File.WriteAllText(outputPath, string.Join(Environment.NewLine, badFolders.Select(e => e.FullName)));
            File.AppendAllText(outputPath, $"\r\n{badFolders.Count}");

            if (DeleteFiles)
                badFolders.ForEach((d) =>
                {
                    try
                    {
                        d.Delete(true);
                    }
                    catch (Exception e)
                    {
                        File.AppendAllText(alldirs, $"Dir: {d.FullName}\r\n\r\n{e.Message}\r\n\r\n{e}");
                    }
                });
        }
    }
}