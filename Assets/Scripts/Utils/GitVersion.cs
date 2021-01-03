using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace Utils
{
    public class GitException : InvalidOperationException
    {
        public GitException(int exitCode, string errors) : base(errors) =>
            ExitCode = exitCode;

        public readonly int ExitCode;
    }

    public static class Git
    {
        public static string BuildVersion => Run(@"describe --tags --long --dirty --match ""v[0-9]*""");
        
        public static string Branch => Run(@"rev-parse --abbrev-ref HEAD");
        public static string Status => Run(@"status --porcelain");

        public static string Hash => Run(@"show-ref --hash");

        private static string Run(string arguments)
        {
            using var process = new Process();
            var exitCode = process.Run(@"git", arguments, Application.dataPath,
                out var output, out var errors);
            if (exitCode == 0)
                return output;
            throw new GitException(exitCode, errors);
        }
    }

    public static class ProcessExtensions
    {
        public static int Run(this Process process, string application,
            string arguments, string workingDirectory, out string output,
            out string errors)
        {
            process.StartInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                FileName = application,
                Arguments = arguments,
                WorkingDirectory = workingDirectory
            };

            var outputBuilder = new StringBuilder();
            var errorsBuilder = new StringBuilder();
            process.OutputDataReceived += (_, args) => outputBuilder.AppendLine(args.Data);
            process.ErrorDataReceived += (_, args) => errorsBuilder.AppendLine(args.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            output = outputBuilder.ToString().TrimEnd();
            errors = errorsBuilder.ToString().TrimEnd();
            return process.ExitCode;
        }
    }
}