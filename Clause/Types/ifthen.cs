using Clause.Handlers;
using System.Diagnostics;
namespace Clause.Types.LanguageTypes
{
    public class IfThen
    {
        public string? Line { get; set; }

        public IfThen(string? line)
        {
            this.Line = line;
        }

        public async Task ExecuteIf(List<Object<object>> obs)
        {
            List<string> ParsedIf = this.Line.Split(':').ToList<string>();

            if(ParsedIf[0] == "IF")
            {
                if(ParsedIf[2] == "IS")
                {
                    if(ParseArgs(ParsedIf[1], ParsedIf[3], obs))
                    {
                        if(ParsedIf[4].StartsWith("COMMAND//"))
                        {
                            //Add Logic
                            Executor exec = new(Dependency.ParseDependencyFromLine(ParsedIf[4]), this.Line);
                            Process proc = await exec.ExecuteFile();
                        }

                        if(ParsedIf[4].StartsWith("OUTPUT//"))
                        {
                            Output output = Output.ParseOutput(ParsedIf[4]);
                            output.OutToConsole();
                        }
                    }
                }
            }
        }

        public bool ParseArgs(object midArgs, object comp, List<Object<object>> obs)
        {
            foreach(Object<object> va in obs)
            {
                if(midArgs.ToString().Contains(va.varname))
                {
                    if(va == comp)
                    {
                        return true;
                    }
                }
            }

            if(midArgs == comp)
            {
                return true;
            }

            return false;
        }
    }
}