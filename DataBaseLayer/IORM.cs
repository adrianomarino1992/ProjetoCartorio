using System;

namespace DataBaseLayer
{
    public interface IORM
    {
        bool Error { get; set; }
        string Message { get; set; }
        bool CreateTable<T>();

        bool UpdateTable<T>();

        bool Save<T>(T obj);

        bool Edit<T>(T obj);

        bool Remove<T>(T obj);

        bool Add<T>(T obj);

        O Search<T,O>(object Id);


    }
}
