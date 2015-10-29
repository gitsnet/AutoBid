function ShowLoader() {
    $("#loaderImage").show();
}

function HideLoader() {
    $("#loaderImage").hide();
}

$('#TabPrev1').click(function () {
    $('#tab1').show();
    $('#tab2').hide();
    $("#liDetails2").removeClass("active");
    $("#liDetails").addClass("active");
});
$('#TabPrev2').click(function () {
    $('#tab2').show();
    $('#tab3').hide();
    $("#liPhotoUpload").removeClass("active");
    $("#liDetails2").addClass("active");
});
$('#TabPrev3').click(function () {
    $('#tab3').show();
    $('#tab4').hide();
    $("#liPreview").removeClass("active");
    $("#liPhotoUpload").addClass("active");
});

function EditPhotos() {
    $('#tab3').show();
    $('#tab4').hide();
    $("#liPreview").children().removeClass("active");
    $("#liPhotoUpload").children().addClass("active");
}

function EditAdvert() {
    $('#tab1').show();
    $('#tab4').hide();
    $("#liPreview").children().removeClass("active");
    $("#liDetails").children().addClass("active");
}

$('#TabPrev4').click(function () {
    $('#tab4').show();
    $('#tab5').hide();
    $("#liConfirm").removeClass("active");
    $("#liPreview").addClass("active");
});

$('#TabPrivatePrev2').click(function () {
    $('#tab1').show();
    $('#tab2').hide();
    $("#liPhotoUpload").removeClass("active");
    $("#liDetails").addClass("active");
});
$('#PrevPrice').click(function () {
    $('#tab2').show();
    $('#tab3').hide();
    $("#liAdvert").removeClass("active");
    $("#liPhotoUpload").addClass("active");
});

