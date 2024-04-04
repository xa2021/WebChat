var ChatSiteService = function () {


    var getMessageToConversation = async function (conversationId,done,fail) {
        $.ajax({
            type: "POST",
            url: "Partial/Message",
            contentType: "application/json",
            data: JSON.stringify({ conversationId: conversationId })
        })
            .done(done)
            .fail(fail)
    }

    var getContactsToConversation = async function (done, fail) {
        $.ajax({
            type: "POST",
            url: "Partial/GetUsersToNewConversation",                      
        })
            .done(done)
            .fail(fail)
    }


    var createNewChatWithUsers = async function (contactIdList, inputElement, done, fail) {
        $.ajax({
            type: 'POST',
            url: "Partial/CreateNewChat",
            contentType: "application/json",
            data: JSON.stringify({ contactIdList: contactIdList, inputElement: inputElement })
        })
            .done(done)
            .fail(fail)


    }
    var addMessage = async function (conversationId,text,done,fail) {
        $.ajax({
            type: "POST",
            url: "api/HomeApi/AddNewMessage",
            contentType: "application/json",
            data: JSON.stringify({ conversationId: conversationId , text:text})
        })
            .done(done)
            .fail(fail)
    }

    var searchConversation = async function (query,done,fail) {
        $.ajax({
            type: "POST",
            url: "Partial/SearchConversation",
            contentType: "application/json",
            data: JSON.stringify({query:query})
        })
            .done(done)
            .fail(fail)
    }
 


    return {
        getMessageToConversation: getMessageToConversation,
        getContactsToConversation: getContactsToConversation,
        createNewChatWithUsers: createNewChatWithUsers,
        addMessage: addMessage,
        searchConversation: searchConversation
     
    }
}();