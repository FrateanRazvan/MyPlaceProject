"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var rooms_service_1 = require("./rooms.service");
describe('RoomsService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(rooms_service_1.RoomsService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=rooms.service.spec.js.map