//$(".btnnav").on("click", function () {
//    var divShow = $(this).attr("data-tab"); 
//    $('html, body').animate({
//        scrollTop: 0
//    }, 2000, function () {
//        $("[id^=tab]").hide();
//        $(".steps>li").removeClass("active");

//        $("." + divShow.slice(1)).addClass("active");
//        $(divShow).show();
//    });

//});

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
        url: '/AuctionHouseAddEditVehicle/GetModels',
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

$('#ddlMakes').trigger("change");

$(function () {
    //$("#Reserve").inputmask("decimal", {
    //    radixPoint: ".",
    //    groupSeparator: ",",
    //    digits: 2,
    //    autoGroup: true,
    //    prefix: '$'
    //});
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

    $('#SaleDate').datepicker({
        format: "dd/mm/yyyy", startDate: date,
    });
    $("#SaleDate").inputmask("99/99/9999");

    $('#DateOfFirstRegistration').datepicker({
        format: "dd/mm/yyyy", endDate: '+0d',

    });
    $("#DateOfFirstRegistration").inputmask("99/99/9999");

    //$('#RegistrationDate').datepicker({
    //    format: "dd/mm/yyyy", endDate: '+0d',

    //});
    //$("#RegistrationDate").inputmask("99/99/9999");




    $('.row').find('.auctionhouse>input[type=file]').each(function () {

        $(this).change(function () {
            var ctrlID = $(this).attr("data-ctrlID");
            var hv = $('#hdnAucVehicleID').val();
            console.log(hv);
            console.log(ctrlID);

            $('#spnMessage_' + ctrlID).html('Please wait...');


            $('#frmImgUpload_' + ctrlID).ajaxSubmit({
                url: '/AuctionHouseAddEditVehicle/UploadVehicleImage',
                data: { ctrlID: ctrlID, AuctionHouseVehicleID: hv },
                type: 'POST',
                datatype: 'json',
                success: function (retFilename) {

                    console.log(retFilename);

                    if (!retFilename) {
                        $('#spnMessage_' + ctrlID).html('');
                        return;
                    }

                    else {
                        var d = new Date();
                        var n = d.getMilliseconds();
                        $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr("data-isempty", "0");
                        $('#auc_imgRemoveImage_' + ctrlID).show();
                        $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr('src', '/Content/Assets/AuctionHouseSaleVehicleImages/' + retFilename);
                        $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr('data-isempty', 'false');
                        if (!$('#TabPhotoUpload').is(':visible')) {
                            $('#TabPhotoUpload').show();
                            $('#TabPhotoUpload').attr('visible', true);
                            $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).text("NON-DELETE");
                        }
                        else {

                        }
                        $('#spnMessage_' + ctrlID).html('');

                    }

                },
                error: function () { $('#spnMessage_' + ctrlID).html(''); }
            })
        });
    });


    $('.row').find('img[ID^=auc_imgRemoveImage_]').each(function () {
        $(this).click(function () {

            //if ($(this).html() == 'Delete') {
            var ctrlID = $(this).attr("data-ctrlID");
            var hv = $('#hdnAucVehicleID').val();
            console.log(hv);
            $('#spnMessage_' + ctrlID).html('Please wait...');
            $.ajax({
                url: '/AuctionHouseAddEditVehicle/RemoveVehicleImage',
                data: { VehicleImage: $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr('src'), AuctionHouseVehicleID: hv },
                type: 'post',
                datatype: 'json',
                success: function (retValue) {
                    console.log(retValue);
                    $('#spnMessage_' + ctrlID).html('');
                    if (retValue) {
                        $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr("data-isempty", "1");
                        $('#auc_flVehicleFile_' + ctrlID).val('');
                        $('#auc_flVehicleFile_' + ctrlID).replaceWith($('#auc_flVehicleFile_' + ctrlID).clone(true));

                        //$('#divCtrl_' + ctrlID).css({ 'visibility': 'hidden' });
                        $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr('src', '/Content/images/uploadimg.png');
                        $('#auc_imgVehicleImagePlaceHolder_' + ctrlID).attr('data-isempty', 'true');
                        $('#auc_imgRemoveImage_' + ctrlID).hide();
                        var counter = 0;
                        $("[id^=auc_imgVehicleImagePlaceHolder_]").each(function () {
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

    $('input.chkimported').on('change', function () {
        $('input.chkimported').not(this).prop('checked', false);
    });

    $('input.chkfullvs').on('change', function () {
        $('input.chkfullvs').not(this).prop('checked', false);
    });

    $('input.chkvcar').on('change', function () {
        $('input.chkvcar').not(this).prop('checked', false);
    });

    $('input.chkhpi').on('change', function () {
        $('input.chkhpi').not(this).prop('checked', false);
    });


});

$('#TabPhotoUpload').click(function () {
    ShowLoader();
    var mainHTML = "";
    var imgArray = TradePushImages();
    $.ajax({
        url: '/AuctionHouseAddEditVehicle/SaveImages',
        data: { arr: imgArray },
        type: 'post',
        datatype: 'json',
        async: true,
        traditional: true,
        success: function (retValue) {
            if (retValue) {
                HideLoader();
                console.log(retValue);
                $('#tab2').hide();
                $('tab1').hide();
                $("#details2").removeClass("active");
                $("#liPhotoUpload").addClass("active");
                $("#liPhotoUpload").attr("data-enable", "true");


                mainHTML += "<div class='col-md-12'>\
                    <table width='100%' cellspacing='0' cellpadding='0' border='0' class='table table-bordered table-striped'>\
                                    <tbody>\
                                        <tr>\
                                            <th>Current Vehicles Live</th>\
                                             <th>Reg.</th>\
                                             <th>Reserve</th>\
                                            <th>Action</th>\
                                           </tr>\
                                        <tr>\
                                        <td>Vehicle Example</td>\
                                        <td>" + retValue.RegistrationNo + "</td>\
                                        <td>"+ retValue.Reserve + "</td>\
                                        <td>\
                                        <button class='btn btn-primary btn-xs' type='button' id='btnEdit' onclick='getPreview();'>EDIT</button>\
                                        <button class='btn btn-success btn-xs' type='button'>PRINT FORM</button>\
                                        </td>\
                                    </tr>\
                                    </tbody>\
                                </table>\
                                </div>";
                $('#divHtml').html(mainHTML)
                //$('#divHtml').html(retValue.toString());
                $('#tab3').show();

                HideLoader();

            }
        }
    });
});



var TradePushImages = function () {
    var imgArray = new Array();

    $("#tab2").children().find("[id^=auc_imgVehicleImagePlaceHolder_]").each(function () {
        if ($(this).attr("data-isempty") == "false") {
            var filename = $(this).attr("src").substring($(this).attr("src").lastIndexOf('/') + 1);
            imgArray.push(filename);
        }
    });
    return imgArray;
}

//$(".chkimported").click(function () {
//    $(".chkimported").attr("checked", false); //uncheck all checkboxes
//    $(this).attr("checked", true);  //check the clicked one
//});


$('[id^=fueltype]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanfuelmsg').hide();
    }
})

$('[id^=importedList]').change(function () {
    if ($(this).is(":checked")) {
        // console.log(this.id);
        IsFuel = true;
        $('#spanImportmsg').hide();
    }
})

$('[id^=TransmissionTypeSelected]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanTransmissionmsg').hide();
    }
})

$('[id^=fullVSProvidedList]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanFullVSmsg').hide();
    }
})

