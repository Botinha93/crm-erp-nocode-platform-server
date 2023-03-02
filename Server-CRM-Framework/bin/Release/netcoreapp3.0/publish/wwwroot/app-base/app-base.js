import { globalVariables } from './internal.js';
class caf {
    getPropriety(name) {
        return globalVariables.entities[globalVariables.curentEntity].proprieties[name];
    }
    getEntity(name) {
        return globalVariables.entities[name];
    }
}
//# sourceMappingURL=app-base.js.map