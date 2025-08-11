using Domain.Common;
namespace Domain.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }

    }
}
