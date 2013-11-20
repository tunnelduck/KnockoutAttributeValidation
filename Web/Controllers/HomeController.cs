using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KnockoutAttributeValidation;
using StructureMap;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new PersonDetailsModel()
                {
                    Address = new Address()
                };

            var validationModel = ObjectFactory.GetInstance<AttributeValidationModelBuilder>().GetValidation(model.GetType());

            return View(new ModelValidation() { Model = model, ValidationModel = validationModel });
        }

        
    }

    public class ModelValidation
    {
        public object Model { get; set; }

        public object ValidationModel { get; set; }
    }

    public class PersonDetailsModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string EmailAddress { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("EmailAddress", ErrorMessage = "Emails must match")]
        public string ConfirmEmailAddress { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        [Required(ErrorMessage = "Address is required")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Address must be at least 3 characters and no more than 10")]
        public string Address1 { get; set; }
    }
}
