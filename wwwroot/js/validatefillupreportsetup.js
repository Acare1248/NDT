/*$(function () {
  $.validator.setDefaults({
    submitHandler: function () {
      alert( "Form successful submitted!" );
      $("#InputReportOfDevice").empty();
      ReloadSelectMenu();
    }
  });*/
  $('#ReportFormRegistation').validate({
      submitHandler: function () {
        CheckDuplicateReport();
      },
    rules: 
        {
          InputReportName: {
            required: true,
            //email: true,
          },
          InputEmailAddress: {
            required: true,
            //minlength: 5
            email: true,
          },
          InputEmailSubject: {
            required: true
          },
          radioKeyFrom: {
            required: true
          },
          DeviceKeyFrom: {
            required: true
          }
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

  $('#quickForm2').validate({
    submitHandler: function () {
      CheckDuplicateDevices();
    },
    rules: {
      InputDeviceName: {
        required: true,
        //email: true,
      },
      InputEmailAddress: {
        required: true,
        //minlength: 5
        email: true,
      },
      InputReportOfDevice: {
        required: true
      },
      radioKeyFrom: {
        required: true
      },
      InputDeviceKeyw: {
        required: true
      }
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
/*});*/