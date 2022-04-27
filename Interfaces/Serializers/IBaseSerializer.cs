using System.Collections.Generic;

namespace Interfaces.Serializers
{
    public interface IBaseSerializer<T, I>
    {

        void Serialize(IList<T> list);

        IList<T> Deserialize();

    }
}
