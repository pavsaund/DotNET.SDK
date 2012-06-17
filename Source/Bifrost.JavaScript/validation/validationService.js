﻿Bifrost.namespace("Bifrost.validation");
Bifrost.validation.validationService = (function () {
    return {
        extendAllProperties: function (target) {
            for (var property in target) {
                target[property].extend({ validation: {} });
            }
        },
        applyForCommand: function (command) {
            Bifrost.validation.validationService.extendAllProperties(command.parameters);

            var methodParameters = {
                name: command.name
            }
            $.ajax({
                type: "GET",
                url: "/Validation/GetForCommand",
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: methodParameters,
                complete: function (d) {
                    var result = $.parseJSON(d.responseText);
					if( !result || !result.properties ) {
						return;
					}
                    for (var property in result.properties) {
                        if (!command.parameters.hasOwnProperty(property)) {
                            command.parameters[property] = ko.observable().extend({ validation: {} });
                        }
                        command.parameters[property].validator.setOptions(result.properties[property]);
                    }
                }
            });
        }
    }
})();