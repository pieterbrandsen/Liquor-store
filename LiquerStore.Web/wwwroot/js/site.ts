import { Datatables } from "./datatables.js";

export class Site {
  /**
   * Run the products or reserve Datatables
   * @param data JSON formatted string
   * @param type A type, products or reserve
   */
  public static runSite(data: string[], type: "products" | "reserve" | "orders") {
    switch (type) {
      case "products":
        Datatables.products(data);
        break;
      case "reserve":
        Datatables.reserve(data);
        break;
        case "orders": 
        Datatables.orders(data);
        break;
      default:
        console.log("Wrong type input");
        break;
    }
  }
}
