namespace Clause.Types.LanguageTypes
{
    public class Object<T>
    {
        public T? val { get; set; }
        public string? varname { get; set; }
        
        public object? GetVal()
        {
            if(typeof(T) == typeof(string))
            {
                string? ret = val?.ToString();
                return ret;
            }

            if(typeof(T) == typeof(int))
            {
                int ret = Convert.ToInt32(this.val);
                return ret;
            }

            if(typeof(T) == typeof(bool))
            {
                bool ret = Convert.ToBoolean(this.val);
                return ret;
            }

            return null;
        }

        public string? ToString()
        {
            if(typeof(T) != typeof(string))
            {
                object? toConvert = this.GetVal();
                return toConvert?.ToString();
            }

            return null;
        }
    }
}