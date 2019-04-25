namespace SIS.MvcFramework.Services
{
    public interface IServiceCollection
    {
        void AddService<TSource, TDestination>();

        T CreateInstance<T>();
    }
}


