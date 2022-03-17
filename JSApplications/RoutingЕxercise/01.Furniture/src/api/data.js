import * as api from './api.js';

const endpoints = {
    'catalog': '/data/catalog',
};

export async function createIdea(){
    return api.get(endpoints.catalog);
}

export async function createFurniture(data){
    return api.post(endpoints.create, data)
}
