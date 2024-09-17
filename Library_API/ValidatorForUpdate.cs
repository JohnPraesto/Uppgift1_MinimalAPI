using FluentValidation;
using Library_API.Models;
using Library_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library_API
{
    public class ValidatorForUpdate : AbstractValidator<Book>
    {
        public ValidatorForUpdate()
        {
            RuleFor(book => book.Title).NotEmpty().WithMessage("Book must have a Title.");
            RuleFor(book => book.Author).NotEmpty().WithMessage("Book must have an Author.");
        }
    }
}
