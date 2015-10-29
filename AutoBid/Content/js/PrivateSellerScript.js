

$('#btnPrivateTabDetail1').click(function () {
    var IsFuel = false;
    $('#divFuelTypes').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked'))
            IsFuel = true;
    })
    var alreadyShown = false;
    if ($('#txtNewMakename').is(':visible'))
        alreadyShown = true;
    $('#txtNewMakename').show();
   
    if ($('#FormCarSellingDetails').valid() && IsFuel) {
        ShowLoader();
        $('#btnTabDetail1').val('Wait!!!');
        $("#FormCarSellingDetails").ajaxSubmit({
            success: function (data) {
                console.log(data);
                if (data) {
                    $('html, body').animate({
                        scrollTop: $('.mb20').offset().top - 130
                    }, 2000, function () {
                        $("#tab1").fadeOut(function () {
                            $("#tab1").hide();
                            $("#tab2").show();
                            HideLoader();
                            $("#liDetails").removeClass("active");
                            $("#liPhotoUpload").addClass("active");
                            $("#liDetails").attr("data-enable","true");
                            $("#liPhotoUpload").attr("data-enable", "true");
                        });
                    });
                }
                else {
                    window.location.href = "./";
                }
            },
            error: function (err) {
                console.log(err)
            }
        });
    }
    else {
        if (!IsFuel) {
            $('#spanfuelmsg').css('color', 'red').html("At least one fuel type must be selected.");
        } else {
            $('#spanfuelmsg').html('');
        }
        $('html, body').animate({
            scrollTop: $('.field-validation-error').first().offset().top - 130
        }, 2000);
        //$(document.getElementsByName($('.field-validation-error').attr('data-valmsg-for'))).focus();
    }
    if (!alreadyShown)
        $('#txtNewMakename').hide();
    //$("#Selectedfueltypes").val(slvals.toString());
});

var PrivatePushImages = function () {
    var imgArray = new Array();

    $("#tab2").children().find("[id^=private_imgVehicleImagePlaceHolder_]").each(function () {
        if ($(this).attr("data-isempty") == "false") {
            var filename = $(this).attr("src").substring($(this).attr("src").lastIndexOf('/') + 1);
            imgArray.push(filename);
        }
    });
    console.log(imgArray.length);
    return imgArray;
}
$('#TabPrivatePhotoUpload').click(function () {   
    ShowLoader();
    var imgArray= PrivatePushImages();
    $.ajax({
        url: '/CarSeller/SaveImages',
        data: { arr: imgArray },
        type: 'post',
        datatype: 'json',
        async: true,
        traditional: true,
        success: function (retValue) {
            if (retValue) {
                $('html, body').animate({
                    scrollTop: $('#tab4').offset().top - 500
                }, 3000, function () {
                    //$('#tab5').html("");
                    //$('#tab').html('<span> Generating preview!!! </span>');
                    $.ajax({
                        url: '/CarSeller/LoadPreview',
                        data: {},
                        type: 'post',
                        datatype: 'html',
                        async: true,
                        success: function (retValue) {
                            if (retValue) {
                                $('#tab2').hide();
                                $('tab4').hide();
                                $("#liPhotoUpload").removeClass("active");
                                $("#liAdvert").addClass("active");
                                $("#liAdvert").attr("data-enable","true");

                                $('#divHtml').html(retValue.toString());
                                $('#tab3').show();

                                HideLoader();
                            }

                        },
                        error: function () { }
                    });

                });
            }

        },
        error: function () { //$('#spnMessage_' + ctrlID).html(''); 
        }
    });
});

$('#btnPrivateTabDetail2').click(function () {
    console.log("clicked");
    if ($("#frmPrivateDetails2").valid()) {
        ShowLoader();
        $("#frmPrivateDetails2").ajaxSubmit({


            success: function () {

                var varVehicleID = $('#hdnVehicleID').val();

                console.log("finish");
                console.log(varVehicleID);

                $.ajax({
                    type: "POST",
                    url: '/CarSeller/FinishPrivateSession',
                    data: {},
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        console.log(result);

                    }
                });

                $('html, body').animate({
                    scrollTop: $('.mb20').offset().top - 100
                }, 2000, function () {
                    $("#tab3").fadeOut(function () {
                        $('#tab3').hide();
                        $('#tab4').show();
                        HideLoader();
                        $("#liAdvert").removeClass("active");

                    });
                });
            },
            error: function () {
            }
        });
    }

});

