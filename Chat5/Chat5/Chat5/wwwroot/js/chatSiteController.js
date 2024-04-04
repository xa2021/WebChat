var ChatSiteController = function (chatSiteService) {

    var isDoneGetMessage = function (response) {
       var inputArea = document.querySelector('.right-panel-conversations');
        inputArea.innerHTML = response;
        scrollToBottom(inputArea)
    }
    const scrollToBottom = (element) => {    
        element.scrollTop = element.scrollHeight;
    }

    var isDoneGetConversation = function (response) {

        var inputArea = document.querySelector('.modal-contacts-list');
        inputArea.innerHTML = response;
    }
    var isDoneCreateConversation = function (response) {
              
        var inputArea = document.querySelector('.left-panel-conversations-list');
        $(response).prependTo(inputArea)      
        var clickImitation =  document.querySelector('.left-panel-conversations-list li:nth-child(1) > a');
        clickImitation.click();            
        $('#exampleModalCenter').modal('hide');
    }

    var isFailGetMessage = function () {
        console.log('nie udało się');
    }
    var isFailGetContact = function () {
        console.log('nie udało się');
    }
    var isFailCreateNewConversation = function () {
        console.log('nie udało się');
    }
    var isFailSearchConversation= function () {
        console.log('nie udało się');
    }  
    var isFailPushMessage = function () {
        console.log('nie udało się');
    }
    var isSuccessSearchConversation = function (response) {

        var input = document.querySelector('.left-panel-conversations');


        input.innerHTML = response;
    }


    //hub -- signalr

    var pushOkMessage = function (response) {           

        conCon.invoke("MessageInformationBold", { conversationId: clickedElementWithContact })

        conCon.invoke("SendMessage", {
            currentLog: response.userCurrentLog,
            conversationId: response.message.conversationId,
            from: response.message.from,
            name: response.message.name,
            sentDateTime: response.message.sentDateTime,
            text: response.message.text
        })
    }
 


    var clickedElementWithContact = null;
    var conCon;
    var init = function () {

        var connectionsHub = () => {
            var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

            connection.on("BoldConversationName", getMessage => {
                if (clickedElementWithContact != getMessage.conversationId) {
                    var aa = document.querySelector(`[data-conversationid="${getMessage.conversationId}"]`)
                    aa.classList.add('addNeedReadText')
                }                     
                
            })

            connection.on("ReceivedMessage", message => {

                console.log(message)
                var containerMessage = document.querySelector('.messages-container > ul');

                if (message.conversationId === clickedElementWithContact.toString()) {
                    var x;
                    let date = new Date(message.sentDateTime)
                    let options = {
                        year: '2-digit',
                        month: '2-digit',
                        day: '2-digit',
                        hour: '2-digit',
                        minute: '2-digit',
                        second: '2-digit'

                    };
                    let formattedDate = date.toLocaleString(undefined, options);             

                    if (message.from == message.currentLog) {


                        x = `<li class="right">
                                <div class="message-right-container">
                                    <div>
                                        <i class='bx bxs-user'></i>
                                    </div>
                                    <div class="chat-right-window">
                                        <p class="chat-right-name"> ${message.name}</p>
                                        <p class="chat-right-window-message">
                                            ${message.text}
                                        </p>
                                        <p class="chat-right-date"> ${formattedDate} </p>
                                    </div>
                                </div>
                            </li>`;
                           }

                    //else {
                    //    x = `<li class="left">
                    //            <div class="message-left-container">
                    //                <div>
                    //                    <i class='bx bxs-user'></i>
                    //                </div>
                    //                <div class="chat-window">
                    //                    <p class="chat-name"> ${message.name}</p>
                    //                    <p class="chat-window-message">
                    //                        ${message.text}
                    //                    </p>
                    //                    <p class="chat-date"> ${message.sentDateTime} </p>
                    //                </div>
                    //            </div>
                    //        </li>`;
                    //}
                                       
                                             
                                  

                    $(x).appendTo(containerMessage);   
                    var inputArea = document.querySelector('.right-panel-conversations');                  
                    scrollToBottom(inputArea)

                    console.log('dodano')

                }
            })


            connection.start().catch(function (err) {
                return console.error(err.toString());
            })

            return connection;
        }

         conCon = connectionsHub();

        //konwersacje
        $('.left-panel-conversations').on('click', '.conversationItem',async function () {

            if (this.classList.contains('addNeedReadText'))
            {               
                this.classList.remove('addNeedReadText')
            }

            var elementWithClass = document.querySelector('.activeBtn-select-leftContacts');
            if (elementWithClass != null) {
                elementWithClass.classList.remove('activeBtn-select-leftContacts')
            }            
           $(this).parent().addClass('activeBtn-select-leftContacts');;                  
            var inputArea = document.querySelector('.right-panel-conversations');
            inputArea.innerHTML = "";
            var conversId = $(this).attr('data-conversationid')    
            if (conversId != null) {
                clickedElementWithContact = conversId;
              await   chatSiteService.getMessageToConversation(conversId,isDoneGetMessage,isFailGetMessage);
            }
        })

        //znajdz kontakty
        $('.add-conversation').on('click',async  function () {

            $('#exampleModalCenter').modal('show');

            await chatSiteService.getContactsToConversation(isDoneGetConversation,isFailGetContact);
        });

        //zapisz modal i dodaj do bazy elementy


        $(".modal-contacts-list-accept").on('click', async function (e) {
            var contactIdList = [];
            var elementsList = document.querySelectorAll('.modal-contact-elementsList');
            var inputElement = $('.modal-contact-elementInput').val();                   
            
            for (var i = 0; i < elementsList.length; i++) {

                if (elementsList[i].checked == true){
                    var id = elementsList[i].getAttribute("data-contactid")
                    contactIdList.push(id);                    
                }
            }
            
            if (contactIdList.length > 0) { 

                if (contactIdList.length == 1) {
                  
                    await chatSiteService.createNewChatWithUsers(contactIdList, inputElement, isDoneCreateConversation,isFailCreateNewConversation);
                } else
                {
                    alertify.error("Wprowadz nazwę grupy").dismissOthers()
                }              
            } else {
                alertify.error("Wybierz rozmówcę").dismissOthers()
            }              
        })

        // wyślij wiadomosć

        $('.right-bottom-text-messageSendMessaage').on('click',async function () {

            if (clickedElementWithContact != null) {

                var text = document.querySelector('.right-bottom-text-messageInput').value;

                if (text.length > 0) {

                    await chatSiteService.addMessage(clickedElementWithContact, text, pushOkMessage, isFailPushMessage);

                    document.querySelector('.right-bottom-text-messageInput').value = "";
                }
            } else {
                alertify.error('Nie wybrano rozmócy.').dismissOthers();
            }           
        })

        //szukanie kontaktu

        document.querySelector('.search-conversation').addEventListener('input', function (event) {
            const searchTerm = event.target.value.toLowerCase();

            if (searchTerm.length >= 3) {               
                chatSiteService.searchConversation(searchTerm, isSuccessSearchConversation, isFailSearchConversation);
            }
            if (searchTerm.length == 0) {                
                chatSiteService.searchConversation(searchTerm, isSuccessSearchConversation, isFailSearchConversation);
            }
        });        

    }  




    return {
        init: init
    }


}(ChatSiteService)