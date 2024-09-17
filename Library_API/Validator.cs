using FluentValidation;
using Library_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library_API
{
    public class Validator : AbstractValidator<CreatedAndUpdatedBookDTO>
    {
        public Validator()
        {
            RuleFor(book => book.Title).NotEmpty().WithMessage("Book must have a Title.");
            RuleFor(book => book.Author).NotEmpty().WithMessage("Book must have an Author.");
        }
    }
}
