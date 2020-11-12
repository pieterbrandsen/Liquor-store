export const dataTable = (data: string[]): void => {
    $(document).ready(function() {
        $('#table').DataTable({
            data: data,
            processing: true, // for show progress bar
            serverSide: false, // for process server side
            // filter: true, // this is for disable filter (search box)
            orderMulti: false, // for disable multiple column at once
            columns: [
                {
                    "data": "Name",
                    "render": function(data, type, full, meta) {
                        return full.Whisky.Name;
                    }
                },
                {
                    "data": "Age",
                    "render": function(data, type, full, meta) {
                        return full.Whisky.Age;
                    }
                },
                {
                    "data": "ProductionArea",
                    "render": function(data, type, full, meta) {
                        return full.Whisky.ProductionArea;
                    }
                },
                {
                    "data": "AlcoholPercentage",
                    "render": function(data, type, full, meta) {
                        return full.Whisky.AlcoholPercentage;
                    }
                },
                {
                    "data": "Kind",
                    "render": function(data, type, full, meta) {
                        return full.Whisky.Kind;
                    }
                },
                {
                    "data": "Available",
                    "render": function(data, type, full, meta) {
                        return full.Available;
                    }
                },
                {
                    "render": function(data, type, full, meta) {
                        return `<a class="btn btn-info" href="/Liquers/Edit?Id=${full.Id}">Aanpassen</a>`;
                    }
                },
                {
                    "render": function(data, type, full, meta) {
                        return `<a class="btn btn-warning" href="/Liquers/Details?Id=${full.Id}">Alle gegevens</a>`;
                    }
                },
                {
                    "render": function(data, type, full, meta) {
                        return (full.Whisky.SoftDelete) ? "Actief" : "Uitgezet";
                    }
                },
            ]
        });
      });
};