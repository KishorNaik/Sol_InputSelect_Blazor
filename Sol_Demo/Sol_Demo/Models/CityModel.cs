using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models
{
    public class CityModel
    {
        [CitySelectValidation]
        public int Id { get; set; }

        public String Name { get; set; }
    }

    public class CitySelectValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validateResult = null;
            int valueObj = (int)value;

            if (valueObj == 0)
            {
                validateResult = new ValidationResult("Please Select the City", new[] { validationContext.MemberName });
            }
            else
            {
                validateResult = ValidationResult.Success;
            }

            return validateResult;
        }
    }
}