export class Datatables {	
  /**	
   * Update the table based on products fields	
   * @param data A string containing the data in JSON format	
   */	
  public static products(data: string[]): void {	
    $(document).ready(function () {	
      $("#table").DataTable({	
        data: data,	
        processing: true, // for show progress bar	
        serverSide: false, // for process server side	
        // filter: true, // this is for disable filter (search box)	
        orderMulti: false, // for disable multiple column at once	
        columns: [	
          {	
            data: "Name",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Name;	
            },	
          },	
          {	
            data: "Age",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Age;	
            },	
          },	
          {	
            data: "ProductionArea",	
            render: function (data, type, full, meta) {	
              return full.Whisky.ProductionArea;	
            },	
          },	
          {	
            data: "AlcoholPercentage",	
            render: function (data, type, full, meta) {	
              return full.Whisky.AlcoholPercentage;	
            },	
          },	
          {	
            data: "Kind",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Kind;	
            },	
          },	
          {	
            data: "Available",	
            render: function (data, type, full, meta) {	
              return full.Available;	
            },	
          },	
          {	
            render: function (data, type, full, meta) {	
              return `<a class="btn btn-info" href="/Products/Edit?Id=${full.Id}">Aanpassen</a>`;	
            },	
          },	
          {	
            render: function (data, type, full, meta) {	
              return `<a class="btn btn-warning" href="/Products/Details?Id=${full.Id}">Alle gegevens</a>`;	
            },	
          },	
          {	
            render: function (data, type, full, meta) {	
              return full.SoftDeleted ? "Uitgezet" : "Actief";	
            },	
          },	
        ],	
      });	
    });	
  }	

  /**	
   * Update the table based on reserve fields	
   * @param data A string containing the data in JSON format	
   */	
  public static reserve(data: string[]): void {	
    $(document).ready(function () {	
      $("#table").DataTable({	
        data: data,	
        processing: true, // for show progress bar	
        serverSide: false, // for process server side	
        // filter: true, // this is for disable filter (search box)	
        orderMulti: false, // for disable multiple column at once	
        columns: [	
          {	
            data: "Name",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Name;	
            },	
          },	
          {	
            data: "Age",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Age;	
            },	
          },	
          {	
            data: "AlcoholPercentage",	
            render: function (data, type, full, meta) {	
              return full.Whisky.AlcoholPercentage;	
            },	
          },	
          {	
            data: "Kind",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Kind;	
            },	
          },	
          {	
            data: "Available",	
            render: function (data, type, full, meta) {	
              return full.Available;	
            },	
          },	
          {	
            render: function (data, type, full, meta) {	
              return `<a class="btn btn-warning" href="/Reserve/Details?Id=${full.Id}">Alle gegevens</a>`;	
            },	
          },	
          {	
            render: function (data, type, full, meta) {	
              return `<a class="btn btn-success" href="/Reserve/Reserve?Id=${full.Id}">Reserveren</a>`;	
            },	
          },	
        ],	
      });	
    });	
  }	

    /**	
   * Update the table based on orders fields	
   * @param data A string containing the data in JSON format	
   */	
  public static orders(data: string[]): void {	
    $(document).ready(function () {	
      $("#table").DataTable({	
        data: data,	
        processing: true, // for show progress bar	
        serverSide: false, // for process server side	
        // filter: true, // this is for disable filter (search box)	
        orderMulti: false, // for disable multiple column at once	
        columns: [	
          {	
            data: "FullName",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Name;	
            },	
          },	
          {	
            data: "Name",	
            render: function (data, type, full, meta) {	
              return full.Whisky.Age;	
            },	
          },	
          {	
            data: "Completed",	
            render: function (data, type, full, meta) {	
              return full.Whisky.AlcoholPercentage;	
            },	
          },	
        ],	
      });	
    });	
  }	
} 