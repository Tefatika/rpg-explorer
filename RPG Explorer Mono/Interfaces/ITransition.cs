namespace RPGExplorer.Interfaces
{
    interface ITransition
    {
        Entity Destination { get; }
        bool CanGo(Entity entity, IPerceptor perceptor = null);
    }
}