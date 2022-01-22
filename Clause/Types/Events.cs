namespace Clause.Types
{
    public class EventHandler
    {
        public static void OutputExecutor(Output output)
        {
            Console.WriteLine(output);
        }

        public static void OnOutput(string outputPortion)
        {
            Output toOut = Output.ParseOutput(outputPortion);
            OutputExecutor(toOut);
        }
    }
}