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
            var model = new PersonDetails()
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

    public class PersonDetails
    {
        [EmailAddress]
        public string EmailAddress { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("EmailAddress")]
        public string ConfirmEmailAddress { get; set; }

        [Required]
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        [StringLength(10, MinimumLength = 3)]
        public string Address1 { get; set; }
    }
}
