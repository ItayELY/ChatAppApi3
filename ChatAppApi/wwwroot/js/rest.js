async function getAll() {
    const r = await fetch('/api/UsersApi');
    const d = r.json();
    console.log(d);
}

async function register() {
    const r = await fetch('/api/UsersApi', {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify({ id: 'hey', name: 'hey', password: 'hey' }) // body data type must match "Content-Type" header
    });
    console.log(r.json());
}

async function login() {
    const r = await fetch('/api/LoginApi', {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify({ id: 'u', password: 'u' }) // body data type must match "Content-Type" header
    });
    console.log(r.json());
}

async function contacts() {
    const r = await fetch('/api/Contacts');
    const d = r.json();
    console.log(d);
}

async function contact() {
    const r = await fetch('/api/Contacts/itay');
    const d = r.json();
    console.log(d);
}


async function addContact() {
    const r = await fetch('/api/Contacts', {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify({ Userid: 'u', Contactid: 'hey', name: 'heya', server: 'heyserver' }) // body data type must match "Content-Type" header
    });
    console.log(r.json());
}
async function messages() {
    const r = await fetch('/api/Contacts/itay/messages');
    const d = r.json();
    console.log(d);
}
async function addMessage() {
    d = new Date
    const r = await fetch('/api/Contacts/itay/messages', {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify({content: 'hey bruv', created: d.toJSON(), sent: true }) // body data type must match "Content-Type" header
    });
    console.log(r.json());
}
