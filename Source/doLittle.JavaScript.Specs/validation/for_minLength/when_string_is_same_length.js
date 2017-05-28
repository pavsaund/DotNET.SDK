﻿describe("when string is same length", function () {
    var validator = doLittle.validation.minLength.create({ options: { length: 5 } });
    var result = validator.validate("12345");

    it("should be valid", function () {
        expect(result).toBe(true);
    });
});