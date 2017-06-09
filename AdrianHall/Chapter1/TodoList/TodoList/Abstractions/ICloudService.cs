using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Abstractions
{
    public interface ICloudService
    {
        ICloudTable<T> GetTable<T>() where T : TableData;
    }
}
