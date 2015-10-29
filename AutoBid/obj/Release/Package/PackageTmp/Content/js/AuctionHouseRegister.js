
//    $('#btnAuctionNext').click(function () {
//        if ($("#AuctionHouseName").val() && $("#Address").val() && $("#PostalCode").val() && $("#hdnAuctionLogo").val()) {
//            $.ajax({
//                url: '/AuctionHouse/InsertAuctionHouse',
//                data: { AuctionHouseName: $("#AuctionHouseName").val(), Address: $("#Address").val(), PostalCode: $("#PostalCode").val(), Logo: $("#hdnAuctionLogo").val() },
//                type: 'post',
//                datatype: 'json',
//                async: true,
//                success: function (data) {
//                    if (!jQuery.isEmptyObject(data)) {                       
//                        $("#tab2").hide();
//                        $("#tab3").show();

//                    }
//                },
//                error: function () { //$('#spnMessage_' + ctrlID).html('');
//                }
//            });
//        }
//        else {
//            $("#alertmsg").text("Required");
//            $("#alert").fadeTo(2000, 500).slideUp(500, function () {
//                $("#alert").alert('close');
//            });
//        }
//    });


$('#flAuctionLogo').change(function () {
    $("#frmAuctionHouseRegistration").ajaxSubmit({
        url: '/AuctionHouse/UploadAuctionHouseImg',
        success: function (data) {
            if (data.type) {
                $("#hdnAuctionLogo").val(data.msg);
                $("#imgAuctionLogo").attr("src", "/Content/Assets/AuctionHouseImages/" + data.msg);
            }
            else {
                $("#alertmsg").text(data.msg);
                $("#alert").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert").alert('close');
                });
            }
        },
        error: function () {
        }
    });
});


//$('#btnAuctionRegNext').click(function () {
//    var html = "";
//    if ($("#About").val() && $("#Buyer_Fees").val()) {
//        $.ajax({
//            url: '/AuctionHouse/InsertAuctionHouse',
//            data: { AuctionHouseName: $("#AuctionHouseName").val(), Address: $("#Address").val(), PostalCode: $("#PostalCode").val(), Logo: $("#hdnAuctionLogo").val(), About: $("#About").val(), Buyer_Fees: $("#Buyer_Fees").val() },
//            type: 'post',
//            datatype: 'json',
//            async: true,
//            success: function (data) {
//                console.log(data);
//                if (!jQuery.isEmptyObject(data)) {
//                    html += '<div class="header">\
//                                    <h1>' + data.AuctionHouseName + '</h1>\
//                                    <span class="right">' + data.Address + '</span>\
//                                </div>\
//                                <div class="content">\
//                                    <span class="right socialnetwork"><i class="fa fa-facebook facebook"></i> <i class="fa fa-twitter twitter"></i></span>\
//                                    <h3>About Auction House</h3>\
//                                    <div class="divider"></div>\
//                                    <div class="left" style="width:50%;">';
//                    if (data.Logo != null) {
//                        html += '<img src="/Content/Assets/AuctionHouseImages/' + data.Logo + '" class="thumbnail" width="50%">';

//                    }
//                    else {
//                        html += '<img src="/Content/images/noimage.jpg" class="thumbnail" width="50%">';
//                    }
//                    html += '</div><p style="float:left;">' + data.About + '</p><div class="clearfix"></div><div class="clearfix"></div>';

//                    html += '';
//                    $("#divAuctionContent").html(html);
//                    $("#tab3").hide();
//                    $("#tab4").show();

//                }
//            },
//            error: function () { }
//        });
//    }
//    else {
//        $("#alertmsg").text("Required");
//        $("#alert").fadeTo(2000, 500).slideUp(500, function () {
//            $("#alert").alert('close');
//        });
//    }
//});
//$("#btnAuctionConfirm").click(function () {

