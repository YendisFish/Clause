namespace Clause.Types
{
    public class Dependency
    {
        public string ScriptLine { get; set; }
        public string FileName { get; set; }

        public Dependency(string line, string name)
        {
            this.FileName = name;
            this.ScriptLine = line;
        }

        public static Dependency? ParseDependencyFromLine(string line)
        {
            if(line.StartsWith("//"))
            {
                Dependency dep = new(line, line.Replace("//", ""));
                return dep;
            }

            return null;
        }
    }
}