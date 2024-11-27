namespace Domain.Aggregates.CategoryAggregate.Entities
{
    public class Subcategory : BaseEntity
    {
        public string Name { get; private set; }
        public Guid IdCategory { get; private set; }
        
        private readonly List<FilterGroup> _filtersGroups = new List<FilterGroup>();
        public IReadOnlyCollection<FilterGroup> FiltersGroups => _filtersGroups.AsReadOnly();

        public Subcategory(string name, Guid idCategory)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");

            Name = name;
            IdCategory = idCategory;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentNullException(nameof(newName), "Name cannot be null or empty.");

            Name = newName;
        }

        public void AddFilterGroup(string filterGroupName)
        {
            if (string.IsNullOrWhiteSpace(filterGroupName))
                throw new ArgumentNullException(nameof(filterGroupName), "FilterGroupName cannot be null or empty.");

            if (_filtersGroups.Any(f => f.Name == filterGroupName))
                throw new InvalidOperationException("FilterGroup is already associated with this subcategory.");

            _filtersGroups.Add(new FilterGroup(filterGroupName, this.Id));
        }

        public void RemoveFilterGroup(string filterGroupName)
        {
            if (string.IsNullOrWhiteSpace(filterGroupName))
                throw new ArgumentNullException(nameof(filterGroupName), "FilterGroupName cannot be null or empty.");

            var filterGroup = _filtersGroups.Find(f => f.Name == filterGroupName);
            if(filterGroup is not null)
                if (!_filtersGroups.Remove(filterGroup))
                    throw new InvalidOperationException("FilterGroup does not exist in this subcategory.");
        }
    }
}
