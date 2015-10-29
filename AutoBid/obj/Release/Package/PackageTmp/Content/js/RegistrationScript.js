$('#flUploadLogo').change(function () {
 
    $("#FrmSellerlogoUpload").ajaxSubmit({
            url: '/Account/UploadSellerCompanyLogo',
            success: function (retFilename) {
                $("#CompanyLogo").val(retFilename);
                $('.img-responsive').attr('src', '/Content/Assets/CompanyLogos/' + retFilename + '?y=' + new Date());
            },
            error: function (err)
            {
                
            }
        });
});
$(function () {
    $("#YearofFoundation").inputmask("9999");
    $("#Phone").inputmask("(999) 999-9999");
    $("#CompanyContact").inputmask("(999) 999-9999");
    $("#CompanyContact2").inputmask("(999) 999-9999");
    $("#CompanyContact3").inputmask("(999) 999-9999");

    $('#PostalCode').keyup(function () {
        $(this).val($(this).val().toUpperCase());
    });
    $('#CompanyPostalCode').keyup(function () {
        $(this).val($(this).val().toUpperCase());
    });
})