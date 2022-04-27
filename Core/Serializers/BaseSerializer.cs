using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Interfaces.Serializers;

namespace Core.Serializers
{
    public abstract class BaseSerializer<T, I> : IBaseSerializer<T, I>
    {
        protected abstract string Path { get; }

        public IList<T> Deserialize()
        {
            if (File.Exists(Path))
            {
                var json = File.ReadAllText(Path);
                var list = JsonSerializer.Deserialize<List<I>>(json);
                return list.Cast<T>().ToList();
            }

            return new List<T>();
        }

        public void Serialize(IList<T> list)
        {
            var listToSerialize = list.Cast<I>().ToList();
            var json = JsonSerializer.Serialize(listToSerialize);
            File.WriteAllText(Path, json);
        }
    }
}
