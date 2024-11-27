namespace Domain.Aggregates.CategoryAggregate.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        private readonly List<Subcategory> _subcategories = new List<Subcategory>();
        public IReadOnlyCollection<Subcategory> Subcategories => _subcategories.AsReadOnly();

        public Category(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Category name cannot be null or empty.");

            Name = name;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException(nameof(newName), "Category name cannot be null or empty.");

            Name = newName;
        }

        public void AddSubcategory(string nameSubcategory)
        {
            if (string.IsNullOrEmpty(nameSubcategory))
                throw new ArgumentNullException(nameof(nameSubcategory), "Category name cannot be null or empty.");

            if (_subcategories.Any(sc => sc.Name == nameSubcategory))
                throw new InvalidOperationException("Subcategory is already associated with this category.");

            _subcategories.Add(new Subcategory(nameSubcategory, this.Id));
        }

        public void RemoveSubcategory(string nameSubcategory)
        {
            if (string.IsNullOrEmpty(nameSubcategory))
                throw new ArgumentNullException(nameof(nameSubcategory), "Category name cannot be null or empty.");

            var sub = _subcategories.Find(sc => sc.Name == nameSubcategory);
            if (sub != null)
                if (!_subcategories.Remove(sub))
                    throw new InvalidOperationException("Subcategory does not exist in this category.");
        }

        public bool ContainsSubcategory(Guid subIdCategory)
        {
            return _subcategories.Any(sc => sc.Id == subIdCategory);
        }
    }
}
