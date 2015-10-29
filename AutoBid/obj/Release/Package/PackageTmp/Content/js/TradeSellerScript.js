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
    $('#MOTExpiryDate').datepicker({
        format: "dd/mm/yyyy", startDate: date,
    });
    $("#MOTExpiryDate").inputmask("99/99/9999");

    $('#TAXExpiryDate').datepicker({
        format: "dd/mm/yyyy", startDate: date,
    });
    $("#TAXExpiryDate").inputmask("99/99/9999");

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
$('#ddlMakes').change(function () {
    console.log("llll");
    console.log($("#hdnModelID").val());
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
                    $("#hdnModelID").val($(this).val());
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
$(document).ready(function () {
    
    $('.row').find('img[ID^=trade_imgRemoveImage_]').each(function () {
        $(this).click(function () {

            //if ($(this).html() == 'Delete') {
            var ctrlID = $(this).attr("data-ctrlID");
            // alert(ctrlID);
            //alert($('#imgVehicleImagePlaceHolder_' + ctrlID).attr('src'));
            $('#spnMessage_' + ctrlID).html('Please wait...');
            $.ajax({
                url: '/CarSeller/RemoveVehicleImage',
                data: { VehicleImage: $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr('src') },
                type: 'post',
                datatype: 'json',
                success: function (retValue) {
                    $('#spnMessage_' + ctrlID).html('');
                    if (retValue) {
                        $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr("data-isempty", "1");
                        $('#trade_flVehicleFile_' + ctrlID).val('');
                        $('#trade_flVehicleFile_' + ctrlID).replaceWith($('#trade_flVehicleFile_' + ctrlID).clone(true));

                        //$('#divCtrl_' + ctrlID).css({ 'visibility': 'hidden' });
                        $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr('src', '/Content/images/uploadimg.png');
                        $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr('data-isempty', 'true');
                        $('#trade_imgRemoveImage_' + ctrlID).hide();
                        var counter = 0;
                        $("[id^=trade_imgVehicleImagePlaceHolder_]").each(function () {
                            if ($(this).attr("data-isempty") == "false")
                                counter++;
                        });
                        if (counter == 0) {
                            $("#TabPhotoUpload").attr("visible", true);
                            $("#TabPhotoUpload").hide();
                        }

                    }
                },
                error: function () { $('#spnMessage_' + ctrlID).html(''); }
            });
            //}
        });
    });

    //$.ajax({
    //    type: "POST",
    //    url: '/CarSeller/GetVehicleImage',
    //    data: "{VehicleID:" + VehicleID + "}",
    //    dataType: "json",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (modelData) {
    //        console.log(VehicleID);
    //    }
      
});

    $('.row').find('.tradeSeller>input[type=file]').each(function () {
        $(this).change(function () {
            //alert("lllll");
            //$('#TabPrivatePhotoUpload').attr('visible', true);

            var ctrlID = $(this).attr("data-ctrlID");
            console.log(ctrlID);
            $('#spnMessage_' + ctrlID).html('Please wait...');
            $('#frmImgUpload_' + ctrlID).ajaxSubmit({
                url: '/CarSeller/UploadVehicleImage',
                data: { ctrlID: ctrlID },
                type: 'POST',
                datatype: 'json',
                success: function (retFilename) {
                    if (!retFilename) {
                        $('#spnMessage_' + ctrlID).html('');
                        //alert(retFilename);
                        return;
                    }

                    else {
                        var d = new Date();
                        var n = d.getMilliseconds();
                        $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr("data-isempty", "0");
                        $('#trade_imgRemoveImage_' + ctrlID).show();
                        $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr('src', '/Content/Assets/CarSellerImages/' + retFilename);
                        $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).attr('data-isempty', 'false');
                        if (!$('#TabPhotoUpload').is(':visible')) {
                            $('#TabPhotoUpload').show();
                            $('#TabPhotoUpload').attr('visible', true);
                            $('#trade_imgVehicleImagePlaceHolder_' + ctrlID).text("NON-DELETE");
                        }
                        else {
                            //if ($('#trade_imgVehicleImagePlaceHolder_' + ctrlID).text() != "NON-DELETE")
                            //   $('#trade_imgRemoveImage_' + ctrlID).show();

                        }
                        $('#spnMessage_' + ctrlID).html('');

                    }
                    //$('#spnIcon_' + ctrlID).removeClass().addClass('fa fa-edit');
                    //if (!$('#TabPhotoUpload').is(':visible')) {
                    //    $('#TabPhotoUpload').show();
                    //    $('#spnEdit_' + ctrlID).html('NON-DELETABLE');
                    //}
                    //else {
                    //    if ($('#spnEdit_' + ctrlID).html() != 'NON-DELETABLE') {
                    //        $('#divCtrl_' + ctrlID).css({ 'visibility': 'visible' });
                    //        $('#spnEdit_' + ctrlID).html('Delete');
                    //    }
                    //}
                },
                error: function () { $('#spnMessage_' + ctrlID).html(''); }
            })
        });
    });
$('#ddlMakes').trigger("change");
//});
$('#TabPreview').click(function () {
    /*$('#tab4').hide();
    $('#tab5').show();
    $('html, body').animate({
        scrollTop: $('#tab4').offset().top - 500
    }, 3000, function () {
       
        $("#liPreview").removeClass("active");
        $("#liConfirm").addClass("active");
    });*/

    //$('#btnPreview').removeAttr("disabled");

    ShowLoader();
    $("#frmPreview").ajaxSubmit({
        success: function (res) {
            if (res) {

                $('#btnConfirm').removeAttr("disabled");
                $('html, body').animate({
                    scrollTop: $('.mb20').offset().top - 100
                }, 2000, function () {
                    $("#tab2").fadeOut(function () {
                        $('#tab4').hide();
                        $('#tab5').show();
                        HideLoader();
                        $("#liPreview").children().removeClass("active");
                        $("#liConfirm").children().addClass("active");
                    });
                });
            }
        },
        error: function () {
        }
    });

});

$('#TabPhotoUpload').click(function () {
    ShowLoader();
    var imgArray = TradePushImages();
    $.ajax({
        url: '/CarSeller/SaveImages',
        data: { arr: imgArray },
        type: 'post',
        datatype: 'json',
        async: true,
        traditional: true,
        success: function (retValue) {
            if (retValue) {
                $('#btnPreview').removeAttr("disabled");
                //$('#btnPhotoUpload').removeAttr("disabled");
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
                                $('#tab3').hide();
                                $("#liPhotoUpload").children().removeClass("active");
                                $("#liPreview").children().addClass("active");

                                $('#divHtml').html(retValue.toString());
                                $('#tab4').show();
                                HideLoader();
                            }
                        },
                        error: function () { }
                    });
                });
            }
        },
        error: function () { $('#spnMessage_' + ctrlID).html(''); }
    });
});

