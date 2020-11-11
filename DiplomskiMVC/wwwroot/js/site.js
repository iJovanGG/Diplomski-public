var disabledForm = null;

$(document).ready(function () {
    $(document).on('show.bs.modal', '.modal', function () {
        $(this).appendTo('body');
    });

    $(".disableOnSubmit").on("submit", function () {
        disabledForm(this);
    })

    $(".custom-file-upload").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

    $('.alert').on("close.bs.alert", function () {
        $(this).hide();
        return false;
    });

    $(".createSubjectForm").on("submit", function (e) {
        e.preventDefault();
        let form = $(this);
        let resultTarget = form.data("return-target");
        disableForm(this);
        $.post(window.location.origin + form.attr("action"), form.serializeArray(), {})
            .done(function (result) {
                $("#" + resultTarget).prepend(result);
                form[0].reset();
                $(".createSubjectForm").modal('hide');
                enableForm();
            })
            .fail(function (error) {
                displayErrorBox(error);
                enableForm();
            })
    });

    $('.editSubjectBtn').click(function () {
        $.get(window.location.origin + $(this).attr('formaction'), {})
            .done(function (result) {
                $("#editSubjectModal .modal-content").html(result);
                $("#editSubjectModal").modal();

                $("#addProfessorToSubjectBtn").click(function () {
                    $.get(window.location.origin + $(this).attr('formaction'), {})
                        .done(function (result) {
                            $("#AddProfessorToSubjectForm select").html('');
                            result.forEach(function (element) {
                                let option = document.createElement('option');
                                option.setAttribute('value', element.Id);
                                option.text = element.FullName;
                                $("#AddProfessorToSubjectForm select").append(option);
                                
                            })
                            $("#AddProfessorToSubjectForm select").selectpicker();
                            $("#addProfessorToSubjectFormWrapper").collapse('show');
                            $("#addProfessorToSubjectBtn").hide();
                        })
                })

                $('#AddProfessorToSubjectForm').on('submit', function (e) {
                    e.preventDefault();
                    disableForm('#editSubjectModal .modal-content');
                    $.post(window.location.origin + $(this).attr("action"), $(this).serializeArray(), {})
                        .done(function (result) {
                            $("#" + resultTarget).prepend(result);
                            $('#AddProfessorToSubjectForm')[0].reset();
                            $(".createSubjectForm").modal('hide');
                            $("#addProfessorToSubjectFormWrapper").collapse('hide');
                            $("#addProfessorToSubjectBtn").show();
                            enableForm();

                        })
                        .fail(function (html, settings, error) {
                            displayErrorBox(error);
                            enableForm();
                        })
                })
            })
    })

    $("#Discription").tinymce({
        height: 500,
        menubar: false,
        plugins: "link image code table",
        toolbar: 'undo redo | styleselect | forecolor | bold italic '
            + '| alignleft aligncenter alignright alignjustify | outdent indent | link image | code | table',
        images_upload_handler: thesisImageUploadHendler
    });

    $('#saveDraftThesis').click(function () {
        $('#thesisForm').attr('action', $(this).attr('formaction'));
        $('#thesisForm').submit();
    })

    $('#commentForm').on('submit', function (e) {
        e.preventDefault();
        if ($(this).find('textarea').val() == '') {
            $(this).find('#comment-error').show();
            return;
        }
        $(this).unbind('submit').submit();
    })


    $('#profileNavigation .nav-link').click(function () {
        let toShow = $(this).data('subject');
        console.log(toShow);
        if (toShow == null) {
            $(".thesisCard").show();
            return;
        }
            
        $(".thesisCard").hide();
        $(".thesisCard." + toShow).show();
    })

    $("#requestThesis").click(function () {
        $.get(window.location.origin + $(this).attr("formaction"), {})
            .done(function () {
                location.href = location.href;
            })
            .fail(function (html, settings, error) {
            displayErrorBox();
        })
    })

    $(".denyRequest").click(function () {
        $("#denyRequestModal").modal();
        let requestId = $(this).data('request-id');
        $("#denyRequestBtn").click(function () {
            $.post(window.location.origin + $(this).attr("formaction"), { "response": $("#response").val(), "requestId": requestId }, function () { })
                .done(function () { console.log("dasdas"); location.reload() })
                .fail(function (html, settings, error) {
                displayErrorBox();
            });
        })
    })

    $('.approveRequest').click(function () {
        confirmationPopup("approveRequest", [$(this).data('request-id'), $(this).attr('formaction')], "Odobravanje ovog zahteva odbiće sve ostale za ovu temu.")
    })
})

function disableForm(formElement) {
    let jQForm = $(formElement);
    disabledForm = jQForm;
    jQForm.append('<div class="cover-element"><div class="lds-ellipsis"><div></div><div></div><div></div><div></div></div></div>');
}

function enableForm() {
    if (disabledForm == null)
        return
    disabledForm.find(".cover-element").remove();
    disabledForm = null;
}

function displayErrorBox(errorText) {
    if (errorText == null || errorText == '')
        errorText = 'Pokušajte ponovo, ako se greska nastavlja pojavljivati obavestite admina.'
    $('body').prepend('<div class="alert show fade alert-warning alert-with-icon text-left error-box" id="errorBox">'
        + '<button type="button" aria-hidden="true" class="close" data-dismiss="alert" aria-label="Close"> '
        + '<span aria-hidden="true">&times;</span></button> <span data-notify="icon" class="tim-icons icon-support-17"></span>'
        + '<strong>Došlo je do greške</strong> <p>' + errorText + '</p> </div>');
}

function confirmationPopup(functionName, parameters, text) {
    $popup = $("#confirmationPopUp");

    if (text == null)
        $popup.find('.modal-body').html('Da li ste sigurni?');
    else
        $popup.find('.modal-body').html(text);

    if (functionName == null && parameters == null) {
        $popup.find(".no-function").show();
        $popup.find(".function").hide();
        $popup.modal();
        return;
    }
    else {
        $popup.find(".no-function").hide();
        $popup.find(".function").show();
    }

    $popup.find('.confirm').on("click", function () {
        window[functionName].apply(null, parameters);
        $popup.modal('hide');
    })

    $popup.modal();
}

function thesisImageUploadHendler(blobInfo, success, failure, progress) {
    var xhr, formData;

    xhr = new XMLHttpRequest();
    xhr.withCredentials = false;
    xhr.open('POST', window.location.origin + '/thesis/uploadImage');

    xhr.upload.onprogress = function (e) {
        progress(e.loaded / e.total * 100);
    };

    xhr.onload = function () {
        var json;

        if (xhr.status === 403) {
            failure('HTTP Error: ' + xhr.status, { remove: true });
            return;
        }

        if (xhr.status < 200 || xhr.status >= 300) {
            failure('HTTP Error: ' + xhr.status);
            return;
        }

        json = JSON.parse(xhr.responseText);

        if (!json || typeof json.location != 'string') {
            failure('Invalid JSON: ' + xhr.responseText);
            return;
        }

        success(json.location);
    };

    xhr.onerror = function () {
        failure('Image upload failed due to a XHR Transport error. Code: ' + xhr.status);
    };

    formData = new FormData();
    formData.append('image', blobInfo.blob(), blobInfo.filename());
    formData.append('thesisId', $('input#Id').val());

    xhr.send(formData);
};

function approveRequest(requestId, link) {
    $.post(window.location.origin + link, { "requestId": requestId }, function () { })
        .done(function () { location.href = window.location.href.split('?')[0] })
    .fail(function (html, settings, error) {
        displayErrorBox();
    });
}