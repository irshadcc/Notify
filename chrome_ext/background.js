"use strict";

var firebaseConfig = {
    apiKey: "AIzaSyCDEIkb3liTJxSdPi0wQ76Xq1YJ0jx8D6I",
    authDomain: "biblography-6adfa.firebaseapp.com",
    databaseURL: "https://biblography-6adfa.firebaseio.com",
    projectId: "biblography-6adfa",
    storageBucket: "biblography-6adfa.appspot.com",
    messagingSenderId: "192403779073",
    appId: "1:192403779073:web:3ab4c8d77df20091cc5a00",
    measurementId: "G-SB2KC6FQCN"
};

//Firebase Login and Update 


firebase.initializeApp(firebaseConfig);
var db = firebase.firestore()
var auth = firebase.auth()

var noteBookID = ''
var notesID = ''
var noteBooks = []
var notes = []


auth.signInWithEmailAndPassword('test_user_1@gmail.com', 'password')
    .then((res) => {

        const user_notebooks_ref = db.collection('notebooks')
                            .doc(auth.currentUser.uid)
                            .collection('user_notebooks')
        const user_notes_ref = db.collection('notes')
                            .doc(auth.currentUser.uid)
                            .collection('user_notes')

        user_notebooks_ref.onSnapshot(serverUpdate => {

            noteBooks = serverUpdate.docs.map(_doc => {
                const data = _doc.data();
                data['id'] = _doc.id;
                return data;
            });
            console.log("Event : Server Update Notebooks",noteBooks)
            chrome.runtime.sendMessage({action : 'update_notebooks_dom'},(response)=>{
                console.log("Event : Popup.js - ",response)
            })
        });
        
        user_notes_ref.onSnapshot( (serverUpdate) => {
            console.log("Event : Server update notes ",serverUpdate)

            notes = serverUpdate.docs.map( _doc => {
                const data = _doc.data() ;
                data['id'] = _doc.id ;
                return data 
            })
            // notes = notes.filter((note)=>  note.noteBookID == noteBookID )
            console.log("Event : Server Update Notes",notes)
            chrome.runtime.sendMessage({action : 'update_notes_dom'},(response)=>{
                console.log("Event : Popup.js - ",response)
            })
        })

    })
    .catch(function (error) {

        console.error(error.code, error.message)
    })

// Add option when right-clicking
chrome.contextMenus.create({
    title: "Highlight",
    onclick: highlightText,
    contexts: ["selection"]
});

chrome.contextMenus.create({
    title: "Toggle Cursor",
    onclick: toggleHighlighterCursorFromContext
});
chrome.contextMenus.create({
    title: "Highlighter color",
    id: "highlight-colors"
});
chrome.contextMenus.create({
    title: "Yellow",
    id: "yellow",
    parentId: "highlight-colors",
    type: "radio",
    onclick: changeColorFromContext
});
chrome.contextMenus.create({
    title: "Cyan",
    id: "cyan",
    parentId: "highlight-colors",
    type: "radio",
    onclick: changeColorFromContext
});
chrome.contextMenus.create({
    title: "Lime",
    id: "lime",
    parentId: "highlight-colors",
    type: "radio",
    onclick: changeColorFromContext
});
chrome.contextMenus.create({
    title: "Magenta",
    id: "magenta",
    parentId: "highlight-colors",
    type: "radio",
    onclick: changeColorFromContext
});

// Get the initial color value
chrome.storage.sync.get('color', (values) => {
    var color = values.color ? values.color : "yellow";
    chrome.contextMenus.update(color, {
        checked: true
    });
});

// Add Keyboard shortcut
chrome.commands.onCommand.addListener(function (command) {
    if (command === "execute-highlight") {
        trackEvent('highlight-source', 'keyboard-shortcut');
        highlightText();
    }
});

// Listen to messages from content scripts
chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    if (request.action && request.action == 'highlight') {
        trackEvent('highlight-source', 'highlighter-cursor');
        highlightText();
    }
    if (request.action && request.action == 'track-event') {
        if (request.trackCategory && request.trackAction) {
            trackEvent(request.trackCategory, request.trackAction)
        }
    }
    if (request.action && request.action == "save_to_database") {
        save_to_database(request.message);

    }
    if (request.action && request.action == "open_new_tab"){
        handle_open_new_tab(request.message)

    }
   

});


