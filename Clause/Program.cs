using Clause.Types.Records;
using Clause.Handlers;
namespace Clause.Main
{
    class EntryPoint
    {
        public static void Main(params string[] args)
        {
            TakeAway(args).GetAwaiter().GetResult();
        }

        public static async Task TakeAway(string[] args)
        {
            if(args.Length == 1)
            {
                if(args[0].Contains(".clause"))
                {
                    Reader rdr = await Reader.ReadFromStart(args[0]);
                    
                } else 
                {
                    new CException(new List<object> { "No Clause file found", "File: " + args[0] }).Throw();
                }
            }
        }
    }
}
