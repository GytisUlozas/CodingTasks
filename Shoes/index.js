const data = [
    {name: "Jonas", size: 40},
    {name: "Petras", size: 41},
    {name: "Jonas", size: 41},
    {name: "Petras", size: 42},
    {name: "Jonas", size: 42},
    {name: "Jonas", size: 43},
    {name: "Izidorius", size: 43},
    {name: "Petras", size: 43},
    {name: "Jonas", size: 44},
    {name: "Petras", size: 45}
];

function ApiLength () {
    return data.length;
}

function ApiGetSize(i) {
    return data[i].size;
}

function ApiGetName(i) {
    return data[i].name;
}
//Boiler plate code up to this point


//If you have a problem, throw hash map at it.
function PopularShoeSize() {
    let collection = new Map();
    
    for(let i = 1; i < ApiLength(); i++) {
        let size = ApiGetSize(i);
        if(collection.has(size)) {
            let count = collection.get(size) + 1;
            collection.set(size, count);
        }
        else {
            collection.set(size, 1);
        }
    }

    collection = new Map([...collection].sort((a,b)=> {
        return b[1] - a[1];
    }));

    if([...collection][0][1] === [...collection][1][1] ) {
        return -1;
    }
    return [...collection][0][0];
}

function PopularName() {
    const popularSize = PopularShoeSize();
    let collection = new Map();
    
    for(let i = 1; i < ApiLength(); i++) {
        if(ApiGetSize(i) === popularSize) {
            let name  = ApiGetName(i);
            if(collection.has(name)) {
                let count = collection.get(name) + 1;
                collection.set(name, count);
            }
            else {
                collection.set(name, 1);
            }
        }
    }

    collection = new Map([...collection].sort((a,b)=> {
        return b[1] - a[1];
    }));

    if([...collection][0][1] === [...collection][1][1] ) {
        return -1;
    }
    return [...collection][0][0];
}

//Let's see what we get
console.log(PopularShoeSize());
console.log(PopularName());