$('#ddlMakes').change(function () {

    var makeID = $(this).val();
    if ($("#ddlMakes option:selected").index() == 0) {
        $('#ddlModels').slideDown('slow');
        $('#txtNewModelname').slideUp('slow');
        $('#spnCarModelNotInList').html("My car model not in list.");
        $('#txtNewMakename').val('');
        $(document).find('span[for=txtNewMakename]').show();

        return;
    }

    $('#txtNewMakename').val($("#ddlMakes option:selected").text());
    $(document).find('span[for=txtNewMakename]').hide();
    $.ajax({
        type: "POST",
        url: '/CarSeller/GetModels',
        data: "{MakeID:" + makeID + "}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (modelData) {
            $('#txtNewModelname').val("");
            $("#ddlModels").empty();

            //alert(modelData.length);
            if (modelData.length == 0) {
                $('#ddlModels').slideUp('slow');
                $('#txtNewModelname').slideDown('slow');
                $('#txtNewModelname').focus();
                $('#spnCarModelNotInList').hide();
            }
            else {
                $('#ddlModels').slideDown('slow');
                $('#txtNewModelname').slideUp('slow');
                $('#ddlModels').focus();
                $("#ddlModels").append("<option value=''>" + "-- Select your car model --</option>");
                $.each(modelData, function (index, optionData) {
                    console.log($("#hdnModelID").val());
                    if ($("#hdnModelID").val() == optionData.ModelID.toString()) {
                        console.log($("#hdnModelID").val());
                        $("#ddlModels").append("<option value='" + optionData.ModelID + "' selected>" +
                                        optionData.ModelName.toUpperCase() + "</option>");
                    }
                    else {
                        $("#ddlModels").append("<option value='" + optionData.ModelID + "'>" +
                                      optionData.ModelName.toUpperCase() + "</option>");
                    }
                });
                $('#ddlModels').change(function () {
                    if ($("#ddlMakes option:selected").index() == 0) {
                        $('#txtNewModelname').val('');
                    }
                    else {
                        $('#txtNewModelname').val($("#ddlModels option:selected").text());
                    }
                });
                $('#spnCarModelNotInList').show();
                $('#ddlModels').focus();
            }
        }
    });
});

$(function () {

    $("#price").inputmask("decimal", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 2,
        autoGroup: true,
        prefix: '£'
    });
    $('#price').blur(function () {
        var currencyValue = $(this).val().split(',').join('').substring(1, $(this).val().length);
        if (parseFloat(currencyValue) > parseFloat(1000000)) {
            alert("The vehicle price should be less than 1 Million!!!");
            $(this).val('');
        }
    });
    var date = new Date();
    date.setDate(date.getDate() - 1);

    $('#DateOfFirstRegistration').datepicker({
        format: "dd/mm/yyyy", endDate: '+0d',
        
    });
    $("#DateOfFirstRegistration").inputmask("99/99/9999");

    $("#ContactNumberOnAdvert").inputmask("(999) 999-9999");
    $("#ContactNumber").inputmask("(999) 999-9999");

    $('#spnCarModelNotInList').click(function () {
        if ($(this).html() == "Show model list") {
            $('#ddlModels').slideDown('slow');
            $('#txtNewModelname').slideUp('slow');
            $(this).html("My car model not in list.");
            //$('#ddlModels').focus();
        }
        else {
            $('#ddlModels').slideUp('slow');
            $('#txtNewModelname').slideDown('slow');
            $(this).html("Show model list");
            //$('#txtNewModelname').focus();
        }
    });
    $('#spnCarMakeNotInList').click(function () {
        $('#txtNewMakename').val('');
        if ($(this).html() == "Show make list") {
            $('#ddlMakes').slideDown('slow');
            $('#txtNewMakename').slideUp('slow');
            $(this).html("My car make not in list.");


            $('#ddlModels').slideDown('slow');
            $('#txtNewModelname').slideUp('slow');
            $('#spnCarModelNotInList').show();
        }
        else {
            $('#ddlMakes').slideUp('slow');
            $('#txtNewMakename').slideDown('slow');
            $(this).html("Show make list");


            $('#ddlModels').slideUp('slow');
            $('#txtNewModelname').slideDown('slow');
            $('#spnCarModelNotInList').hide();
        }
    });
    $('#txtNewMakename').blur(function () {
        if ($(this).val().trim().length != 0)
            $("#ddlMakes option:eq(0)").attr('selected', true);

        $("#ddlMakes option:contains(" + $('#txtNewMakename').val().toUpperCase().trim() + ")").attr('selected', true);
        if ($("#ddlMakes option:selected").index() != 0) {
            $('#ddlMakes').slideDown('slow');
            $('#txtNewMakename').slideUp('slow');
            $('#spnCarMakeNotInList').html("My car make not in list.");

            $('#ddlModels').slideDown('slow');
            $('#txtNewModelname').slideUp('slow');
            $('#spnCarModelNotInList').show();

            $('#ddlMakes').change();
        }
    });

});

