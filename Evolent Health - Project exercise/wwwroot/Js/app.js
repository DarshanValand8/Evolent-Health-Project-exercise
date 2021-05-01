let BaseUrl = "api/Contacts/";

$(document).ready(function () {
    console.log("ready!");
    GetContactList();
});


function GetContactList() {
    let url = BaseUrl + "GetAll"
    $.get(url, function (data) {
        if (data) {
            var tableBody = "";
            for (var i = 0; i < data.length; i++) {
                tableBody += '<tr><td>' + data[i].firstName + '</td><td>' + data[i].lastName + '</td><td>' + data[i].email + '</td><td>' + data[i].phoneNumber + '</td><td><button class="btnEdit" onclick="editPopup(' + data[i].id + ')">Edit</button>&nbsp;<button class="btnDel" onclick="deletePopup(' + data[i].id +')">Delete</button></td></tr>'
            }
            $("#tableBody").html(tableBody);
        }
    });
}

function GetContact(id) {
    let url = BaseUrl + "getById/" + id
    $.get(url, function (data) {
        if (data) {
            $('#txtFirstName').val(data.firstName);
            $('#txtLastName').val(data.lastName);
            $('#txtEmail').val(data.email);
            $('#txtMobile').val(data.phoneNumber);
            $('#hdnId').val(data.id);
            var tableBody = "";
        }
    });
}

function CreateContact(contact) {
    $.ajax({
        type: "POST",
        url: BaseUrl + "createContact",
        data: JSON.stringify(contact),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#contactSuccess').css('display','block');
            clearForm();
            GetContactList();
        },
        failure: function (e) {
        }
    });
}

function saveContact() {
    let contact = {};
    contact.FirstName = $('#txtFirstName').val();
    contact.LastName = $('#txtLastName').val();
    contact.Email = $('#txtEmail').val();
    contact.PhoneNumber = $('#txtMobile').val();
    if (validateContact(contact)) {
        CreateContact(contact)
    }
}

function editContact() {
    let contact = {};
    contact.FirstName = $('#txtFirstName').val();
    contact.LastName = $('#txtLastName').val();
    contact.Email = $('#txtEmail').val();
    contact.PhoneNumber = $('#txtMobile').val();
    contact.Id = parseInt($('#hdnId').val());
    
    if (validateContact(contact)) {
        CreateContact(contact)
    }
}

function deletePopup(id) {
    var res = confirm('Are you sure!')
    if (res) {
        let url = BaseUrl + "deleteContact/" + id
        $.get(url, function (data) {
            GetContactList();
        });
    }
    

}
function validateContact(contact) {
    //FirstName
    if (contact.FirstName.trim() === "") {
        $('#txtFirstName').css('border', '2px solid red');
        return false;
    }
    else {
        $('#txtFirstName').css('border', '1px solid black');
    }

    //LastName
    if (contact.LastName.trim() === "") {
        $('#txtLastName').css('border', '2px solid red');
        return false;
    }
    else {
        $('#txtLastName').css('border', '1px solid black');
    }

    //Email
    var emailRegex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (contact.Email.trim() === "" || !emailRegex.test(contact.Email.trim())) {
        $('#txtEmail').css('border', '2px solid red');
        return false;
    }
    else {
        $('#txtEmail').css('border', '1px solid black');
    }

    //Mobile
    var moblieRegex = /^\d*(?:\.\d{1,2})?$/;
    if (contact.PhoneNumber.trim() === "" || !moblieRegex.test(contact.PhoneNumber.trim())) {
        $('#txtMobile').css('border', '2px solid red');
        return false;
    }
    else {
        $('#txtMobile').css('border', '1px solid black');
    }

    return true;
}

function clearForm() {
    $('#txtFirstName').val('');
    $('#txtLastName').val('');
    $('#txtEmail').val('');
    $('#txtMobile').val('');
    $('#hdnId').val('');
}
function createPopup() {
    $('#btnEdit').css('display', 'none');
    $('#btnSave').css('display', 'block');
    openPopup();
}

function openPopup() {
    $('#contactSuccess').css('display', 'none');    
    $('#createContactModel').show(500);
}

function closePopup() {
    $('#createContactModel').hide(500);
    clearForm();
}

function editPopup(id) {
    GetContact(id);
    $('#btnEdit').css('display', 'block');
    $('#btnSave').css('display', 'none');
    openPopup();

}


