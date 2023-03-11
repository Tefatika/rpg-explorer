namespace RPGExplorer.Interfaces
{
    interface ITaker
    {
        void Take(Entity entity);
        void Put(Entity entity, Entity target);
        void Drop(Entity entity);
    }
}