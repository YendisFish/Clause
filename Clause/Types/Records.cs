namespace Clause.Types.Records
{
    public record CException(List<object> ErrorData)
    {
        public void Throw()
        {
            Console.WriteLine("Program threw exception:" + ErrorData[0]);
            Console.WriteLine("Extra data:");

            for(int x = 1; x < ErrorData.Count(); x++)
            {
                Console.WriteLine(ErrorData[x]);
            }
        }
    }
}