namespace RedPanda.ObjectPooling
{
    public interface IPooled
    {
        SO_PooledObject PooledObject { get; set; }
        /// <summary>
        /// This method is for setting or resetting values. 
        /// </summary>
        void OnStart();
        /// <summary>
        /// This method is for deactivating the object.
        /// </summary>
        void OnRelease();
    }
}