using FluentValidation;

namespace Service.DTOs.Education
{
    public class EducationEditDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class EducationEditDtoValidator : AbstractValidator<EducationEditDto>
    {
        public EducationEditDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Education name is required").MaximumLength(100);
        }
    }
}
