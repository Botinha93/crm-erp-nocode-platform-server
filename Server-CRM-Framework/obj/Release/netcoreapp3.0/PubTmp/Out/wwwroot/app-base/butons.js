import { globalVariables } from './auxiliar.js';
import { auxiliar } from './auxiliar.js';
import { topmenubuntons } from './internal.js';
import { images } from './internal.js';
export function addDefaultButons() {
    new topmenubuntons(images.new, "New", () => {
        globalVariables.entities[globalVariables.curentEntity].clearView();
        auxiliar.clearView(globalVariables.entities[globalVariables.curentEntity].viewContent(), globalVariables.entities[globalVariables.curentEntity].getName(), globalVariables.enumViews.ENTITY);
    });
    new topmenubuntons(images.save, "Save", () => {
        globalVariables.entities[globalVariables.curentEntity].saveView();
    });
    new topmenubuntons(images.trash, "Delete", () => {
    });
    new topmenubuntons(images.accept, "Set as Active", () => {
    });
    new topmenubuntons(images.block, "Deactivate", () => {
    });
    new topmenubuntons(images.graph, "PDF Report", () => {
    });
    topmenubuntons.detectWrap();
}
//# sourceMappingURL=butons.js.map