var domModule = (function(){
    function addElement(selector, elementToAppend){
        var parentElement = document.querySelector(selector);
        parentElement.appendChild(elementToAppend);
    }

    function removeElement(selector, elementToRemove){
        var parentElement = document.querySelector(selector);
        parentElement.removeChild(elementToRemove);
    }

    function attachEvent(selector, event, eventHandler){
        var elements = document.querySelectorAll(selector);
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventHandler, event);
        }
    }

    function retrieveElements(selector){
        var elements = document.querySelectorAll(selector);
        return elements;
    }

    return {
        addElement: addElement,
        removeElement: removeElement,
        attachEventListener: attachEvent,
        retrieveElements: retrieveElements
    }
}())