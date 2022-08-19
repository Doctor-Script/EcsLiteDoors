using Leopotam.EcsLite;

namespace EcsLiteDoors
{
    public static class EcsUtils
    {
        public static ref T GetOrAdd<T>(this EcsPool<T> pool, int entity) where T : struct
        {
            if (pool.Has(entity)) {
                return ref pool.Get(entity);
            }

            return ref pool.Add(entity);
        }
    }
}