$('[id^=interiortrimlist]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanIntTrimmsg').hide();
    }
})



$('[id^=serviceauctionlist]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanServicemsg').hide();
    }
})

$('[id^=VCARregisteredList]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanVCARRegmsg').hide();
    }
})

$('[id^=HPIClearList]').change(function () {
    if ($(this).is(":checked")) {
        console.log(this.id);
        IsFuel = true;
        $('#spanHPImsg').hide();
    }
})



$('#btnTabDetail1').click(function (e) {
    console.log("log")

    e.preventDefault();

    var IsFuel = false;
    $('#divFuelTypes').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsFuel = true;
        }

    })

    var IsIntTrim = false;
    $('#divInteriorTrimTypes').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsIntTrim = true;
        }

    })

    var IsTransmission = false;
    $('#divTransmissionType').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsTransmission = true;
        }

    })

    var IsServiceHis = false;
    $('#divService').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsServiceHis = true;
        }

    })

    var IsImported = false;
    $('#divImportedTypes').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsImported = true;
        }
    })

    var IsFullVS = false;
    $('#divFullVS').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsFullVS = true;
        }

    })

    var IsVCARReg = false;
    $('#divVCARReg').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsVCARReg = true;
        }

    })

    var IsHPI = false;
    $('#divHPI').find('input[type=checkbox]').each(function () {
        if ($(this).prop('checked')) {
            IsHPI = true;
        }

    })

    var alreadyShown = false;
    if ($('#txtNewMakename').is(':visible'))
        alreadyShown = true;
    $('#txtNewMakename').show();


    if ($('#frmAuctionHouseSaleAddEditVehicle').valid() && IsFuel && IsIntTrim && IsTransmission && IsServiceHis && IsImported && IsFullVS && IsVCARReg && IsHPI) {
        HideLoader();
        console.log("form")
        $("#divRegError").html("");
        ShowLoader();
        $('#btnTabDetail1').val('Wait!!!');
        $("#frmAuctionHouseSaleAddEditVehicle").ajaxSubmit({
            success: function (data) {
                console.log(data);
                if (data.ErrMsgType.toLowerCase() == "success") {
                    $('#hdnAucVehicleID').val(data.AuctionHouseVehicleID);
                    //$('#details2').removeAttr("disabled");

                    $('html, body').animate({
                        scrollTop: $('.mb20').offset().top - 130
                    }, 2000, function () {


                        //$("#tab1").fadeOut(function () {
                        $("#tab1").hide();
                        $("#tab2").show();
                        $("#tab3").hide();
                        HideLoader();
                        $('#liDetails').removeClass("active");
                        $('#Details2').addClass("active");

                        HideLoader();
                    });
                    //});
                }
                else {

                    HideLoader();
                    $("#divRegError").show();
                    $("#divRegError").html(data.ErrMsg);

                }
            },
            error: function () {
            }
        });
    }

    else {
        if (!IsFuel) {
            $('#spanfuelmsg').css('display', 'block').html("At least one fuel type must be selected.");
            $('#spanfuelmsg').addClass("text-danger");
        } else {
            $('#spanfuelmsg').html('');
        }

        if (!IsIntTrim) {
            $('#spanIntTrimmsg').css('display', 'block').html("At least one Interior Trim type must be selected.");
            $('#spanIntTrimmsg').addClass("text-danger");
        } else {
            $('#spanIntTrimmsg').html('');
        }

        if (!IsTransmission) {
            $('#spanTransmissionmsg').css('display', 'block').html("At least one Transmission type must be selected.");
            $('#spanTransmissionmsg').addClass("text-danger");
        } else {
            $('#spanTransmissionmsg').html('');
        }

        if (!IsServiceHis) {
            $('#spanServicemsg').css('display', 'block').html("At least one Service History must be selected.");
            $('#spanServicemsg').addClass("text-danger");
        } else {
            $('#spanServicemsg').html('');
        }

        if (!IsImported) {
            $('#spanImportmsg').css('display', 'block').html("One Imported Type must be selected.");
            $('#spanImportmsg').addClass("text-danger");
        } else {
            $('#spanImportmsg').html('');
        }


        if (!IsFullVS) {
            $('#spanFullVSmsg').css('display', 'block').html("One Full VS must be selected.");
            $('#spanFullVSmsg').addClass("text-danger");
        } else {
            $('#spanFullVSmsg').html('');
        }

        if (!IsVCARReg) {
            $('#spanVCARRegmsg').css('display', 'block').html("One VCAR Register must be selected.");
            $('#spanVCARRegmsg').addClass("text-danger");
        } else {
            $('#spanVCARRegmsg').html('');
        }

        if (!IsHPI) {
            $('#spanHPImsg').css('display', 'block').html("One HPI Clear must be selected.");
            $('#spanHPImsg').addClass("text-danger");
        } else {
            $('#spanHPImsg').html('');
        }


    }
    if (!alreadyShown)
        $('#txtNewMakename').hide();

});


