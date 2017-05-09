namespace PCMarket.Common.APIs
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Extensions;

    internal class AccessabilityWorker
    {
        private readonly PublicApisAccessability accessTokens;
        private IDictionary<string, string> fieldsByName;

        public AccessabilityWorker()
        {
            this.accessTokens = new PublicApisAccessability();
        }

        public string GetPairedTypeParameter(string key)
        {
            if (this.fieldsByName == null)
            {
                this.fieldsByName =
                    new ConcurrentDictionary<string, string>(this.GetStringFieldValues());
            }

            var searchedKey = this.GetSuitableName(key);
            return this.fieldsByName[searchedKey];
        }

        private string GetSuitableName(string key)
        {
            var wordsOfTypename = key.GetSplittedPascalCaseWords();
            var searchedKey = string.Empty;
            var meetCount = 0;
            foreach (var fieldName in this.fieldsByName.Keys)
            {
                int innerCounter = 0;
                var wordsOfFieldname = new SortedSet<string>(
                    fieldName.GetSplittedPascalCaseWords());
                foreach (var typenameWord in wordsOfTypename)
                {
                    var foundWord = string.Empty;
                    foreach (var fieldnameWord in wordsOfFieldname)
                    {
                        if (string.Compare(typenameWord, fieldnameWord, StringComparison.CurrentCultureIgnoreCase) == 0)
                        {
                            foundWord = fieldnameWord;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(foundWord))
                    {
                        wordsOfFieldname.Remove(foundWord);
                        innerCounter++;
                    }
                }

                if (innerCounter > meetCount)
                {
                    meetCount = innerCounter;
                    searchedKey = fieldName;
                }
            }

            return searchedKey;
        }

        private IDictionary<string, string> GetStringFieldValues()
        {
            var fields = accessTokens.GetType()
                .GetTypeInfo()
                .DeclaredFields
                .Where(df => df.FieldType.Name == "String")
                .Select(fieldInfo => new
                    {
                        fieldInfo.Name,
                        Value = (string)fieldInfo.GetValue(accessTokens)
                    })
                .ToDictionary(name => name.Name, value => value.Value);
            return fields;
        }
    }
}