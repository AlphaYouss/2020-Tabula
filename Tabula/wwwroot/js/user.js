function SetBoardsClick() {
    document.getElementById("projectBoards-toggle").addEventListener("click", function () {
        if (document.getElementById('projectBoards-toggle').checked) {
            document.getElementById('projectIcon').className = "fa fa-caret-up";
        } else {
            document.getElementById('projectIcon').className = "fa fa-caret-down";
        }
    });

    document.getElementById("personalBoard-toggle").addEventListener("click", function () {
        if (document.getElementById('personalBoard-toggle').checked) {
            document.getElementById('personalIcon').className = "fa fa-caret-up";
        } else {
            document.getElementById('personalIcon').className = "fa fa-caret-down";
        }
    });
}

function SetClicks() {
    $('#changeEmail').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            type: "GET",
            url: changeEmailUrl,
        }).done(function (r) {
            $('#partial').html(r);
        }).fail(function (e) {
            console.log(e.responseText);
        });
    });

    $('#changePassword').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            type: "GET",
            url: changePasswordUrl,
        }).done(function (r) {
            $('#partial').html(r);
        }).fail(function (e) {
            console.log(e.responseText);
        });
    });
}