function ShowLoader() {
    $("#loaderImage").show();
}

function HideLoader() {
    $("#loaderImage").hide();
}

$('#TabPrev2').click(function () {
    $('#tab1').show();
    $('#tab2').hide();
    $('#tab3').hide();
    $("#details2").removeClass("active");
    $("#liPhotoUpload").removeClass("active");
    $("#liDetails").addClass("active");
});

function Home() {
    console.log(this.id);
    window.location.href = "/AuctionHouseAddEditVehicle/Index";

    $.ajax({
        type: "POST",
        url: '/AuctionHouseAddEditVehicle/Finish',
        data: "{AuctionHouseVehicleID:" + AuctionHouseVehicleID + "}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
        }
    });

}

function RegCheck() {
    console.log(this.id);
    window.location.href = "/AuctionHouseAddEditVehicle/RegNoCheck";

    $.ajax({
        type: "POST",
        url: '/AuctionHouseAddEditVehicle/Finish',
        data: "{regno:" + AuctionHouseVehicleID + "}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
        }
    });

}





$('#TabPrevUpload').click(function () {
    HideLoader();
    $('#tab2').show();
    $('#tab3').hide();
    $('#tab1').hide();
    $("#liPhotoUpload").removeClass("active");
    $("#details2").addClass("active");
    $("#liDetails").removeClass("active");
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

$("#aucSaleNew").click(function () {


    $('#auctionSale-pop-up').modal("show");

});
$("#btnAdd").click(function () {


    $('#imageUploadModal').modal("show");

});

$("#AddAucSaleCan").click(function () {

    $('#auctionSale-pop-up').modal("hide");

});

$('#AddAucSale').click(function (e) {

    e.preventDefault();


    if ($('#frmAucSaleNew').valid()) {
        console.log("piya")
        //ShowLoader();
        $('#AddAucSale').val('Wait!!!');
        $("#frmAucSaleNew").ajaxSubmit({

            success: function (res) {

                console.log(res);

                if (res.msg.toLowerCase() == "success") {

                    $("#divSaleTitle").hide();
                    $("#ddlSale").append("<option value='" + res.AuctionHouseSaleID + "' selected='selected'>" + res.Title + "</option>");
                    $('#auctionSale-pop-up').modal("hide");

                }
                else {


                    $("#divSaleTitle").html(res.msg);
                    $("#divSaleTitle").show();

                }
            },
            error: function () {
            }

        });
    }
    else {
        $('html, body').animate({
            scrollTop: $('.input-validation-error').first().offset().top - 130
        }, 2000);
    }

});





$('#imageUploadModal').on('hidden.bs.modal', function () {
    $('div.dz-success').remove();
    $('.dz-message').css("display", "block");
})
Dropzone.options.dropzoneForm = {
    init: function () {

        this.on("complete", function (data) {
            $('.dz-message').css("display", "none");
            console.log("data");
            var res = JSON.parse(data.xhr.responseText);
            console.log(res);
            $("#btnDeleteOption").show();

            $("#nodata").hide();
            $("#btnDoneOption").hide();

            $("#gallery").append('<div class="col-sm-4"> <span id="spnImgMsg" class="glyphicon glyphicon-remove galleryclose" style="display:none;cursor:pointer;" data-value="' + res.AuctionHouseCarSellingVehicleImagesMoreID + '" onclick="deleteImage(this);"></span><img src="/Content/Assets/AuctionHouseSaleImagesMore/' + res.Filename + '" class="img-responsive"></div>')



        });
    }
};
$("#btnDeleteOption").on("click", function () {
    console.log("Delete")

    $("#spnImgMsg").show();
    $(this).hide();
    $("#btnAdd").hide();
    $("#btnDoneOption").show();
    $(".galleryclose").show();

});
$("#btnDoneOption").on("click", function () {

    $(this).hide();
    $("#btnAdd").show();
    $("#btnDeleteOption").hide();
    $(".galleryclose").hide();

});

var deleteImage = function (a) {

    var parentDiv = $(a).parent();
    $(parentDiv).remove();
    var imgid = $(a).attr("data-value");
    if (imgid) {
        $.ajax({
            url: "/AuctionHouseAddEditVehicle/RemoveImage",
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ AuctionHouseCarSellingVehicleImagesMoreID: imgid }),
            async: true,
            processData: false,
            cache: false,
            success: function (res) {


            },
        });
    }
    else {
        alert("error");
    }
}

var getPreview = function () {

    $('#btnEdit').on("click", function () {
        console.log("EDIT")
        $('#tab1').show();
        $('#tab2').hide();
        $('#tab3').hide();
        $("#details2").removeClass("active");
        $("#liPhotoUpload").removeClass("active");
        $("#liDetails").addClass("active");
    });
}

$(document).ready(function () {

});

