import {ApiService} from "./api-service.js";

let userCardTemplate = document.getElementById("user-card-template");
let userCardsContainer = document.getElementById("users-list-container");

function reloadUsersList() {
    let userCards = [];
    
    ApiService.loadUsers( (response) => {

        for (let user of response) {
            let card = userCardTemplate.innerHTML;
            
            card = card.replaceAll("{name}", user.name);
            card = card.replaceAll("{age}", user.age);
            card = card.replaceAll("{userId}", user.id);
            
            card = `<div class="user-card">${card}</div>>`

            userCards.push( card );
        }

        userCardsContainer.innerHTML = userCards.join();
    } );
}


function removeUser( userId ) {
    ApiService.removeUser( userId, reloadUsersList )
}

function addUser() {
    const userName = $("#username-input").val();
    const userAge = $("#age-input").val();
    
    ApiService.addUser( userName, userAge, reloadUsersList )
}

window.removeUser = removeUser;
window.addUser = addUser;


reloadUsersList();