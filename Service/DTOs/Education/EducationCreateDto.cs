using FluentValidation;

namespace Service.DTOs.Education
{
   public class EducationCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class EducationCreateDtoValidator : AbstractValidator<EducationCreateDto>
    {
        public EducationCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Education name is required").MaximumLength(100); 
        }
    }
}
