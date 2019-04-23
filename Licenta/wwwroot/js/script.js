function showElement(clicked_id) {
    var x;
    if (clicked_id === "btnAddPref") {
        x = document.getElementsByClassName("formStudentPref");
        if (x[0].style.display === "none")
            x[0].style.display = "block";
        else
            if (x[0].style.display === "block")
                x[0].style.display = "none";
    }
    if (clicked_id === "btnShowDormPref") {
        x = document.getElementById("dormPref");
        if (x.style.display === "none")
            x.style.display = "block";
    }
    if (clicked_id === "btnShowRoommatePref") {
        x = document.getElementById("roommatesPref");
        if (x.style.display === "none")
            x.style.display = "block";
    }
    else if (clicked_id === "btnAdd1PrefRoom") {
        x = document.getElementById("room1Pref");
        if (x.style.display === "none")
            x.style.display = "block";
    }

    else if (clicked_id === "btnAdd2DormPref") {
        x = document.getElementById("2DormPref");
        if (x.style.display === "none")
            x.style.display = "block";
    }
    else if (clicked_id === "btnAdd2PrefRoom") {
        x = document.getElementById("room2Pref");
        if (x.style.display === "none")
            x.style.display = "block";
    }

    else if (clicked_id === "btnAdd3DormPref") {
        x = document.getElementById("3DormPref");
        if (x.style.display === "none")
            x.style.display = "block";
    }
    else if (clicked_id === "btnAdd3PrefRoom") {
        x = document.getElementById("room3Pref");
        if (x.style.display === "none")
            x.style.display = "block";
    }

    else if (clicked_id === "btnAdd4DormPref") {
        x = document.getElementById("4DormPref");
        if (x.style.display === "none")
            x.style.display = "block";
    }
    else if (clicked_id === "btnAdd4PrefRoom") {
        x = document.getElementById("room4Pref");
        if (x.style.display === "none")
            x.style.display = "block";
    }

    else if (clicked_id === "btnAdd5DormPref") {
        x = document.getElementById("5DormPref");
        if (x.style.display === "none")
            x.style.display = "block";
    }
    else if (clicked_id === "btnAdd5PrefRoom") {
        x = document.getElementById("room5Pref");
        if (x.style.display === "none")
            x.style.display = "block";
    }

    function showHideForm() {
        var x = document.getElementsByClassName("formAdmin");
        if (x[0].style.display === "none")
            x[0].style.display = "block";
        else
            if (x[0].style.display === "block")
                x[0].style.display = "none";
    }
    function showFormDD() {
        var x = document.getElementById("formDD");
        if (x.style.display === "none")
            x.style.display = "block";
    }