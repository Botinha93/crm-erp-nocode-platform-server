import { globalVariables } from './internal.js';
export class moduleBase {
    getName() {
        return this.name;
    }
    getlocalizedName() {
        return this.localizedName;
    }
}
export class module {
    static new(name, localizedName, type, coolSize) {
        return globalVariables.moduleRegistry[type](name, localizedName, coolSize);
    }
}
//# sourceMappingURL=module-base.js.map