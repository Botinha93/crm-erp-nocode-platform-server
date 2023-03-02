import { textboxModule } from '../internal.js';
import { globalVariables } from '../internal.js';
export class numberBoxModule extends textboxModule {
    constructor(data) {
        super(data);
        this.imput.setAttribute("type", "number");
    }
    getType() {
        return 'NumberBox';
    }
    getValue() {
        return Number(this.imput.value);
    }
}
globalVariables.moduleRegistry['NumberBox'] = (data) => {
    return new numberBoxModule(data);
};
//# sourceMappingURL=numberbox.js.map