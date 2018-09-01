﻿namespace MusicX.Common.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SongAttributes
    {
        private readonly IDictionary<MetadataType, IList<string>> values;

        public SongAttributes()
        {
            this.values = new Dictionary<MetadataType, IList<string>>();
        }

        public string this[MetadataType key]
        {
            get
            {
                if (this.values.ContainsKey(key) && this.values[key].Any())
                {
                    return this.values[key].Last();
                }

                return null;
            }

            set
            {
                if (this.values.ContainsKey(key))
                {
                    this.values[key].Add(value);
                }
                else
                {
                    this.values.Add(key, new List<string> { value });
                }
            }
        }

        public IEnumerable<string> All(MetadataType attribute)
        {
            if (!this.values.ContainsKey(attribute))
            {
                this.values.Add(attribute, new List<string>());
            }

            return this.values[attribute];
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in this.values)
            {
                stringBuilder.Append($"[{item.Key}]=\"{string.Join(",", item.Value)}\"; ");
            }

            return stringBuilder.ToString();
        }
    }
}