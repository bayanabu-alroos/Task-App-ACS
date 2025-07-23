$(document).ready(function () {
    $('#searchInput').on('input', function () {
        let term = $(this).val().trim();

        $.ajax({
            url: '/Home/Search',
            type: 'GET',
            data: { term: term },
            success: function (data) {
                const tbody = $('#resultTable tbody');
                tbody.empty();
                console.log(data);

                if (data.length > 0) {
                    data.forEach(item => {
                        tbody.append(`<tr><td>${item.id}</td><td>${item.email}</td><td>${item.phoneNumber}</td></tr>`);
                    });
                    $('#resultTable').show();
                    $('#noResults').hide();
                } else {
                    $('#resultTable').hide();
                    $('#noResults').show();
                }
            }
        });
    });
});