function SetClicks() {

    // UserID

    let userID = document.getElementById("userID").value;

    // Reorder lists

    $('#reorderLists').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: reorderListsUrl,
            data: { 'userID': userID },
        }).done(function (r) {
            $('#partial').html(r);
        }).fail(function (e) {
            console.log(e.responseText);
        });
    });

    // Reorder lists confirmed

    $('#reorderAllLists').on('click', function (e) {
        let listIDs = [];

        let lOCBChildren = document.getElementById("listsOfCurrentBoard").children;

        for (let i = 0; i < lOCBChildren.length; i++) {
            listIDs.push(lOCBChildren[i].children[1].value);
        }
    });

    // Create list

    $('#createList').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: createListUrl,
            data: { 'userID': userID },
        }).done(function (r) {
            $('#partial').html(r);
        }).fail(function (e) {
            console.log(e.responseText);
        });
    });

    let listCount = document.getElementById("boardlists").childElementCount;

    // Create card

    for (let i = 0; i < listCount; i++) {
        let listID = document.getElementsByName("hiddenlistid" + i)[0].value;

        $('#createCard' + i).on('click', function (e) {
            e.preventDefault();
            $.ajax({
                type: "POST",
                url: createCardUrl,
                data: { 'listid': listID, 'userID': userID },
            }).done(function (r) {
                $('#partial').html(r);
            }).fail(function (e) {
                console.log(e.responseText);
            });
        });
    }

    // View, edit and delete list

    for (let i = 0; i < listCount; i++) {
        // Get list id based on listCount

        let listID = document.getElementsByName("hiddenlistid" + i)[0].value;

        $('#vlist' + i).on('click', function (e) {
            e.preventDefault();
            $.ajax({
                type: "POST",
                url: viewListUrl,
                data: { 'listid': listID, 'userID': userID },
            }).done(function (r) {
                $('#partial').html(r);
            }).fail(function (e) {
                console.log(e.responseText);
            });
        });

        $('#elist' + i).on('click', function (e) {
            e.preventDefault();
            $.ajax({
                type: "POST",
                url: editListUrl,
                data: { 'listid': listID, 'userID': userID },
            }).done(function (r) {
                $('#partial').html(r);
            }).fail(function (e) {
                console.log(e.responseText);
            });
        });

        $('#dlist' + i).on('click', function (e) {
            e.preventDefault();
            $.ajax({
                type: "POST",
                url: deleteListUrl,
                data: { 'listid': listID, 'userID': userID },
            }).done(function (r) {
                $('#partial').html(r);
            }).fail(function (e) {
                console.log(e.responseText);
            });
        });
    }

    let totalCards = 0;

    // View, edit and delete card

    for (let i = 0; i < listCount; i++) {
        // CardElementsCount and listID

        let cardElementsCount = document.getElementById("list" + i).querySelectorAll("[id*='ls']").length;
        let listID = document.getElementsByName("hiddenlistid" + i)[0].value;

        for (let ii = 0; ii < cardElementsCount; ii++) {
            // Get cardID based on current list

            let cardID = document.getElementById("list" + i).querySelectorAll("[id^='hiddencardid']")[ii].value;

            $('#vcard' + totalCards).on('click', function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: viewCardUrl,
                    data: { 'cardID': cardID, 'listID': listID, 'userID': userID },
                }).done(function (r) {
                    $('#partial').html(r);
                }).fail(function (e) {
                    console.log(e.responseText);
                });
            });

            $('#ecard' + totalCards).on('click', function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: editCardUrl,
                    data: { 'cardID': cardID, 'listID': listID, 'userID': userID },
                }).done(function (r) {
                    $('#partial').html(r);
                }).fail(function (e) {
                    console.log(e.responseText);
                });
            });

            $('#dcard' + totalCards).on('click', function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: deleteCardUrl,
                    data: { 'cardID': cardID, 'listID': listID, 'userID': userID },
                }).done(function (r) {
                    $('#partial').html(r);
                }).fail(function (e) {
                    console.log(e.responseText);
                });
            });
            totalCards++;
        }
    }
}

function ChangeOrderOfCards() {
    let listLength = document.getElementById("boardlists").childElementCount;

    // Loop through list element

    for (let i = 0; i < listLength; i++) {
        // Loop through a list

        let listElement = document.getElementById("list" + i);
        let cards = listElement.querySelectorAll("[id*='ls']");

        for (let x = 0; x < cards.length; x++) {
            // Gather data from a single card

            listElement.querySelectorAll("[id*='ls']")[x].id = "ls" + i + "card" + x;

            listElement.querySelectorAll("[id^='hiddencardorderid']")[x].id = "hiddencardorderid" + x
            listElement.querySelectorAll("[id^='hiddencardorderid']")[x].value = x;

            listElement.querySelectorAll("[id^='hiddencardid']")[x].id = "hiddencardid" + x;
        }
    }
    GatherIDS();
}

function GatherIDS() {
    let listCollection = [];
    let listLength = document.getElementById("boardlists").childElementCount;

    // Loop through list

    for (let i = 0; i < listLength; i++) {

        // Gather list IDs

        let listElement = document.getElementById("list" + i);

        let listID = document.getElementsByName("hiddenlistid" + i)[0].value;
        let listOrderID = document.getElementsByName("hiddenlistorderid" + i)[0].value;

        let cardElementsCount = document.getElementById("list" + i).querySelectorAll("[id*='ls']").length;

        let hiddenCardIDS = [];
        let hiddenCardOrderIDS = [];

        //Loop through the cards in the list

        for (let ii = 0; ii < cardElementsCount; ii++) {

            //if (listElement.querySelectorAll("[id^='hiddencardid']")[ii]) {
                hiddenCardIDS.push(listElement.querySelectorAll("[id^='hiddencardid']")[ii].value);
            //}

            //if (listElement.querySelectorAll("[id^='hiddencardorderid']")[ii]) {
                hiddenCardOrderIDS.push(listElement.querySelectorAll("[id^='hiddencardorderid']")[ii].value);
            //}
        }

        let list = { ID: listID, orderID: listOrderID, cardIDs: hiddenCardIDS, cardOrderIDs: hiddenCardOrderIDS };

        listCollection.push(list);
    }

    let userID = document.getElementById("userID").value;

    $.ajax({
        type: "POST",
        traditional: true,
        url: reorderCardsUrl,
        data: { json: JSON.stringify({ allCardIDs: listCollection }), 'userID': userID }
    });
}

function reorderAllListsClick() {
    let listIDs = [];

    let lOCBChildren = document.getElementById("listsOfCurrentBoard").children;

    for (let i = 0; i < lOCBChildren.length; i++) {
        listIDs.push(lOCBChildren[i].children[1].value);
    }

    document.getElementById("json").value = JSON.stringify({ listIDs });
}