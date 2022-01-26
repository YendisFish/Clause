namespace Clause.Types
{
    public class Output
    {
        public string OutputValue { get; set; }

        public Output(string value)
        {
            this.OutputValue = value;
        }

        public static Output ParseOutput(string value)
        {
            if(value.Contains("OUTPUT//"))
            {
                string x = value.Replace("OUTPUT//", "");
                Output ret = new(x);
                return ret;
            }

            return new Output("EMPTY");
        }

        public async Task OutToConsole() 
        {
            Console.WriteLine(this.OutputValue); 
        }
    }
}