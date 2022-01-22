using Clause.Types;

namespace Clause.Handlers
{
    public class DependencyChecker
    {
        public Dependency? dep { get; set; }

        public DependencyChecker(Dependency dependency)
        {
            this.dep = dependency;
        }

        public bool CheckDependency()
        {
            if(this.dep is not null)
            {
                foreach(string dir in Directory.GetDirectories("C:/Program Files/"))
                {
                    if(this.dep.FileName.ToLower() == dir.ToLower())
                    {
                        return true;
                    }
                    else 
                    {
                        continue;
                    }
                }
            }

            return false;
        }
    }
}