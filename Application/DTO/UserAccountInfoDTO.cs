using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserAccountInfoDTO : IRequest<Result>
    {
        public Guid Id { get; set; }
        public DateOnly DateCreated { get; }
        public string Sex { get; set; }
        public string Alias { get; set; }
    }
}
