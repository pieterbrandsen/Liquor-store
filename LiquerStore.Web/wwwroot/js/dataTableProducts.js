export var dataTable = function (data) {
    $(document).ready(function () {
        $("#table").DataTable({
            data: data,
            processing: true,
            serverSide: false,
            // filter: true, // this is for disable filter (search box)
            orderMulti: false,
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
                        return "<a class=\"btn btn-info\" href=\"/Products/Edit?Id=" + full.Id + "\">Aanpassen</a>";
                    },
                },
                {
                    render: function (data, type, full, meta) {
                        return "<a class=\"btn btn-warning\" href=\"/Products/Details?Id=" + full.Id + "\">Alle gegevens</a>";
                    },
                },
                {
                    render: function (data, type, full, meta) {
                        console.log(full.SoftDeleted);
                        return full.SoftDeleted ? "Uitgezet" : "Actief";
                    },
                },
            ],
        });
    });
};
