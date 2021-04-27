$('.nano-content').scrollTop(9999999);

function updateScroll() {
    $('.nano-content').scrollTop(9999999);
}

var _connectionId = '';

const connection1 = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection1.on("ReceiveMessage", function (user, message, imageUrl, timeValue, name) {

    document.getElementById("messageInput").value = "";

    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    var li = document.createElement("li");
    li.classList.add("mar-btm");

    var avatarHolder = document.createElement("div");
    var userIdd = document.getElementById("userInput").value;

    if (user === userIdd) {
        avatarHolder.classList.add("media-left");
    } else {
        avatarHolder.classList.add("media-right");
    }
    var avatar = document.createElement("img");
    avatar.classList.add("img-circle", "img-sm");
    avatar.src = imageUrl;
    avatar.alt = "Profile Image";
    avatarHolder.appendChild(avatar);
    li.appendChild(avatarHolder);

    var bubble = document.createElement("div");
    bubble.classList.add("media-body", "pad-hor");
    if (user !== userIdd) {
        bubble.classList.add("speech-right");
    } 
    var speech = document.createElement("div");
    speech.classList.add("speech");

    var anchor = document.createElement("a");
    anchor.classList.add("media-heading");
    anchor.innerHTML = name;
    speech.appendChild(anchor);

    var message = document.createElement("p");
    message.innerHTML = msg;
    speech.appendChild(message);

    var time = document.createElement("p");
    time.classList.add("speech-time");
    var icon = document.createElement("i");
    icon.classList.add("fa", "fa-clock-o", "fa-fw");
    time.append(icon);
    time.append(timeValue);
    speech.appendChild(time);

    bubble.appendChild(speech);
    li.append(bubble);

    //li.textContent = msg;
    document.getElementById("messagesList").appendChild(li);

    if (user !== userIdd) {
        var audio = new Audio('/audio/piece-of-cake.mp3');
        audio.play();
    }

    updateScroll();
});

connection1.start().then( async function () {
    _connectionId = await  connection1.invoke("GetConnectionId");
    console.log(_connectionId);
    document.getElementById("sendButton").disabled = false;
    joinRoom();
}).catch(function (err) {
    return console.error(err.toString());
});

var joinRoom = function () {
    var url = '/Chats/Chat/JoinChat/' + _connectionId.toString() + "/" + document.getElementById("roomName").value;
    axios.post(url, null)
        .then(res => {
            console.log("Room Joined!", res);
        })
        .catch(err => {
            console.log("Failed to Join Roon!", res);
        });
}

var sendMessage = function () {
    event.preventDefault();
    var data = new FormData(event.target);

    axios.post('/Chats/Chat/SendMessage', data)
        .then(res => {
            console.log("message sent");
        })
        .catch(err => {
            console.log("It aint working");
        });
}

function ShowCreateChatModal() {

    var url = "/Chats/Home/CreateChat";

    $("#ModalPlaceHolder").load(url,
        function () {
            $("#ModalPlaceHolder").modal("show");
        });
}