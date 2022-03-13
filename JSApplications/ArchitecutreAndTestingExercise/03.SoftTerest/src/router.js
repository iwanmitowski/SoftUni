export function init(links){

    const main = document.querySelector('main');
    document.querySelector('nav').addEventListener('click', onNavigate);

    const context = {
        showSection,
        goTo,
        updateNav,
    }
    
    return context;

    function onNavigate(e){
        let target = e.target;
        if (target.tagName == 'IMG') {
            target = target.parentElement;
        }
    
        if (target.tagName == 'A') {
            e.preventDefault();
    
            let url = new URL(target.href);
            let name = url.pathname;
            
            goTo(name);
        }
    }
    
    function showSection (section){
        main.replaceChildren(section);
    }
    
    function goTo(name, ...params){
        let handler = links[name];
        if (typeof handler == 'function') {
            
            handler(context, ...params);
        }
    }

    function updateNav(){
        const user = localStorage.getItem('user');

        if (user) {
            document.querySelectorAll('.user').forEach(e => e.style.display = 'block');
            document.querySelectorAll('.guest').forEach(e => e.style.display = 'none');
        }
        else{
            document.querySelectorAll('.user').forEach(e => e.style.display = 'none');
            document.querySelectorAll('.guest').forEach(e => e.style.display = 'block');
        }
    }
}