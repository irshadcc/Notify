"use strict";

(() => { // Restrict the scope of the variables to this file
    const selection = window.getSelection();
    const selectionString = selection.toString();

    if (selectionString) { // If there is text selected

        let container = selection.getRangeAt(0).commonAncestorContainer;

        // Sometimes the element will only be text. Get the parent in that case
        // TODO: Is this really necessary?
        while (!container.innerHTML) {
            container = container.parentNode;
        }
        let request = {
            action : 'save_to_database',
            message : {
                title : window.document.title,
                selection : selectionString,
                container : container ,
                url : window.location.hostname + window.location.pathname,
            }
        }
        chrome.storage.sync.get('color', (values) => {
            const color = values.color;

            request.message.color = color ;
            store(selection, container, window.location.hostname + window.location.pathname, color, (highlightIndex) => {
                highlight(selectionString, container, selection, color, highlightIndex);
            });
            chrome.runtime.sendMessage('',request,function(response){
                console.log("Sent message to background.js",response)
            })

           
        });
    }
    document.addEventListener('go-to-source',function(event){


        let noteElem = document.head.lastChild ;
        let request = {}
        request.action = "open_new_tab" 
        request.message = JSON.parse(noteElem.textContent)
        console.log("Event : Open new tab",request.message.url)
        chrome.runtime.sendMessage(request)

    })

})();
