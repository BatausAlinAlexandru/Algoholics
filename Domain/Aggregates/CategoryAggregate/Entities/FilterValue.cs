namespace Domain.Aggregates.CategoryAggregate.Entities
{
    public class FilterValue : BaseEntity
    {
        public string Name { get; set; }
        public Guid IdFilterGroup { get; set; }

        public FilterValue() { }
        public FilterValue(string name, Guid idFilterGroup) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Filter name cannot be null or empty.");

            this.Name = name;
            this.IdFilterGroup = idFilterGroup;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException(nameof(newName), "FilterGroup name cannot be null or empty.");

            Name = newName;
        }
    }
}
