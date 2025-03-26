const navlinks=document.getElementsByTagName("a");
const currentURL=window.location.href;
for(let link of navlinks){
    if(link.href==currentURL){
        link.classList.add('activeLink')
    }
}