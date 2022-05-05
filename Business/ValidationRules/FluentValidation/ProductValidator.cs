using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(f => f.ProductName).NotEmpty();
            RuleFor(f=>f.ProductName).MinimumLength(2);
            RuleFor(f => f.UnitPrice).NotEmpty();
            RuleFor(f => f.UnitPrice).GreaterThan(0);
            RuleFor(f => f.UnitPrice).GreaterThanOrEqualTo(10).When(f => f.CategoryId == 1);
            RuleFor(f => f.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
