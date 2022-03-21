
let books = []

let Book = function (pTitle, pGenre, pYear) {
    this.Id = Math.random().toString(16).slice(5)  // tiny chance could get duplicates!
    this.Title = pTitle;
    this.Genre = pGenre;
    this.Year = pYear;
}

// books.push(new Book("Ender's Game","SiFI", "1985" ));
// books.push(new Book("The Wind-Up Bird Chronicle", "Fantasy", "1997" ));
// books.push(new Book("The Dark Tower", "Fantasy", "1982" ));

document.addEventListener("DOMContentLoaded", function () {
    RefreshList();
});

function RefreshList() {
    let myul = document.getElementById("bookList");
    while (myul.firstChild) {    // remove any old data so don't get duplicates
        myul.removeChild(myul.firstChild);
    };

    // go get the data from the server
    // need to insert api to wake up the server API path
    // need Book as this is a route,
    // node could have been
    // index
    // users
    // book
    $.get("api/Book", function (data, status) {  // AJAX get
        books = data;  // put the returned server json data into our local array

        // sort by priority
        books.sort(function (a, b) {
            return (a.year) - (b.year);
        });
        books.forEach(function (item) {
            let myli = document.createElement('li');
            myli.classList.add('list-group-item');
            myli.innerHTML = item.Id + ":  " + item.Title + ":  " + item.Genre + ":  " + item.Year;
            myul.appendChild(myli);
        });
    })

}

// finds object in array based on a item's property
function indexOfbyKey(obj_list, key, value) {
    for (index in obj_list) {
        if (obj_list[index][key] === value) return index;
    }
    return -1;
}

// find does not really have to make a server call, as we are keeping 
// the client side array consistent with the Server side array
function find() {
   
    let searchId = document.getElementById("SearchId").value

    // searching local
    //  let found = "Success";
    //const indexOfBook = indexOfbyKey(books, "Id", searchId);
    //if (indexOfBook < 0) {
    //    alert("No such book");
    //}
    //    else {
    //    document.getElementById("editTitle").value = books[indexOfBook].Title;
    //    document.getElementById("editGenre").value = books[indexOfBook].Genre;
    //    document.getElementById("editYear").value = books[indexOfBook].Year;
    //}

    $.getJSON("api/Book/" + searchId)
        .done(function (data) {
            document.getElementById("editTitle").value = data.Title;
            document.getElementById("editGenre").value = data.Genre;
            document.getElementById("editYear").value = data.Year;
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('Error: Book with ID of ' + searchId + ' not found');
        });





}

function updateItem() {
    let title = document.getElementById("editTitle").value
    let genre = document.getElementById("editGenre").value
    let year = document.getElementById("editYear").value
    let newBook = new Book(title, genre, year);
    let searchId = document.getElementById("SearchId").value
    newBook.Id = searchId;  // don't want to change the Id, so overwrite constructor's

    $.ajax({
        url: "api/Book/" + searchId,
        type: "PUT",
        data: JSON.stringify(newBook),
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            alert(result);
            RefreshList();  // will update local array as well
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }
    });
   
}



function deleteItem() {
    let which = document.getElementById("deleteId").value
    console.log(which);
    $.ajax({
        type: "DELETE",
        url: "api/Book/" + which,
        success: function (response) {
            alert(response);
            document.getElementById("deleteId").value = "";
            RefreshList();  // will update local array as well, needs to be in the anom function
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Server could not delete Book with Id " + which)
        }
    });

   
};




function addItem() {
    let title = document.getElementById("newTitle").value
    let genre = document.getElementById("newGenre").value
    let year = document.getElementById("newYear").value
    let newBook = new Book(title, genre, year);

    $.ajax({
        url: "api/Book",
        type: "POST",
        data: JSON.stringify(newBook),
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            alert(result + " was added");
            RefreshList();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }
    });



  
};