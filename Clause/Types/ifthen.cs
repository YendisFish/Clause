namespace Clause.Types.LanguageTypes
{
    public class IfThen
    {
        public string? Line { get; set; }

        public IfThen(string? line)
        {
            this.Line = line;
        }

        public void ExecuteIf(List<Object> obs)
        {
            List<string> ParsedIf = this.Line.Split(':').ToList<string>();

            if(ParsedIf[0] == "IF")
            {
                if(ParseArgs(ParsedIf[1], obs))
                {
                    
                }
            }
        }

        public bool ParseArgs(string midArgs, List<Object> obs)
        {
            foreach(Object<object> va in obs)
            {
                if(midArgs.Contains(va.varname))
                {
                    if(midArgs.Contains('<'))
                    {
                        //Add Logic
                    }

                    if(midArgs.Contains('>'))
                    {
                        //Add Logic
                    }

                    if(midArgs.Contains('='))
                    {
                        //Add Logic
                    }
                }
            }

            switch(midArgs)
            {
                
            }
        }
    }
}