$(document).ready(function () {

    $('.row').find('img[ID^=Private_imgRemoveImage_]').each(function () {
        $(this).click(function () {

            //if ($(this).html() == 'Delete') {
            var ctrlID = $(this).attr("data-ctrlID");
            // alert(ctrlID);
            //alert($('#imgVehicleImagePlaceHolder_' + ctrlID).attr('src'));
            $('#spnMessage_' + ctrlID).html('Please wait...');
            $.ajax({
                url: '/CarSeller/RemoveVehicleImage',
                data: { VehicleImage: $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr('src') },
                type: 'post',
                datatype: 'json',
                success: function (retValue) {
                    $('#spnMessage_' + ctrlID).html('');
                    if (retValue) {
                        $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr("data-isempty", "1");
                        $('#private_flVehicleFile_' + ctrlID).val('');
                        $('#private_flVehicleFile_' + ctrlID).replaceWith($('#private_flVehicleFile_' + ctrlID).clone(true));

                        //$('#divCtrl_' + ctrlID).css({ 'visibility': 'hidden' });
                        $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr('src', '/Content/images/uploadimg.png');
                        $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr('data-isempty', 'true');
                        $('#Private_imgRemoveImage_' + ctrlID).hide();
                        var counter = 0;
                        $("[id^=private_imgVehicleImagePlaceHolder_]").each(function () {
                            if ($(this).attr("data-isempty") == "false")
                                counter++;
                        });
                        if (counter == 0) {
                            $("#TabPrivatePhotoUpload").attr("visible", true);
                            $("#TabPrivatePhotoUpload").hide();
                        }

                    }
                },
                error: function () { $('#spnMessage_' + ctrlID).html(''); }
            });
            //}
        });
    });

    $('.row').find('.privateSeller>input[type=file]').each(function () {
        $(this).change(function () {
            //alert("lllll");

            //$('#TabPhotoUpload').attr('visible', true);
            var ctrlID = $(this).attr("data-ctrlID");

            $('#spnMessage_' + ctrlID).html('Please wait...');
            $('#frmImgUpload_' + ctrlID).ajaxSubmit({
                url: '/CarSeller/UploadVehicleImage',
                data: { ctrlID: ctrlID },
                type: 'POST',
                datatype: 'json',
                success: function (retFilename) {
                    if (!retFilename) {
                        $('#spnMessage_' + ctrlID).html('');
                        alert(retFilename);
                        return;
                    }

                    else {
                        var d = new Date();
                        var n = d.getMilliseconds();
                        $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr("data-isempty", "0");
                        $('#Private_imgRemoveImage_' + ctrlID).show();
                        $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr('src', '/Content/Assets/CarSellerImages/' + retFilename)
                        $('#private_imgVehicleImagePlaceHolder_' + ctrlID).attr('data-isempty', 'false');
                        if (!$('#TabPrivatePhotoUpload').is(':visible')) {
                            $('#TabPrivatePhotoUpload').show();
                            $('#TabPrivatePhotoUpload').attr('visible', true);
                            $('#private_imgVehicleImagePlaceHolder_' + ctrlID).text("NON-DELETE");

                        }
                        else {
                            //if ($('#imgVehicleImagePlaceHolder_' + ctrlID).text() != "NON-DELETE")
                            //    //$('#imgRemoveImage_' + ctrlID).show();
                        }
                        // $('#TabPrivatePhotoUpload').show();

                        $('#spnMessage_' + ctrlID).html('');
                    }
                    $('#spnIcon_' + ctrlID).removeClass().addClass('fa fa-edit');
                    if (!$('#TabPhotoUpload').is(':visible')) {
                        $('#TabPhotoUpload').show();
                        $('#spnEdit_' + ctrlID).html('NON-DELETABLE');
                    }
                    else {
                        if ($('#spnEdit_' + ctrlID).html() != 'NON-DELETABLE') {
                            $('#divCtrl_' + ctrlID).css({ 'visibility': 'visible' });
                            $('#spnEdit_' + ctrlID).html('Delete');
                        }
                    }
                },
                error: function () { $('#spnMessage_' + ctrlID).html(''); }
            })
        });
    });
   
        $('#ddlMakes').trigger("change");
});