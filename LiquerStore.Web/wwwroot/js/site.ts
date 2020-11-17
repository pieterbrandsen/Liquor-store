import {Datatables} from "js/datatables";

export class Site {
  /**
   * Run the products or reserve Datatables
   * @param data JSON formatted string
   * @param type A type, products or reserve
   */
  public static runSite(data: string[], type: "products" | "reserve") {
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
  }
}