
(function () {
    ko.attributeValidation = function () {

        var self = this;

        self.validators = [];

        var validationExtenders = {
            Required: function (model, propertyName, validator) {
                model[propertyName].extend({ required: { message: validator.ErrorMessage } });
            },
            MinLength: function (model, propertyName, validator) {
                model[propertyName].extend({ minLength: { params: validator.Length, message: validator.ErrorMessage } });
            },
            MaxLength: function (model, propertyName, validator) {
                model[propertyName].extend({ maxLength: { params: validator.Length, message: validator.ErrorMessage } });
            },
            RegularExpression: function (model, propertyName, validator) {
                model[propertyName].extend({ pattern: { params: validator.Pattern, message: validator.ErrorMessage } });
            },
            Range: function (model, propertyName, validator) {
                if (validator.Minimum !== null) {
                    model[propertyName].extend({ min: { params: validator.Minimum, message: validator.ErrorMessage } });
                }
                
                if (validator.Maximum !== null) {
                    model[propertyName].extend({ max: { params: validator.Maximum, message: validator.ErrorMessage } });
                }
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
                    model[propertyName].extend({ equal: { params: compareProperty, message: validator.ErrorMessage } });
                }
            }
        };

        self.addValidatorExtender = function (extenderType, extender) {
            //extenderType: string, same as what IValidator ValidatorType property is
            //extender: function, function (model, propertyName, validator)
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

        self.applyValidationToModel = function (model, validationModel) {

            if (model === undefined) {
                return;
            }

            var prop;
            for (prop in model) {
                var propertyValidation = validationModel.PropertyValidators[prop];
                if (propertyValidation == undefined) {
                    continue;
                }

                if (propertyValidation.ChildModel != null) {
                    self.applyValidationToModel(model[prop], propertyValidation.ChildModel);
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

        self.init = function (data) {
            //data.model: the data model which has had knockout mapping run on it
            //data.validationModel: contains all validation rules for data.model

            if (typeof data.model["__ko_mapping__"] === 'undefined') {
                window.console && console.log("model must be created from knockout mapping plugin");
            }

            self.applyValidationToModel(data.model, data.validationModel);
            self.groupedValidation = ko.validation.group(data.model, { deep: true });

            return self;
        };
    };
})();