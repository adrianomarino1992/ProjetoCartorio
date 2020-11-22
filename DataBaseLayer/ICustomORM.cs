using System;

namespace DataBaseLayer
{
    public interface ICustomORM
    {
        bool CreateTable<T>();

        bool UpdateTable<T>();

        bool Save<T>(T obj);

        bool Edit<T>(T obj);

        bool Remove<T>(object Id);

        bool Add<T>(T obj);

        T Search<T>(object Id);


    }
}
