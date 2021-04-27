

var _newsFeedConnectionId = '';
  
const newsFeedConnection = new signalR.HubConnectionBuilder().withUrl("/newsFeedHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

newsFeedConnection.on("feed", function (userId, imageUrl, subject, content, device, createdText, attachedImage, attachedVideo, attachedAudio, attachedAudioType) {
    
    document.getElementById("messageInput").value = "";
    document.getElementById('imagesAttached').innerHTML = "";
    document.getElementById('videoAttached').innerHTML = "";
    document.getElementById('audioAttached').innerHTML = "";

    var msg = content.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    console.log("Feed sent to clients!");

    var media = document.createElement("div");
    media.classList.add("media-block");

    var anchor = document.createElement("a");
    anchor.setAttribute("href", "/Identity/Profile/Index?id=" + userId);
    anchor.classList.add("media-left");

    media.append(anchor);

    var image = document.createElement("img");
    image.classList.add("img-circle", "img-sm");
    image.setAttribute("alt", "Profile Picture");
    image.setAttribute("src", imageUrl);

    anchor.append(image);

    var mediabody = document.createElement("div");
    mediabody.classList.add("media-body");

    media.append(mediabody);

    var mediabodymargin = document.createElement("div");
    mediabodymargin.classList.add("mar-btm");

    mediabody.append(mediabodymargin);

    var mediabodyanchor = document.createElement("a");
    anchor.setAttribute("href", "/Identity/Profile/Index?id=" + userId);
    mediabodyanchor.classList.add("btn-link", "text-semibold", "media-heading", "box-inline");
    mediabodyanchor.innerHTML = subject;

    mediabodymargin.append(mediabodyanchor);

    var mediabodyCreatedText = document.createElement("p");
    mediabodyCreatedText.classList.add("text-muted", "text-sm");

    var icon = document.createElement("i");
    icon.classList.add("fa");
    if (device === "Mobile") {
        icon.classList.add("fa-mobile");
    } else if (device === "Web") {
        icon.classList.add("fa-globe");
    }
    icon.classList.add("fa-lg");

    mediabodyCreatedText.append(icon);
    mediabodyCreatedText.innerHTML = "From " + device + " " + createdText;

    mediabodymargin.append(mediabodyCreatedText);

    var mediabodyContent = document.createElement("p");
    mediabodyContent.innerHTML = msg;

    mediabody.append(mediabodyContent);

    if (attachedImage.length > 0) {
        var imageUpload = document.createElement("img");
        imageUpload.classList.add("img-responsive");
        imageUpload.setAttribute("alt", "Profile Picture");
        imageUpload.style.width = '100%';
        imageUpload.setAttribute("src", attachedImage);

        mediabody.append(imageUpload);
    }
    if (attachedVideo.length > 0) {
        var iframeUpload = document.createElement("iframe");
        iframeUpload.style.width = '100%';
        iframeUpload.id = "randomid_"+id;
        iframeUpload.setAttribute("src", attachedVideo);

        mediabody.append(iframeUpload);
    }
    if (attachedAudio.length > 0) {
        var sound = document.createElement("audio");
        sound.id = 'audio-player_'+id;
        sound.controls = 'controls';
        sound.src = attachedAudio;
        sound.type = attachedAudioType;

        mediabody.append(sound);
    }

    var bodyFooter = document.createElement("div");
    bodyFooter.classList.add("pad-ver");

    var buttonGroup = document.createElement("div");
    buttonGroup.classList.add("btn-group");

    var mediafooteranchor = document.createElement("a");
    mediafooteranchor.setAttribute("href", "/Home/ComingSoon");
    mediafooteranchor.classList.add("btn", "btn-sm", "btn-default", "btn-hover-primary");

    var thumbsUpIcon = document.createElement("i");
    thumbsUpIcon.classList.add("fa", "fa-thumbs-up");

    mediafooteranchor.append(thumbsUpIcon);

    buttonGroup.append(mediafooteranchor);

    var mediafooteranchor2 = document.createElement("a");
    mediafooteranchor2.setAttribute("href", "/Home/ComingSoon");
    mediafooteranchor2.classList.add("btn", "btn-sm", "btn-default", "btn-hover-primary");

    var thumbsDownIcon = document.createElement("i");
    thumbsDownIcon.classList.add("fa", "fa-thumbs-down");

    buttonGroup.append(mediafooteranchor2);

    mediafooteranchor2.append(thumbsDownIcon);

    bodyFooter.append(buttonGroup);

    var mediafooteranchor3 = document.createElement("a");
    mediafooteranchor3.setAttribute("href", "/Home/ComingSoon");
    mediafooteranchor3.classList.add("btn", "btn-sm", "btn-default", "btn-hover-primary");
    mediafooteranchor3.innerHTML = "Comment";

    bodyFooter.append(mediafooteranchor3);

    mediabody.append(bodyFooter);

    var bottomline = document.createElement("hr");
    mediabody.append(bottomline);

    document.getElementById("newsFeedHolder").prepend(media);
});

newsFeedConnection.start().then( async function () {
    _newsFeedConnectionId = await newsFeedConnection.invoke("GetConnectionId");
    console.log(_newsFeedConnectionId);
    document.getElementById("sendButton").disabled = false;
    joinGroup();
}).catch(function (err) {
    return console.error(err.toString());
});

var joinGroup = function () {
    var url = '/Feeds/Home/JoinFriendGroup/' + _newsFeedConnectionId.toString();
    axios.post(url, null)
        .then(res => {
            console.log("Friend List Joined!", res);
        })
        .catch(err => {
            console.log("Failed to Friend List!", res);
        });
}


var sendFeed = function () {
    event.preventDefault();
    var data = new FormData(event.target);

    axios.post('/Feeds/Home/SharePublicFeed', data)
        .then(res => {
            console.log("feed posted");
        })
        .catch(err => {
            console.log("It aint working");
        });
}

var sendPrivateFeed = function () {
    event.preventDefault();
    var data = new FormData(event.target);

    axios.post('/Feeds/Home/SharePrivateFeed', data)
        .then(res => {
            console.log("private feed posted");
        })
        .catch(err => {
            console.log("It aint working");
        });
}

function clickLike(id, count) {
    var url = '/Feeds/Home/Like/' + id.toString();
    var newCount = parseInt(count);
    axios.post(url, null)
        .then(res => {
            var dislikebtn = document.getElementById("dislikeButton_" + id);
            if (dislikebtn.classList.contains("active")) {
                dislikebtn.classList.remove("active");
                dislikebtn.innerHTML = '<i class="fa fa-thumbs-down"></i>';
                newCount = newCount + 1;
            }

            var likebtn = document.getElementById("likeButton_" + id);
            if (likebtn.classList.contains("active")) {
                likebtn.classList.remove("active");
                likebtn.innerHTML = '<i class="fa fa-thumbs-up"></i>';
                newCount = newCount - 1;
            } else {
                likebtn.classList.add("active");
                likebtn.innerHTML = '<i class="fa fa-thumbs-up"></i> You Liked it';
                newCount = newCount + 1;
            }

            var spanclass = document.getElementById("countlikespan_" + id);
            if (newCount === 0) {
                if (spanclass.classList.contains("tag")) {
                    spanclass.classList.remove("tag", "tag-sm");
                }
                spanclass.innerHTML = "";
            }
            if (newCount === 1) {
                if (spanclass.classList.contains("tag")) {
                } else {
                    spanclass.classList.add("tag", "tag-sm");
                }
            }
            if (newCount > 1) {
                spanclass.innerHTML = '<i class="fa fa-heart text-danger"></i> ' + newCount + 'Likes';
            }


        })
        .catch(err => {
            console.log("Failed to Friend List!", err);
        });
}

function clickDislike(id, count) {
    var url = '/Feeds/Home/Dislike/' + id.toString();
    var newCount = parseInt(count);
    axios.post(url, null)
        .then(res => {
            var likebtn = document.getElementById("likeButton_" + id);
            if (likebtn.classList.contains("active")) {
                likebtn.classList.remove("active");
                likebtn.innerHTML = '<i class="fa fa-thumbs-up"></i>';
                newCount = newCount - 1;
            }

            var dislikebtn = document.getElementById("dislikeButton_" + id);
            if (dislikebtn.classList.contains("active")) {
                dislikebtn.classList.remove("active");
                dislikebtn.innerHTML = '<i class="fa fa-thumbs-down"></i>';
                newCount = newCount + 1;
            } else {
                dislikebtn.classList.add("active");
                dislikebtn.innerHTML = '<i class="fa fa-thumbs-down"></i> You Disliked it';
                newCount = newCount - 1;
            }

            var spanclass = document.getElementById("countlikespan_" + id);
            if (newCount === 0) {
                if (spanclass.classList.contains("tag")) {
                    spanclass.classList.remove("tag", "tag-sm");
                }
                spanclass.innerHTML = "";
            }
            if (newCount === 1) {
                if (spanclass.classList.contains("tag")) {
                } else {
                    spanclass.classList.add("tag", "tag-sm");
                }
            }
            if (newCount > 1) {
                spanclass.innerHTML = '<i class="fa fa-heart text-danger"></i> ' + newCount + 'Likes';
            }


        })
        .catch(err => {
            console.log("Failed to Friend List!", err);
        });
}

function getVideoFile() {
    document.getElementById("videoUpload").click();
}

function getImageFile() {
    document.getElementById("imageUpload").click();
}

function getFile() {
    document.getElementById("fileUpload").click();
}

function getAudioFile() {
    document.getElementById("audioUpload").click();
}

function ShowCreateCommentModal(ff) {

    var url = "/Feeds/Home/CreateComment?parentId=" + ff;

    $("#ModalPlaceHolder").load(url,
        function () {
            $("#ModalPlaceHolder").modal("show");
        });
}

function ShowEditCommentModal(ff) {

    var url = "/Feeds/Home/EditComment?id=" + ff;

    $("#ModalPlaceHolder").load(url,
        function () {
            $("#ModalPlaceHolder").modal("show");
        });
}

function ShowDeleteModal(ff) {

    var url = "/Feeds/Home/DeleteComment?id=" + ff;

    $("#ModalPlaceHolder").load(url,
        function () {
            $("#ModalPlaceHolder").modal("show");
        });
}

var loadImage = function (event) {
    var output = document.getElementById('imagesAttached');

    output.innerHTML = "";

    var avatar = document.createElement("img");
    avatar.style.width = '200px';
    avatar.src = URL.createObjectURL(event.target.files[0]);
    avatar.alt = event.target.files[0].Name;
    output.appendChild(avatar);
};

var loadVideo = function (event) {
    var output = document.getElementById('videoAttached');

    output.innerHTML = "";

    var iframe = document.createElement('iframe');
    iframe.frameBorder = 0;
    iframe.width = '300px';
    iframe.height = '250px';
    iframe.id = "randomid";
    iframe.setAttribute("src", URL.createObjectURL(event.target.files[0]));

    output.appendChild(iframe);
};

var loadAudio = function (event) {
    var output = document.getElementById('audioAttached');

    output.innerHTML = "";

    var holder = document.createElement('div');
    holder.classList.add("alert", "alert-info", "media", "fade", "in");
    holder.style.padding = '5px';
    holder.innerHTML = '<i class="fa fa-close"></i><strong>Audio File Added!</strong> You successfully added: ' + event.target.files[0].name;

    output.appendChild(holder);
};