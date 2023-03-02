import { textboxModule } from '../internal.js';
import { globalVariables } from '../internal.js';
export class numberBoxModule extends textboxModule {
    constructor(name, localizedName, image = 'no', coolSize) {
        super(name, localizedName, image, coolSize);
        this.imput.setAttribute("type", "number");
    }
    getType() {
        return 'NumberBox';
    }
    getValue() {
        return Number(this.imput.value);
    }
}
globalVariables.moduleRegistry['NumberBox'] = (name, localizedName, coolSize = 3, image = 'no') => {
    return new numberBoxModule(name, localizedName, image, coolSize);
};
//# sourceMappingURL=numberbox.js.map