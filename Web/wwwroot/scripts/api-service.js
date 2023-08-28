
export class ApiService {

    static loadUsers( successFunction ) {
        ApiService.makeGetRequest( "user", successFunction )
    }

    static removeUser( userId, successFunction ) {
        ApiService.makeGetRequest( `user/${userId}/remove`, successFunction )
    }

    static addUser( userName, userAge, successFunction ) {
        ApiService.makePostRequest( `user`, { name: userName, age: userAge }, successFunction )
    }
    
    static makeGetRequest( requestUrl, successFunction ) {
        $.ajax({
            method: "GET",
            url: requestUrl,
        }).done( successFunction );
    }

    static makePostRequest( requestUrl, data, successFunction ) {
        $.ajax({
            method: "POST",
            contentType: "application/json",
            url: requestUrl,
            data: JSON.stringify(data)
        }).done( successFunction );
    }
}