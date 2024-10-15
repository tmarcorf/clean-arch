using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validations;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, "product image");

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.9m, 99, "product image");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.9m, 99, "product image");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, mininum 3 characters");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, "product image aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainExceptionImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, null);

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, null);

            action
                .Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainExceptionImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, "");

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.9m, 99, "product image");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, value, "");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }
    }
}
