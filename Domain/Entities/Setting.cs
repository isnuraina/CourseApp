using Domain.Common;

namespace Domain.Entities
{
    public class Setting:BaseEntity
    {
        public int EducationPageTake { get; set; }
        public int GroupPageTake { get; set; }
    }
}
