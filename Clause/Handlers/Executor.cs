using Clause.Types;
using System.Diagnostics;

namespace Clause.Handlers
{
    public class Executor
    {
        public Dependency File { get; set; }

        public Executor(Dependency dep) 
        {   
            this.File = dep;
        }

        public Process? ExecuteFile()
        {
            ProcessStartInfo inf = new();
            inf.FileName = this.File.FileName;
            inf.Arguments = ParseLineToArgs();

            Process? proc = Process.Start(inf);

            return proc;
        }

        public string ParseLineToArgs()
        {
            string toparse = this.File.ScriptLine;
            toparse.Replace("//" + this.File.FileName, "");
            
            return toparse;
        }
    }
}