$(function () {

    // attach datepicker to textboxes
    $('#BirthDate').datepicker({ dateFormat: "mm-dd" });
    $('#HireDate').datepicker({ dateFormat: "mm-dd" });

    $('#register-btn').on('click', '.req-employee-field', function () {
        if ($('.req-employee-field').val() == '') {
            new jBox('Notice', {
                content: 'You must enter a value for required.',
                autoClose: 2000, // time in milliseconds
                color: 'red', // black, red, green, blue, yellow
                stack: false, // true, false
                closeOnEsc: true,
                target: $('#' + this.id),
                position: {
                    x: 'left',
                    y: 65
                },
            });
        }
    });

});