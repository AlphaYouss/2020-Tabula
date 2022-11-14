// Original link: https://medium.com/javascript-in-plain-english/using-javascript-to-create-trello-like-card-re-arrange-and-drag-and-drop-557e60125bb4

function allowDrop(ev) {
    ev.preventDefault();
}

function dragStart(ev) {
    ev.dataTransfer.setData("text/plain", ev.target.id);
}

function dropIt(ev) {
    ev.preventDefault();

    // Get drop element and target element

    let sourceId = ev.dataTransfer.getData("text/plain");
    let sourceIdEl = document.getElementById(sourceId);
    let sourceIdParentEl = sourceIdEl.parentElement;

    let targetEl = document.getElementById(ev.target.id);
    let targetParentEl = targetEl.parentElement;
  
    if (targetParentEl.id !== sourceIdParentEl.id) {
        if (targetEl.className === sourceIdEl.className ){
            targetParentEl.appendChild(sourceIdEl);      
        }
        else{
            targetEl.appendChild(sourceIdEl);       
        }       
    }
}