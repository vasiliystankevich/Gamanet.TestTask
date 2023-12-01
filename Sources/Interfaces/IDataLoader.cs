using Gamanet.TestTask.Wpf.Logic;
using System.Collections.Generic;
using System.IO;

namespace Gamanet.TestTask.Wpf.Interfaces
{
    public interface IDataLoader
    {
        IEnumerable<Person> Load(StreamReader reader);
    }
}
