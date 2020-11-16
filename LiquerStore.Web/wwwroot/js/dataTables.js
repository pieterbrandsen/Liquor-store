export var dataTable = function (data, isAuthenticated) {
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
                        return "<a class=\"btn btn-info\" href=\"/Liquers/Edit?Id=" + full.Id + "\">Aanpassen</a>";
                    },
                },
                {
                    render: function (data, type, full, meta) {
                        return "<a class=\"btn btn-warning\" href=\"/Liquers/Details?Id=" + full.Id + "\">Alle gegevens</a>";
                    },
                },
                {
                    render: function (data, type, full, meta) {
                        return full.Whisky.SoftDelete ? "Actief" : "Uitgezet";
                    },
                },
                {
                    render: function (data, type, full, meta) {
                        return "<a class=\"btn btn-success\" href=\"/Liquers/Reserve?Id=" + full.Id + "\">Reserveren</a>";
                    },
                },
            ],
        });
    });
};
