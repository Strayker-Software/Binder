namespace Binder.Task.Factories
{
    public class CategoryFactory : ICategoryFactory
    {
        public ICategory GetCategory(ECategory categoryType)
        {
            return categoryType switch
            {
                ECategory.Standard => new StandardCategory(),
                _ => null
            };
        }
    }
}
