using Clause.Types.LanguageTypes;
using Clause.Types;
using System.Diagnostics;

namespace Clause.Handlers 
{
    public class Reader
    {
        public string Path { get; set; }
        
        public Reader(string path)
        {
            this.Path = path;
        }

        public List<string> GetDependencies() 
        {
            List<string> ret = new();
            string[] script = File.ReadAllLines(this.Path);

            foreach(string value in script)
            {
                if(value.StartsWith("//"))
                {
                    string dependency = value.Replace("//", "").Trim();
                    ret.Add(dependency);
                }
            }

            return ret;
        }

        public List<string> OrderedCommands()
        {
            List<string> ret = new();
            string[] script = File.ReadAllLines(this.Path);

            foreach(string value in script)
            {
                if(value.StartsWith("COMMAND//"))
                {
                    string command = value.Replace("COMMAND//", "").Trim();
                    ret.Add(command);
                }
            }

            return ret;
        }

        public List<string> OrderedOutput()
        {
            List<string> ret = new();
            string[] script = File.ReadAllLines(this.Path);

            foreach(string value in script)
            {
                if(value.StartsWith("OUTPUT//"))
                {
                    string command = value.Replace("OUTPUT//", "");
                    ret.Add(command);
                }
            }
            return ret;
        }    

        public List<Object> GetVariables()
        {
            List<Object> variables = new();
            string[] script = File.ReadAllLines(this.Path);

            foreach(string value in script)
            {
                if(value.Contains("BOOL"))
                {
                    List<string> splitted = value.Split("//").ToList<string>();

                    Object<bool> boolval = new();
                    boolval.val = Convert.ToBoolean(splitted[2]);
                    boolval.varname = splitted[1].ToString();
                }
            }

            return variables;
        }

        public static string[] ReadFile(string Path)
        {
            return File.ReadAllLines(Path);
        }

        public string[] ReadSelf()
        {
            return File.ReadAllLines(this.Path);
        }

        public static Reader ReadFromStart(string Path)
        {
            Reader ret = new Reader(Path);
            string[] script = File.ReadAllLines(ret.Path);

            List<Dependency> dependencies = new();
            List<string> commands = new();
            List<Object> varibales = new();
            List<Output> outputs = new();
            
            foreach(string value in script)
            {
                if(value.StartsWith("//"))
                {
                    Dependency? dep = Dependency.ParseDependencyFromLine(value);
                    bool ifexists = new DependencyChecker(dep).CheckDependency();

                    if(ifexists) 
                    {
                        dependencies.Add(dep);
                    }
                }

                if(value.StartsWith("COMMAND//"))
                {
                    foreach(Dependency dep in dependencies)
                    {
                        if(value.ToLower().Contains(dep.FileName.ToLower()))
                        {
                            Process? exec = new Executor(dep).ExecuteFile();
                        }
                    }
                }

                if(value.StartsWith("STRING//"))
                {
                    Object<string> str = new();
                    //Implement Logic
                    varibales.Add(str);
                }

                if(value.StartsWith("INT//"))
                {
                    Object<int> num = new();
                    //Implement Logic
                    varibales.Add(num);
                }
                
                if(value.StartsWith("BOOL//"))
                {
                    Object<bool> bol = new();
                    //Implement Logic
                    varibales.Add(bol);
                }

                if(value.StartsWith("OUTPUT//"))
                {
                    Output toOut = Output.ParseOutput(value);
                    toOut.OutToConsole();
                }
            }

            return ret;
        }
    }
}