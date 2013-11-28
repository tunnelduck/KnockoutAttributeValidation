Knockout Attribute Validation allows for easily adding validation rules to your view model from Data Attributes defined in your server code allowing DRY coding. Its dependencies are Knockout, [Knockout Mapping](http://knockoutjs.com/documentation/plugins-mapping.html), and [Knockout Validation](https://github.com/Knockout-Contrib/Knockout-Validation). 

## Demo

[Demo](http://examples.oxenfur.com/attributevalidation)

## Solution Layout

The solution contains two projects, KnockoutAttributeValidation and Web. KnockoutAttributeValidation is a class library that contains all the backend code to generate the validation model which contains a set of all the rules from your data annotations. Web is a Web Api template that contains a working example of how to use the code. 

## Example

Everything referred to in this section is in the Web project.

Validation model json serialization is done in HomeController.cs. Note, in this example I am using StructureMap but any IoC container could be used; be sure to look at StructureMapRegistry.cs for the corresponding set-up. The IoC is used for injecting all the validation builders and make it easy to add your own custom ones.

```csharp
public ActionResult Index()
{
    var model = new PersonDetailsModel()
    {
        Address = new Address()
    };

    var validationModel = ObjectFactory.GetInstance<AttributeValidationModelBuilder>().GetValidation(model.GetType());

    return View(new ModelValidation() { Model = model, ValidationModel = validationModel });
}
```

View Model javascript set-up in index.cshtml for the Home Controller:

```javascript
var viewModel = function() {

    var self = this;

    self.vm = ko.mapping.fromJS(model);

    self.onClick = function() {
        console.log(self.attributeValidation.isValid());
    };

    self.attributeValidation = new ko.attributeValidation().init({ model: self.vm, validationModel: validationModel });

};
        

var vm = new viewModel();
ko.applyBindings(vm);
```

The view requires inclusion of knockout, knockout mapping, knockout validation, and the custom script knockout.attributeValidation.js written to map the json serialized validation rules to the view model. The attributeValidation javascript comes with built in validators for basic validation but also exposes the function addValidatorExtender for adding custom validation rules as well.
