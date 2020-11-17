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
                        return "<a class=\"btn btn-warning\" href=\"/Reserve/Details?Id=" + full.Id + "\">Alle gegevens</a>";
                    },
                },
                {
                    render: function (data, type, full, meta) {
                        return "<a class=\"btn btn-success\" href=\"/Reserve/Reserve?Id=" + full.Id + "\">Reserveren</a>";
                    },
                },
            ],
        });
    });
};
