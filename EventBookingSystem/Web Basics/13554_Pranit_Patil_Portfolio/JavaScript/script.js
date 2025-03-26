var tablinks=document.getElementsByClassName("tab-links");
        var tabcontents=document.getElementsByClassName("tab-contents");
        function opentab(tabname){
            for(tablink of tablinks){
                tablink.classList.remove("active-link");
            } 
            for(tabcontent of tabcontents){
                tabcontent.classList.remove("active-tab");
            }
            event.currentTarget.classList.add("active-link");
            document.getElementById(tabname).classList.add("active-tab");
        }

// ---------Certificate-----------
        document.querySelectorAll('.certificate img').forEach(img => {
    img.addEventListener('click', () => {
        window.open(img.src, '_blank');
    });
});

// -------for menubar--------
var sidemenu=document.getElementById("sidemenu")

function openmenu(){
    sidemenu.style.right="0";
}
function closemenu(){
    sidemenu.style.right="-200px";
}


// -------------sheet--------------

const scriptURL = 'https://script.google.com/macros/s/AKfycbwyeWohHnuWn7MYtccCxFIPjK_At_XZO8VK4ItQLFXLfsWckHrc0TJ002tLK2qC55eZog/exec'
  const form = document.forms['submit-to-google-sheet']
  const msg = document.getElementById("msg");

  form.addEventListener('submit', e => {
    e.preventDefault()
    fetch(scriptURL, { method: 'POST', body: new FormData(form)})
      .then(response => {
          msg.innerHTML="Message sent Successfully"
          setTimeout(function(){
            msg.style.color="green";
            msg.innerHTML=""
        },5000)
        form.reset()
      })
      .catch(error => {
        msg.style.color="red";
        msg.innerHTML=error.message})
  })
