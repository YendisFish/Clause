using Clause.Types;
using System.Diagnostics;

namespace Clause.Handlers
{
    public class Executor
    {
        public Dependency File { get; set; }
        public string Line { get; set; }

        public Executor(Dependency dep, string line) 
        {   
            this.File = dep;
            this.Line = line;
        }

        public async Task<Process?> ExecuteFile()
        {
            ProcessStartInfo inf = new();
            inf.FileName = this.File.FileName;
            Console.WriteLine(ParseLineToArgs());
            inf.Arguments = ParseLineToArgs();

            Process? proc = Process.Start(inf);

            return proc;
        }

        public string ParseLineToArgs()
        {
            string toparse = this.Line;
            string ret = toparse.Replace("COMMAND//" + this.File.FileName, "");
            
            return ret;
        }
    }
}