namespace Binder.Task.Factories
{
    public enum ECategory
    {
        Standard,
        None
    }

    public interface ICategoryFactory
    {
        ICategory GetCategory(ECategory categoryType);
    }
}
