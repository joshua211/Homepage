function focusElement(id) {
  const element = document.getElementById(id);
  element.focus();
}

function scrollToBottom(id) {
  var objDiv = document.getElementById(id);
  objDiv.scrollTop = objDiv.scrollHeight;
}
