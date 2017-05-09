namespace PCMarket.Common.APIs
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public static class AccessabilityGetter
    {
        private static readonly IDictionary<string, string> parametersByName;
        private static readonly AccessabilityWorker worker;

        static AccessabilityGetter()
        {
            parametersByName = new ConcurrentDictionary<string, string>();
            worker = new AccessabilityWorker();
        }

        public static string GetAccessParameterByName<T>(string searchedParameter)
            where T : class, new()
        {
            var typeofT = typeof(T);
            var key = $"{typeofT}{searchedParameter}";
            if (!parametersByName.ContainsKey(key))
            {
                parametersByName.Add(key, worker.GetPairedTypeParameter(key));
            }

            return parametersByName[key];
        }
    }
}