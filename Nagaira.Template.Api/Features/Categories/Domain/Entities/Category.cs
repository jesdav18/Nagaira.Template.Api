namespace Nagaira.Template.Api.Features.Categories.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateModification { get; set; }
        public string? UserRegister { get; set; }
        public string? UserModification { get; set; }
    }
}
