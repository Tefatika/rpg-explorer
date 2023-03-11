using RPGExplorer.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace RPGExplorer
{
    static class ContainerUtils
    {
        public static string GetContentsAsString(IContainer container)
        {
            // String builder
            StringBuilder stringBuilder = new StringBuilder();

            // Container name
            if (container is INamed named)
                stringBuilder.AppendFormat("The {0}", named.Name.ToLower());
            else
                stringBuilder.Append("This container");
            
            if (container.Contents.Count == 0)
                stringBuilder.Append(" is empty.");
            else
            {
                stringBuilder.Append(" currently contains:");

                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                foreach (var content in container.Contents)
                {
                    if (dictionary.ContainsKey(content.Name))
                        ++dictionary[content.Name];
                    else
                        dictionary[content.Name] = 1;
                }

                foreach (var keyValuePairs in dictionary)
                    stringBuilder.AppendFormat("\n{0}x {1}{2}", keyValuePairs.Value, keyValuePairs.Key, keyValuePairs.Value > 1 ? "s" : "");
            }

            // Return string
            return stringBuilder.ToString();
        }
    }
}