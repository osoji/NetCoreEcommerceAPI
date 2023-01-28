namespace NetCoreAPI.Entities
{
    public partial class Category
    {
        public int CategoryId { get; set; }

        public int? ParentId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public string CategorySlug { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> ChildrenCategories { get; set; } = new List<Category>();
    }
}

