namespace RPGExplorer.Interfaces
{
    interface IHitter
    {
        void Hit(Entity target, Entity means = null);
    }
}