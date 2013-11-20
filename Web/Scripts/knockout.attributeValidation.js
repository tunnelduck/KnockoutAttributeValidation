
(function () {
    ko.attributeValidation = (function (data) {
        //data.model: the data model which has had knockout mapping run on it
        //data.validationModel: contains all validation rules for data.model

        var self = this;

        self.validators = [];

        var validationExtenders = {
            Required: function (model, propertyName, validator) {
                model[propertyName].extend({ required: true, message: validator.ErrorMessage });
            },
            MinLength: function (model, propertyName, validator) {
                model[propertyName].extend({ minLength: validator.Length, message: validator.ErrorMessage });
            },
            MaxLength: function (model, propertyName, validator) {
                model[propertyName].extend({ maxLength: validator.Length, message: validator.ErrorMessage });
            },
            RegularExpression: function (model, propertyName, validator) {
                model[propertyName].extend({ pattern: validator.Pattern });
            },
            Compare: function (model, propertyName, validator) {

                var compareProperty, prop;
                for (prop in model) {
                    if (prop === validator.OtherProperty) {
                        compareProperty = model[prop];
                        break;
                    }
                }

                if (typeof compareProperty !== 'undefined') {
                    model[propertyName].extend({ equal: compareProperty });
                }
            }
        };

        self.addValidatorExtender = function (extenderType, extender) {
            validationExtenders[extenderType] = extender;
        };

        self.isValid = function () {
            var i;
            for (i = 0; i < self.validators.length; ++i) {
                if (self.validators[i].isValid() === false) {

                    self.groupedValidation.showAllMessages(true);
                    return false;
                }
            }

            return true;
        };

        self.applyValidation = function (model, validationModel) {

            if (model === undefined) {
                return;
            }

            var prop;
            for (prop in model) {
                var propertyValidation = validationModel.PropertyValidators[prop];
                if (propertyValidation === undefined) {
                    continue;
                }

                if (propertyValidation.ChildModel != null) {
                    self.applyValidation(model[prop], propertyValidation.ChildModel);
                } else {
                    var i, isValidatorAdded = false;

                    for (i = 0; i < propertyValidation.Validators.length; ++i) {
                        var validator = propertyValidation.Validators[i];

                        var validationExtender = validationExtenders[validator.ValidatorType];
                        if (validationExtender) {
                            validationExtender(model, prop, validator);
                            isValidatorAdded = true;
                        }
                    }

                    if (isValidatorAdded) {
                        self.validators.push(model[prop]);
                    }
                }


            }
        };

        (function init() {

            if (typeof data.model["__ko_mapping__"] === 'undefined') {
                window.console && console.log("model must be created from knockout mapping plugin");
            }

            self.applyValidation(data.model, data.validationModel);
            self.groupedValidation = ko.validation.group(data.model, { deep: true });
        })();

        return this;

    });
})();