$('#btnTabDetail2').click(function () {

    console.log("aaa");

    if ($('#frmDetails2').valid()) {
        ShowLoader();
        $("#frmDetails2").ajaxSubmit({
            success: function () {

                $('#btnPhotoUpload').removeAttr("disabled");
                $('html, body').animate({
                    scrollTop: $('.mb20').offset().top - 100
                }, 2000, function () {
                    $("#tab2").fadeOut(function () {
                        $('#tab2').hide();
                        $('#tab3').show();
                        HideLoader();
                        $("#liDetails2").children().removeClass("active");
                        $("#liPhotoUpload").children().addClass("active");
                    });
                });
            },
            error: function () {
            }
        });
    }
    else {
        $('html, body').animate({
            scrollTop: $('.field-validation-error').first().offset().top - 130
        }, 2000);
    }

});

$('btnAuctionNext').click(function () {
   
    if ($('#formAuctionHouse').valid()) {
        ShowLoader();
        //$('#btnTabDetail1').val('Wait!!!');
        $("#formAuctionHouse").ajaxSubmit({
            success: function () {
                $('html, body').animate({
                    scrollTop: $('.mb20').offset().top - 130
                }, 2000, function () {
                    $("#tab1").fadeOut(function () {
                        $("#tab1").hide();
                        $("#tab2").show();
                        HideLoader();
                        $("#liDetails").removeClass("active");
                        $("#liDetails2").addClass("active");
                    });
                });
            },
            error: function () {
            }
        });
    }
});


$('#btnTabDetail1').click(function () {

    console.log("btnTrade");

    var IsFuel = false;
    $('#divFuelTypes').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked'))
            IsFuel = true;
    })
    var alreadyShown = false;
    if ($('#txtNewMakename').is(':visible'))
        alreadyShown = true;
    $('#txtNewMakename').show();
    console.log($('#FormCarSellingDetails').valid());
    console.log(IsFuel);
    if ($('#FormCarSellingDetails').valid() && IsFuel) {
        ShowLoader();
        $('#btnTabDetail1').val('Wait!!!');
        $("#FormCarSellingDetails").ajaxSubmit({
            success: function () {

                console.log("btnTrade");

                $('#details2').removeAttr("disabled");

                $('html, body').animate({
                    scrollTop: $('.mb20').offset().top - 130
                }, 2000, function () {
                    $("#tab1").fadeOut(function () {
                        $("#tab1").hide();
                        $("#tab2").show();
                        HideLoader();
                        $("#liDetails").children().removeClass("active");
                        $("#liDetails2").children().addClass("active");
                    });
                });
            },
            error: function () {
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

var TradePushImages = function () {
    var imgArray = new Array();

    $("#tab3").children().find("[id^=trade_imgVehicleImagePlaceHolder_]").each(function () {
        if ($(this).attr("data-isempty") == "false") {
            var filename = $(this).attr("src").substring($(this).attr("src").lastIndexOf('/') + 1);
            imgArray.push(filename);
        }
    });
    return imgArray;
}