async function getNotebooks() {

    console.log("Event : Manual Fetch Notebooks")

    noteBooks = db.collection('notebooks')
                            .doc(auth.currentUser.uid)
                            .collection('user_notebooks')
                            .get()
                            .then((serverUpdate)=>{
                                const notebook = serverUpdate.docs.map(_doc => {
                                    const data = _doc.data() 
                                    data['id'] = _doc.id
                                    return data 
                                })
                                return notebook
                            })
    return noteBooks
}

async function getNotes() {
    console.log("Event : Manual Fetch Notes")
    notes = db.collection('notes')
                .doc(auth.currentUser.uid)
                .collection('user_notes')
                .get()
                .then((serverUpdate)=>{
                    const note = serverUpdate.docs.map( _doc => {
                        const data = _doc.data() 
                        data['id'] = _doc.id
                        return data 
                    })
                })
    return notes
}

function save_to_database(message) {

    // let request = {
    //     message : {
    //         selection : selection,
    //         container : container ,
    //         url : window.location.hostname + window.location.pathname,
    //         color : color 
    //     }
    // }

    let body = `
            <div class="ext-note">
                <p>${message.selection}</p>
                <a href="${message.url}">${message.url}</a> 
            </div>
    `




    if (noteBookID != '') {

        let new_note = {
            title: message.title,
            notebookID: noteBookID,
            timestamp: firebase.firestore.FieldValue.serverTimestamp(),
            body: body,
            tags: [],
            url: message.url

        }
        console.log("Event : Save a new note database",new_note)
        db.collection('notes')
            .doc(auth.currentUser.uid)
            .collection('user_notes')
            .add(new_note)

        // if(notesID == ''){

        //     console.log("Event : Save a new note database",new_note)
        //     db.collection('notes')
        //         .doc(auth.currentUser.uid)
        //         .collection('user_notes')
        //         .add(new_note)


        // } else {

        //     let old_note = notes.filter((note)=> note.id == notesID)
        //     old_note.body += new_note.body
        //     db.collection('notes')
        //         .doc(auth.currentUser.uid)
        //         .collection('user_notes')
        //         .doc(old_note.id)
        //         .update(old_note)

        //     console.log("Event : Appended a note ",old_note)

            
        // }
        
    } else {
        console.log('Notebook not selected', noteBookID)

    }

}


/*
Background JS Utility Functions

*/


function handle_open_new_tab(message){

    chrome.tabs.create({url:message.url}, function(tab){
        console.log("Event : New Tab Opened",tab)
    })

}

function changeNotesId(newNoteID){
    
    console.log("Event : Change Notes ID",newNoteID)
    notesID = newNoteID

}

function changeNotebookId(noteBookId) {

    console.log("Event : Change Notebook ID",noteBookId)
    noteBookID = noteBookId;
}

// function highlightTextFromContext() {
//     trackEvent('highlight-source', 'context-menu');
//     // chrome.tabs.executeScript({
//     //     file: 'contentScripts/highlight.js'
//     // })
//     highlightText();
// }

function highlightText() {
    trackEvent('highlight-action', 'highlight');
    chrome.tabs.executeScript({
        file: 'contentScripts/highlight.js'
    });
}

function toggleHighlighterCursorFromContext() {
    trackEvent('toggle-cursor-source', 'context-menu');
    toggleHighlighterCursor();
}

function toggleHighlighterCursor() {
    trackEvent('highlight-action', 'toggle-cursor');
    chrome.tabs.executeScript({
        file: 'contentScripts/toggleHighlighterCursor.js'
    });
}

function removeHighlights() {
    trackEvent('highlight-action', 'clear-all');
    chrome.tabs.executeScript({
        file: 'contentScripts/removeHighlights.js'
    });
}

function showHighlight(highlightId) {
    trackEvent('highlight-action', 'show-highlight');

    chrome.tabs.executeScript({
        code: `var highlightId = ${highlightId};`
    }, function () {
        chrome.tabs.executeScript({
            file: 'contentScripts/showHighlight.js'
        });
    });
}

function changeColorFromContext(info) {
    trackEvent('color-change-source', 'context-menu');
    changeColor(info.menuItemId);
}

function changeColor(color) {
    trackEvent('color-changed-to', color);
    chrome.storage.sync.set({
        color: color
    });

    // Also update the context menu
    chrome.contextMenus.update(color, {
        checked: true
    });
}

function trackEvent(category, action) {
    // _gaq.push(['_trackEvent', category, action]);
    console.log("Track Event : ", category, action)
}