//    var html = "";
//    $.ajax({
//        url: '/AuctionHouse/ClearAuctionSession',
//        data: {},
//        type: 'post',
//        datatype: 'json',
//        async: true,
//        success: function (data) {
//            if (!jQuery.isEmptyObject(data)) {
//                html += '<div class="section formwrap">\
//                <div class="container">\
//                <div class="row">\
//                <div class="row steptitle"> Thank You </div>\
//                <br>\
//                <div class="col-md-12">\
//                <div class="content">\
//                 One of the motorbid team member will be in touch shortly.\
//                <br>\
//                 <br>\
//                <br>\
//                <br>\
//                Return to\
//                <a href="/Home/Index" id="lnkHomeid" >Homepage</a>\
//                <br>\
//                <br>\
//                <br>\
//                </div>\
//                </div>\
//                </div>\
//                </div>\
//                </div>';
//                html += '';
//                $('#tab5').html(html);
//                $('#tab5').show();
//                $('#tab4').hide();
//            }
//        }

//    });
//})



//$("#linkauchouse").click(function () {
//    $("#tab1").show();
//    $("#tab3").hide();
//});

//$("#lnkHomeid").on("click", function () {
//    console.log("HI........");
//    $("#tab1").show();
//})
var GeneratePreview = function () {
    console.log("Preview");
    var html = "";
    html += '<div class="header">\
       <h1>' + $("#AuctionHouseName").val() + '</h1>\
        <span class="right">' + $("#Address").val() + '</span>\
         </div>\
          <div class="content">\
          <span class="right socialnetwork"><i class="fa fa-facebook facebook"></i> <i class="fa fa-twitter twitter"></i></span>\
           <h3>About Auction House</h3>\
            <div class="divider"></div>\
             <div class="left" style="width:50%;">';

    if ($("#hdnAuctionLogo").val() != null) {
        html += '<img src="/Content/Assets/AuctionHouseImages/' + $("#hdnAuctionLogo").val() + '" class="thumbnail" width="50%">';

    }
    else {
        html += '<img src="/Content/images/noimage.jpg" class="thumbnail" width="50%">';
    }
    html += '</div><p style="float:left;">' + $("#About").val() + '</p><div class="clearfix"></div><div class="clearfix"></div>';

    html += '';
    $("#divAuctionPreviewContent").html(html);

}
$('#btnAuctionRegisterConfirm').click(function () {
    //if ($("#UserName").val() && $("#Password").val() && $("#ConfirmPassword").val()) {
    console.log("AucReg");

    if ($('#frmAuctionHouseRegistration').valid()) {

        var html = "";

        $("#frmAuctionHouseRegistration").ajaxSubmit({
            url: "/AuctionHouse/Registration",
            success: function (data) {

                console.log("AucReg");
                console.log(data);
                if (data) {

                    if (!jQuery.isEmptyObject(data)) {
                        html += '<div class="section formwrap">\
                                    <div class="container">\
                                    <div class="row">\
                                    <div class="row steptitle"> thank you </div>\
                                    <br>\
                                    <div class="col-md-12">\
                                    <div class="content">\
                                     one of the motorbid team member will be in touch shortly.\
                                    <br>\
                                     <br>\
                                    <br>\
                                    <br>\
                                    return to\
                                    <a href="/home/index" id="lnkhomeid" >homepage</a>\
                                    <br>\
                                    <br>\
                                    <br>\
                                    </div>\
                                    </div>\
                                    </div>\
                                    </div>\
                                    </div>';
                        html += '';
                        $('#tab5').html(html);
                        $('#tab5').show();
                        $('#tab4').hide();
                    }



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
    
});


$(".btnNav").on("click", function () {
    var parent = $(this).parent().parent().parent().parent().attr('id');
  
    if ($(this).attr('data-type')!='prev'){
    if ($("#" + parent).find('.text-danger').length == 0) {
        $("[id^=tab]").hide();
        var divShow = $(this).attr("data-tab");
        $(divShow).show();
    }
    else {

    }
    } else {
        $("[id^=tab]").hide();
        var divShow = $(this).attr("data-tab");
        $(divShow).show();
    }
});

