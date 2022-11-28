$('#itrequestJob').validate({
    submitHandler: function (form) {
        form.submit();
    },
    rules:
    {
        Text1: {
            required: true,
            //email: true,
        },
    },
    messages: {
        email: {
            required: "Please enter a email address",
            email: "Please enter a valid email address"
        },
        password: {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long"
        },
        terms: "Please accept our terms"
    },
    errorElement: 'span',
    errorPlacement: function (error, element) {
        error.addClass('invalid-feedback');
        element.closest('.form-group').append(error);
    },
    highlight: function (element, errorClass, validClass) {
        $(element).addClass('is-invalid');
    },
    unhighlight: function (element, errorClass, validClass) {
        $(element).removeClass('is-invalid');
    }
});