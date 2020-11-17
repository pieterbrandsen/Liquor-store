import { Datatables } from "js/datatables";
var Site = /** @class */ (function () {
    function Site() {
    }
    /**
     * Run the products or reserve Datatables
     * @param data JSON formatted string
     * @param type A type, products or reserve
     */
    Site.runSite = function (data, type) {
        switch (type) {
            case "products":
                Datatables.products(data);
                break;
            case "reserve":
                Datatables.reserve(data);
                break;
            default:
                console.log("Wrong type input");
                break;
        }
    };
    return Site;
}());
export { Site };
