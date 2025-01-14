using System.Xml.Linq;

namespace Domain.Aggregates.CategoryAggregate.Entities
{
    public class FilterGroup : BaseEntity
    {
        public string Name { get; private set; }
        public Guid IdSubcategory { get; private set; }

        private readonly List<FilterValue> _values = new List<FilterValue>();
        public IReadOnlyCollection<FilterValue> Values => _values.AsReadOnly();

        public FilterGroup() { }

        public FilterGroup(string name, Guid subIdCategory)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "FilterGroup name cannot be null or empty or with spaces.");

            Name = name;
            IdSubcategory = subIdCategory;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentNullException(nameof(newName), "FilterGroup name cannot be null or empty or with spaces.");

            Name = newName;
        }

        public void AddFilterValue(FilterValue filterValue)
        {
            if (filterValue == null)
                throw new ArgumentNullException(nameof(filterValue), "Filter cannot be null.");

            if (_values.Any(f => f.Id == filterValue.Id))
                throw new InvalidOperationException("Filter is already associated with this subcategory.");

            _values.Add(filterValue);
        }

        public void RemoveFilter(FilterValue filterValue)
        {
            if (filterValue == null)
                throw new ArgumentNullException(nameof(filterValue), "Filter cannot be null.");

            if (!_values.Remove(filterValue))
                throw new InvalidOperationException("Filter does not exist in this subcategory.");
        }
    }
}
